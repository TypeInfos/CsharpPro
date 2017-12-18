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
    public partial class GLYInformation : Form
    {
        
        public GLYInformation()
        {
            InitializeComponent();
        }
        private void InitCBX()
        {
            cbxSKID.DataSource = BLLDB.SKB.GetModelList("");
            cbxSKID.DisplayMember = "SKID";
            cbxSKID.ValueMember = "SKID";
        }
        private void BindData()
        {
            dgvData.DataSource = BLLDB.GLB.GetViewModelList("");
            
        }

        private void ClearInput()
        {
            txtName.Clear();
            cbxSKID.SelectedIndex = -1;
            txtUSER.Clear();
            cbxSex.SelectedIndex = -1;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnDelete.Enabled = false;
            txtUSER.ReadOnly = false;
            txtName.Focus();
        }
        private bool CheckUserInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.Focus();
                tip.Show("必须输入", txtName, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtUSER.Text.Trim()))
            {
                txtUSER.Focus();
                tip.Show("必须输入", txtUSER, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxSex.Text.Trim()))
            {
                cbxSex.DroppedDown = true;
                tip.Show("必须选择", cbxSex, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxSKID.Text.Trim()))
            {
                cbxSKID.DroppedDown = true;
                tip.Show("必须选择", cbxSKID, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void GLYInformation_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            BindData();
            InitCBX();
            
        }
        private void SelectedSex(string str)
        {

            if (str == "男")
            {
                cbxSex.SelectedIndex = 0;
            }
            else if (str == "女")
            {
                cbxSex.SelectedIndex = 1;
            }
            else
            {
                cbxSex.SelectedIndex = 2;
            }
                      
        }
        private bool CheckModelChanged()
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                GLB model = (GLB)dgvData.SelectedRows[0].DataBoundItem;
                return model.ADYNAME == txtName.Text &&
                    model.ADSEX == cbxSex.Text &&
                    model.SKID == cbxSKID.Text;
            }
            else
            {
                return false;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                GLB model = (GLB)dgvData.SelectedRows[0].DataBoundItem;
                txtName.Text = model.ADYNAME;
                txtUSER.Text = model.ADUSERNAME;

                SelectedSex(model.ADSEX);
                cbxSKID.Text = model.SKID;

                txtUSER.ReadOnly = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckUserInput() && !BLLDB.GLB.CheckADNAME(txtUSER.Text))
            {
                string pd = Interaction.InputBox("请输入密码", "输入密码", "", -1, -1);

                GLB model = new GLB()
                {
                    SKID = cbxSKID.Text,
                    ADSEX = cbxSex.Text,
                    ADPASSWORD = pd,
                    ADUSERNAME = txtUSER.Text,
                    ADYNAME = txtName.Text
                };
                if (BLLDB.GLB.Add(model) == true)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (CheckUserInput() && !CheckModelChanged())
            {
                
                GLB model = new GLB()
                {
                    SKID = cbxSKID.Text,
                    ADSEX = cbxSex.Text,
                    ADUSERNAME = txtUSER.Text,
                    ADYNAME = txtName.Text,
                    ADPASSWORD = BLLDB.GLB.GetPassword(txtUSER.Text)
                };
                if (BLLDB.GLB.Update(model) == true)
                {
                    MessageBox.Show("更新成功");
                    BindData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }
        private bool CheckUsed(string msg)
        {
            if (msg == LoginForm.username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗?", "删除提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (CheckUsed(txtUSER.Text))
                {
                    MessageBox.Show("当前管理员账户正在使用中,不能删除");
                }
                else
                {
                    if (BLLDB.GLB.Delete(txtUSER.Text))
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

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
