using System;
namespace TSGLXT.Model
{
	/// <summary>
	/// DZB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DZB
	{
		public DZB()
		{}
		#region Model
		private string _dzid;
		private string _bkisbn;
		private string _dzname;
		private int? _dzyear;
		private string _dzduty;
		private string _dzaddress;
		/// <summary>
		/// 
		/// </summary>
		public string DZID
		{
			set{ _dzid=value;}
			get{return _dzid;}
		}
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
		public string DZNAME
		{
			set{ _dzname=value;}
			get{return _dzname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DZYEAR
		{
			set{ _dzyear=value;}
			get{return _dzyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DZDUTY
		{
			set{ _dzduty=value;}
			get{return _dzduty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DZADDRESS
		{
			set{ _dzaddress=value;}
			get{return _dzaddress;}
		}
		#endregion Model

	}
}

