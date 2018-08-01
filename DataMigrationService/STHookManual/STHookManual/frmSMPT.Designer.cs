namespace STHookAdmin
{
    partial class frmSMPT
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
            this.spltTracker = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chkEnableSSL = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).BeginInit();
            this.spltTracker.Panel1.SuspendLayout();
            this.spltTracker.Panel2.SuspendLayout();
            this.spltTracker.SuspendLayout();
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
            this.spltTracker.Panel1.Controls.Add(this.Label16);
            this.spltTracker.Panel1MinSize = 30;
            // 
            // spltTracker.Panel2
            // 
            this.spltTracker.Panel2.AutoScroll = true;
            this.spltTracker.Panel2.BackColor = System.Drawing.Color.White;
            this.spltTracker.Panel2.Controls.Add(this.lblID);
            this.spltTracker.Panel2.Controls.Add(this.btnUpdate);
            this.spltTracker.Panel2.Controls.Add(this.chkEnableSSL);
            this.spltTracker.Panel2.Controls.Add(this.label5);
            this.spltTracker.Panel2.Controls.Add(this.label3);
            this.spltTracker.Panel2.Controls.Add(this.label4);
            this.spltTracker.Panel2.Controls.Add(this.label2);
            this.spltTracker.Panel2.Controls.Add(this.label1);
            this.spltTracker.Panel2.Controls.Add(this.txtPort);
            this.spltTracker.Panel2.Controls.Add(this.txtEmail);
            this.spltTracker.Panel2.Controls.Add(this.txtUsername);
            this.spltTracker.Panel2.Controls.Add(this.txtPassword);
            this.spltTracker.Panel2.Controls.Add(this.txtHost);
            this.spltTracker.Size = new System.Drawing.Size(797, 521);
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
            this.btnClose.Location = new System.Drawing.Point(765, 0);
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
            this.Label16.Size = new System.Drawing.Size(797, 30);
            this.Label16.TabIndex = 266;
            this.Label16.Text = "SMTP Settings";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(225, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 21);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "\"\"";
            this.lblID.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 13F);
            this.btnUpdate.Location = new System.Drawing.Point(229, 337);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 37);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chkEnableSSL
            // 
            this.chkEnableSSL.AutoSize = true;
            this.chkEnableSSL.Font = new System.Drawing.Font("Arial", 12F);
            this.chkEnableSSL.Location = new System.Drawing.Point(130, 145);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnableSSL.Size = new System.Drawing.Size(111, 22);
            this.chkEnableSSL.TabIndex = 16;
            this.chkEnableSSL.Text = "Enable SSL";
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(89, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Notification Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(85, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Username (Email):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(133, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Passsword:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(182, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(179, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Host:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Arial", 13F);
            this.txtPort.Location = new System.Drawing.Point(229, 98);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(442, 27);
            this.txtPort.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Arial", 13F);
            this.txtEmail.Location = new System.Drawing.Point(229, 281);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(442, 27);
            this.txtEmail.TabIndex = 10;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Arial", 13F);
            this.txtUsername.Location = new System.Drawing.Point(229, 193);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(442, 27);
            this.txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 13F);
            this.txtPassword.Location = new System.Drawing.Point(229, 237);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(442, 27);
            this.txtPassword.TabIndex = 9;
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Arial", 13F);
            this.txtHost.Location = new System.Drawing.Point(229, 47);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(442, 27);
            this.txtHost.TabIndex = 8;
            // 
            // frmSMPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 521);
            this.Controls.Add(this.spltTracker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSMPT";
            this.Text = "frmSMPT";
            this.Load += new System.EventHandler(this.frmSMPT_Load);
            this.spltTracker.Panel1.ResumeLayout(false);
            this.spltTracker.Panel1.PerformLayout();
            this.spltTracker.Panel2.ResumeLayout(false);
            this.spltTracker.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).EndInit();
            this.spltTracker.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer spltTracker;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkEnableSSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblID;
    }
}