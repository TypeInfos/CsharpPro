using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TSGLXT.DAL
{
	/// <summary>
	/// 数据访问类:DALDZB
	/// </summary>
	public partial class DALDZB
	{
		public DALDZB()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DZID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DZB");
			strSql.Append(" where DZID=@DZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DZID", SqlDbType.VarChar,5)			};
			parameters[0].Value = DZID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSGLXT.Model.DZB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DZB(");
			strSql.Append("DZID,BKISBN,DZNAME,DZYEAR,DZDUTY,DZADDRESS)");
			strSql.Append(" values (");
			strSql.Append("@DZID,@BKISBN,@DZNAME,@DZYEAR,@DZDUTY,@DZADDRESS)");
			SqlParameter[] parameters = {
					new SqlParameter("@DZID", SqlDbType.VarChar,5),
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13),
					new SqlParameter("@DZNAME", SqlDbType.VarChar,15),
					new SqlParameter("@DZYEAR", SqlDbType.Int,4),
					new SqlParameter("@DZDUTY", SqlDbType.VarChar,20),
					new SqlParameter("@DZADDRESS", SqlDbType.VarChar,20)};
			parameters[0].Value = model.DZID;
			parameters[1].Value = model.BKISBN;
			parameters[2].Value = model.DZNAME;
			parameters[3].Value = model.DZYEAR;
			parameters[4].Value = model.DZDUTY;
			parameters[5].Value = model.DZADDRESS;

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
		public bool Update(TSGLXT.Model.DZB model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DZB set ");
			strSql.Append("BKISBN=@BKISBN,");
			strSql.Append("DZNAME=@DZNAME,");
			strSql.Append("DZYEAR=@DZYEAR,");
			strSql.Append("DZDUTY=@DZDUTY,");
			strSql.Append("DZADDRESS=@DZADDRESS");
			strSql.Append(" where DZID=@DZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BKISBN", SqlDbType.VarChar,13),
					new SqlParameter("@DZNAME", SqlDbType.VarChar,15),
					new SqlParameter("@DZYEAR", SqlDbType.Int,4),
					new SqlParameter("@DZDUTY", SqlDbType.VarChar,20),
					new SqlParameter("@DZADDRESS", SqlDbType.VarChar,20),
					new SqlParameter("@DZID", SqlDbType.VarChar,5)};
			parameters[0].Value = model.BKISBN;
			parameters[1].Value = model.DZNAME;
			parameters[2].Value = model.DZYEAR;
			parameters[3].Value = model.DZDUTY;
			parameters[4].Value = model.DZADDRESS;
			parameters[5].Value = model.DZID;

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
		public bool Delete(string DZID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DZB ");
			strSql.Append(" where DZID=@DZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DZID", SqlDbType.VarChar,5)			};
			parameters[0].Value = DZID;

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
		public bool DeleteList(string DZIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DZB ");
			strSql.Append(" where DZID in ("+DZIDlist + ")  ");
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
		public TSGLXT.Model.DZB GetModel(string DZID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DZID,BKISBN,DZNAME,DZYEAR,DZDUTY,DZADDRESS from DZB ");
			strSql.Append(" where DZID=@DZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DZID", SqlDbType.VarChar,5)			};
			parameters[0].Value = DZID;

			TSGLXT.Model.DZB model=new TSGLXT.Model.DZB();
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
		public TSGLXT.Model.DZB DataRowToModel(DataRow row)
		{
			TSGLXT.Model.DZB model=new TSGLXT.Model.DZB();
			if (row != null)
			{
				if(row["DZID"]!=null)
				{
					model.DZID=row["DZID"].ToString();
				}
				if(row["BKISBN"]!=null)
				{
					model.BKISBN=row["BKISBN"].ToString();
				}
				if(row["DZNAME"]!=null)
				{
					model.DZNAME=row["DZNAME"].ToString();
				}
				if(row["DZYEAR"]!=null && row["DZYEAR"].ToString()!="")
				{
					model.DZYEAR=int.Parse(row["DZYEAR"].ToString());
				}
				if(row["DZDUTY"]!=null)
				{
					model.DZDUTY=row["DZDUTY"].ToString();
				}
				if(row["DZADDRESS"]!=null)
				{
					model.DZADDRESS=row["DZADDRESS"].ToString();
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
			strSql.Append("select DZID,BKISBN,DZNAME,DZYEAR,DZDUTY,DZADDRESS ");
			strSql.Append(" FROM DZB ");
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
			strSql.Append(" DZID,BKISBN,DZNAME,DZYEAR,DZDUTY,DZADDRESS ");
			strSql.Append(" FROM DZB ");
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
			strSql.Append("select count(1) FROM DZB ");
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
				strSql.Append("order by T.DZID desc");
			}
			strSql.Append(")AS Row, T.*  from DZB T ");
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
			parameters[0].Value = "DZB";
			parameters[1].Value = "DZID";
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

