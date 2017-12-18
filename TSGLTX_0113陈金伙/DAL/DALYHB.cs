﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TSGLXT.DAL
{
	/// <summary>
	/// 数据访问类:DALYHB
	/// </summary>
	public partial class DALYHB
	{
		public DALYHB()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string username)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YHB");
			strSql.Append(" where username=@username ");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,10)			};
			parameters[0].Value = username;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.YHB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YHB(");
			strSql.Append("username,password)");
			strSql.Append(" values (");
			strSql.Append("@username,@password)");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,10),
					new SqlParameter("@password", SqlDbType.VarChar,10)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;

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
		public bool Update(TSGLXT.Model.YHB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YHB set ");
			strSql.Append("password=@password");
			strSql.Append(" where username=@username ");
			SqlParameter[] parameters = {
					new SqlParameter("@password", SqlDbType.VarChar,10),
					new SqlParameter("@username", SqlDbType.VarChar,10)};
			parameters[0].Value = model.password;
			parameters[1].Value = model.username;

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
		public bool Delete(string username)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YHB ");
			strSql.Append(" where username=@username ");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,10)			};
			parameters[0].Value = username;

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
		public bool DeleteList(string usernamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YHB ");
			strSql.Append(" where username in ("+usernamelist + ")  ");
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
		public TSGLXT.Model.YHB GetModel(string username)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 username,password from YHB ");
			strSql.Append(" where username=@username ");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,10)			};
			parameters[0].Value = username;

			TSGLXT.Model.YHB model=new TSGLXT.Model.YHB();
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
		public TSGLXT.Model.YHB DataRowToModel(DataRow row)
		{
			TSGLXT.Model.YHB model=new TSGLXT.Model.YHB();
			if (row != null)
			{
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
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
			strSql.Append("select username,password ");
			strSql.Append(" FROM YHB ");
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
			strSql.Append(" username,password ");
			strSql.Append(" FROM YHB ");
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
			strSql.Append("select count(1) FROM YHB ");
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
				strSql.Append("order by T.username desc");
			}
			strSql.Append(")AS Row, T.*  from YHB T ");
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
			parameters[0].Value = "YHB";
			parameters[1].Value = "username";
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

