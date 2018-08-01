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
    public partial class frmServiceTrade : Form
    {
        public frmServiceTrade()
        {
            InitializeComponent();
        }

        SThook.STHookManager hookManager = new SThook.STHookManager();

        private void frmServiceTrade_Load(object sender, EventArgs e)
        {
            HookCredentials hookSettings = hookManager.getHookSettings();

            if (hookSettings != null)
            {
                lblID.Text = hookSettings.id.ToString();
                chkSettings.Checked = Convert.ToBoolean(hookSettings.runProductionMode);
                txtSTURI.Text = hookSettings.ServiceTradeURI;
                txtSTUsername.Text = hookSettings.ServiceTradeUserName;
                txtSTPassword.Text = hookSettings.ServiceTradePassword;
                txtConnectionString.Text = hookSettings.AS400ConnectionString;

                txtSTURITest.Text = hookSettings.ServiceTradeURITest;
                txtSTUsernameTest.Text = hookSettings.ServiceTradeUserNameTest;
                txtSTPasswordTest.Text = hookSettings.ServiceTradePasswordTest;
                txtConnectionStringTest.Text = hookSettings.AS400ConnectionStringTest;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



       private void btnUpdate_Click(object sender, EventArgs e)
        {
           bool success = false;
            var Id = Convert.ToInt32(lblID.Text);
           
           try
            {
                success = hookManager.updateHookCredentials(Id, chkSettings.Checked, txtSTURI.Text, txtSTUsername.Text, txtSTPassword.Text, txtConnectionString.Text,
                                                         txtSTURITest.Text, txtSTUsernameTest.Text, txtSTPasswordTest.Text, txtConnectionStringTest.Text);

             }
            
           catch
            {
               
            }

            if (success)
            {
                MessageBox.Show("Hook settings updated successfully. ", "Settings Update", MessageBoxButtons.OK);
            }
        }
    }
}
