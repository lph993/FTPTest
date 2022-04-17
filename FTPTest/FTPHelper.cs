
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;
using FTPTest;

namespace FCS.Helper
{
    public class FTPHelper
    {

        public string ftpURI;
        private readonly string ftpUserID;
        private readonly string ftpServerIP;
        private readonly string ftpPassword;
        string ftpRemotePath;
		private bool MyUsePassive
		{
			get
			{
				return MainHome.IsPassive;
			}
		}
		private bool MyKeepAlive
		{
			get
			{
				return MainHome.IsAlive;
			}
		}
		private Encoding encoding
		{
			get
			{
				if (MainHome.IsUTF8)
				{
					return Encoding.UTF8;
				}
				else
				{
					return Encoding.Default;
				}
			}
		}

        /// <summary>  
        /// 构造函数
        /// </summary>
        public FTPHelper(string FtpServerIP, string FtpUserID, string FtpPassword, string FtpRemotePath = null)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpURI = string.IsNullOrEmpty(ftpRemotePath) ? string.Format("ftp://{0}/", ftpServerIP) : string.Format("ftp://{0}/{1}/", ftpServerIP, ftpRemotePath);
        }

        /// <summary>
        /// 判断FTP服务器是否正常
        /// </summary>
        public bool FTPLogin()
        {
            FtpWebRequest reqFTP;
			FtpWebResponse response=null;
            try
            {
                Console.WriteLine(ftpURI);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = MyUsePassive;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = MyKeepAlive;
                response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("FTP登陆异常:" + ex.Message + " URI: " + ftpURI+"\n");
				if (response != null) response.Close();
                return false;
            }
        }

        /// <summary>  
        /// 上传  
        /// </summary>   
        public void Upload(string filename)
		{
			FileInfo fileInf = new FileInfo(filename); 
			string str;
			FtpWebRequest reqFTP;
			FileStream fs = null; ;
			Stream strm = null; ;
            try
			{
				str=fileInf.Name.Replace(" ", "%20");
				str = ftpURI + str;
				Console.WriteLine(str);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(str));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.KeepAlive = MyKeepAlive;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = MyUsePassive;
                reqFTP.ContentLength = fileInf.Length;
                ServicePointManager.DefaultConnectionLimit = 50;
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                fs = fileInf.OpenRead();
                strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)//可以在这里计算上传进度
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                Console.WriteLine("上传成功！\n");
				strm.Dispose();
				fs.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FTP文件上传异常:" + ex.Message + " URI: " + ftpURI + fileInf.Name+"\n");
				if (strm != null)
				{
					strm.Close();
					strm.Dispose();
				}
				if (fs != null)
				{
					fs.Close();
					fs.Dispose();
				}
                return;
            }
        }

        /// <summary>  
        /// 下载  
        /// </summary>   
        public void Download(string folder, string fileName,long fileSize=0)
		{
			FtpWebRequest reqFTP;
			FtpWebResponse response = null;
			Stream ftpStream = null;
			FileStream outputStream = null;
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
				string str = fileName.Replace(" ", "%20");
				str = ftpURI + str;
				Console.WriteLine(str);
                outputStream = new FileStream(string.Format("{0}\\{1}", folder, fileName), FileMode.Create);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(str));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.UsePassive = MyUsePassive;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = MyKeepAlive;
                ServicePointManager.DefaultConnectionLimit = 50;
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                int bufferSize = 2048;
                int readCount;
				long readTemp=0;
				decimal readP=0;
				int cursorP = 0;
                byte[] buffer = new byte[bufferSize];
				readCount = ftpStream.Read(buffer, 0, bufferSize);
				Console.WriteLine();
				cursorP = Console.CursorTop;
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
					if (fileSize > 0)
					{
						Console.SetCursorPosition(readP>9?9:8, cursorP);
						readTemp += readCount==0?2048:readCount;
						if (fileSize <= 2048) readTemp=fileSize;
						readP = Math.Floor(Math.Round(decimal.Parse(((decimal)readTemp / (decimal)fileSize).ToString("0.000")), 2) * 100);
						Console.Write(string.Format(readP > 9 ? "\b\b\b\b\b\b\b\b\b进度：{0}%" : "\b\b\b\b\b\b\b\b\b\b进度：{0}%", readP));
					}
                }
				Console.WriteLine();
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                Console.WriteLine("下载成功！\n");
				outputStream.Dispose();
				ftpStream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FTP文件下载异常:" + ex.Message + " URI: " + ftpURI + fileName+"\n");
				if (outputStream != null)
				{
					outputStream.Close();
					outputStream.Dispose();
				}
				if (ftpStream != null)
				{
					ftpStream.Close();
					ftpStream.Dispose();
				}
				if (response != null) response.Close();
                return;
            }
        }

        /// <summary>  
        /// 删除文件  
        /// </summary>  
        public void Delete(string fileName)
		{
			FtpWebRequest reqFTP;
			FtpWebResponse response = null;
			Stream datastream = null;
			StreamReader sr = null;
            try
			{
				string str = fileName.Replace(" ", "%20");
				str = ftpURI + str;
				Console.WriteLine(str);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(str));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.KeepAlive = MyKeepAlive;
                string result = String.Empty;
                response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                datastream = response.GetResponseStream();
                sr = new StreamReader(datastream,encoding);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
                Console.WriteLine("删除["+fileName+"]成功！\n");
				sr.Dispose();
				datastream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ftp文件删除异常:" + ex.Message + " URI: " + ftpURI + fileName+"\n");
				if (sr != null)
				{
					sr.Close();
					sr.Dispose();
				}
				if (datastream != null)
				{
					datastream.Close();
					datastream.Dispose();
				}
				if (response != null) response.Close();
                return;
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        public void DeleteFolder(string folderName)
		{
			FtpWebRequest reqFTP;
			FtpWebResponse response=null;
			Stream datastream=null;
			StreamReader sr=null;
            try
			{
				string str = folderName.Replace(" ", "%20");
				str = ftpURI + str;
				Console.WriteLine(str);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(str));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                reqFTP.KeepAlive = MyKeepAlive;
                string result = String.Empty;
                response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                datastream = response.GetResponseStream();
                sr = new StreamReader(datastream,encoding);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
				Console.WriteLine("删除[" + folderName + "]成功！\n");
				sr.Dispose();
				datastream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ftp文件删除异常:" + ex.Message + " URI: " + ftpURI + folderName+"\n");
				if (sr != null)
				{
					sr.Close();
					sr.Dispose();
				}
				if (datastream != null)
				{
					datastream.Close();
					datastream.Dispose();
				}
				if (response != null) response.Close();
                return;
            }
        }

        /// <summary>  
        /// 获取FTP文件列表(包括文件夹)
        /// </summary>   
        public List<string> GetAllList()
        {
			List<string> list;
			FtpWebRequest req;
            try
            {
				Console.WriteLine(ftpURI);
                req = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI));
                req.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                req.UsePassive = MyUsePassive;
                req.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                req.UseBinary = true;
				req.KeepAlive = MyKeepAlive;
				list = new List<string>();
                using (FtpWebResponse res = (FtpWebResponse)req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream(),encoding))
                    {
                        string s;
						Console.WriteLine("文件原信息：");
                        while ((s = sr.ReadLine()) != null)
                        {
                            list.Add(s);
                            Console.WriteLine(s);
                        }
						Console.WriteLine();
						sr.Close();
						sr.Dispose();
					}
					res.Close();
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("FTP获取所有文件信息异常:" + ex.Message + " URI: " + ftpURI+"\n");
                return null;
            }
        }

        /// <summary>  
        /// 创建文件夹  
        /// </summary>   
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
			FtpWebResponse response=null;
			Stream ftpStream = null;
            try
            {
				string str = dirName.Replace(" ", "%20");
				str = ftpURI + str;
				Console.WriteLine(str);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(str));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
				reqFTP.UseBinary = true;
				reqFTP.KeepAlive = MyKeepAlive;
				reqFTP.UsePassive = MyUsePassive;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
                Console.WriteLine("创建文件夹["+dirName+"]成功!\n");
				ftpStream.Dispose();
            }
            catch (Exception ex)
            {
				Console.WriteLine("FTP创建文件夹:" + ex.Message + "\n");
				if (ftpStream != null)
				{
					ftpStream.Close();
					ftpStream.Dispose();
				}
				if (response != null) response.Close();
                return;
            }
        }

        /// <summary>  
        /// 重命名  
        /// </summary> 
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
			FtpWebResponse response = null;
			Stream ftpStream = null;
            try
			{
				string str=currentFilename.Replace(" ", "%20");
				string str1 = newFilename.Replace(" ", "%20");
				str = ftpURI + str;
				Console.WriteLine(str);
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(str));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = str1;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
                Console.WriteLine("重命名(移动)["+currentFilename+"]到["+newFilename+"]...\n");
				ftpStream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FTP重命名(移动)失败:" + ex.Message + " URI: " + ftpURI + currentFilename+"\n");
				if (ftpStream != null)
				{
					ftpStream.Close();
					ftpStream.Dispose();
				}
				if (response != null) response.Close();
                return;
            }
        }

        /// <summary>  
        /// 移动文件  
        /// </summary>  
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }

        /// <summary>  
        /// 切换当前目录  
        /// </summary>  
        /// <param name="IsRoot">true:绝对路径 false:相对路径</param>   
        public void GotoDirectory(string DirectoryName)
        {
			string str=DirectoryName.Replace(" ", "%20");
            ftpURI = ftpURI + str + "/";
            Console.WriteLine("FTP Uri: "+ftpURI+"\n");
        }

        /// <summary>
        /// 整合ftp文件信息 模式2
        /// </summary>
        /// <param name="list">文件详细信息</param>
        /// <returns></returns>
        public List<UInfo> GetFile1(List<string> list)
        {
            List<UInfo> infos = new List<UInfo>();
            char[] chars;
			try
			{
				Console.WriteLine("解析 启用 模式1");
				if (list != null && list.Count > 0)
				{
					foreach (string str in list)
					{
						UInfo info = new UInfo();
						/*strs = Regex.Replace(str, @"\s+", " ").Split(' ');
						info.Time = strs[0] + " " + strs[1];
						if (strs[2].Equals("<DIR>"))
						{
							info.IsFolder = true;
							info.Size = 0;
						}
						else
						{
							info.IsFolder = false;
							info.Size = int.Parse(strs[2]);
						}
						info.Name = strs[3];*/
						
						chars = str.ToCharArray();
						int i = 0;
						bool isAppend=false;
						bool isToFile = false;
						StringBuilder sb = new StringBuilder();
						string temp;
						foreach(char ch in chars){
							if (isToFile || !ch.Equals(' '))
							{
								sb.Append(ch);
								isAppend = true;
							}
							else
							{
								if (isAppend)
								{
									switch (i)
									{
										case 0:
										case 1://时间
											info.Time += sb.ToString();
											break;
										case 2:
											temp = sb.ToString();
											if (temp.Equals("<DIR>"))
											{
												info.Size = 0;
												info.State = State.folder;
											}
											else
											{
												info.Size = long.Parse(sb.ToString());
												info.State = State.file;
											}
											if(i==2) isToFile = true;
											break;
									}
									sb.Clear();
									i++;
								}
								isAppend = false;
							}
						}
						if (isToFile)
						{
							info.Name = sb.ToString().TrimStart().TrimEnd();
							sb.Clear();
						}
						infos.Add(info);
					}
					Console.WriteLine("模式2 成功\n");
					return infos;
				}
				else
				{
					return null;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("模式2 出错 "+ex.Message+"\n");
				return null;
			}
        }

		/// <summary>
		/// 整合ftp文件信息 模式1
		/// </summary>
		/// <param name="list">文件详细信息</param>
		/// <returns></returns>
		public List<UInfo> GetFile(List<string> list)
		{
			List<UInfo> infos = new List<UInfo>();
			char[] chars;
			try
			{
				Console.WriteLine("解析 启用 模式1");
				if (list != null && list.Count > 0)
				{
					foreach (string str in list)
					{
						UInfo info = new UInfo();
						/*strs = Regex.Replace(str, @"\s+", " ").Split(' ');
						info.QX = strs[0];
						if (info.QX.Contains("d"))
						{
							info.IsFolder = true;

						}
						else
						{
							info.IsFolder = false;
						}
						info.Others = string.Format("{0},{1},{2}", strs[1], strs[2], strs[3]);
						info.Size = int.Parse(strs[4]);
						info.Time = string.Format("{0},{1},{2}", strs[5], strs[6], strs[7]);
						info.Name = strs[8];*/
						chars = str.ToCharArray();
						int i = 0;
						bool isAppend=false;
						bool isToFile = false;
						StringBuilder sb = new StringBuilder();
						foreach (char ch in chars)
						{
							if (isToFile || !ch.Equals(' '))
							{
								sb.Append(ch);
								isAppend = true;
							}
							else
							{
								if (isAppend)
								{
									switch (i)
									{
										case 0://权限
											info.QX = sb.ToString();
											if (info.QX.Contains("d"))
											{
												info.State = State.folder;

											}
											else if (info.QX.Contains("l"))
											{
												info.State = State.link;
											}
											else if (info.QX.Substring(0, 1).Equals("-"))
											{
												info.State = State.file;
											}
											else
											{
												info.State = State.unknow;
											}
											break;
										case 1:
										case 2:
										case 3:
											info.Others += sb.ToString();
											break;
										case 4:
											info.Size = long.Parse(sb.ToString());
											break;
										case 5:
										case 6:
										case 7:
											info.Time += sb.ToString();
											if (i == 7) isToFile = true;
											break;
									}
									sb.Clear();
									i++;
								}
								isAppend = false;
							}
						}
						if (isToFile)
						{
							string temp = sb.ToString().TrimStart();
							sb.Clear();
							int len = temp.IndexOf("->");
							info.Name = temp.Substring(0,len>0?len:temp.Length).TrimEnd();
							info.Link = temp.Substring(len > 0 ? len+2 : 0).TrimStart().TrimEnd();
							Console.WriteLine("Link:" + info.Link);
						}
						infos.Add(info);
					}
					Console.WriteLine("模式1 成功\n");
					return infos;
				}
				else
				{
					return null;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("模式1 出错 "+ex.Message+"\n");
				return null;
			}
		}
    }
}
