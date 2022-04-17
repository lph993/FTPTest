using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FTPTest
{
    public class LogHelper
    {
        public static bool justAddTB = false;
        private static string LogPath;
        private static StreamWriter fileWriter = null;
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="filePath">文件路径（项目bin\）</param>
        /// <param name="isAppend">是否已追加的方式写入日志</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileContent">文件内容</param>
        public static void SaveLog(bool isAppend,string path,string fileName, string fileContent)
        {
            try
            {
                LogPath = string.Format("{0}\\{1}.log", path, fileName);
                if (!Directory.Exists(LogPath))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        justAddTB = true;
                        AddLog("日志文件创建失败，无法记录日志！");
                        justAddTB = false;
                        return;
                    }
                }
                fileWriter = new StreamWriter(LogPath, isAppend, Encoding.UTF8);
                fileWriter.Write(fileContent);
                fileWriter.Flush();
                fileWriter.Close();
                fileWriter.Dispose();
            }
            catch (Exception ex)
            {
                if (fileWriter != null)
                {
                    fileWriter.Close();
                    fileWriter.Dispose();
                }
                throw ex;
            }
        }

        public static void AddLog(string log)
        {
            log = string.Format("【{0}】{1}\n", DateTime.Now, log);
            SaveLog(true, Application.StartupPath+"\\log\\","ftplog.log", log);
        }
    }
}
