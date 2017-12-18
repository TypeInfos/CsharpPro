using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLYHB
	/// </summary>
	public partial class BLLYHB
	{
		private readonly TSGLXT.DAL.DALYHB dal=new TSGLXT.DAL.DALYHB();
		public BLLYHB()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string username)
		{
			return dal.Exists(username);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.YHB model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TSGLXT.Model.YHB model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string username)
		{
			
			return dal.Delete(username);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string usernamelist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(usernamelist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSGLXT.Model.YHB GetModel(string username)
		{
			
			return dal.GetModel(username);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public TSGLXT.Model.YHB GetModelByCache(string username)
		{
			
			string CacheKey = "YHBModel-" + username;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(username);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSGLXT.Model.YHB)objModel;
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
		public List<TSGLXT.Model.YHB> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSGLXT.Model.YHB> DataTableToList(DataTable dt)
		{
			List<TSGLXT.Model.YHB> modelList = new List<TSGLXT.Model.YHB>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSGLXT.Model.YHB model;
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

