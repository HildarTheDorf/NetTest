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
    public partial class ucLoggedIn : UserControl
    {
        mAccount acc = null;
        cAccount cAcc = null;

        public ucLoggedIn()
        {
            InitializeComponent();
        }


        public void Display()
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.HideAll();

            p_mucs.m_ucLoggedIn.Left = p_mucs.m_ucLogin.Left;
            p_mucs.m_ucLoggedIn.Top = p_mucs.m_ucLogin.Top;
            p_mucs.m_ucLoggedIn.Show();

            acc = new mAccount();

            Guid? mAccount = acc.accountLoggedIn();
            if (mAccount == null || mAccount == Guid.Empty)
            {

            }
            else
            {
                cAcc = new cAccount().readById((Guid)mAccount);
                //Check if should log out
                TimeSpan ts = DateTime.Now - cAcc.accDT;
                if (ts.Minutes >=5)
                {
                    p_mucs.m_ucLogin.Display();
                }
                mCash mCash = new mCash();
                LINuser.Text = cAcc.accUserName;
                LINbalance.Text = mCash.getBalance();
            }
        }

        private void ucLoggedIn_Load(object sender, EventArgs e)
        {

        }

        private void LINspendcash_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucCashSpend.Display();
        }

        private void LINtransactions_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucTransactions.Display();
        }

        private void LINaddcash_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucCashAdd.Display();
        }

        private void LINLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
