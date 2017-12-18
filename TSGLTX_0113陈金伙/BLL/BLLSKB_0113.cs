using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLSKB
	/// </summary>
	public partial class BLLSKB
	{
		public bool CheckSKIDExist(string str)
        {
            return this.GetModelList("SKID='" + str + "'").Count != 0;
        }

        public List<TSGLXT.Model.SKB> GetAddressModelList(string strWhere)
        {
            DataSet ds = dal.GetAddressList(strWhere);
            return DataAddresslist(ds.Tables[0]);
        }
        public List<TSGLXT.Model.SKB> DataAddresslist(DataTable dt)
        {

            List<TSGLXT.Model.SKB> modelList = new List<TSGLXT.Model.SKB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.SKB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TSGLXT.Model.SKB();
                    if (dt.Rows[n]["SKADDRESS"] != null && dt.Rows[n]["SKADDRESS"].ToString() != "")
                    {
                        model.SKADDRESS = dt.Rows[n]["SKADDRESS"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;

        }
        public List<TSGLXT.Model.SKB> GetViewModelList(string strWhere)
        {
            DataSet ds = dal.GetDetailList(strWhere);
            return DataViewDetaiList(ds.Tables[0]);
        }
        public List<TSGLXT.Model.SKB> DataViewDetaiList(DataTable dt)
        {

            List<TSGLXT.Model.SKB> modelList = new List<TSGLXT.Model.SKB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.SKB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TSGLXT.Model.SKB();
                    if (dt.Rows[n]["SKID"] != null && dt.Rows[n]["SKID"].ToString() != "")
                    {
                        model.SKID = dt.Rows[n]["SKID"].ToString();
                    }
                    if (dt.Rows[n]["BKISBN"] != null && dt.Rows[n]["BKISBN"].ToString() != "")
                    {
                        model.bkisbn = dt.Rows[n]["BKISBN"].ToString();
                    }
                    if (dt.Rows[n]["BKNAME"] != null && dt.Rows[n]["BKNAME"].ToString() != "")
                    {
                        model.bkname = dt.Rows[n]["BKNAME"].ToString();
                    }
                    if (dt.Rows[n]["BKPRICE"] != null && dt.Rows[n]["BKPRICE"].ToString() != "")
                    {
                        model.bkprice = dt.Rows[n]["BKPRICE"].ToString();
                    }
                    if (dt.Rows[n]["BKAUTHOR"] != null && dt.Rows[n]["BKAUTHOR"].ToString() != "")
                    {
                        model.bkauthor = dt.Rows[n]["BKAUTHOR"].ToString();
                    }
                    if (dt.Rows[n]["SKADDRESS"] != null && dt.Rows[n]["SKADDRESS"].ToString() != "")
                    {
                        model.SKADDRESS = dt.Rows[n]["SKADDRESS"].ToString();
                    }
         
                    if (dt.Rows[n]["SKTELEPHONE"] != null && dt.Rows[n]["SKTELEPHONE"].ToString() != "")
                    {
                        model.SKTELEPHONE = dt.Rows[n]["SKTELEPHONE"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
          
        }


	}
}

