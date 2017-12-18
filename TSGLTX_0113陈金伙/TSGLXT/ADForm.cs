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
    public partial class ADForm : Form
    {
        static bool glyinformation;
        static bool skform;
        static bool SKQuiry;
        static bool bookform;
        static bool dzform;
        public ADForm()
        {
            InitializeComponent();
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
        private void 管理员信息XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!glyinformation)
            {
                GLYInformation frm = new GLYInformation();
                frm.MdiParent = this;
                frm.Show();
                glyinformation = true;
            }
            else
            {
                ChildrenFormCheck("GLYInformation");
            }
            
        }

        private void ADForm_Load(object sender, EventArgs e)
        {
            toolLabel1.Text += LoginForm.username;
            glyinformation = false;
            skform = false;
            SKQuiry = false;
            bookform = false;
            dzform = false;
        }


        private void 书库管理SToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frmMdi = null;
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            switch (menu.Text)
            {
                case "书库管理(&S)":
                    if (!skform)
                    {
                        SKForm frm = new SKForm();
                        frm.MdiParent = this;
                        frm.Show();
                        skform = true;
                    }
                    else
                    {
                        ChildrenFormCheck("SKForm");
                    }
                    break;
                case "书库查询(&C)":
                    if (!SKQuiry)
                    {
                        frmMdi = new SKQuiry();
                        frmMdi.MdiParent = this;
                        frmMdi.Show();
                        SKQuiry = true;
                    }
                    else
                    {
                        string str = "SKQuiry";
                        ChildrenFormCheck(str);
                    }
                    break;
                case "图书管理(&T)":
                    if (!bookform)
                    {
                        frmMdi = new BookForm();
                        frmMdi.MdiParent = this;
                        frmMdi.Show();
                        bookform = true;
                    }
                    else
                    {
                        string str = "BookForm";
                        ChildrenFormCheck(str);
                    }
                    break;
                default:
                    break;
            }
        }

        private void 读者查询VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dzform)
            {
                DZForm frm = new DZForm();
                frm.MdiParent = this;
                frm.Show();
                dzform = true;
            }
            else
            {
                ChildrenFormCheck("DZForm");
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
