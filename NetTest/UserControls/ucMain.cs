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
    public partial class ucMain : UserControl
    {

        private mUCs m_UCs = null;
        private cAccount cAcc = null;

        public ucMain(mUCs m_UCs)
        {
            this.m_UCs = m_UCs;
            InitializeComponent();

        }


        public void Init()
        {

            cAcc = new mAccount().getAccount();
            if (cAcc == null)
            {
                m_UCs.ShowScreen_Login();
            }
            else
            {
                mCash mCash = new mCash();
                LINuser.Text = cAcc.accUserName;
            }

        }

        private void LINspendcash_Click(object sender, EventArgs e)
        {
            m_UCs.ShowScreen_CashSpend();
        }

        private void LINtransactions_Click(object sender, EventArgs e)
        {
            m_UCs.ShowScreen_Transactions();
        }

        private void LINaddcash_Click(object sender, EventArgs e)
        {
            m_UCs.ShowScreen_CashAdd();
        }

        private void doLoadClick(object sender, EventArgs e)
        {
            Init();
        }
    }
}
