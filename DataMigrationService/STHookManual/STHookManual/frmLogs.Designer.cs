namespace STHookAdmin
{
    partial class frmLogs
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spltTracker = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblmain = new System.Windows.Forms.Label();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.rdDates = new Telerik.WinControls.UI.RadGridView();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.rdLog = new Telerik.WinControls.UI.RadGridView();
            this.dtProductionStatus = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).BeginInit();
            this.spltTracker.Panel1.SuspendLayout();
            this.spltTracker.Panel2.SuspendLayout();
            this.spltTracker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdDates.MasterTemplate)).BeginInit();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // spltTracker
            // 
            this.spltTracker.BackColor = System.Drawing.Color.White;
            this.spltTracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltTracker.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltTracker.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.spltTracker.IsSplitterFixed = true;
            this.spltTracker.Location = new System.Drawing.Point(0, 0);
            this.spltTracker.Name = "spltTracker";
            this.spltTracker.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltTracker.Panel1
            // 
            this.spltTracker.Panel1.AutoScroll = true;
            this.spltTracker.Panel1.BackColor = System.Drawing.Color.White;
            this.spltTracker.Panel1.Controls.Add(this.btnClose);
            this.spltTracker.Panel1.Controls.Add(this.lblmain);
            this.spltTracker.Panel1MinSize = 30;
            // 
            // spltTracker.Panel2
            // 
            this.spltTracker.Panel2.AutoScroll = true;
            this.spltTracker.Panel2.BackColor = System.Drawing.Color.Gray;
            this.spltTracker.Panel2.Controls.Add(this.spltMain);
            this.spltTracker.Size = new System.Drawing.Size(996, 652);
            this.spltTracker.SplitterDistance = 30;
            this.spltTracker.SplitterWidth = 10;
            this.spltTracker.TabIndex = 288;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(964, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 30);
            this.btnClose.TabIndex = 297;
            this.btnClose.Text = "X";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblmain
            // 
            this.lblmain.BackColor = System.Drawing.Color.White;
            this.lblmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblmain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblmain.Font = new System.Drawing.Font("Arial", 16F);
            this.lblmain.ForeColor = System.Drawing.Color.Black;
            this.lblmain.Location = new System.Drawing.Point(0, 0);
            this.lblmain.Name = "lblmain";
            this.lblmain.Size = new System.Drawing.Size(996, 30);
            this.lblmain.TabIndex = 266;
            this.lblmain.Text = "Logs";
            this.lblmain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltMain.IsSplitterFixed = true;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.spltMain.Panel1.Controls.Add(this.rdDates);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.Panel3);
            this.spltMain.Size = new System.Drawing.Size(996, 612);
            this.spltMain.SplitterDistance = 200;
            this.spltMain.TabIndex = 3;
            // 
            // rdDates
            // 
            this.rdDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdDates.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rdDates.MasterTemplate.AllowAddNewRow = false;
            this.rdDates.MasterTemplate.AllowColumnReorder = false;
            this.rdDates.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rdDates.Name = "rdDates";
            this.rdDates.ReadOnly = true;
            this.rdDates.Size = new System.Drawing.Size(200, 612);
            this.rdDates.TabIndex = 3;
            this.rdDates.Text = "radGridView1";
            this.rdDates.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rdDates_CellClick);
            this.rdDates.Click += new System.EventHandler(this.rdDates_Click);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.rdLog);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(792, 612);
            this.Panel3.TabIndex = 1;
            // 
            // rdLog
            // 
            this.rdLog.AutoSizeRows = true;
            this.rdLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdLog.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rdLog.MasterTemplate.AllowAddNewRow = false;
            this.rdLog.MasterTemplate.AllowColumnReorder = false;
            this.rdLog.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.FieldName = "ServiceTradeId";
            gridViewTextBoxColumn1.HeaderText = "Service Trade ID";
            gridViewTextBoxColumn1.Name = "ServiceTradeId";
            gridViewDateTimeColumn1.FieldName = "TimeStamp";
            gridViewDateTimeColumn1.HeaderText = "Time Stamp";
            gridViewDateTimeColumn1.Name = "TimeStamp";
            gridViewTextBoxColumn2.FieldName = "Description";
            gridViewTextBoxColumn2.HeaderText = "Log Detail";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Description";
            gridViewTextBoxColumn3.FieldName = "logType";
            gridViewTextBoxColumn3.HeaderText = "Log Type";
            gridViewTextBoxColumn3.Name = "logType";
            this.rdLog.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.rdLog.MasterTemplate.EnableFiltering = true;
            this.rdLog.MasterTemplate.EnableSorting = false;
            this.rdLog.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rdLog.Name = "rdLog";
            this.rdLog.ReadOnly = true;
            this.rdLog.Size = new System.Drawing.Size(792, 612);
            this.rdLog.TabIndex = 2;
            this.rdLog.Text = "radGridView1";
            // 
            // dtProductionStatus
            // 
            this.dtProductionStatus.AllowUserToAddRows = false;
            this.dtProductionStatus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtProductionStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtProductionStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtProductionStatus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtProductionStatus.BackgroundColor = System.Drawing.Color.White;
            this.dtProductionStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtProductionStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtProductionStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProductionStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtProductionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtProductionStatus.Location = new System.Drawing.Point(0, 0);
            this.dtProductionStatus.MultiSelect = false;
            this.dtProductionStatus.Name = "dtProductionStatus";
            this.dtProductionStatus.ReadOnly = true;
            this.dtProductionStatus.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtProductionStatus.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtProductionStatus.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtProductionStatus.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.dtProductionStatus.RowTemplate.Height = 30;
            this.dtProductionStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProductionStatus.Size = new System.Drawing.Size(996, 652);
            this.dtProductionStatus.TabIndex = 287;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(996, 652);
            this.lblHeader.TabIndex = 289;
            this.lblHeader.Text = "Job Production Status";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(996, 652);
            this.Controls.Add(this.spltTracker);
            this.Controls.Add(this.dtProductionStatus);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogs";
            this.Load += new System.EventHandler(this.frmLogs_Load);
            this.spltTracker.Panel1.ResumeLayout(false);
            this.spltTracker.Panel1.PerformLayout();
            this.spltTracker.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).EndInit();
            this.spltTracker.ResumeLayout(false);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdDates.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdDates)).EndInit();
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdLog.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductionStatus)).EndInit();
            this.ResumeLayout(false);

        }

        //private void rdDates_CellClick(object sender, System.EventArgs e)
        //{
        //    throw new System.NotImplementedException();
        //}

        #endregion

        internal System.Windows.Forms.SplitContainer spltTracker;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblmain;
        internal System.Windows.Forms.DataGridView dtProductionStatus;
        internal System.Windows.Forms.Label lblHeader;
        private Telerik.WinControls.UI.RadGridView rdLog;
        internal System.Windows.Forms.SplitContainer spltMain;
        internal System.Windows.Forms.Panel Panel3;
        private Telerik.WinControls.UI.RadGridView rdDates;
    }
}