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
    public partial class ucCashAdd : UserControl
    {
        cAccount cAcc = null;
        mUCs m_UCs = null;
        mCash m_cash = null;

        public ucCashAdd(mUCs m_UCs)
        {
            this.m_UCs = m_UCs;

            InitializeComponent();
        }


        public void Init()
        {
            m_UCs.SetMessageBox(pan_MessageBox);
            cAcc = new mAccount().getAccount();
            if (cAcc == null)
            {
                m_UCs.ShowScreen_Login();
            }
            else
            {
                m_cash = new mCash();
            }
        }


        private void PCSAdd_Click(object sender, EventArgs e)
        {
            double cash = 0.0;
            if (!double.TryParse(PCAamount.Text, out cash))
            {
                //Cash amount not successfully parsed
            }
            var r_cash = m_cash.doUpdate(cAcc.accUserName, CashCategory.PCC_CashAdd, cash, AccountAuditType.AAT_CashSpent);
            if (r_cash == null)
            {
                //Cash not successfully added
            }

            m_UCs.ShowScreen_Main();
        }

        private void doLoadClick(object sender, EventArgs e)
        {
            Init();
        }
    }
}
