using CCWin;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPTest
{
    public partial class CreateFolderForm : Form
    {

        public string Str
        {
            get
            {
                return folderTb.Text;
            }
        }

        public CreateFolderForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.No;
        }

        private void FolderBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
