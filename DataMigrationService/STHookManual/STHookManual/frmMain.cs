using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace STHookAdmin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        bool drag;
        int mousex;
        int mousey;

        private void lblHeader_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }


        private void lblheader_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            drag = true;
            mousex = System.Windows.Forms.Cursor.Position.X - this.Left;
            mousey = System.Windows.Forms.Cursor.Position.Y - this.Top;
        }


        private void lblheader_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = System.Windows.Forms.Cursor.Position.Y - mousey;
                this.Left = System.Windows.Forms.Cursor.Position.X - mousex;
            }
        }

        private void lblheader_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            drag = false;
            System.Environment.Exit(0); /* TODO ERROR: Skipped SkippedTokensTrivia */
        }

        private void mnuLogs_Click(object sender, EventArgs e)
        {
      

            var f = (frmLogs)Application.OpenForms["frmlogs"];

            if (f == null)
            {
                f = new frmLogs();
                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
            else
            {
                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }

           

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuSMTP_Click(object sender, EventArgs e)
        {

            var f = (frmSMPT)Application.OpenForms["frmsmpt"];

            if (f == null)
            {
                f = new frmSMPT();

                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
            else
            {
                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }

        }

        private void mnuHookCredentials_Click(object sender, EventArgs e)
        {
            var f = (frmServiceTrade)Application.OpenForms["frmservicetrade"];

            if (f == null)
            {
                f = new frmServiceTrade();

                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
            else
            {
                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
        }

        private void mnuInvoice_Click(object sender, EventArgs e)
        {
            var f = (frmST)Application.OpenForms["frmst"];

            if (f == null)
            {
                f = new frmST();

                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
            else
            {
                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
        }

        private void radMainMenu_Click(object sender, EventArgs e)
        {
            radMainMenu.PopupEditorElement.ShowPopup();
        }

        private void mnuUserMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            radMainMenu.PopupEditorElement.ClosePopup();
        }

        private void mnuManualRun_Click(object sender, EventArgs e)
        {
            var f = (frmManualRun)Application.OpenForms["frmmanualrun"];

            if (f == null)
            {
                f = new frmManualRun();

                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
            else
            {
                f.MdiParent = this;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                f.AutoScroll = true;
                f.Show();
                f.Focus();
            }
        }

    }
}
