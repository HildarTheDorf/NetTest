using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTest.Models;

namespace NetTest
{
    public partial class PettyCash : Form
    {
        private Assembly _assembly = System.Reflection.Assembly.GetExecutingAssembly();
        private FileVersionInfo _info;

        public mUCs m_UCs = null;
        private cAccount cAcc = null;
        public PettyCash()
        {
            InitializeComponent();

            InitApp();
        }

        public void InitApp()
        {
            this._info = FileVersionInfo.GetVersionInfo(_assembly.Location);
            m_UCs = new mUCs(this);


            cAccount m_acc = new mAccount().getAccount();
            if (m_acc == null)
            {
                m_UCs.ShowScreen_Login();
            }
            else
            {
                m_UCs.ShowScreen_Main();
            }


            labVersion.Text = "Version: " + this._info.FileVersion;
        }

        private void doMainMenuClick(object sender, EventArgs e)
        {
            cAcc = new mAccount().getAccount();
            if (cAcc == null)
            {
                m_UCs.ShowScreen_Login();
            }
            else
            {
                m_UCs.ShowScreen_Main();
            }
        }

        private void butLogout_Click(object sender, EventArgs e)
        {
            mAccount m_account = new mAccount();
            cAcc = m_account.getAccount();
            if (cAcc != null)
            {
                var lr = m_account.doLogout(cAcc.accUserName);
                if (lr != null)
                {
                    m_UCs.ShowScreen_Login();
                }
            }
        }
    }
}
