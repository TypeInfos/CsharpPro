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
    public partial class SKQuiry : Form
    {
        public SKQuiry()
        {
            InitializeComponent();
        }
        private void BindData(string msg)
        {
            dgvData.DataSource = BLLDB.SKB.GetViewModelList(msg);
        }
        private void SKQuiry_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            BindData("");
        }





        private void cbxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 1)
            {
                cbxSelect.DataSource = BLLDB.SKB.GetAddressModelList("");
                cbxSelect.DisplayMember = "SKADDRESS";
                cbxSelect.ValueMember = "SKADDRESS";
            }
            else if (cbxType.SelectedIndex == 0)
            {
                cbxSelect.DataSource = BLLDB.SKB.GetModelList("");
                cbxSelect.DisplayMember = "SKID";
                cbxSelect.ValueMember = "SKID";
            }
        }

        private void cbxSelect_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string txt = cbxSelect.Text;

            if (cbxType.SelectedIndex == 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append(" SKID=" + "'" + txt + "'");
                BindData(str.ToString());
            }
            else if (cbxType.SelectedIndex == 1)
            {
                StringBuilder str = new StringBuilder();
                str.Append(" SKADDRESS=" + "'" + txt + "'");
                BindData(str.ToString());
            }
        }
    }
}
