using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSGLXT
{
    public partial class UserForm : Form
    {

        static bool manageuser;
        static bool changePassword;
        static bool borrowForm;

        public UserForm()
        {
            InitializeComponent();
        }

        private void 用户管理YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!manageuser)
            {
                ManageUser frm = new ManageUser();
                frm.MdiParent = this;
                frm.Show();
                manageuser = true;
            }
            else
            {
                string msg = "ManageUser";
                ChildrenFormCheck(msg);
            }
        }
        private void ChildrenFormCheck(string msg)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                if (childrenForm.Name == msg)
                {

                    childrenForm.Activate();
                }
            }
        }

        private void 修改密码XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!changePassword)
            {
                ChangePasswordForm frm = new ChangePasswordForm();
                frm.MdiParent = this;
                frm.Show();
                changePassword = true;
            }
            else
            {
                ChildrenFormCheck("ChangePasswordForm");
            }
        }


        private void UserForm_Load(object sender, EventArgs e)
        {
            toolLabel.Text += LoginForm.username;
            manageuser = false;
            changePassword = false;
            borrowForm = false;
        }

        private void 借书JToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!borrowForm)
            {
                BorrowForm frm = new BorrowForm();
                frm.MdiParent = this;
                frm.Show();
                borrowForm = true;
            }
            else
            {
                ChildrenFormCheck("BorrowForm");
            }
        }

        private void loginFormLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Program.Context.MainForm;
            LoginForm log = new LoginForm();
            Program.Context.MainForm = log;
            log.Show();
            frm.Close();
        }
    }
}
