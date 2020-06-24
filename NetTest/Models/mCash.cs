using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTest.DataSets;
using NetTest.DataSets.ds_cashTableAdapters;

namespace NetTest.Models
{
    class mCash
    {
        public mCash()
        {

        }

        public List<cCategory> getCategoryList()
        {
            List<cCategory> ret = new List<cCategory>();
            spCashCategoryListTableAdapter ta = new spCashCategoryListTableAdapter();
            var dt = ta.doReadList();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (var dr in dt)
                    {
                        cCategory cat = new cCategory();
                        cat.pccKey = dr.pccKey;
                        cat.pccName = dr.pccName;
                        ret.Add(cat);
                    }
                }
            }

            return ret;

        }


        public double getBalance()
        {
            double dRet = 0.0;
            List<cCash> lCash = doReadList();
            if (lCash != null && lCash.Count > 0)
            {
                var cash = lCash.FirstOrDefault();
                if(cash != null)
                {
                    dRet = cash.pcaTotal;
                }
            }

            return dRet;

        }

        public cCash doUpdate(string username, CashCategory key, double? cash, AccountAuditType addspend)
        {
            cCash ret = null;
            spCashReadListTableAdapter ta = new spCashReadListTableAdapter();
            var dt = ta.doUpdate(username, key.ToString(), cash, addspend.ToString(), DateTime.Now);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    var dr = dt.FirstOrDefault();
                    ret = getCash(dr);
                }
            }
            return ret;
        }


        private DataTable MakeDataGrdivViewTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable dt = new DataTable("CashDGV");

            // Add three column objects to the table.
            
            DataColumn col0 = new DataColumn();
            col0.DataType = System.Type.GetType("System.Int32");
            col0.ColumnName = "id";
            col0.AutoIncrement = true;
            dt.Columns.Add(col0);
            
            DataColumn col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "Person";
            col1.DefaultValue = "";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.Double");
            col2.ColumnName = "Amount";
            dt.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.String");
            col3.ColumnName = "Category";
            dt.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.DataType = System.Type.GetType("System.DateTime");
            col4.ColumnName = "DateTime";
            dt.Columns.Add(col4);

            // Create an array for DataColumn objects.
            DataColumn[] keys = new DataColumn[1];
            keys[0] = col0;
            dt.PrimaryKey = keys;

            // Return the new DataTable.
            return dt;
        }
        public DataTable getCashForDataGridView(List<cCash> lCash)
        {
            var ret = new DataTable();
            foreach(var iCash in lCash)
            {
                var dr = ret.NewRow();
                dr["DateTime"] = iCash.pcaDT;
                dr["Amount"] = iCash.pcaAmount;
                dr["Category"] = iCash.pccKey;
                dr["Person"] = String.Format("{0} {1}",iCash.accFirstName, iCash.accLastName);

            }

            return ret;
        }

        public List<cCash> doReadList()
        {
            List<cCash> ret = null;

            spCashReadListTableAdapter ta = new spCashReadListTableAdapter();
            var dt = ta.doReadList();

            if (dt!= null && dt.Rows.Count >0)
            {
                ret = new List<cCash>();

                foreach(var dr in dt)
                {
                    cCash cash = getCash(dr);
                    ret.Add(cash);
;                }
            }

            return ret;
        }

        public cCash getCash(ds_cash.spCashReadListRow dr)
        {
            cCash ret = new cCash();
                ret.accUserName = dr.accUserName;
                ret.accFirstName = dr.accFirstName;
                ret.accLastName = dr.accLastName;
            ret.pcaDT = dr.pcaDT;
            ret.pcaAmount = dr.pcaAmount;
            if (!dr.IspcaTotalNull())
            {
                ret.pcaTotal = dr.pcaTotal;
            }
                ret.pccKey = dr.pccKey;
                ret.pccName = dr.pccName;
            return ret;
        }
    }
    class cCategory
    {
        public string pccKey;
        public string pccName;

        public cCategory()
        {

        }
    }


    class cCash
    {
        public DateTime pcaDT;
        public double pcaAmount;
        public double pcaTotal;
        public string accUserName;
        public string accFirstName;
        public string accLastName;
        public string pccKey;
        public string pccName;

        public cCash()
        {

        }

    }

    public enum CashCategory
    {
        PCC_Nothing = 0,
        PCC_CashAdd,
        PCC_Tea,
        PCC_Stat,
        PCC_Travel,
        PCC_Clean
    }
}
