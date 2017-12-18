using System;
namespace TSGLXT.Model
{
	/// <summary>
	/// GLB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GLB
	{
		public GLB()
		{}
		#region Model
		private string _adyname;
		private string _adsex;
		private string _adusername;
		private string _skid;
		private string _adpassword;
		/// <summary>
		/// 
		/// </summary>
		public string ADYNAME
		{
			set{ _adyname=value;}
			get{return _adyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADSEX
		{
			set{ _adsex=value;}
			get{return _adsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ADUSERNAME
		{
			set{ _adusername=value;}
			get{return _adusername;}
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
		public string ADPASSWORD
		{
			set{ _adpassword=value;}
			get{return _adpassword;}
		}
		#endregion Model

	}
}

