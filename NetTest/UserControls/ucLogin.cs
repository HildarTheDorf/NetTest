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
using NetTest.DataSets;
using NetTest.DataSets.sitedbTableAdapters;

namespace NetTest.UserControls
{
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }

        public void Display()
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.HideAll();

            //p_mucs.m_ucLogin.Left = p_mucs.m_ucLogin.Left;
            //p_mucs.m_ucLogin.Top = p_mucs.m_ucLogin.Top;
            p_mucs.m_ucLogin.Show();
        }

        private void liSubmit_Click(object sender, EventArgs e)
        {
            Guid accId = new mAccount().getAccountIdFromUsernamePwd(LIusername.Text, LIpwd.Text);

            if (accId != Guid.Empty)
            {
                spAccountLoginOutTableAdapter ta = new spAccountLoginOutTableAdapter();
                sitedb.spAccountLoginOutDataTable dt = ta.GetData(accId, DateTime.Now, "Li");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        sitedb.spAccountLoginOutRow dr = dt[0];
                        if (dr.acaAccount != Guid.Empty)
                        {
                            Licontinue.Visible = true;
                            LIstatus.Text = "Logged in";
                            LIusername.Enabled = false;
                            LIpwd.Enabled = false;
                            LIsubmit.Enabled = false;
                        }
                    }
                }
            }
        }

        private void ucLogin_Load(object sender, EventArgs e)
        {
            Licontinue.Visible = false;
            LIstatus.Text = "";
        }

        private void Licontinue_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;

            p_mucs.m_ucLogin.Hide();
            if (p_mucs != null)
            {
                p_mucs.m_ucLoggedIn.Left = p_mucs.m_ucLogin.Left;
                p_mucs.m_ucLoggedIn.Top = p_mucs.m_ucLogin.Top;
                p_mucs.m_ucLoggedIn.Show();
            }
        }
    }
}
