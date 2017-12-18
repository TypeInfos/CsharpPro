using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLTSB
	/// </summary>
	public partial class BLLTSB
	{
		private readonly TSGLXT.DAL.DALTSB dal=new TSGLXT.DAL.DALTSB();
		public BLLTSB()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BKISBN)
		{
			return dal.Exists(BKISBN);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.TSB model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TSGLXT.Model.TSB model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string BKISBN)
		{
			
			return dal.Delete(BKISBN);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BKISBNlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(BKISBNlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSGLXT.Model.TSB GetModel(string BKISBN)
		{
			
			return dal.GetModel(BKISBN);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public TSGLXT.Model.TSB GetModelByCache(string BKISBN)
		{
			
			string CacheKey = "TSBModel-" + BKISBN;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BKISBN);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSGLXT.Model.TSB)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSGLXT.Model.TSB> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSGLXT.Model.TSB> DataTableToList(DataTable dt)
		{
			List<TSGLXT.Model.TSB> modelList = new List<TSGLXT.Model.TSB>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSGLXT.Model.TSB model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

