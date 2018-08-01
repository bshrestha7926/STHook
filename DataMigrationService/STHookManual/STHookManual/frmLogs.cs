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
using Telerik.WinControls.UI;
using System.Data.Entity;

namespace STHookAdmin
{
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }


       SThook.STHookManager hookManager = new SThook.STHookManager();

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

      

       
        private void frmLogs_Load(object sender, EventArgs e)
        {
            hookManager.getMainLog(this.rdDates);
            hookManager.getLogsByLogId(hookManager.getLogIDforLastRun(), rdLog, lblmain);
                 
        }

     
        private void rdDates_Click(object sender, EventArgs e)
        {

        }


        private void rdDates_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //Check if Header is Clicked
            if (e.RowIndex != -1)
            {
                //Check if invalid column is clicked
                if (e.ColumnIndex != -1)
                {

                    if (rdDates.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {

                        var id = Convert.ToInt32(rdDates.Rows[e.RowIndex].Cells[0].Value);
                        hookManager.getLogsByLogId(id, rdLog, lblmain);
                        
                    }

                }
            }
        }
    }
}
