using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTest.DataSets;
using NetTest.DataSets.ds_accountTableAdapters;

namespace NetTest.Models
{
    class mAccount
    {



        public cAccount getAccount()
        {
            cAccount ret = null;


            spAccountReadTableAdapter ta = new spAccountReadTableAdapter();
            var dt = ta.doRead();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    var dr = dt.FirstOrDefault();
                    ret = getAccount(dr);
                }
            }


            return ret;
        }


        public cAccount getAccount(ds_account.spAccountReadRow dr)
        {
            cAccount ret = new cAccount();

            ret.accId = dr.accId;
            ret.accFirstName = dr.accFirstName;
            ret.accLastName = dr.accLastName;
            ret.accUserName = dr.accUserName;
            ret.accAudDT = dr.acaDT;
            ret.accAutKey = dr.autKey;

            return ret;
        }


        public cAccount doLogin(string username, string pwd)
        {
            cAccount ret = null;
            spAccountReadTableAdapter ta = new spAccountReadTableAdapter();
            var dt = ta.doLogin(username, pwd);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    var dr = dt.FirstOrDefault();
                    ret = getAccount(dr);
                }
            }

            return ret;
        }

        public cAccount doLogout(string username)
        {
            cAccount ret = null;
            spAccountReadTableAdapter ta = new spAccountReadTableAdapter();
            var dt = ta.doLogout(username);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    var dr = dt.FirstOrDefault();
                    ret = getAccount(dr);
                }
            }

            return ret;
        }
    }
    class cAccount
    {
        public Guid accId;
        public string accFirstName;
        public string accLastName;
        public string accUserName;
        public DateTime accAudDT;
        public string accAutKey;

        public cAccount()
        {

        }

    }

    public enum AccountAuditType
    {
        AAT_Default = 0,
        AAT_Login,
        AAT_Logout,
        AAT_CashAdded,
        AAT_CashSpent
    }

}
