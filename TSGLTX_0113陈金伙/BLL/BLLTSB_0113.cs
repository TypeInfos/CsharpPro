using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLTSB
	/// </summary>
	public partial class BLLTSB
	{
        public bool CheckISBNExist(string msg)
        {
            return this.GetModelList("BKISBN='" + msg + "'").Count != 0;
        }

        public bool CheckSKIDExist(string msg)
        {
            return this.GetModelList("SKID='" + msg + "'").Count != 0;
        }
	}
}

