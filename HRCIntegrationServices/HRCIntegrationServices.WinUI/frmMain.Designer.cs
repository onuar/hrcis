namespace HRCIntegrationServices.WinUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clstTables = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chcCheckOrUncheck = new System.Windows.Forms.CheckBox();
            this.chcCheckAll = new System.Windows.Forms.CheckBox();
            this.chcSql = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chcOracle = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chcExcludeIsIdentity = new System.Windows.Forms.CheckBox();
            this.chcSeqTrg = new System.Windows.Forms.CheckBox();
            this.chcDelete = new System.Windows.Forms.CheckBox();
            this.chcInsert = new System.Windows.Forms.CheckBox();
            this.chcCreate = new System.Windows.Forms.CheckBox();
            this.txtQueries = new System.Windows.Forms.RichTextBox();
            this.grpQueries = new System.Windows.Forms.GroupBox();
            this.chcClearQueries = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpQueries.SuspendLayout();
            this.SuspendLayout();
            // 
            // clstTables
            // 
            this.clstTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.clstTables.CheckOnClick = true;
            this.clstTables.FormattingEnabled = true;
            this.clstTables.Location = new System.Drawing.Point(10, 19);
            this.clstTables.Name = "clstTables";
            this.clstTables.Size = new System.Drawing.Size(242, 439);
            this.clstTables.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.chcCheckOrUncheck);
            this.groupBox1.Controls.Add(this.chcCheckAll);
            this.groupBox1.Controls.Add(this.clstTables);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 489);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // chcCheckOrUncheck
            // 
            this.chcCheckOrUncheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chcCheckOrUncheck.AutoSize = true;
            this.chcCheckOrUncheck.Location = new System.Drawing.Point(153, 466);
            this.chcCheckOrUncheck.Name = "chcCheckOrUncheck";
            this.chcCheckOrUncheck.Size = new System.Drawing.Size(100, 17);
            this.chcCheckOrUncheck.TabIndex = 1;
            this.chcCheckOrUncheck.Text = "Check Reverse";
            this.chcCheckOrUncheck.UseVisualStyleBackColor = true;
            this.chcCheckOrUncheck.CheckedChanged += new System.EventHandler(this.ChcCheckOrUncheckCheckedChanged);
            // 
            // chcCheckAll
            // 
            this.chcCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chcCheckAll.AutoSize = true;
            this.chcCheckAll.Location = new System.Drawing.Point(11, 466);
            this.chcCheckAll.Name = "chcCheckAll";
            this.chcCheckAll.Size = new System.Drawing.Size(71, 17);
            this.chcCheckAll.TabIndex = 1;
            this.chcCheckAll.Text = "Check All";
            this.chcCheckAll.UseVisualStyleBackColor = true;
            this.chcCheckAll.CheckedChanged += new System.EventHandler(this.ChcCheckAllCheckedChanged);
            // 
            // chcSql
            // 
            this.chcSql.AutoSize = true;
            this.chcSql.Location = new System.Drawing.Point(9, 34);
            this.chcSql.Name = "chcSql";
            this.chcSql.Size = new System.Drawing.Size(47, 17);
            this.chcSql.TabIndex = 2;
            this.chcSql.Text = "SQL";
            this.chcSql.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chcOracle);
            this.groupBox2.Controls.Add(this.chcSql);
            this.groupBox2.Location = new System.Drawing.Point(281, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // chcOracle
            // 
            this.chcOracle.AutoSize = true;
            this.chcOracle.Location = new System.Drawing.Point(9, 57);
            this.chcOracle.Name = "chcOracle";
            this.chcOracle.Size = new System.Drawing.Size(57, 17);
            this.chcOracle.TabIndex = 2;
            this.chcOracle.Text = "Oracle";
            this.chcOracle.UseVisualStyleBackColor = true;
            this.chcOracle.CheckedChanged += new System.EventHandler(this.ChcOracleCheckedChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(281, 305);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 27);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Query Generate >>>";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerateClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chcExcludeIsIdentity);
            this.groupBox3.Controls.Add(this.chcSeqTrg);
            this.groupBox3.Controls.Add(this.chcDelete);
            this.groupBox3.Controls.Add(this.chcInsert);
            this.groupBox3.Controls.Add(this.chcCreate);
            this.groupBox3.Location = new System.Drawing.Point(281, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 158);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Query Type";
            // 
            // chcExcludeIsIdentity
            // 
            this.chcExcludeIsIdentity.AutoSize = true;
            this.chcExcludeIsIdentity.Enabled = false;
            this.chcExcludeIsIdentity.Location = new System.Drawing.Point(60, 64);
            this.chcExcludeIsIdentity.Name = "chcExcludeIsIdentity";
            this.chcExcludeIsIdentity.Size = new System.Drawing.Size(134, 17);
            this.chcExcludeIsIdentity.TabIndex = 4;
            this.chcExcludeIsIdentity.Text = "Exclude IsIdentity Field";
            this.chcExcludeIsIdentity.UseVisualStyleBackColor = true;
            // 
            // chcSeqTrg
            // 
            this.chcSeqTrg.AutoSize = true;
            this.chcSeqTrg.Enabled = false;
            this.chcSeqTrg.Location = new System.Drawing.Point(9, 114);
            this.chcSeqTrg.Name = "chcSeqTrg";
            this.chcSeqTrg.Size = new System.Drawing.Size(166, 17);
            this.chcSeqTrg.TabIndex = 3;
            this.chcSeqTrg.Text = "Create Sequence and Trigger";
            this.chcSeqTrg.UseVisualStyleBackColor = true;
            // 
            // chcDelete
            // 
            this.chcDelete.AutoSize = true;
            this.chcDelete.Location = new System.Drawing.Point(9, 89);
            this.chcDelete.Name = "chcDelete";
            this.chcDelete.Size = new System.Drawing.Size(57, 17);
            this.chcDelete.TabIndex = 2;
            this.chcDelete.Text = "Delete";
            this.chcDelete.UseVisualStyleBackColor = true;
            // 
            // chcInsert
            // 
            this.chcInsert.AutoSize = true;
            this.chcInsert.Location = new System.Drawing.Point(9, 64);
            this.chcInsert.Name = "chcInsert";
            this.chcInsert.Size = new System.Drawing.Size(52, 17);
            this.chcInsert.TabIndex = 2;
            this.chcInsert.Text = "Insert";
            this.chcInsert.UseVisualStyleBackColor = true;
            this.chcInsert.CheckedChanged += new System.EventHandler(this.ChcInsertCheckedChanged);
            // 
            // chcCreate
            // 
            this.chcCreate.AutoSize = true;
            this.chcCreate.Location = new System.Drawing.Point(9, 39);
            this.chcCreate.Name = "chcCreate";
            this.chcCreate.Size = new System.Drawing.Size(57, 17);
            this.chcCreate.TabIndex = 2;
            this.chcCreate.Text = "Create";
            this.chcCreate.UseVisualStyleBackColor = true;
            // 
            // txtQueries
            // 
            this.txtQueries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueries.Location = new System.Drawing.Point(6, 19);
            this.txtQueries.Name = "txtQueries";
            this.txtQueries.Size = new System.Drawing.Size(386, 464);
            this.txtQueries.TabIndex = 5;
            this.txtQueries.Text = "";
            // 
            // grpQueries
            // 
            this.grpQueries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQueries.Controls.Add(this.txtQueries);
            this.grpQueries.Location = new System.Drawing.Point(487, 12);
            this.grpQueries.Name = "grpQueries";
            this.grpQueries.Size = new System.Drawing.Size(398, 489);
            this.grpQueries.TabIndex = 6;
            this.grpQueries.TabStop = false;
            this.grpQueries.Text = "Queries";
            // 
            // chcClearQueries
            // 
            this.chcClearQueries.AutoSize = true;
            this.chcClearQueries.Checked = true;
            this.chcClearQueries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcClearQueries.Location = new System.Drawing.Point(281, 282);
            this.chcClearQueries.Name = "chcClearQueries";
            this.chcClearQueries.Size = new System.Drawing.Size(89, 17);
            this.chcClearQueries.TabIndex = 7;
            this.chcClearQueries.Text = "Clear Queries";
            this.chcClearQueries.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 513);
            this.Controls.Add(this.chcClearQueries);
            this.Controls.Add(this.grpQueries);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "HRC Integration Services";
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpQueries.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clstTables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chcCheckOrUncheck;
        private System.Windows.Forms.CheckBox chcCheckAll;
        private System.Windows.Forms.CheckBox chcSql;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chcOracle;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chcInsert;
        private System.Windows.Forms.CheckBox chcCreate;
        private System.Windows.Forms.RichTextBox txtQueries;
        private System.Windows.Forms.GroupBox grpQueries;
        private System.Windows.Forms.CheckBox chcClearQueries;
        private System.Windows.Forms.CheckBox chcSeqTrg;
        private System.Windows.Forms.CheckBox chcDelete;
        private System.Windows.Forms.CheckBox chcExcludeIsIdentity;

    }
}