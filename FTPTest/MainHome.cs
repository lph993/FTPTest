using FCS.Helper;
using FTPTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CCWin;

namespace FTPTest
{
    public partial class MainHome : Form
    {

        private const string SYS = "SYS";
        private const string SERVER = "SERVER";
        private const string USER = "USER";
        private const string PWD = "PWD";
        private const string IS_UNIX = "IS_UNIX";
		private const string UTF8 = "UTF8";
		private const string PASSIVE = "PASSIVE";
		private const string ALIVE = "ALIVE";

		public static bool IsUTF8 = false;
		public static bool IsUnix = true;
		public static bool IsPassive = true;
		public static bool IsAlive = false;

        private FTPHelper ftp;
        private List<UInfo> fileInfos;

        public MainHome()
        {
            InitializeComponent();
        }

		private Label GetNewLabel(string str)
		{
			Label label=new Label()
			{
				Text = str,
				TextAlign = ContentAlignment.MiddleCenter,
				Padding = new Padding(0, 7, 0, 7),
				Margin=new Padding(0),
				AutoSize = true,
				Dock = DockStyle.Left
			};
			label.Click+=new EventHandler(Label_Click);
			return label;
		}

		private void Label_Click(object Sender,EventArgs e)
		{
			Init_UI(false);
			StringBuilder sb = new StringBuilder();
			Label label;
			for (int i = 0; i < pathList.Controls.Count; i++)
			{
				label = (Label)pathList.Controls[i];
				if (pathList.Controls.Count > 0 && i <= pathList.Controls.IndexOf((Label)Sender))
				{
					sb.Append(label.Text);
				}
				else
				{
					RemovePathListMoreItem(i);
					break;
				}
			}
			Console.WriteLine(sb+"\n");
			ftp.ftpURI = sb.ToString();
			sb.Clear();
			sb = null;
			fileList.Focus();
			RefreshList();
		}

        private void StartConBtn_Click(object sender, EventArgs e)
        {
			startConBtn.Enabled = false;
            InitFtp();
            IniHelper.Write(SYS, SERVER, serverTb.Text);
            IniHelper.Write(SYS, USER, userTb.Text);
            IniHelper.Write(SYS, PWD, pwdTb.Text);
            if (ftp.FTPLogin())
            {
                Console.WriteLine("登录成功！\n");
                Init_UI(true);
				pathList.Controls.Clear();
				Label label = GetNewLabel(ftp.ftpURI);
				pathList.Controls.Add(label);
                RefreshList();
            }
            else
            {
                Console.WriteLine("登录失败！\n");
                Init_UI(false);
            }
			startConBtn.Enabled = true;
        }

        private void RefreshList()
        {
			Init_UI(false);
            fileList.Clear();
            fileList.BeginUpdate();
            fileInfos=IsUnix?ftp.GetFile(ftp.GetAllList()):ftp.GetFile1(ftp.GetAllList());
            if (fileInfos!=null)
			{
				Console.WriteLine("fileList列表：");
                foreach (UInfo info in fileInfos)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = info.Name,
                        ImageIndex = info.ImageIndex
                    };
                        fileList.Items.Add(item);
                       Console.WriteLine(info.Name);
                }
				Console.WriteLine();
            }
            else
            {
                Console.WriteLine("无文件信息...\n");
            }
            fileList.Show();
            fileList.EndUpdate();
			Init_UI(true);
        }

        private OpenFileDialog dialog;
        private List<string> fileSelects;
        private void FileBtn_Click(object sender, EventArgs e)
        {
            if (dialog == null)
            {
                dialog = new OpenFileDialog
                {
                    InitialDirectory = Application.StartupPath,
                    Multiselect = true,
                    Title = "选择文件"
                };
                fileSelects = new List<string>();
            }
            fileSelects.Clear();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str1="";
                string temp;
                foreach(string str in dialog.FileNames)
                {
                    temp = str;
                    fileSelects.Add(temp);
                    str1 += temp+"|";
                }
                filePathTb.Text = str1.Substring(0,str1.Length-1);
            }
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
			Init_UI(false);
			string[] strs=filePathTb.Text.Split('|');
            if (strs!=null&&strs.Length > 0)
            {
                foreach (string path in strs)
				{
					Console.WriteLine("上传："+path);
					ftp.Upload(path);
					RefreshList();
                }
            }
            else
            {
                Console.WriteLine("未选中文件...\n");
            }
			Init_UI(true);
        }

        private void MainHome_Shown(object sender, EventArgs e)
        {
            Init_ini();
			
            Init_UI(false);
        }

        private void Init_UI(bool b)
        {
            cmsMenu.Enabled=fileBtn.Enabled=uploadBtn.Enabled=fileList.Enabled=pathList.Enabled = b;
        }

		private void Init_ini()
		{
			serverTb.Text = IniHelper.Read(SYS, SERVER, "");
			userTb.Text = IniHelper.Read(SYS, USER, "");
			pwdTb.Text = IniHelper.Read(SYS, PWD, "");
			IsUnix = IniHelper.Read(SYS, IS_UNIX, "1").Equals("1") ? true : false;
			IsUTF8 = IniHelper.Read(SYS, UTF8, "0").Equals("0") ? false : true;
			IsPassive = IniHelper.Read(SYS, PASSIVE, "1").Equals("1") ? true : false;
			IsAlive = IniHelper.Read(SYS, ALIVE, "0").Equals("0") ? false : true;
			if (IsUnix)
			{
				fileInfoMode.Text = "UNIX";
			}
			else
			{
				fileInfoMode.Text = "DOS";
			}

			if (IsUTF8)
			{
				utf8Btn.ForeColor = Color.Black;
			}
			else
			{

				utf8Btn.ForeColor=Color.Gray;
			}
			if (IsPassive)
			{
				passiveBtn.Text = "被动";
			}
			else
			{
				passiveBtn.Text = "主动";
			}
			if (IsAlive)
			{
				aliveBtn.ForeColor = Color.Black;
			}
			else
			{
				aliveBtn.ForeColor = Color.Gray;
			}
		}

        private void InitFtp()
        {
            ftp = new FTPHelper(serverTb.Text, userTb.Text, pwdTb.Text);
        }

        
        private void ModeBtn_Click(object sender, EventArgs e)
        {
			infoBtn.Enabled = false;
            foreach(string str in ftp.GetAllList())
            {
                LogHelper.AddLog(str);
            }
            Console.WriteLine("文件目录写入...\n");
			infoBtn.Enabled = true;
        }

        private void FileList_DoubleClick(object sender, EventArgs e)
        {
            if (fileList.SelectedIndices.Count ==1)
            {
                UInfo info = fileInfos[fileList.SelectedIndices[0]];
                if (info.State==State.folder)
				{
					Console.WriteLine("进入目录：" + info.Name);
                    ftp.GotoDirectory(info.Name);
                    RefreshList();
					Label label = GetNewLabel(string.Format("{0}/", info.Name));
					pathList.Controls.Add(label);
				}
				else if (info.State == State.link)
				{

				}
            }
        }

        private void 创建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFolderForm form = new CreateFolderForm();
            if (form.ShowDialog() == DialogResult.Yes&&!string.IsNullOrEmpty(form.Str))
            {
                ftp.MakeDir(form.Str);
            }
            form.Dispose();
			RefreshList();
        }

        private void Mi1_Click(object sender, EventArgs e)
        {
			if (fileList.SelectedIndices.Count > 0)
			{
				UInfo info;
				foreach (int i in fileList.SelectedIndices)
				{
					Console.WriteLine("删除文件(文件夹)："+fileInfos[i].Name);
					info = fileInfos[i];
					if (info.State==State.folder)
					{
						ftp.DeleteFolder(info.Name);
					}
					else if (info.State == State.file||info.State==State.unknow)
					{
						ftp.Delete(info.Name);
					}
					RefreshList();
				}
			}
        }

		private void utf8Btn_Click(object sender, EventArgs e)
		{
			if (IsUTF8)
			{
				utf8Btn.ForeColor=Color.Gray;
				IsUTF8 = false;
				Console.WriteLine("启用 编码 默认\n");
			}
			else
			{
				utf8Btn.ForeColor = Color.Black;
				IsUTF8 = true;
				Console.WriteLine("启用 编码 UTF8\n");
			}
			IniHelper.Write(SYS, UTF8, IsUTF8 ? "1" : "0");
		}

		private void cmsMenu_Opening(object sender, CancelEventArgs e)
		{
			if (fileList.SelectedIndices.Count > 0)
			{
				mi1.Enabled = true;
				下载ToolStripMenuItem.Enabled = true;
			}
			else
			{
				mi1.Enabled = false;
				下载ToolStripMenuItem.Enabled = false;
			}
		}

		private void RemovePathListMoreItem(int index)
		{
			if ((pathList.Controls.Count-1) >= index)
			{
				pathList.Controls.RemoveAt(index);
				RemovePathListMoreItem(index);
			}
		}

		private void fileInfoMode_Click(object sender, EventArgs e)
		{
			if (IsUnix)
			{
				fileInfoMode.Text = "DOS";
				IsUnix = false;
			}
			else
			{
				fileInfoMode.Text = "UNIX";
				IsUnix = true;
			}
			Console.WriteLine(string.Format("目录浏览:{0}", fileInfoMode.Text));
			IniHelper.Write(SYS, IS_UNIX, IsUnix ? "1" : "0");
		}

		private void passiveBtn_Click(object sender, EventArgs e)
		{
			if (IsPassive)
			{
				passiveBtn.Text = "主动";
				IsPassive = false;
			}
			else
			{
				passiveBtn.Text = "被动";
				IsPassive = true;
			}
			Console.WriteLine(string.Format("Passive:{0}", IsPassive));
			IniHelper.Write(SYS, PASSIVE, IsPassive ? "1" : "0");
		}

		private void aliveBtn_Click(object sender, EventArgs e)
		{
			if (IsAlive)
			{
				aliveBtn.ForeColor = Color.Gray;
				IsAlive = false;
			}
			else
			{
				aliveBtn.ForeColor = Color.Black;
				IsAlive = true;
			}
			Console.WriteLine(string.Format("Alive:{0}", IsAlive));
			IniHelper.Write(SYS, ALIVE, IsAlive ? "1" : "0");
		}

		private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RefreshList();
		}

		private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Init_UI(false);
			foreach (int i in fileList.SelectedIndices)
			{
				Console.WriteLine("下载：" + fileInfos[i].Name);
				ftp.Download(Application.StartupPath + "\\Download\\", fileInfos[i].Name, fileInfos[i].Size);
			}
			Init_UI(true);
		}
    }
}
