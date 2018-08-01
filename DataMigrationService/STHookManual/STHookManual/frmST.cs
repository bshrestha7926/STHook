using HillerService.DataMigration.ServiceTradeIntegration;
using HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace STHookAdmin
{
    public partial class frmST : Form
    {
        public frmST()
        {
            InitializeComponent();
        }

        SThook.STHookManager hookManager = new SThook.STHookManager();


        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtInvoice.Text != string.Empty)
            {
            var Invoices = hookManager.searchInvoice(txtInvoice.Text);
        
            if (Invoices != null)
       
            {
                

         rdInvoices.DataSource = Invoices;
         hookManager.bestFitRadGridView(rdInvoices);

         var tags = hookManager.SearchTags(txtInvoice.Text);

           
              
         rdgTags.DataSource = tags;
                
            }

            }
            else
            {
                MessageBox.Show("Search Field cannot be empty.", "Error", MessageBoxButtons.OK);
            }
            
        }

        private void frmST_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            IApiManager serviceTrade = new ServiceTradeAPIManager();
            var Invoices = hookManager.GetAllInvoices();

            if (Invoices != null)
            {
                rdInvoices.DataSource = Invoices;
                hookManager.bestFitRadGridView(rdInvoices);
            }
           
        }


    
    }
}
