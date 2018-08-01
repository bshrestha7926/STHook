using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HillerService.DataMigration.ServiceTradeIntegration;
using System.Threading;
using Telerik.WinControls.UI;


namespace STHookAdmin
{
     

    public partial class frmManualRun : Form
    {
        static frmManualRun frm;

        public frmManualRun()
        {
            InitializeComponent();
            frm = this;
        }

        SThook.STHookManager hookManager = new SThook.STHookManager();

        private void btnManualRun_Click(object sender, EventArgs e)
        {
            Thread tid1 = new Thread(new ThreadStart(RunHook));
            Thread tid2 = new Thread(new ThreadStart(DisplayLogs));

            tid1.Start();
            tid2.Start();
        }

        private void frmManualRun_Load(object sender, EventArgs e)
        {
            
        }

        static void DisplayLogs()
        {
            SThook.STHookManager hook = new SThook.STHookManager();
            hook.getLogsByLogIdManual(hook.getLogIDforLastRun());

            if (hook != null)
            {
                frm.rdLog.DataSource = hook;
                //hook.bestFitRadGridView(frm.rdLog);
            }
        }

        static void RunHook()
        {
            HillerServiceDataMigrator hs = new HillerServiceDataMigrator();

            hs.PerformMigration();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
