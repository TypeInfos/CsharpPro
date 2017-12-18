using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using TSGLXT.BLL;
using TSGLXT.Model;
namespace TSGLXT
{
    public partial class DZForm : Form
    {
        static string ISBN = null;
        static string dzid = null;
        static bool flag;
        public DZForm()
        {
            InitializeComponent();
        }

        private void InitCBX()
        {
            for(int i = 16;i<60;i++)
            {
                txtYear.Items.Add(i);
            }
        }
        public void ClearAll()
        {
            txtYear.SelectedIndex = -1;
            txtDuty.SelectedIndex = -1;
            txtAddress.SelectedIndex = -1;
            txtName.Clear();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
        }
        private void BindData(string msg)
        {
            dgvData.DataSource = BLLDB.DZB.GetViewModelList(msg);


        }

        private void DZForm_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            flag = false;
            BindData("");
            InitCBX();
        }
        private void cbxDuty_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (flag)
            {
                string txt = cbxCX.Text;
                StringBuilder str = new StringBuilder();
                str.Append(" DZDUTY=" + "'" + txt + "'");
                BindData(str.ToString());
            }
            flag = true;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvData.SelectedRows.Count == 1)
            {
                DZB model = (DZB)dgvData.SelectedRows[0].DataBoundItem;
                txtName.Text = model.DZNAME;
                txtDuty.Text = model.DZDUTY;
                txtYear.Text = model.DZYEAR.ToString();
                txtAddress.Text = model.DZADDRESS;
                ISBN = model.BKISBN;
                dzid = model.DZID;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnModify.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.Focus();
                tip.Show("必须输入", txtName, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtDuty.Text.Trim()))
            {
                txtDuty.DroppedDown = true;
                tip.Show("必须选择", txtDuty, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtYear.Text.Trim()))
            {
                txtYear.DroppedDown = true;
                tip.Show("必须选择", txtYear, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                txtAddress.DroppedDown = true;
                tip.Show("必须选择", txtAddress, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInput() && ISBN != null)
            {
                string msg = MakeIdentifying();
                DZB model = new DZB()
                {

                    DZID = msg,
                    DZADDRESS = txtAddress.Text,
                    DZDUTY = txtDuty.Text,
                    DZNAME = txtName.Text,
                    DZYEAR = int.Parse(txtYear.Text),
                    BKISBN = ISBN
                };
                if (BLLDB.DZB.Add(model) == true)
                {
                    MessageBox.Show("添加纪录成功");
                    BindData("");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("添加纪录失败");
                }
            }  
        }
        private string MakeIdentifying()
        {
            int num = 0;
            char[] str = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
            };
            Random r = new Random();
            string msg = null;
            while (true)
            {

                int rand = r.Next(0, 10);
                msg += str[rand];
                num++;
                if (num == 5)
                    break;
            }
            return msg;
        }
        public bool CheckModelChanged()
        {

            if (dgvData.SelectedRows.Count == 1)
            {
                DZB model = (DZB)dgvData.SelectedRows[0].DataBoundItem;
                return model.DZADDRESS == txtAddress.Text &&
                    model.DZDUTY == txtDuty.Text &&
                    model.DZNAME == txtName.Text &&
                    model.DZYEAR == int.Parse(txtYear.Text);
            }
            else
            {
                return false;
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (CheckInput() && !CheckModelChanged())
            {
                DZB model = new DZB()
                { 
                    BKISBN = ISBN,
                    
                    DZID = dzid,
                    DZNAME = txtName.Text,
                    DZYEAR = int.Parse(txtYear.Text),
                    DZDUTY = txtDuty.Text,
                    DZADDRESS = txtAddress.Text
                };
                if (BLLDB.DZB.Update(model) == true)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定要删除这条记录吗", "删除提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (BLLDB.DZB.Delete(dzid) == true)
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

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 0)
            {
                cbxSelect.DataSource = BLLDB.DZB.GetAddressModelList("");
                cbxSelect.DisplayMember = "DZADDRESS";
                cbxSelect.ValueMember = "DZADDRESS";
            }
            else if (cbxType.SelectedIndex == 1)
            {
                cbxSelect.DataSource = BLLDB.DZB.GetNameModelList("");
                cbxSelect.DisplayMember = "DZNAME";
                cbxSelect.ValueMember = "DZNAME";
            }
        }

        private void cbxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = cbxSelect.Text;

            if (cbxType.SelectedIndex == 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append(" DZADDRESS=" + "'" + txt + "'");
                BindData(str.ToString());
            }
            else if (cbxType.SelectedIndex == 1)
            {
                StringBuilder str = new StringBuilder();
                str.Append(" DZNAME=" + "'" + txt + "'");
                BindData(str.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbxSelect.SelectedIndex = -1;
            cbxType.SelectedIndex = -1;
            BindData("");
            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cbxCX.SelectedIndex == 0)
            {


                dgvData.DataSource = BLLDB.DZB.GetNameList("", txtQuery.Text,cbxCX.SelectedIndex);
 
            }
            else if (cbxCX.SelectedIndex == 1)
            {
                dgvData.DataSource = BLLDB.DZB.GetNameList("", txtQuery.Text, cbxCX.SelectedIndex);
            }
            else if (cbxCX.SelectedIndex == 2)
            {
                dgvData.DataSource = BLLDB.DZB.GetNameList("", txtQuery.Text, cbxCX.SelectedIndex);
            }
            
            
        }
        
    }
}
