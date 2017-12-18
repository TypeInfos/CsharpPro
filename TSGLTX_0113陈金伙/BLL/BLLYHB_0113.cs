using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSGLXT.Model;
namespace TSGLXT.BLL
{
	/// <summary>
	/// BLLYHB
	/// </summary>
	public partial class BLLYHB
	{
		public bool CheckUser(string username,string password)
        {
            YHB model = this.GetModel(username);
            if (model == null || model.password != password)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckYserExist(string msg)
        {
            return this.GetModelList("username='" + msg + "'").Count != 0;
        }
        public bool CheckPassword(string username,string password)
        {
            YHB model = this.GetModel(username);
            if (model.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}

