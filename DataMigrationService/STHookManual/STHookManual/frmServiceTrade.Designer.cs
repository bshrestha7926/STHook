namespace STHookAdmin
{
    partial class frmServiceTrade
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
            this.label4 = new System.Windows.Forms.Label();
            this.chkSettings = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSTURITest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConnectionStringTest = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSTPasswordTest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSTUsernameTest = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSTURI = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtSTPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSTUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).BeginInit();
            this.spltTracker.Panel1.SuspendLayout();
            this.spltTracker.Panel2.SuspendLayout();
            this.spltTracker.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.spltTracker.Panel2.Controls.Add(this.label4);
            this.spltTracker.Panel2.Controls.Add(this.chkSettings);
            this.spltTracker.Panel2.Controls.Add(this.groupBox2);
            this.spltTracker.Panel2.Controls.Add(this.groupBox1);
            this.spltTracker.Panel2.Controls.Add(this.lblID);
            this.spltTracker.Panel2.Controls.Add(this.btnUpdate);
            this.spltTracker.Size = new System.Drawing.Size(946, 669);
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
            this.btnClose.Location = new System.Drawing.Point(914, 0);
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
            this.Label16.Size = new System.Drawing.Size(946, 30);
            this.Label16.TabIndex = 266;
            this.Label16.Text = "Hook Settings";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(34, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(708, 43);
            this.label4.TabIndex = 30;
            this.label4.Text = "Warning: The changes made here could cause issue with the Service Trade Hook Oper" +
    "ation.\r\nEnsure that you have correct information before saving the changes.";
            // 
            // chkSettings
            // 
            this.chkSettings.AutoSize = true;
            this.chkSettings.Font = new System.Drawing.Font("Arial", 13F);
            this.chkSettings.Location = new System.Drawing.Point(71, 2);
            this.chkSettings.Name = "chkSettings";
            this.chkSettings.Size = new System.Drawing.Size(222, 25);
            this.chkSettings.TabIndex = 29;
            this.chkSettings.Text = "Run in Production Mode";
            this.chkSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSTURITest);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtConnectionStringTest);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSTPasswordTest);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtSTUsernameTest);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 13F);
            this.groupBox2.Location = new System.Drawing.Point(28, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(890, 227);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F);
            this.label9.Location = new System.Drawing.Point(57, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Service Trade URI:";
            // 
            // txtSTURITest
            // 
            this.txtSTURITest.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSTURITest.Location = new System.Drawing.Point(201, 31);
            this.txtSTURITest.Name = "txtSTURITest";
            this.txtSTURITest.Size = new System.Drawing.Size(671, 27);
            this.txtSTURITest.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(17, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "AS400 Connectionstring:";
            // 
            // txtConnectionStringTest
            // 
            this.txtConnectionStringTest.Font = new System.Drawing.Font("Arial", 13F);
            this.txtConnectionStringTest.Location = new System.Drawing.Point(201, 173);
            this.txtConnectionStringTest.Name = "txtConnectionStringTest";
            this.txtConnectionStringTest.Size = new System.Drawing.Size(671, 27);
            this.txtConnectionStringTest.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(12, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Service Trade Password:";
            // 
            // txtSTPasswordTest
            // 
            this.txtSTPasswordTest.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSTPasswordTest.Location = new System.Drawing.Point(201, 129);
            this.txtSTPasswordTest.Name = "txtSTPasswordTest";
            this.txtSTPasswordTest.Size = new System.Drawing.Size(671, 27);
            this.txtSTPasswordTest.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.Location = new System.Drawing.Point(10, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Service Trade Username:";
            // 
            // txtSTUsernameTest
            // 
            this.txtSTUsernameTest.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSTUsernameTest.Location = new System.Drawing.Point(201, 82);
            this.txtSTUsernameTest.Name = "txtSTUsernameTest";
            this.txtSTUsernameTest.Size = new System.Drawing.Size(671, 27);
            this.txtSTUsernameTest.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSTURI);
            this.groupBox1.Controls.Add(this.txtConnectionString);
            this.groupBox1.Controls.Add(this.txtSTPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSTUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 13F);
            this.groupBox1.Location = new System.Drawing.Point(28, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 233);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Production Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(57, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Service Trade URI:";
            // 
            // txtSTURI
            // 
            this.txtSTURI.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSTURI.Location = new System.Drawing.Point(201, 31);
            this.txtSTURI.Name = "txtSTURI";
            this.txtSTURI.Size = new System.Drawing.Size(671, 27);
            this.txtSTURI.TabIndex = 8;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Font = new System.Drawing.Font("Arial", 13F);
            this.txtConnectionString.Location = new System.Drawing.Point(201, 173);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(671, 27);
            this.txtConnectionString.TabIndex = 9;
            // 
            // txtSTPassword
            // 
            this.txtSTPassword.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSTPassword.Location = new System.Drawing.Point(201, 129);
            this.txtSTPassword.Name = "txtSTPassword";
            this.txtSTPassword.Size = new System.Drawing.Size(671, 27);
            this.txtSTPassword.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(17, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "AS400 Connectionstring:";
            // 
            // txtSTUsername
            // 
            this.txtSTUsername.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSTUsername.Location = new System.Drawing.Point(201, 82);
            this.txtSTUsername.Name = "txtSTUsername";
            this.txtSTUsername.Size = new System.Drawing.Size(671, 27);
            this.txtSTUsername.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Service Trade Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(10, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Service Trade Username:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(37, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 21);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "\"\"";
            this.lblID.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 13F);
            this.btnUpdate.Location = new System.Drawing.Point(233, 578);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 37);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmServiceTrade
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(946, 669);
            this.Controls.Add(this.spltTracker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServiceTrade";
            this.Text = "frmServiceTrade";
            this.Load += new System.EventHandler(this.frmServiceTrade_Load);
            this.spltTracker.Panel1.ResumeLayout(false);
            this.spltTracker.Panel1.PerformLayout();
            this.spltTracker.Panel2.ResumeLayout(false);
            this.spltTracker.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltTracker)).EndInit();
            this.spltTracker.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer spltTracker;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSTUsername;
        private System.Windows.Forms.TextBox txtSTPassword;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.TextBox txtSTURI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSTUsernameTest;
        private System.Windows.Forms.TextBox txtSTPasswordTest;
        private System.Windows.Forms.TextBox txtConnectionStringTest;
        private System.Windows.Forms.TextBox txtSTURITest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSettings;
        private System.Windows.Forms.Label label4;
    }
}