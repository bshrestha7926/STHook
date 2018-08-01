namespace STHookAdmin
{
    partial class frmST
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdInvoices = new Telerik.WinControls.UI.RadGridView();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.spltTracker = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.rdgTags = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rdInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdInvoices.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).BeginInit();
            this.spltTracker.Panel1.SuspendLayout();
            this.spltTracker.Panel2.SuspendLayout();
            this.spltTracker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTags.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(216, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdInvoices
            // 
            this.rdInvoices.AutoSizeRows = true;
            this.rdInvoices.BackColor = System.Drawing.Color.Gray;
            this.rdInvoices.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdInvoices.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdInvoices.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdInvoices.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdInvoices.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdInvoices.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rdInvoices.MasterTemplate.AllowAddNewRow = false;
            this.rdInvoices.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "SIID";
            gridViewTextBoxColumn1.HeaderText = "Service Trade ID";
            gridViewTextBoxColumn1.IsPinned = true;
            gridViewTextBoxColumn1.Name = "SIID";
            gridViewTextBoxColumn1.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Left;
            gridViewTextBoxColumn1.Width = 89;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "URI";
            gridViewTextBoxColumn2.HeaderText = "URI";
            gridViewTextBoxColumn2.Name = "URI";
            gridViewTextBoxColumn2.Width = 26;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Name";
            gridViewTextBoxColumn3.HeaderText = "Name";
            gridViewTextBoxColumn3.Name = "Name";
            gridViewTextBoxColumn3.Width = 38;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Status";
            gridViewTextBoxColumn4.HeaderText = "Status";
            gridViewTextBoxColumn4.Name = "Status";
            gridViewTextBoxColumn4.Width = 39;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "CustomerPo";
            gridViewTextBoxColumn5.HeaderText = "Customer PO";
            gridViewTextBoxColumn5.Name = "CustomerPo";
            gridViewTextBoxColumn5.Width = 74;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Notes";
            gridViewTextBoxColumn6.HeaderText = "Notes";
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "Notes";
            gridViewTextBoxColumn6.Width = 38;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "FPMARActive";
            gridViewCheckBoxColumn1.HeaderText = "FPMAR Active";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "FPMARActive";
            gridViewCheckBoxColumn1.Width = 93;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "CreatedDateTime";
            gridViewTextBoxColumn7.HeaderText = "Time Stamp";
            gridViewTextBoxColumn7.Name = "CreatedDateTime";
            gridViewTextBoxColumn7.Width = 68;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "TotalPrice";
            gridViewTextBoxColumn8.HeaderText = "TotalPrice";
            gridViewTextBoxColumn8.Name = "TotalPrice";
            gridViewTextBoxColumn8.Width = 57;
            this.rdInvoices.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rdInvoices.MasterTemplate.EnableFiltering = true;
            this.rdInvoices.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rdInvoices.Name = "rdInvoices";
            this.rdInvoices.ReadOnly = true;
            this.rdInvoices.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdInvoices.Size = new System.Drawing.Size(562, 509);
            this.rdInvoices.TabIndex = 4;
            this.rdInvoices.Text = "radGridView1";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(9, 12);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(201, 24);
            this.txtInvoice.TabIndex = 5;
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
            this.spltTracker.Panel1.Controls.Add(this.Label16);
            this.spltTracker.Panel1MinSize = 30;
            // 
            // spltTracker.Panel2
            // 
            this.spltTracker.Panel2.AutoScroll = true;
            this.spltTracker.Panel2.BackColor = System.Drawing.Color.Gray;
            this.spltTracker.Panel2.Controls.Add(this.spltMain);
            this.spltTracker.Size = new System.Drawing.Size(1134, 593);
            this.spltTracker.SplitterDistance = 30;
            this.spltTracker.SplitterWidth = 10;
            this.spltTracker.TabIndex = 289;
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
            this.btnClose.Location = new System.Drawing.Point(1102, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 30);
            this.btnClose.TabIndex = 297;
            this.btnClose.Text = "X";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label16
            // 
            this.Label16.BackColor = System.Drawing.Color.White;
            this.Label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label16.Font = new System.Drawing.Font("Arial", 16F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(0, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(1134, 30);
            this.Label16.TabIndex = 266;
            this.Label16.Text = "ST Invoice Query";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.spltMain.Panel1.Controls.Add(this.btnViewAll);
            this.spltMain.Panel1.Controls.Add(this.txtInvoice);
            this.spltMain.Panel1.Controls.Add(this.btnSearch);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.Panel3);
            this.spltMain.Size = new System.Drawing.Size(1134, 553);
            this.spltMain.SplitterDistance = 40;
            this.spltMain.TabIndex = 3;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewAll.Location = new System.Drawing.Point(921, 0);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(213, 40);
            this.btnViewAll.TabIndex = 6;
            this.btnViewAll.Text = "View All Sent Invoices";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.rdgTags);
            this.Panel3.Controls.Add(this.rdInvoices);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(1134, 509);
            this.Panel3.TabIndex = 1;
            // 
            // rdgTags
            // 
            this.rdgTags.AutoSizeRows = true;
            this.rdgTags.BackColor = System.Drawing.Color.Gray;
            this.rdgTags.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdgTags.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdgTags.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdgTags.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdgTags.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdgTags.Location = new System.Drawing.Point(562, 0);
            // 
            // 
            // 
            this.rdgTags.MasterTemplate.AllowAddNewRow = false;
            this.rdgTags.MasterTemplate.AllowColumnReorder = false;
            this.rdgTags.MasterTemplate.EnableFiltering = true;
            this.rdgTags.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rdgTags.Name = "rdgTags";
            this.rdgTags.ReadOnly = true;
            this.rdgTags.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdgTags.Size = new System.Drawing.Size(562, 509);
            this.rdgTags.TabIndex = 5;
            this.rdgTags.Text = "radGridView1";
            // 
            // frmST
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1134, 593);
            this.Controls.Add(this.spltTracker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmST";
            this.Text = "frmST";
            this.Load += new System.EventHandler(this.frmST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdInvoices.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdInvoices)).EndInit();
            this.spltTracker.Panel1.ResumeLayout(false);
            this.spltTracker.Panel1.PerformLayout();
            this.spltTracker.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).EndInit();
            this.spltTracker.ResumeLayout(false);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel1.PerformLayout();
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgTags.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTags)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private Telerik.WinControls.UI.RadGridView rdInvoices;
        private System.Windows.Forms.TextBox txtInvoice;
        internal System.Windows.Forms.SplitContainer spltTracker;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.SplitContainer spltMain;
        internal System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.Button btnViewAll;
        private Telerik.WinControls.UI.RadGridView rdgTags;
    }
}