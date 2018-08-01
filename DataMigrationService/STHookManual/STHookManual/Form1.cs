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

namespace STHookAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            STHookEntities context = new STHookEntities();

            var query = from l in context.DailyLog
                           select l;

            var logs = query.ToList();
            rdLog.DataSource = logs;
            //            dataGridView1.DataSource = logs;
            

        }
    }
}
