using System;
namespace TSGLXT.Model
{
	/// <summary>
	/// SKB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SKB
	{
        //public string skid { get; set; }
        public string bkisbn { get; set; }
        public string bkname { get; set; }
        public string bkprice { get; set; }
        public string bkauthor { get; set; }
	}
}

