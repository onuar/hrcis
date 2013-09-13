using System;
using HRCIntegrationServices.WinUI.BaseControls;
using HRCIS.SchemaLoader;
using HRCIS.DataLoader;
using HRCIS.DataLoader.Entities;
using HRCIS.DataLoader.Lists;
using HRCIS.QueryBuilder.Insert;
using HRCIS.SchemaLoader.Entities;
using HRCIS.SchemaLoader.Lists;

namespace HRCIntegrationServices.WinUI
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMainLoad(object sender, EventArgs e)
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

        private void BtnGenerateClick(object sender, EventArgs e)
        {
            if (clstTables.CheckedItems == null)
            {
                return;
            }

            if (chcClearQueries.Checked)
                txtQueries.Text = string.Empty;

            var schemaList = new SchemaList();
            var schemaLoader = new SchemaLoader();
            foreach (var ob in clstTables.CheckedItems)
            {
                schemaList.Add(schemaLoader.GetSchema((HrcTable)ob));
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
                        txtQueries.Text += GenerateQuery(schemaData, new SqlQueryBuilder());

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
                var deleteBuilder = new InsertQueryBuilder();
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
                var oracleQBuilder = new OracleFunctionQueryBuilder();

                foreach (var schema in schemaList)
                {
                    HrcColumn identityColumn = schema.Columns.GetIdentityColumnIfExist();
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

        private string GenerateQuery(HrcSchemaData schemaData, InsertQueryStrategy insertQueryStrategy)
        {
            var queryBuilder = new InsertQueryBuilder(insertQueryStrategy);
            return queryBuilder.GenerateQuery(schemaData, chcExcludeIsIdentity.Checked);
        }

        private SchemaDataList GetSchemaDatas(SchemaList schemaList)
        {
            var dataLoader = new DataLoader(schemaList);
            return dataLoader.GetSchemaDatas();
        }

        private void ChcCheckAllCheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clstTables.Items.Count; i++)
            {
                clstTables.SetItemChecked(i, chcCheckAll.Checked);
            }
        }

        private void ChcCheckOrUncheckCheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clstTables.Items.Count; i++)
            {
                clstTables.SetItemChecked(i, !clstTables.GetItemChecked(i));
            }
        }

        private void ChcOracleCheckedChanged(object sender, EventArgs e)
        {
            if (!chcOracle.Checked)
            {
                chcSeqTrg.Checked = false;
            }
            chcSeqTrg.Enabled = chcOracle.Checked;
        }

        private void ChcInsertCheckedChanged(object sender, EventArgs e)
        {
            chcExcludeIsIdentity.Checked = chcInsert.Checked;
            chcExcludeIsIdentity.Enabled = chcInsert.Checked;
        }
    }
}
