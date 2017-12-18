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
		private readonly TSGLXT.DAL.DALGLB dal=new TSGLXT.DAL.DALGLB();
		public BLLGLB()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ADUSERNAME)
		{
			return dal.Exists(ADUSERNAME);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.GLB model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TSGLXT.Model.GLB model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ADUSERNAME)
		{
			
			return dal.Delete(ADUSERNAME);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ADUSERNAMElist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(ADUSERNAMElist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSGLXT.Model.GLB GetModel(string ADUSERNAME)
		{
			
			return dal.GetModel(ADUSERNAME);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public TSGLXT.Model.GLB GetModelByCache(string ADUSERNAME)
		{
			
			string CacheKey = "GLBModel-" + ADUSERNAME;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ADUSERNAME);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSGLXT.Model.GLB)objModel;
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
		public List<TSGLXT.Model.GLB> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSGLXT.Model.GLB> DataTableToList(DataTable dt)
		{
			List<TSGLXT.Model.GLB> modelList = new List<TSGLXT.Model.GLB>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSGLXT.Model.GLB model;
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

