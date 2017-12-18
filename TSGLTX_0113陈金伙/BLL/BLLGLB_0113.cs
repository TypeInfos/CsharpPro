using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLGLB
	/// </summary>
	public partial class BLLGLB
	{
        public string GetPassword(string username)
        {
            GLB model = this.GetModel(username);
            return model.ADPASSWORD;

        }
		public bool CheckUser(string username,string password)
        {
            GLB model = this.GetModel(username);
            if (model == null || model.ADPASSWORD != password)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        public List<TSGLXT.Model.GLB> GetViewModelList(string strWhere)
        {
            DataSet ds = dal.GetDetailList(strWhere);
            return DataViewDetaiList(ds.Tables[0]);
        }
        public List<TSGLXT.Model.GLB> DataViewDetaiList(DataTable dt)
        {

            List<TSGLXT.Model.GLB> modelList = new List<TSGLXT.Model.GLB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TSGLXT.Model.GLB model;
                for(int n = 0;n < rowsCount;n++)
                {
                    model = new TSGLXT.Model.GLB();
                    if (dt.Rows[n]["ADYNAME"] != null && dt.Rows[n]["ADYNAME"].ToString() !="")
                    {
                        model.ADYNAME = dt.Rows[n]["ADYNAME"].ToString();
                    }
                    if (dt.Rows[n]["ADUSERNAME"] != null && dt.Rows[n]["ADUSERNAME"].ToString() != "")
                    {
                        model.ADUSERNAME = dt.Rows[n]["ADUSERNAME"].ToString();

                    }
                    if (dt.Rows[n]["SKID"] != null && dt.Rows[n]["SKID"].ToString() != "")
                    {
                        model.SKID = dt.Rows[n]["SKID"].ToString();
                    }
                    if (dt.Rows[n]["ADSEX"] != null && dt.Rows[n]["ADSEX"].ToString() != "")
                    {
                        model.ADSEX = dt.Rows[n]["ADSEX"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public bool CheckADNAME(string msg)
        {
            return this.GetModelList("ADUSERNAME='" + msg + "'").Count != 0;
        }
        public bool CheckSKIDExist(string msg)
        {
            return this.GetModelList("SKID='" + msg + "'").Count != 0;
        }
	}
}

