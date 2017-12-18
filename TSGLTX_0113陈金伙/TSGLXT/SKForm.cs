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
    public partial class SKForm : Form
    {
        public SKForm()
        {
            InitializeComponent();
        }
        private void BindData()
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = BLLDB.SKB.GetModelList("");
            
        }
        
        private void ClearInput()
        {
            cbxAdress.SelectedIndex = -1;
            txtArea.Clear();
            txtID.Clear();
            txtTelephone.Clear();

            btnAdd.Enabled = true;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            txtID.ReadOnly = false;
            txtID.Focus();
        }
        private bool CheckScanf()
        {
            if (string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                txtID.Focus();
                tip1.Show("必须输入", txtID, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtArea.Text.Trim()))
            {
                txtArea.Focus();
                tip1.Show("必须输入", txtArea, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtTelephone.Text.Trim()))
            {
                txtTelephone.Focus();
                tip1.Show("必须输入", txtTelephone, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxAdress.Text.Trim()))
            {
                cbxAdress.DroppedDown = true;
                tip1.Show("必须选择", cbxAdress, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckModelChanged()
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                SKB model = (SKB)dgvData.SelectedRows[0].DataBoundItem;
                return model.SKADDRESS == cbxAdress.Text &&
                    model.SKAREA == txtArea.Text &&
                    model.SKTELEPHONE == txtTelephone.Text;
            }
            else
            {
                return false;
            }
        }
        private bool CheckSKID()
        {
            if (BLLDB.SKB.CheckSKIDExist(txtID.Text))
            {
                txtID.Focus();
                tip1.Show("该编号已存在", txtID, 1000);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckScanf() && !CheckSKID())
            {
                SKB model = new SKB()
                {
                    SKID = txtID.Text,
                    SKAREA = txtArea.Text,
                    SKTELEPHONE = txtTelephone.Text,
                    SKADDRESS = cbxAdress.Text
                };
                if (BLLDB.SKB.Add(model) == true)
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                SKB model = (SKB)dgvData.SelectedRows[0].DataBoundItem;
                txtArea.Text = model.SKAREA;
                txtID.Text = model.SKID;
                txtTelephone.Text = model.SKTELEPHONE;
                cbxAdress.Text = model.SKADDRESS;

                btnAdd.Enabled = false;
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
                txtID.ReadOnly = true;
            }
        }

        private void SKForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (CheckScanf() && !CheckModelChanged())
            {
                SKB model = new SKB()
                {
                    SKID = txtID.Text,
                    SKAREA = txtArea.Text,
                    SKTELEPHONE = txtTelephone.Text,
                    SKADDRESS = cbxAdress.Text
                };
                if(BLLDB.SKB.Update(model) == true)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定要删除该记录吗?","删除提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                if (BLLDB.GLB.CheckSKIDExist(txtID.Text) || BLLDB.TSB.CheckSKIDExist(txtID.Text))
                {
                    MessageBox.Show("该书库号与管理员和图书有联系，不能删除");
                    
                }
                else
                {
                    if (BLLDB.SKB.Delete(txtID.Text) == true)
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
    }
}
