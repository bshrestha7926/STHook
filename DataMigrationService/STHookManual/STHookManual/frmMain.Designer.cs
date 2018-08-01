namespace STHookAdmin
{
    partial class frmMain
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rdTitle = new Telerik.WinControls.UI.RadTitleBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.radMainMenu = new Telerik.WinControls.UI.RadPopupEditor();
            this.rPopUpLogin = new Telerik.WinControls.UI.RadPopupContainer();
            this.mnuUserMenu = new System.Windows.Forms.MenuStrip();
            this.mnuLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSMTP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHookCredentials = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManualRun = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdTitle)).BeginInit();
            this.rdTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPopUpLogin)).BeginInit();
            this.rPopUpLogin.PanelContainer.SuspendLayout();
            this.rPopUpLogin.SuspendLayout();
            this.mnuUserMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlMain.Controls.Add(this.SplitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMain.Size = new System.Drawing.Size(1224, 88);
            this.pnlMain.TabIndex = 309;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.White;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(5, 5);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.rdTitle);
            this.SplitContainer1.Panel1MinSize = 30;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.radMainMenu);
            this.SplitContainer1.Panel2MinSize = 30;
            this.SplitContainer1.Size = new System.Drawing.Size(1214, 78);
            this.SplitContainer1.SplitterDistance = 35;
            this.SplitContainer1.TabIndex = 299;
            // 
            // rdTitle
            // 
            this.rdTitle.AllowResize = false;
            this.rdTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rdTitle.Controls.Add(this.btnClose);
            this.rdTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTitle.ForeColor = System.Drawing.Color.Black;
            this.rdTitle.Location = new System.Drawing.Point(0, 0);
            this.rdTitle.Margin = new System.Windows.Forms.Padding(0);
            this.rdTitle.Name = "rdTitle";
            // 
            // 
            // 
            this.rdTitle.RootElement.ApplyShapeToControl = true;
            this.rdTitle.Size = new System.Drawing.Size(1214, 35);
            this.rdTitle.TabIndex = 314;
            this.rdTitle.TabStop = false;
            this.rdTitle.Text = "Hiller ST Hook Admin ";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.rdTitle.GetChildAt(0))).Text = "Hiller ST Hook Admin ";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.rdTitle.GetChildAt(0))).BackColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).NumberOfColors = 1;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).Opacity = 1D;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(0))).ClickMode = Telerik.WinControls.ClickMode.Hover;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BorderDrawMode = Telerik.WinControls.BorderDrawModes.RightOverTop;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).Width = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BottomWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.LightGray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.LightGray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.LightGray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).LeftShadowColor = System.Drawing.Color.LightGray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).TopShadowColor = System.Drawing.Color.LightGray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).RightShadowColor = System.Drawing.Color.LightGray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BottomShadowColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 10F);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).StretchHorizontally = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(1))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.rdTitle.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1189, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // radMainMenu
            // 
            this.radMainMenu.AssociatedControl = this.rPopUpLogin;
            this.radMainMenu.AutoSize = false;
            this.radMainMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.radMainMenu.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radMainMenu.Location = new System.Drawing.Point(992, 0);
            this.radMainMenu.Name = "radMainMenu";
            this.radMainMenu.ShowTextBox = false;
            this.radMainMenu.Size = new System.Drawing.Size(222, 39);
            this.radMainMenu.TabIndex = 0;
            this.radMainMenu.Text = "Main Menu";
            this.radMainMenu.Click += new System.EventHandler(this.radMainMenu_Click);
            // 
            // rPopUpLogin
            // 
            this.rPopUpLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rPopUpLogin.Location = new System.Drawing.Point(486, 95);
            this.rPopUpLogin.Name = "rPopUpLogin";
            // 
            // rPopUpLogin.PanelContainer
            // 
            this.rPopUpLogin.PanelContainer.Controls.Add(this.mnuUserMenu);
            this.rPopUpLogin.PanelContainer.Size = new System.Drawing.Size(251, 483);
            this.rPopUpLogin.Size = new System.Drawing.Size(253, 485);
            this.rPopUpLogin.TabIndex = 314;
            this.rPopUpLogin.Text = "RadPopupContainer1";
            // 
            // mnuUserMenu
            // 
            this.mnuUserMenu.AllowItemReorder = true;
            this.mnuUserMenu.AutoSize = false;
            this.mnuUserMenu.BackColor = System.Drawing.Color.Transparent;
            this.mnuUserMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuUserMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnuUserMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mnuUserMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mnuUserMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuUserMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogs,
            this.mnuSMTP,
            this.mnuInvoice,
            this.mnuHookCredentials,
            this.mnuExit,
            this.mnuManualRun});
            this.mnuUserMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.mnuUserMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuUserMenu.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mnuUserMenu.Name = "mnuUserMenu";
            this.mnuUserMenu.Padding = new System.Windows.Forms.Padding(10, 20, 0, 10);
            this.mnuUserMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuUserMenu.ShowItemToolTips = true;
            this.mnuUserMenu.Size = new System.Drawing.Size(251, 483);
            this.mnuUserMenu.TabIndex = 120;
            this.mnuUserMenu.Text = "Securiplex Menu";
            this.mnuUserMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuUserMenu_ItemClicked);
            // 
            // mnuLogs
            // 
            this.mnuLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuLogs.Image = global::STHookAdmin.Properties.Resources.list;
            this.mnuLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuLogs.Name = "mnuLogs";
            this.mnuLogs.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.mnuLogs.Size = new System.Drawing.Size(84, 46);
            this.mnuLogs.Text = "Logs";
            this.mnuLogs.Click += new System.EventHandler(this.mnuLogs_Click);
            // 
            // mnuSMTP
            // 
            this.mnuSMTP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuSMTP.Image = global::STHookAdmin.Properties.Resources.email;
            this.mnuSMTP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuSMTP.Name = "mnuSMTP";
            this.mnuSMTP.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.mnuSMTP.Size = new System.Drawing.Size(143, 46);
            this.mnuSMTP.Text = "SMTP Settings";
            this.mnuSMTP.Click += new System.EventHandler(this.mnuSMTP_Click);
            // 
            // mnuInvoice
            // 
            this.mnuInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuInvoice.Image = global::STHookAdmin.Properties.Resources.invoice;
            this.mnuInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuInvoice.Name = "mnuInvoice";
            this.mnuInvoice.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.mnuInvoice.Size = new System.Drawing.Size(140, 46);
            this.mnuInvoice.Text = "Invoice Query";
            this.mnuInvoice.Click += new System.EventHandler(this.mnuInvoice_Click);
            // 
            // mnuHookCredentials
            // 
            this.mnuHookCredentials.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuHookCredentials.Image = global::STHookAdmin.Properties.Resources.settings;
            this.mnuHookCredentials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuHookCredentials.Name = "mnuHookCredentials";
            this.mnuHookCredentials.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.mnuHookCredentials.Size = new System.Drawing.Size(141, 46);
            this.mnuHookCredentials.Text = "Hook Settings";
            this.mnuHookCredentials.Click += new System.EventHandler(this.mnuHookCredentials_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuExit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuExit.Image = global::STHookAdmin.Properties.Resources.exit;
            this.mnuExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.mnuExit.Size = new System.Drawing.Size(76, 46);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuManualRun
            // 
            this.mnuManualRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuManualRun.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnuManualRun.Image = global::STHookAdmin.Properties.Resources.exit;
            this.mnuManualRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuManualRun.Name = "mnuManualRun";
            this.mnuManualRun.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.mnuManualRun.Size = new System.Drawing.Size(129, 46);
            this.mnuManualRun.Text = "Manual Run";
            this.mnuManualRun.Visible = false;
            this.mnuManualRun.Click += new System.EventHandler(this.mnuManualRun_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1224, 675);
            this.Controls.Add(this.rPopUpLogin);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdTitle)).EndInit();
            this.rdTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radMainMenu)).EndInit();
            this.rPopUpLogin.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rPopUpLogin)).EndInit();
            this.rPopUpLogin.ResumeLayout(false);
            this.mnuUserMenu.ResumeLayout(false);
            this.mnuUserMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        private Telerik.WinControls.UI.RadPopupEditor radMainMenu;
        internal Telerik.WinControls.UI.RadPopupContainer rPopUpLogin;
        internal System.Windows.Forms.MenuStrip mnuUserMenu;
        internal System.Windows.Forms.ToolStripMenuItem mnuLogs;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripMenuItem mnuSMTP;
        internal System.Windows.Forms.ToolStripMenuItem mnuHookCredentials;
        internal System.Windows.Forms.ToolStripMenuItem mnuInvoice;
        internal Telerik.WinControls.UI.RadTitleBar rdTitle;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.ToolStripMenuItem mnuManualRun;
    }
}