using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRCIntegrationServices.WinUI.BaseControls;
using HRCIS.SchemaLoader;
using HRCIS.DataLoader;
using HRCIS.QueryBuilder;

namespace HRCIntegrationServices.WinUI
{
    public partial class frmMain : frmBase
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetAllTables();
        }

        void GetAllTables()
        {
            foreach (var table in new SchemaLoader().GetTableList())
            {
                clstTables.Items.Add(table);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (clstTables.CheckedItems == null)
                return;

            if (chcClearQueries.Checked)
                txtQueries.Text = string.Empty;

            var schemaList = new SchemaList();
            var schemaLoader = new SchemaLoader();
            foreach (var ob in clstTables.CheckedItems)
            {
                schemaList.Add(schemaLoader.GetSchema((HRCTable)ob));
            }

            if (chcInsert.Checked)
            {//is insert
                SchemaDataList schemaDataList = GetSchemaDatas(schemaList);
                if (chcSql.Checked)
                {//insert for sql
                    foreach (var schemaData in schemaDataList)
                    {
                        txtQueries.Text +=
                            string.Format("--SQL insert BEGIN {0}--", schemaData.Schema.TableName)
                            + Environment.NewLine;

                        //generate
                        txtQueries.Text += GenerateQuery(schemaData, new SQLQueryBuilder());

                        txtQueries.Text += Environment.NewLine +
                            string.Format("--SQL insert END {0}--", schemaData.Schema.TableName)
                            + Environment.NewLine + Environment.NewLine;
                    }
                }
                if (chcOracle.Checked)
                {//insert for oracle
                    foreach (var schemaData in schemaDataList)
                    {
                        txtQueries.Text +=
                            string.Format("--ORACLE insert BEGIN {0}--", schemaData.Schema.TableName)
                            + Environment.NewLine;

                        //generate
                        txtQueries.Text += GenerateQuery(schemaData, new OracleQueryBuilder());

                        txtQueries.Text += Environment.NewLine +
                            string.Format("--ORACLE insert END {0}--", schemaData.Schema.TableName)
                            + Environment.NewLine + Environment.NewLine;
                    }
                }
            }//is insert
            if (chcDelete.Checked)
            {
                InsertQueryBuilder deleteBuilder = new InsertQueryBuilder();
                foreach (var schema in schemaList)
                {
                    txtQueries.Text +=
                        string.Format("--DELETE BEGIN {0}--", schema.TableName)
                        + Environment.NewLine;

                    txtQueries.Text += deleteBuilder.GenerateDeleteQuery(schema);

                    txtQueries.Text += Environment.NewLine +
                            string.Format("--DELETE END {0}--", schema.TableName)
                            + Environment.NewLine + Environment.NewLine;
                }
            }
            if (chcOracle.Checked && chcSeqTrg.Checked)
            {
                OracleFunctionQueryBuilder oracleQBuilder = new OracleFunctionQueryBuilder();

                foreach (var schema in schemaList)
                {
                    HRCColumn identityColumn = schema.Columns.GetIdentityColumnIfExist();
                    //seçili tablonun identity kolonu yoksa continue
                    if (identityColumn == null)
                        continue;
                    txtQueries.Text += string.Format("--ORACLE SEQ and TRG BEGIN {0}--", schema.TableName
                        + Environment.NewLine);

                    //generate
                    txtQueries.Text += oracleQBuilder.GenerateCreateSeqAndTrg(schema);

                    txtQueries.Text += Environment.NewLine +
                            string.Format("--ORACLE SEQ and TRG END {0}--", schema.TableName)
                            + Environment.NewLine + Environment.NewLine;
                }
            }
        }

        private string GenerateQuery(HRCSchemaData schemaData, InsertQueryStrategy insertQueryStrategy)
        {
            InsertQueryBuilder queryBuilder = new InsertQueryBuilder(insertQueryStrategy);
            return queryBuilder.GenerateQuery(schemaData, chcExcludeIsIdentity.Checked);
        }

        private SchemaDataList GetSchemaDatas(SchemaList schemaList)
        {
            DataLoader dataLoader = new DataLoader(schemaList);
            return dataLoader.GetSchemaDatas();
        }

        private void chcCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clstTables.Items.Count; i++)
            {
                clstTables.SetItemChecked(i, chcCheckAll.Checked);
            }
        }

        private void chcCheckOrUncheck_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clstTables.Items.Count; i++)
            {
                clstTables.SetItemChecked(i, !clstTables.GetItemChecked(i));
            }
        }

        private void chcOracle_CheckedChanged(object sender, EventArgs e)
        {
            if (!chcOracle.Checked)
                chcSeqTrg.Checked = false;
            chcSeqTrg.Enabled = chcOracle.Checked;
        }

        private void chcInsert_CheckedChanged(object sender, EventArgs e)
        {
            chcExcludeIsIdentity.Checked = chcInsert.Checked;
            chcExcludeIsIdentity.Enabled = chcInsert.Checked;
        }
    }
}
