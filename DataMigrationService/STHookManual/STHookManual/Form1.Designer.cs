namespace STHookAdmin
{
    partial class Form1
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
            this.rdLog = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rdLog
            // 
            this.rdLog.Location = new System.Drawing.Point(12, 133);
            // 
            // 
            // 
            this.rdLog.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rdLog.Name = "rdLog";
            this.rdLog.Size = new System.Drawing.Size(1005, 395);
            this.rdLog.TabIndex = 1;
            this.rdLog.Text = "radGridView1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 553);
            this.Controls.Add(this.rdLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdLog.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rdLog;
    }
}

