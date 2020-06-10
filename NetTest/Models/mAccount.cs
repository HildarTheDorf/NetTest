using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTest.DataSets;
using NetTest.DataSets.sitedbTableAdapters;

namespace NetTest.Models
{
    class mAccount
    {
        public Guid? accountLoggedIn()
        {
            Guid? ret = null;
            spGetAccountLoggedInTableAdapter ta = new spGetAccountLoggedInTableAdapter();
            sitedb.spGetAccountLoggedInDataTable dt = ta.GetData();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sitedb.spGetAccountLoggedInRow dr = dt[0];
                    if (!dr.IsacaAccountNull())
                    {
                        ret = dr.acaAccount;
                    }
                }
            }
            return ret;
        }

        public Guid getAccountIdFromUsernamePwd(string username, string pwd)
        {
            Guid ret = Guid.Empty;
            spGetAccountAsUniqueIdTableAdapter taId = new spGetAccountAsUniqueIdTableAdapter();
            var dtId = taId.GetData(username, pwd);
            if (dtId != null)
            {
                if (dtId.Count > 0)
                {
                    var drId = dtId[0];
                    ret = drId.acaAccount;
                }
            }
            return ret;
        }
    }
    class cAccount
    {
        public cAccount()
        {

        }


        public cAccount(sitedb.spAccountReadByIdDataTable dt)
        {
            sitedb.spAccountReadByIdRow dr = dt[0];
            accId = dr.accId;
            accFirstName = dr.accFirstName;
            accLastName = dr.accLastName;
            accUserName = dr.accUserName;
            accAudKey = dr.actKey;
            accAutKey = dr.autKey;
            accDT = dr.acaDT;

            accAccountTypeList = new List<cAccountType>();

            foreach (sitedb.spAccountReadByIdRow drr in dt)
            {
                accAccountTypeList.Add(new cAccountType(drr));
            }
        }


        public cAccount readById(Guid accId)
        {
            cAccount ret = null;

            spAccountReadByIdTableAdapter ta = new spAccountReadByIdTableAdapter();
            sitedb.spAccountReadByIdDataTable dt = ta.GetData(accId);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ret = new cAccount(dt);
                }
            }


            return ret;
        }


        public cAccount checkLoggedIn()
        {
            cAccount ret = null;

            mAccount acc = new mAccount();
            mUCs p_mucs = mUCs.s_mUCs;
            Guid? mAccount = acc.accountLoggedIn();
            if (mAccount == null)
            {
                p_mucs.HideAll();
                p_mucs.m_ucLogin.Display();

            }
            else
            {
                ret = new cAccount().readById((Guid)mAccount);
            }

            return ret;
        }

        public Guid accId;
        public string accFirstName;
        public string accLastName;
        public string accUserName;
        public string accAudKey;
        public string accAutKey;
        public DateTime accDT;
        public List<cAccountType> accAccountTypeList;
    }

    class cAccountType
    {
        public cAccountType(sitedb.spAccountReadByIdRow dr)
        {
            actkey = dr.actKey.Trim();
            actName = dr.actName;
        }
        public string actName;
        public string actkey;
    }
}
