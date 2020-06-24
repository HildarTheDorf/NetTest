using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTest.Models;


namespace NetTest.UserControls
{
    public partial class ucLogin : UserControl
    {
        private mUCs m_UCs = null;

        public ucLogin(mUCs m_UCs)
        {
            this.m_UCs = m_UCs;
            InitializeComponent();
        }

        private void Init()
        {
            Licontinue.Visible = false;
            LIstatus.Text = "";
        }

        private void liSubmit_Click(object sender, EventArgs e)
        {
            cAccount m_acc = new mAccount().doLogin(LIusername.Text, LIpwd.Text);

            if (m_acc != null)
            {

                Licontinue.Visible = true;
                LIstatus.Text = "Logged in";
                LIusername.Enabled = false;
                LIpwd.Enabled = false;
                LIsubmit.Enabled = false;
            }
        }


        private void Licontinue_Click(object sender, EventArgs e)
        {
            m_UCs.ShowScreen_Main();
        }

        private void doLoadClick(object sender, EventArgs e)
        {
            Init();
        }
    }
}
