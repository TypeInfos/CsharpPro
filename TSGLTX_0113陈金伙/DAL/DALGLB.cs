using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TSGLXT.DAL
{
	/// <summary>
	/// 数据访问类:DALGLB
	/// </summary>
	public partial class DALGLB
	{
		public DALGLB()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ADUSERNAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GLB");
			strSql.Append(" where ADUSERNAME=@ADUSERNAME ");
			SqlParameter[] parameters = {
					new SqlParameter("@ADUSERNAME", SqlDbType.VarChar,10)			};
			parameters[0].Value = ADUSERNAME;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.GLB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GLB(");
			strSql.Append("ADYNAME,ADSEX,ADUSERNAME,SKID,ADPASSWORD)");
			strSql.Append(" values (");
			strSql.Append("@ADYNAME,@ADSEX,@ADUSERNAME,@SKID,@ADPASSWORD)");
			SqlParameter[] parameters = {
					new SqlParameter("@ADYNAME", SqlDbType.VarChar,10),
					new SqlParameter("@ADSEX", SqlDbType.VarChar,2),
					new SqlParameter("@ADUSERNAME", SqlDbType.VarChar,10),
					new SqlParameter("@SKID", SqlDbType.VarChar,6),
					new SqlParameter("@ADPASSWORD", SqlDbType.VarChar,10)};
			parameters[0].Value = model.ADYNAME;
			parameters[1].Value = model.ADSEX;
			parameters[2].Value = model.ADUSERNAME;
			parameters[3].Value = model.SKID;
			parameters[4].Value = model.ADPASSWORD;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TSGLXT.Model.GLB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GLB set ");
			strSql.Append("ADYNAME=@ADYNAME,");
			strSql.Append("ADSEX=@ADSEX,");
			strSql.Append("SKID=@SKID,");
			strSql.Append("ADPASSWORD=@ADPASSWORD");
			strSql.Append(" where ADUSERNAME=@ADUSERNAME ");
			SqlParameter[] parameters = {
					new SqlParameter("@ADYNAME", SqlDbType.VarChar,10),
					new SqlParameter("@ADSEX", SqlDbType.VarChar,2),
					new SqlParameter("@SKID", SqlDbType.VarChar,6),
					new SqlParameter("@ADPASSWORD", SqlDbType.VarChar,10),
					new SqlParameter("@ADUSERNAME", SqlDbType.VarChar,10)};
			parameters[0].Value = model.ADYNAME;
			parameters[1].Value = model.ADSEX;
			parameters[2].Value = model.SKID;
			parameters[3].Value = model.ADPASSWORD;
			parameters[4].Value = model.ADUSERNAME;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ADUSERNAME)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GLB ");
			strSql.Append(" where ADUSERNAME=@ADUSERNAME ");
			SqlParameter[] parameters = {
					new SqlParameter("@ADUSERNAME", SqlDbType.VarChar,10)			};
			parameters[0].Value = ADUSERNAME;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ADUSERNAMElist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GLB ");
			strSql.Append(" where ADUSERNAME in ("+ADUSERNAMElist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSGLXT.Model.GLB GetModel(string ADUSERNAME)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ADYNAME,ADSEX,ADUSERNAME,SKID,ADPASSWORD from GLB ");
			strSql.Append(" where ADUSERNAME=@ADUSERNAME ");
			SqlParameter[] parameters = {
					new SqlParameter("@ADUSERNAME", SqlDbType.VarChar,10)			};
			parameters[0].Value = ADUSERNAME;

			TSGLXT.Model.GLB model=new TSGLXT.Model.GLB();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSGLXT.Model.GLB DataRowToModel(DataRow row)
		{
			TSGLXT.Model.GLB model=new TSGLXT.Model.GLB();
			if (row != null)
			{
				if(row["ADYNAME"]!=null)
				{
					model.ADYNAME=row["ADYNAME"].ToString();
				}
				if(row["ADSEX"]!=null)
				{
					model.ADSEX=row["ADSEX"].ToString();
				}
				if(row["ADUSERNAME"]!=null)
				{
					model.ADUSERNAME=row["ADUSERNAME"].ToString();
				}
				if(row["SKID"]!=null)
				{
					model.SKID=row["SKID"].ToString();
				}
				if(row["ADPASSWORD"]!=null)
				{
					model.ADPASSWORD=row["ADPASSWORD"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ADYNAME,ADSEX,ADUSERNAME,SKID,ADPASSWORD ");
			strSql.Append(" FROM GLB ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ADYNAME,ADSEX,ADUSERNAME,SKID,ADPASSWORD ");
			strSql.Append(" FROM GLB ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM GLB ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ADUSERNAME desc");
			}
			strSql.Append(")AS Row, T.*  from GLB T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "GLB";
			parameters[1].Value = "ADUSERNAME";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

