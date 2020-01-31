﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTest.UserControls;
namespace NetTest.Models
{
    public class mUCs
    {
        public mUCs(ucLogin login, ucLoggedIn loggedin, ucCashSpend cash, ucTransactions trans)
        {
            m_ucLogin = login;
            m_ucLoggedIn = loggedin;
            m_ucCashSpend = cash;
            m_ucTransactions = trans;
        }

        public void HideAll()
        {
            m_ucLogin.Hide();
            m_ucLoggedIn.Hide();
            m_ucCashSpend.Hide();
            m_ucTransactions.Hide();
        }

        static mUCs s_mUCs;

        public ucTransactions m_ucTransactions;
        public ucCashSpend m_ucCashSpend;
        public ucLogin m_ucLogin;
        public ucLoggedIn m_ucLoggedIn;
    }
}