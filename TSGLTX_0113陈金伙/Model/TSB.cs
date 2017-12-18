using System;
namespace TSGLXT.Model
{
	/// <summary>
	/// TSB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TSB
	{
		public TSB()
		{}
		#region Model
		private string _bkisbn;
		private string _skid;
		private string _bkname;
		private int? _bkprice;
		private string _bkauthor;
		/// <summary>
		/// 
		/// </summary>
		public string BKISBN
		{
			set{ _bkisbn=value;}
			get{return _bkisbn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SKID
		{
			set{ _skid=value;}
			get{return _skid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BKNAME
		{
			set{ _bkname=value;}
			get{return _bkname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BKPRICE
		{
			set{ _bkprice=value;}
			get{return _bkprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BKAUTHOR
		{
			set{ _bkauthor=value;}
			get{return _bkauthor;}
		}
		#endregion Model

	}
}

