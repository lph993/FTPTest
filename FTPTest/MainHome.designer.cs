namespace FTPTest
{
    partial class MainHome
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainHome));
            this.startConBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoBtn = new System.Windows.Forms.Button();
            this.pwdTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userTb = new System.Windows.Forms.TextBox();
            this.serverTb = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.aliveBtn = new System.Windows.Forms.Button();
            this.passiveBtn = new System.Windows.Forms.Button();
            this.fileInfoMode = new System.Windows.Forms.Button();
            this.utf8Btn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.fileBtn = new System.Windows.Forms.Button();
            this.filePathTb = new System.Windows.Forms.TextBox();
            this.fileList = new System.Windows.Forms.ListView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.创建文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mi1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pathList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // startConBtn
            // 
            this.startConBtn.Location = new System.Drawing.Point(594, 9);
            this.startConBtn.Name = "startConBtn";
            this.startConBtn.Size = new System.Drawing.Size(61, 23);
            this.startConBtn.TabIndex = 4;
            this.startConBtn.Text = "连  接";
            this.startConBtn.UseVisualStyleBackColor = true;
            this.startConBtn.Click += new System.EventHandler(this.StartConBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infoBtn);
            this.panel1.Controls.Add(this.pwdTb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.userTb);
            this.panel1.Controls.Add(this.serverTb);
            this.panel1.Controls.Add(this.startConBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 41);
            this.panel1.TabIndex = 2;
            // 
            // infoBtn
            // 
            this.infoBtn.Location = new System.Drawing.Point(661, 9);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(61, 23);
            this.infoBtn.TabIndex = 5;
            this.infoBtn.Text = "导出信息";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.ModeBtn_Click);
            // 
            // pwdTb
            // 
            this.pwdTb.Location = new System.Drawing.Point(443, 9);
            this.pwdTb.Name = "pwdTb";
            this.pwdTb.Size = new System.Drawing.Size(123, 21);
            this.pwdTb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP服务：";
            // 
            // userTb
            // 
            this.userTb.Location = new System.Drawing.Point(252, 9);
            this.userTb.Name = "userTb";
            this.userTb.Size = new System.Drawing.Size(138, 21);
            this.userTb.TabIndex = 2;
            // 
            // serverTb
            // 
            this.serverTb.Location = new System.Drawing.Point(68, 9);
            this.serverTb.Name = "serverTb";
            this.serverTb.Size = new System.Drawing.Size(119, 21);
            this.serverTb.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.aliveBtn);
            this.panel2.Controls.Add(this.passiveBtn);
            this.panel2.Controls.Add(this.fileInfoMode);
            this.panel2.Controls.Add(this.utf8Btn);
            this.panel2.Controls.Add(this.uploadBtn);
            this.panel2.Controls.Add(this.fileBtn);
            this.panel2.Controls.Add(this.filePathTb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 71);
            this.panel2.TabIndex = 3;
            // 
            // aliveBtn
            // 
            this.aliveBtn.Location = new System.Drawing.Point(210, 42);
            this.aliveBtn.Name = "aliveBtn";
            this.aliveBtn.Size = new System.Drawing.Size(61, 23);
            this.aliveBtn.TabIndex = 16;
            this.aliveBtn.Text = "保持活动";
            this.aliveBtn.UseVisualStyleBackColor = true;
            this.aliveBtn.Click += new System.EventHandler(this.aliveBtn_Click);
            // 
            // passiveBtn
            // 
            this.passiveBtn.Location = new System.Drawing.Point(138, 42);
            this.passiveBtn.Name = "passiveBtn";
            this.passiveBtn.Size = new System.Drawing.Size(61, 23);
            this.passiveBtn.TabIndex = 15;
            this.passiveBtn.Text = "被动";
            this.passiveBtn.UseVisualStyleBackColor = true;
            this.passiveBtn.Click += new System.EventHandler(this.passiveBtn_Click);
            // 
            // fileInfoMode
            // 
            this.fileInfoMode.Location = new System.Drawing.Point(6, 42);
            this.fileInfoMode.Name = "fileInfoMode";
            this.fileInfoMode.Size = new System.Drawing.Size(51, 23);
            this.fileInfoMode.TabIndex = 14;
            this.fileInfoMode.Text = "UNIX";
            this.fileInfoMode.UseVisualStyleBackColor = true;
            this.fileInfoMode.Click += new System.EventHandler(this.fileInfoMode_Click);
            // 
            // utf8Btn
            // 
            this.utf8Btn.Location = new System.Drawing.Point(66, 42);
            this.utf8Btn.Name = "utf8Btn";
            this.utf8Btn.Size = new System.Drawing.Size(61, 23);
            this.utf8Btn.TabIndex = 13;
            this.utf8Btn.Text = "UTF8";
            this.utf8Btn.UseVisualStyleBackColor = true;
            this.utf8Btn.Click += new System.EventHandler(this.utf8Btn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(651, 9);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(61, 23);
            this.uploadBtn.TabIndex = 10;
            this.uploadBtn.Text = "上传";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(564, 9);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(61, 23);
            this.fileBtn.TabIndex = 9;
            this.fileBtn.Text = "浏览";
            this.fileBtn.UseVisualStyleBackColor = true;
            this.fileBtn.Click += new System.EventHandler(this.FileBtn_Click);
            // 
            // filePathTb
            // 
            this.filePathTb.Location = new System.Drawing.Point(6, 10);
            this.filePathTb.Name = "filePathTb";
            this.filePathTb.Size = new System.Drawing.Size(543, 21);
            this.filePathTb.TabIndex = 8;
            // 
            // fileList
            // 
            this.fileList.ContextMenuStrip = this.cmsMenu;
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fileList.HideSelection = false;
            this.fileList.LargeImageList = this.imageList;
            this.fileList.Location = new System.Drawing.Point(0, 0);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(734, 393);
            this.fileList.SmallImageList = this.imageList;
            this.fileList.StateImageList = this.imageList;
            this.fileList.TabIndex = 7;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Tile;
            this.fileList.DoubleClick += new System.EventHandler(this.FileList_DoubleClick);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator2,
            this.创建文件夹ToolStripMenuItem,
            this.toolStripSeparator3,
            this.下载ToolStripMenuItem,
            this.toolStripSeparator4,
            this.mi1});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(137, 116);
            this.cmsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMenu_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // 创建文件夹ToolStripMenuItem
            // 
            this.创建文件夹ToolStripMenuItem.Name = "创建文件夹ToolStripMenuItem";
            this.创建文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建文件夹ToolStripMenuItem.Text = "创建文件夹";
            this.创建文件夹ToolStripMenuItem.Click += new System.EventHandler(this.创建文件夹ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            this.下载ToolStripMenuItem.Click += new System.EventHandler(this.下载ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // mi1
            // 
            this.mi1.Name = "mi1";
            this.mi1.Size = new System.Drawing.Size(136, 22);
            this.mi1.Text = "删除";
            this.mi1.Click += new System.EventHandler(this.Mi1_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "none.ico");
            this.imageList.Images.SetKeyName(1, "file.ico");
            this.imageList.Images.SetKeyName(2, "folder.ico");
            this.imageList.Images.SetKeyName(3, "link.ico");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pathList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 29);
            this.panel3.TabIndex = 7;
            // 
            // pathList
            // 
            this.pathList.AutoSize = true;
            this.pathList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathList.Location = new System.Drawing.Point(0, 0);
            this.pathList.Name = "pathList";
            this.pathList.Size = new System.Drawing.Size(734, 29);
            this.pathList.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.fileList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(734, 393);
            this.panel4.TabIndex = 8;
            // 
            // MainHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 534);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 566);
            this.Name = "MainHome";
            this.Text = "FTP设置";
            this.Shown += new System.EventHandler(this.MainHome_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startConBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox pwdTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userTb;
        private System.Windows.Forms.TextBox serverTb;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.TextBox filePathTb;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem mi1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem 创建文件夹ToolStripMenuItem;
		private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button utf8Btn;
		private System.Windows.Forms.FlowLayoutPanel pathList;
		private System.Windows.Forms.Button fileInfoMode;
		private System.Windows.Forms.Button aliveBtn;
		private System.Windows.Forms.Button passiveBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

