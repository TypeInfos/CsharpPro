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
    public partial class BookForm : Form
    {
        
        private void BindData(string msg)
        {
            dgvData.DataSource = BLLDB.SKB.GetViewModelList(msg);
        }
        private void ClearAll()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtISBN.Clear();
            txtAuthor.Clear();
            cbxSKID.SelectedIndex = -1;
            txtISBN.ReadOnly = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
        }
        public BookForm()
        {
            InitializeComponent();
        }
        
        private void BookForm_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            cbxSKID.DataSource = BLLDB.SKB.GetModelList("");
            cbxSKID.DisplayMember = "SKID";
            cbxSKID.ValueMember = "SKID";
            BindData("");
        }

        public bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtISBN.Text.Trim()))
            {
                tip1.Show("必须输入", txtISBN, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                tip1.Show("必须输入", txtName, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtAuthor.Text.Trim()))
            {
                tip1.Show("必须输入", txtAuthor, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                tip1.Show("必须输入", txtPrice, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxSKID.Text.Trim()))
            {
                tip1.Show("必须选择", cbxSKID, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                SKB model = (SKB)dgvData.SelectedRows[0].DataBoundItem;
                txtISBN.Text = model.bkisbn;
                txtName.Text = model.bkname;
                txtPrice.Text = model.bkprice;
                txtAuthor.Text = model.bkauthor;
                cbxSKID.Text = model.SKID;

                txtISBN.ReadOnly = true;
                btnAdd.Enabled = false;
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("确定要删除该记录吗?","删除提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (BLLDB.DZB.CheckISBNExist(txtISBN.Text))
                {
                    MessageBox.Show("这本书已有读者正在看，不能删除");
                }
                else
                {
                    if(BLLDB.TSB.Delete(txtISBN.Text) == true)
                    {
                        MessageBox.Show("删除成功");
                        BindData("");
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInput() && !BLLDB.TSB.CheckISBNExist(txtISBN.Text))
            {
                TSB model = new TSB()
                {
                    BKISBN = txtISBN.Text,
                    SKID = cbxSKID.Text,
                    BKAUTHOR = txtAuthor.Text,
                    BKPRICE = int.Parse(txtPrice.Text),
                    BKNAME = txtName.Text
                };
                if (BLLDB.TSB.Add(model) == true)
                {
                    MessageBox.Show("添加成功");
                    BindData("");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }
        private bool CheckISBN()
        {
            if (BLLDB.TSB.CheckISBNExist(txtISBN.Text))
            {
                txtISBN.Focus();
                tip1.Show("已有重复，情重新输入", txtISBN, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private bool CheckModelChanged()
        {

            if (dgvData.SelectedRows.Count == 1)
            {
                //TSB model = (TSB)dgvData.SelectedRows[0].DataBoundItem;
                //return model.BKNAME == txtName.Text &&
                //    model.BKAUTHOR == txtAuthor.Text &&
                //    model.BKPRICE == int.Parse(txtPrice.Text)
                //    && model.SKID == cbxSKID.Text;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (CheckInput() && CheckModelChanged())
            {
                TSB model = new TSB()
                {
                    BKISBN = txtISBN.Text,
                    BKNAME = txtName.Text,
                    BKAUTHOR = txtAuthor.Text,
                    BKPRICE = int.Parse(txtPrice.Text),
                    SKID = cbxSKID.Text
                };
                if (BLLDB.TSB.Update(model) == true)
                {
                    MessageBox.Show("更新成功");
                    BindData("");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }
    }
}
