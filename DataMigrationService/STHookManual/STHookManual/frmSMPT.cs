using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HillerService.DataMigration.Entity;
using System.Data.Entity;

namespace STHookAdmin
{
    public partial class frmSMPT : Form
    {
        public frmSMPT()
        {
            InitializeComponent();
        }

        SThook.STHookManager hookManager = new SThook.STHookManager();

        private void frmSMPT_Load(object sender, EventArgs e)
        {
            var smtpSettings = hookManager.getSMTPDetail();
            lblID.Text = smtpSettings.id.ToString();
            txtHost.Text = smtpSettings.SMTPHost;
            txtPort.Text = smtpSettings.SMTPPort;
            txtUsername.Text = smtpSettings.SMTPUsername;
            txtPassword.Text = smtpSettings.SMTPPassword;
            chkEnableSSL.Checked = Convert.ToBoolean(smtpSettings.SMTPEnableSSL);
            txtEmail.Text = smtpSettings.SMTPNotificationEmail;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        //Update SMTP Settings
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool success =false;

            //Get the ID
            var Id = Convert.ToInt32(lblID.Text);
            try
            {
                success = hookManager.updateSMTPSettings(Id, chkEnableSSL.Checked, txtPort.Text, 
                                    txtHost.Text, txtUsername.Text, txtEmail.Text, txtPassword.Text);
            }

            catch 
            {
                //
            }

            if (success)
            {
                MessageBox.Show("SMTP settings updated successfully. ", "SMTP Update", MessageBoxButtons.OK);
            }
        }

    }
}
