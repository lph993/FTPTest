namespace FTPTest
{
    partial class CreateFolderForm
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
            this.folderTb = new System.Windows.Forms.TextBox();
            this.folderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderTb
            // 
            this.folderTb.Location = new System.Drawing.Point(12, 12);
            this.folderTb.Name = "folderTb";
            this.folderTb.Size = new System.Drawing.Size(202, 21);
            this.folderTb.TabIndex = 0;
            // 
            // folderBtn
            // 
            this.folderBtn.Location = new System.Drawing.Point(220, 10);
            this.folderBtn.Name = "folderBtn";
            this.folderBtn.Size = new System.Drawing.Size(75, 23);
            this.folderBtn.TabIndex = 1;
            this.folderBtn.Text = "创  建";
            this.folderBtn.UseVisualStyleBackColor = true;
            this.folderBtn.Click += new System.EventHandler(this.FolderBtn_Click);
            // 
            // CreateFolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(308, 44);
            this.Controls.Add(this.folderBtn);
            this.Controls.Add(this.folderTb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateFolderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建文件夹";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderTb;
        private System.Windows.Forms.Button folderBtn;
    }
}