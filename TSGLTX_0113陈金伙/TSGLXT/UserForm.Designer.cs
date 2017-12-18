namespace TSGLXT
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.账户管理ZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借书读书SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借书JToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回主页面QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginFormLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.账户管理ZToolStripMenuItem,
            this.借书读书SToolStripMenuItem,
            this.返回主页面QToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 账户管理ZToolStripMenuItem
            // 
            this.账户管理ZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理YToolStripMenuItem,
            this.修改密码XToolStripMenuItem});
            this.账户管理ZToolStripMenuItem.Name = "账户管理ZToolStripMenuItem";
            this.账户管理ZToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            this.账户管理ZToolStripMenuItem.Text = "账户管理(Z)";
            // 
            // 用户管理YToolStripMenuItem
            // 
            this.用户管理YToolStripMenuItem.Name = "用户管理YToolStripMenuItem";
            this.用户管理YToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.用户管理YToolStripMenuItem.Text = "用户管理(Y)";
            this.用户管理YToolStripMenuItem.Click += new System.EventHandler(this.用户管理YToolStripMenuItem_Click);
            // 
            // 修改密码XToolStripMenuItem
            // 
            this.修改密码XToolStripMenuItem.Name = "修改密码XToolStripMenuItem";
            this.修改密码XToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.修改密码XToolStripMenuItem.Text = "修改密码(X)";
            this.修改密码XToolStripMenuItem.Click += new System.EventHandler(this.修改密码XToolStripMenuItem_Click);
            // 
            // 借书读书SToolStripMenuItem
            // 
            this.借书读书SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借书JToolStripMenuItem});
            this.借书读书SToolStripMenuItem.Name = "借书读书SToolStripMenuItem";
            this.借书读书SToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.借书读书SToolStripMenuItem.Text = "借书读书(&S)";
            // 
            // 借书JToolStripMenuItem
            // 
            this.借书JToolStripMenuItem.Name = "借书JToolStripMenuItem";
            this.借书JToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.借书JToolStripMenuItem.Text = "借书(&J)";
            this.借书JToolStripMenuItem.Click += new System.EventHandler(this.借书JToolStripMenuItem_Click);
            // 
            // 返回主页面QToolStripMenuItem
            // 
            this.返回主页面QToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginFormLToolStripMenuItem});
            this.返回主页面QToolStripMenuItem.Name = "返回主页面QToolStripMenuItem";
            this.返回主页面QToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.返回主页面QToolStripMenuItem.Text = "返回主页面(&Q)";
            // 
            // loginFormLToolStripMenuItem
            // 
            this.loginFormLToolStripMenuItem.Name = "loginFormLToolStripMenuItem";
            this.loginFormLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loginFormLToolStripMenuItem.Size = new System.Drawing.Size(270, 30);
            this.loginFormLToolStripMenuItem.Text = "LoginForm(&L)";
            this.loginFormLToolStripMenuItem.Click += new System.EventHandler(this.loginFormLToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 33);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolLabel
            // 
            this.toolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolLabel.Name = "toolLabel";
            this.toolLabel.Size = new System.Drawing.Size(144, 28);
            this.toolLabel.Text = "当前读者用户:";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 549);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 账户管理ZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理YToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借书读书SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借书JToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码XToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel;
        private System.Windows.Forms.ToolStripMenuItem 返回主页面QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginFormLToolStripMenuItem;
    }
}