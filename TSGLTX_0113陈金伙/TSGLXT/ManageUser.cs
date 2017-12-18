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
using Microsoft.VisualBasic;
namespace TSGLXT
{
    public partial class ManageUser : Form
    {
        private void BindData()
        {
            dgvData.DataSource = BLLDB.YHB.GetModelList("");
        }
        private void ClearInput()
        {
            txtUser.Clear();

            btnAdd.Enabled = true;
            btnCZ.Enabled = false;
            btnDelete.Enabled = false;

            txtUser.Focus();
        }
        public ManageUser()
        {
            InitializeComponent();
        }
        private bool CheckModelExist()
        {
            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                txtUser.Focus();
                tip.Show("必须输入", txtUser, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckModelExist() && !BLLDB.YHB.CheckYserExist(txtUser.Text))
            {
                string pd = Interaction.InputBox("请输入密码", "输入密码", "", -1, -1);

                YHB model = new YHB()
                {
                    username = txtUser.Text,
                    password = pd
                };
                if (BLLDB.YHB.Add(model) == true)
                {
                    MessageBox.Show("添加成功");
                    BindData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }

        private void btnCZ_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要重置账户密码吗?", "删除提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                YHB model = new YHB()
                {
                    username = txtUser.Text,
                    password = "666"
                };
                if (txtUser.Text == LoginForm.username)
                {
                    if (BLLDB.YHB.Update(model) == true)
                    {
                        MessageBox.Show("重置当前账户密码成功,密码为666,请重新登录");
                        Form frm = Program.Context.MainForm;
                        LoginForm log = new LoginForm();
                        Program.Context.MainForm = log;
                        log.Show();
                        frm.Close();
                    }
                    else
                    {
                        MessageBox.Show("重置密码失败");
                    }
                }
                else
                {
                    if (BLLDB.YHB.Update(model) == true)
                    {
                        MessageBox.Show("重置密码成功,密码为666,");
                    }
                    else
                    {
                        MessageBox.Show("重置密码失败");
                    }
                }
               

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        
            if (MessageBox.Show("确定要删除当前账户吗?", "删除提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (LoginForm.username == txtUser.Text)
                {
                    MessageBox.Show("不能删除正在登录的账户");
                }
                else
                {
                    if (BLLDB.YHB.Delete(txtUser.Text) == true)
                    {
                        MessageBox.Show("删除成功");
                        BindData();
                        ClearInput();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            BindData();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                YHB model = (YHB)dgvData.SelectedRows[0].DataBoundItem;
                txtUser.Text = model.username;

                btnDelete.Enabled = true;
                btnCZ.Enabled = true;
                btnAdd.Enabled = false;
            }
        }
        
    }
}
