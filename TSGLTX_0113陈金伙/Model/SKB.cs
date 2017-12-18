using System;
namespace TSGLXT.Model
{
	/// <summary>
	/// SKB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	
	public partial class SKB
	{
		public SKB()
		{}
		#region Model
		private string _skid;
		private string _skaddress;
		private string _skarea;
		private string _sktelephone;
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
		public string SKADDRESS
		{
			set{ _skaddress=value;}
			get{return _skaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SKAREA
		{
			set{ _skarea=value;}
			get{return _skarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SKTELEPHONE
		{
			set{ _sktelephone=value;}
			get{return _sktelephone;}
		}
		#endregion Model

	}
}

