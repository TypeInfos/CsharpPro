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
    public partial class LoginForm : Form
    {

        public static string username;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                txtPassword.Focus();
                return;
            }
            if (cbx_select.Text == "用户")
            {
                if (txtIdentify.Text != identifying.Text.Replace(" ", ""))
                {
                    MessageBox.Show("请输入正确的验证码");
                    identifying.Text = MakeIdentifying();
                    return;
                }
                else
                {
                    if (BLLDB.YHB.CheckUser(txtUsername.Text, txtPassword.Text))
                    {

                        UserForm frm = new UserForm();
                        LoginForm.username = txtUsername.Text;
                        Program.Context.MainForm = frm;
                        this.Close();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("请输入正确的用户信息");
                    }
                }

            }
            else if (cbx_select.Text == "管理员")
            {
                if (txtIdentify.Text != identifying.Text.Replace(" ", ""))
                {
                    MessageBox.Show("请输入正确的验证码");
                    identifying.Text = MakeIdentifying();
                    return;
                }
                else
                {
                    if (BLLDB.GLB.CheckUser(txtUsername.Text, txtPassword.Text))
                    {
                        ADForm frm = new ADForm();
                        LoginForm.username = txtUsername.Text;
                        Program.Context.MainForm = frm;
                        this.Close();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("请输入正确的管理员账户信息");
                    }
                }
           
                
            }
            else
            {
                tooltip1.Show("请选择用户类别", cbx_select, 1000);
            }
        }
        private string MakeIdentifying()
        {
            int num = 0;
            char[] str = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c','d','e',
            'f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            Random r = new Random();
            string msg = null;
            while (true)
            {

                int rand = r.Next(0, 35);
                msg += str[rand];
                msg += " ";
                num++;
                if (num == 5)
                    break;
            }
            return msg;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            identifying.Text = MakeIdentifying();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
