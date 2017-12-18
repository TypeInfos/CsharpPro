using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSGLXT.Model;
using TSGLXT.BLL;
namespace TSGLXT
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }
        private void ClearAll()
        {
            oldPassword.Clear();
            newPassowrd.Clear();
            ConfirmPassword.Clear();
        }
        private bool CheckConfirmPassword()
        {
            if (newPassowrd.Text == ConfirmPassword.Text && newPassowrd.Text != oldPassword.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(oldPassword.Text.Trim()))
            {
                oldPassword.Focus();
                tip.Show("必须输入", oldPassword, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(newPassowrd.Text.Trim()))
            {
                newPassowrd.Focus();
                tip.Show("必须输入", newPassowrd, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(ConfirmPassword.Text.Trim()))
            {
                ConfirmPassword.Focus();
                tip.Show("必须输入", ConfirmPassword, 1000);
                return false;
            }
            else
            {
                return true;
            }

        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
               if (CheckInput() && BLLDB.YHB.CheckPassword(LoginForm.username,oldPassword.Text)&&
                   CheckConfirmPassword())
               {
                   YHB model = new YHB()
                   {
                       username = LoginForm.username,
                       password = newPassowrd.Text
                   };
                   if (BLLDB.YHB.Update(model) == true)
                   {
                       MessageBox.Show("成功更改,请重新登录");
                       Form frm = Program.Context.MainForm;
                       LoginForm log = new LoginForm();
                       Program.Context.MainForm = log;
                       log.Show();
                       frm.Close();
                       
                       
                   }
                   else
                   {
                       MessageBox.Show("更改失败");
                   }
               }
            else
               {
                   MessageBox.Show("你的输入有误");
               }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
