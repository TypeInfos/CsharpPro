using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TSGLXT.DAL
{
	/// <summary>
	/// 数据访问类:DALSKB
	/// </summary>
	public partial class DALSKB
	{
		public DALSKB()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SKID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SKB");
			strSql.Append(" where SKID=@SKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SKID", SqlDbType.VarChar,6)			};
			parameters[0].Value = SKID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.SKB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SKB(");
			strSql.Append("SKID,SKADDRESS,SKAREA,SKTELEPHONE)");
			strSql.Append(" values (");
			strSql.Append("@SKID,@SKADDRESS,@SKAREA,@SKTELEPHONE)");
			SqlParameter[] parameters = {
					new SqlParameter("@SKID", SqlDbType.VarChar,6),
					new SqlParameter("@SKADDRESS", SqlDbType.VarChar,20),
					new SqlParameter("@SKAREA", SqlDbType.VarChar,5),
					new SqlParameter("@SKTELEPHONE", SqlDbType.VarChar,11)};
			parameters[0].Value = model.SKID;
			parameters[1].Value = model.SKADDRESS;
			parameters[2].Value = model.SKAREA;
			parameters[3].Value = model.SKTELEPHONE;

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
		public bool Update(TSGLXT.Model.SKB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SKB set ");
			strSql.Append("SKADDRESS=@SKADDRESS,");
			strSql.Append("SKAREA=@SKAREA,");
			strSql.Append("SKTELEPHONE=@SKTELEPHONE");
			strSql.Append(" where SKID=@SKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SKADDRESS", SqlDbType.VarChar,20),
					new SqlParameter("@SKAREA", SqlDbType.VarChar,5),
					new SqlParameter("@SKTELEPHONE", SqlDbType.VarChar,11),
					new SqlParameter("@SKID", SqlDbType.VarChar,6)};
			parameters[0].Value = model.SKADDRESS;
			parameters[1].Value = model.SKAREA;
			parameters[2].Value = model.SKTELEPHONE;
			parameters[3].Value = model.SKID;

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
		public bool Delete(string SKID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SKB ");
			strSql.Append(" where SKID=@SKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SKID", SqlDbType.VarChar,6)			};
			parameters[0].Value = SKID;

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
		public bool DeleteList(string SKIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SKB ");
			strSql.Append(" where SKID in ("+SKIDlist + ")  ");
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
		public TSGLXT.Model.SKB GetModel(string SKID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SKID,SKADDRESS,SKAREA,SKTELEPHONE from SKB ");
			strSql.Append(" where SKID=@SKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SKID", SqlDbType.VarChar,6)			};
			parameters[0].Value = SKID;

			TSGLXT.Model.SKB model=new TSGLXT.Model.SKB();
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
		public TSGLXT.Model.SKB DataRowToModel(DataRow row)
		{
			TSGLXT.Model.SKB model=new TSGLXT.Model.SKB();
			if (row != null)
			{
				if(row["SKID"]!=null)
				{
					model.SKID=row["SKID"].ToString();
				}
				if(row["SKADDRESS"]!=null)
				{
					model.SKADDRESS=row["SKADDRESS"].ToString();
				}
				if(row["SKAREA"]!=null)
				{
					model.SKAREA=row["SKAREA"].ToString();
				}
				if(row["SKTELEPHONE"]!=null)
				{
					model.SKTELEPHONE=row["SKTELEPHONE"].ToString();
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
			strSql.Append("select SKID,SKADDRESS,SKAREA,SKTELEPHONE ");
			strSql.Append(" FROM SKB ");
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
			strSql.Append(" SKID,SKADDRESS,SKAREA,SKTELEPHONE ");
			strSql.Append(" FROM SKB ");
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
			strSql.Append("select count(1) FROM SKB ");
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
				strSql.Append("order by T.SKID desc");
			}
			strSql.Append(")AS Row, T.*  from SKB T ");
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
			parameters[0].Value = "SKB";
			parameters[1].Value = "SKID";
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

