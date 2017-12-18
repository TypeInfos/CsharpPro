using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLDZB
	/// </summary>
	public partial class BLLDZB
	{
		public bool CheckDZID(string num)
        {
            DZB model = this.GetModel(num);
            if (model == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckISBNExist(string isbn)
        {
            return this.GetModelList("BKISBN='" + isbn + "'").Count != 0;
        }
        public List<TSGLXT.Model.DZB> GetNameModelList(string strWhere)
        {
            DataSet ds = dal.GetNameList(strWhere);
            return DataNameList(ds.Tables[0]);
        }
        public List<TSGLXT.Model.DZB> DataNameList(DataTable dt)
        {

            List<TSGLXT.Model.DZB> modelList = new List<TSGLXT.Model.DZB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.DZB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TSGLXT.Model.DZB();

                    if (dt.Rows[n]["DZNAME"] != null && dt.Rows[n]["DZNAME"].ToString() != "")
                    {
                        model.DZNAME = dt.Rows[n]["DZNAME"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;

        }
        public List<TSGLXT.Model.DZB> GetAddressModelList(string strWhere)
        {
            DataSet ds = dal.GetAddressList(strWhere);
            return DateAddressList(ds.Tables[0]);
        }
        public List<TSGLXT.Model.DZB> DateAddressList(DataTable dt)
        {

            List<TSGLXT.Model.DZB> modelList = new List<TSGLXT.Model.DZB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.DZB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TSGLXT.Model.DZB();
                   
                    if (dt.Rows[n]["DZADDRESS"] != null && dt.Rows[n]["DZADDRESS"].ToString() != "")
                    {
                        model.DZADDRESS = dt.Rows[n]["DZADDRESS"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;

        }
        public List<TSGLXT.Model.DZB> GetViewModelList(string strWhere)
        {
            DataSet ds = dal.GetDetailList(strWhere);
            return DataViewDetaiList(ds.Tables[0]);
        }
        public List<TSGLXT.Model.DZB> DataViewDetaiList(DataTable dt)
        {

            List<TSGLXT.Model.DZB> modelList = new List<TSGLXT.Model.DZB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.DZB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TSGLXT.Model.DZB();
                    if (dt.Rows[n]["SKID"] != null && dt.Rows[n]["SKID"].ToString() != "")
                    {
                        model.skid = dt.Rows[n]["SKID"].ToString();
                    }
                    if (dt.Rows[n]["BKISBN"] != null && dt.Rows[n]["BKISBN"].ToString() != "")
                    {
                        model.BKISBN = dt.Rows[n]["BKISBN"].ToString();
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
                    if (dt.Rows[n]["DZID"] != null && dt.Rows[n]["DZID"].ToString() != "")
                    {
                        model.DZID = dt.Rows[n]["DZID"].ToString();
                    }
                    if (dt.Rows[n]["DZNAME"] != null && dt.Rows[n]["DZNAME"].ToString() != "")
                    {
                        model.DZNAME = dt.Rows[n]["DZNAME"].ToString();
                    }
                    if (dt.Rows[n]["DZYEAR"] != null && dt.Rows[n]["DZYEAR"].ToString() != "")
                    {
                        model.DZYEAR = (int)dt.Rows[n]["DZYEAR"];
                    }
                    if (dt.Rows[n]["DZDUTY"] != null && dt.Rows[n]["DZDUTY"].ToString() != "")
                    {
                        model.DZDUTY = dt.Rows[n]["DZDUTY"].ToString();
                    }
                    if (dt.Rows[n]["DZADDRESS"] != null && dt.Rows[n]["DZADDRESS"].ToString() != "")
                    {
                        model.DZADDRESS = dt.Rows[n]["DZADDRESS"].ToString();
                    }

                   
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public List<TSGLXT.Model.DZB> GetNameList(string strWhere,string c,int b)
        {
            DataSet ds = dal.GetDetailList(strWhere);
            return DataNew(ds.Tables[0],c,b);
        }
        public List<TSGLXT.Model.DZB> DataNew(DataTable dt,string c,int b)
        {
            int charA = 0;
            int Sq = 0;
            bool mark = false ;
            int x = 0;
            int num = 0;
            List<TSGLXT.Model.DZB> modelList = new List<TSGLXT.Model.DZB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.DZB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TSGLXT.Model.DZB();
                    if (dt.Rows[n]["SKID"] != null && dt.Rows[n]["SKID"].ToString() != "")
                    {
                        model.skid = dt.Rows[n]["SKID"].ToString();
                    }
                    if (dt.Rows[n]["BKISBN"] != null && dt.Rows[n]["BKISBN"].ToString() != "")
                    {
                        model.BKISBN = dt.Rows[n]["BKISBN"].ToString();
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
                    if (dt.Rows[n]["DZID"] != null && dt.Rows[n]["DZID"].ToString() != "")
                    {
                        model.DZID = dt.Rows[n]["DZID"].ToString();
                    }
                    if (dt.Rows[n]["DZNAME"] != null && dt.Rows[n]["DZNAME"].ToString() != "")
                    {
                        model.DZNAME = dt.Rows[n]["DZNAME"].ToString();
                    }
                    if (dt.Rows[n]["DZYEAR"] != null && dt.Rows[n]["DZYEAR"].ToString() != "")
                    {
                        model.DZYEAR = (int)dt.Rows[n]["DZYEAR"];
                    }
                    if (dt.Rows[n]["DZDUTY"] != null && dt.Rows[n]["DZDUTY"].ToString() != "")
                    {
                        model.DZDUTY = dt.Rows[n]["DZDUTY"].ToString();
                    }
                    if (dt.Rows[n]["DZADDRESS"] != null && dt.Rows[n]["DZADDRESS"].ToString() != "")
                    {
                        model.DZADDRESS = dt.Rows[n]["DZADDRESS"].ToString();
                    }
                    if (b == 0)
                    {
                        foreach (char a in c)
                        {

                            while (num < model.DZNAME.Length)
                            {

                                mark = false;
                                if (a == model.DZNAME[num])
                                {
                                    Sq++;
                                    mark = true;
                                }
                                if (mark)
                                {
                                    num++;
                                    break;
                                }
                                num++;
                            }

                            charA++;
                        }
                        if (charA == Sq)
                        {
                            modelList.Add(model);
                        }
                        charA = 0;
                        num = 0;
                        Sq = 0;
                    }
                    else if (b == 1)
                    {
                        foreach (char a in c)
                        {

                            while (num < model.bkname.Length)
                            {

                                mark = false;
                                if (a == model.bkname[num])
                                {
                                    Sq++;
                                    mark = true;
                                }
                                if (mark)
                                {
                                    num++;
                                    break;
                                }
                                num++;
                            }

                            charA++;
                        }
                        if (charA == Sq)
                        {
                            modelList.Add(model);
                        }
                        charA = 0;
                        num = 0;
                        Sq = 0;
                    }
                    else if (b == 2)
                    {
                        foreach (char a in c)
                        {

                            while (num < model.DZID.Length)
                            {

                                mark = false;
                                if (a == model.DZID[num])
                                {
                                    Sq++;
                                    mark = true;
                                }
                                if (mark)
                                {
                                    num++;
                                    break;
                                }
                                num++;
                            }

                            charA++;
                        }
                        if (charA == Sq)
                        {
                            modelList.Add(model);
                        }
                        charA = 0;
                        num = 0;
                        Sq = 0;
                    }
                    
                }
            }
            return modelList;

        }
	}
}

