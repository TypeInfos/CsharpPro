using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TSGLXT.DAL
{
	/// <summary>
	/// 数据访问类:DALTSB
	/// </summary>
	public partial class DALTSB
	{
		public DALTSB()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BKISBN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TSB");
			strSql.Append(" where BKISBN=@BKISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13)			};
			parameters[0].Value = BKISBN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.TSB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TSB(");
			strSql.Append("BKISBN,SKID,BKNAME,BKPRICE,BKAUTHOR)");
			strSql.Append(" values (");
			strSql.Append("@BKISBN,@SKID,@BKNAME,@BKPRICE,@BKAUTHOR)");
			SqlParameter[] parameters = {
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13),
					new SqlParameter("@SKID", SqlDbType.VarChar,6),
					new SqlParameter("@BKNAME", SqlDbType.VarChar,20),
					new SqlParameter("@BKPRICE", SqlDbType.Int,4),
					new SqlParameter("@BKAUTHOR", SqlDbType.VarChar,20)};
			parameters[0].Value = model.BKISBN;
			parameters[1].Value = model.SKID;
			parameters[2].Value = model.BKNAME;
			parameters[3].Value = model.BKPRICE;
			parameters[4].Value = model.BKAUTHOR;

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
		public bool Update(TSGLXT.Model.TSB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TSB set ");
			strSql.Append("SKID=@SKID,");
			strSql.Append("BKNAME=@BKNAME,");
			strSql.Append("BKPRICE=@BKPRICE,");
			strSql.Append("BKAUTHOR=@BKAUTHOR");
			strSql.Append(" where BKISBN=@BKISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SKID", SqlDbType.VarChar,6),
					new SqlParameter("@BKNAME", SqlDbType.VarChar,20),
					new SqlParameter("@BKPRICE", SqlDbType.Int,4),
					new SqlParameter("@BKAUTHOR", SqlDbType.VarChar,20),
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13)};
			parameters[0].Value = model.SKID;
			parameters[1].Value = model.BKNAME;
			parameters[2].Value = model.BKPRICE;
			parameters[3].Value = model.BKAUTHOR;
			parameters[4].Value = model.BKISBN;

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
		public bool Delete(string BKISBN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TSB ");
			strSql.Append(" where BKISBN=@BKISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13)			};
			parameters[0].Value = BKISBN;

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
		public bool DeleteList(string BKISBNlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TSB ");
			strSql.Append(" where BKISBN in ("+BKISBNlist + ")  ");
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
		public TSGLXT.Model.TSB GetModel(string BKISBN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BKISBN,SKID,BKNAME,BKPRICE,BKAUTHOR from TSB ");
			strSql.Append(" where BKISBN=@BKISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13)			};
			parameters[0].Value = BKISBN;

			TSGLXT.Model.TSB model=new TSGLXT.Model.TSB();
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
		public TSGLXT.Model.TSB DataRowToModel(DataRow row)
		{
			TSGLXT.Model.TSB model=new TSGLXT.Model.TSB();
			if (row != null)
			{
				if(row["BKISBN"]!=null)
				{
					model.BKISBN=row["BKISBN"].ToString();
				}
				if(row["SKID"]!=null)
				{
					model.SKID=row["SKID"].ToString();
				}
				if(row["BKNAME"]!=null)
				{
					model.BKNAME=row["BKNAME"].ToString();
				}
				if(row["BKPRICE"]!=null && row["BKPRICE"].ToString()!="")
				{
					model.BKPRICE=int.Parse(row["BKPRICE"].ToString());
				}
				if(row["BKAUTHOR"]!=null)
				{
					model.BKAUTHOR=row["BKAUTHOR"].ToString();
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
			strSql.Append("select BKISBN,SKID,BKNAME,BKPRICE,BKAUTHOR ");
			strSql.Append(" FROM TSB ");
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
			strSql.Append(" BKISBN,SKID,BKNAME,BKPRICE,BKAUTHOR ");
			strSql.Append(" FROM TSB ");
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
			strSql.Append("select count(1) FROM TSB ");
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
				strSql.Append("order by T.BKISBN desc");
			}
			strSql.Append(")AS Row, T.*  from TSB T ");
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
			parameters[0].Value = "TSB";
			parameters[1].Value = "BKISBN";
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

