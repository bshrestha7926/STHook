namespace STHookAdmin
{
    partial class frmManualRun
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.spltTracker = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblmain = new System.Windows.Forms.Label();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.btnManualRun = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.rdLog = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).BeginInit();
            this.spltTracker.Panel1.SuspendLayout();
            this.spltTracker.Panel2.SuspendLayout();
            this.spltTracker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog.MasterTemplate)).BeginInit();
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
            this.spltTracker.Size = new System.Drawing.Size(1098, 581);
            this.spltTracker.SplitterDistance = 30;
            this.spltTracker.SplitterWidth = 10;
            this.spltTracker.TabIndex = 290;
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
            this.btnClose.Location = new System.Drawing.Point(1066, 0);
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
            this.lblmain.Size = new System.Drawing.Size(1098, 30);
            this.lblmain.TabIndex = 266;
            this.lblmain.Text = "Manual Run";
            this.lblmain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltMain.Font = new System.Drawing.Font("Arial", 11F);
            this.spltMain.IsSplitterFixed = true;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Name = "spltMain";
            this.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.spltMain.Panel1.Controls.Add(this.btnManualRun);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.Panel3);
            this.spltMain.Size = new System.Drawing.Size(1098, 541);
            this.spltMain.SplitterDistance = 40;
            this.spltMain.TabIndex = 3;
            // 
            // btnManualRun
            // 
            this.btnManualRun.Location = new System.Drawing.Point(5, 0);
            this.btnManualRun.Name = "btnManualRun";
            this.btnManualRun.Size = new System.Drawing.Size(121, 40);
            this.btnManualRun.TabIndex = 1;
            this.btnManualRun.Text = "Run Hook";
            this.btnManualRun.UseVisualStyleBackColor = true;
            this.btnManualRun.Click += new System.EventHandler(this.btnManualRun_Click);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.rdLog);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(1098, 497);
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
            gridViewTextBoxColumn4.FieldName = "ServiceTradeId";
            gridViewTextBoxColumn4.HeaderText = "Service Trade ID";
            gridViewTextBoxColumn4.Name = "ServiceTradeId";
            gridViewDateTimeColumn2.FieldName = "TimeStamp";
            gridViewDateTimeColumn2.HeaderText = "Time Stamp";
            gridViewDateTimeColumn2.Name = "TimeStamp";
            gridViewTextBoxColumn5.FieldName = "Description";
            gridViewTextBoxColumn5.HeaderText = "Log Detail";
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "Description";
            gridViewTextBoxColumn6.FieldName = "logType";
            gridViewTextBoxColumn6.HeaderText = "Log Type";
            gridViewTextBoxColumn6.Name = "logType";
            this.rdLog.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.rdLog.MasterTemplate.EnableFiltering = true;
            this.rdLog.MasterTemplate.EnableSorting = false;
            this.rdLog.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rdLog.Name = "rdLog";
            this.rdLog.ReadOnly = true;
            this.rdLog.Size = new System.Drawing.Size(1098, 497);
            this.rdLog.TabIndex = 3;
            this.rdLog.Text = "radGridView1";
            // 
            // frmManualRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 581);
            this.Controls.Add(this.spltTracker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManualRun";
            this.Text = "frmManualRun";
            this.Load += new System.EventHandler(this.frmManualRun_Load);
            this.spltTracker.Panel1.ResumeLayout(false);
            this.spltTracker.Panel1.PerformLayout();
            this.spltTracker.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).EndInit();
            this.spltTracker.ResumeLayout(false);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdLog.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer spltTracker;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblmain;
        internal System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.Button btnManualRun;
        internal System.Windows.Forms.Panel Panel3;
        private Telerik.WinControls.UI.RadGridView rdLog;
    }
}