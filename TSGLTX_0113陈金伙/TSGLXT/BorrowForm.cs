using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSGLXT.BLL;
using TSGLXT.Model;
namespace TSGLXT
{
    public partial class BorrowForm : Form
    {
        static string ISBN = null;
        
        public BorrowForm()
        {
            InitializeComponent();
        }
        private void InitCBX()
        {
            for (int i = 16; i< 60;i++)
            {
                cbxYear.Items.Add(i);
            }
        }
        private void BindData()
        {
            dgvData.DataSource = BLLDB.TSB.GetModelList("");
        }
        private void BorrowForm_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            InitCBX();
            BindData();
            cbxWork.SelectedIndex = 0;
            
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                TSB model = (TSB)dgvData.SelectedRows[0].DataBoundItem;
                ISBN = model.BKISBN;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.Focus();
                tip.Show("必须输入", txtName, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxAddress.Text))
            {
                cbxAddress.DroppedDown = true;
                tip.Show("必须选择", cbxAddress, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxWork.Text.Trim()))
            {
                cbxWork.DroppedDown = true;
                tip.Show("必须选择", cbxWork, 1000);
                return false;
            }
            else if (string.IsNullOrEmpty(cbxYear.Text.Trim()))
            {
                cbxYear.DroppedDown = true;
                tip.Show("必须选择", cbxYear, 1000);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void borrow_Click(object sender, EventArgs e)
        {
            
            
            if (CheckInput() && ISBN != null)
            {
                string msg = MakeIdentifying();
                DZB model = new DZB()
                {
                    
                    DZID = msg,
                    DZADDRESS = cbxAddress.Text,
                    DZDUTY = cbxWork.Text,
                    DZNAME = txtName.Text,
                    DZYEAR = int.Parse(cbxYear.Text),
                    BKISBN = ISBN
                };
                if (BLLDB.DZB.Add(model) == true)
                {
                    MessageBox.Show("借书成功");
                }
                else
                {
                    MessageBox.Show("借书失败");
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
    }
}
