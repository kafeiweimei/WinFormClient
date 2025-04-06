/***
*	Title："Winform" 项目
*		主题：Winform的UI帮助类
*	Description：
*		功能：
*		    1、上传文件
*		    2、下载文件
*		    3、删除文件
*		    4、获取当前目录下明细(包含文件和文件夹)
*		    5、获取当前目录下文件列表(仅文件)
*		    6、获取当前目录下所有的文件夹列表(仅文件夹)
*		    7、判断当前目录下指定的子目录是否存在
*		    8、判断当前目录下指定的文件是否存在
*		    9、创建文件夹
*		    10、获取指定文件大小
*		    11、修改文件名称
*		    12、移动文件移动文件
*		                		                
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Utils
{
    public class FtpHelper
    {
        #region   基础参数
        //FTP服务器的IP地址
        private string ftpServerIP;
        //FTP服务的远程路径
        private string ftpRemotePath;
        //FTP的用户账户
        private string ftpUserID;
        //FTP的用户对应密码
        private string ftpPassword;
        //FTP的资源地址
        private string ftpURI;

        #endregion



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ftpServerIP">FTP连接的服务器地址</param>
        /// <param name="ftpRemotePath">指定FTP连接成功后的目录, 如果不指定即默认为根目录</param>
        /// <param name="ftpUserID">用户名</param>
        /// <param name="ftpPassword">密码</param>
        public FtpHelper(string ftpServerIP, string ftpRemotePath, string ftpUserID, string ftpPassword)
        {
            this.ftpServerIP = ftpServerIP;
            this.ftpRemotePath = ftpRemotePath;
            this.ftpUserID = ftpUserID;
            this.ftpPassword = ftpPassword;
            this.ftpURI = $"ftp://{ftpServerIP}/{ftpRemotePath}";
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filePaths">需上传的文件路径和文件列表</param>
        /// <param name="strFtpPath">需上传文件到FTP服务器文件的路径</param>
        /// <returns></returns>
        public List<FtpResult> UploadFile(List<string> filePaths, string strFtpPath)
        {
            List<FtpResult> ListResult = new List<FtpResult>();
            if (filePaths != null && filePaths.Count > 0)
            {
                foreach (var file in filePaths)
                {
                    FtpResult result = FtpUpload(strFtpPath, file);
                    ListResult.Add(result);
                }
            }
            return ListResult;
        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileDownLoadPath">文件下载到的路径和名称</param>
        /// <param name="needDownLoadFileName">需下载文件的名称</param>
        /// <param name="strMsg">下载文件的消息</param>
        /// <returns></returns>
        public bool Download(string fileDownloadPathAndName, string needDownLoadFileName, out string strMsg)
        {
            FtpWebRequest reqFTP;
            FileStream outputStream = new FileStream(fileDownloadPathAndName, FileMode.Create,FileAccess.ReadWrite);
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri($"{ftpURI}/{needDownLoadFileName}"));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                strMsg = "下载成功";
                return true;
            }
            catch (Exception ex)
            {
                outputStream.Close();
                strMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">需删除的FTP服务器上的文件名称</param>
        public bool Delete(string fileName, out string strMsg)
        {
            try
            {
                string uri = ftpURI + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream, Encoding.GetEncoding("GB2312"));
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
                strMsg = "删除成功";
                return true;
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
                
            }
        }

        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)
        /// </summary>
        /// <returns></returns>
        public string[] GetDirAndFileDetail()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.GetEncoding("GB2312"));
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                throw new Exception("GetFilesDetailList Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 获取当前目录下文件列表(仅文件)
        /// </summary>
        /// <param name="mask">文件类型（如：*.*表示所有）</param>
        /// <returns>返回所有文件数组</returns>
        public string[] GetFileList(string mask)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {
                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    throw new Exception("GetFileList Error --> " + ex.Message.ToString());
                }
                return downloadFiles;
            }
        }

        /// <summary>
        /// 获取当前目录下所有的文件夹列表(仅文件夹)
        /// </summary>
        /// <returns>返回为文件夹数组</returns>
        public string[] GetDirectoryList()
        {
            string[] drectory = GetDirAndFileDetail();
            string m = string.Empty;
            foreach (string str in drectory)
            {
                //int len = str.Length;
                //string tmp = str.Trim().Substring(0, len-1).ToUpper();
                //string tmp1 = str.Trim().Substring(24,5).ToUpper();
                //string tmp2 = str.Trim().Substring(39, str.Length-39).Trim();
                string floderMask = str.Trim().Substring(24, 5).ToUpper();
                if (floderMask == "<DIR>")
                {
                    m += str.Substring(39).Trim() + "\n";
                }
            }
            return m.Split('\n');
        }

        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        /// <returns>存在则返回True</returns>
        public bool DirectoryExist(string RemoteDirectoryName)
        {
            string[] dirList = GetDirectoryList();
            foreach (string str in dirList)
            {
                if (str.Trim() == RemoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断当前目录下指定的文件是否存在
        /// </summary>
        /// <param name="RemoteFileName">远程文件名</param>
        /// <returns>存在则返回True</returns>
        public bool FileExist(string RemoteFileName)
        {
            string[] fileList = GetFileList("*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName">目录名称</param>
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("MakeDir Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 获取指定文件大小
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns>返回文件大小</returns>
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("GetFileSize Error --> " + ex.Message);
            }
            return fileSize;
        }

        /// <summary>
        /// 修改文件名称
        /// </summary>
        /// <param name="currentFilename">当前文件名称</param>
        /// <param name="newFilename">新文件名称</param>
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("ReName Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="currentFilename">当前文件名称</param>
        /// <param name="newFilename">新的文件名称</param>
        public void MovieFile(string currentFilename, string newFilename)
        {
            ReName(currentFilename, newFilename);
        }

        /// <summary>
        /// 上传文件  
        /// </summary>
        /// <param name="ftpPath">ftp路径</param>
        /// <param name="localFile">需上传的本地文件</param>
        /// <returns>返回上传结果</returns>
        public FtpResult FtpUpload(string ftpPath, string localFile)
        {
            //检查目录是否存在，不存在创建  
            FtpResult result = new FtpResult();
            FtpCheckDirectoryExist(ftpPath);
            FileInfo fi = new FileInfo(localFile);
            FileStream fs = fi.OpenRead();
            long length = fs.Length;
            string strUrl = ftpURI + ftpPath + fi.Name;
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(strUrl);
            req.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.ContentLength = length;
            req.Timeout = 10 * 1000;
            try
            {
                Stream stream = req.GetRequestStream();
                int BufferLength = 2048; //2K     
                byte[] b = new byte[BufferLength];
                int i;
                while ((i = fs.Read(b, 0, BufferLength)) > 0)
                {
                    stream.Write(b, 0, i);
                }
                stream.Close();
                stream.Dispose();
            }
            catch (Exception e)
            {
                result.success = false;
                result.strMsg = e.Message;
                result.fileName = fi.Name;
                return result;
            }
            finally
            {
                fs.Close();
                req.Abort();
            }
            req.Abort();
            result.strMsg = ftpPath + fi.Name;
            result.success = true;
            result.fileName = fi.Name;
            return result;
        }

        /// <summary>
        /// 判断文件的目录是否存,不存则创建  
        /// </summary>
        /// <param name="destFilePath">目标文件文件</param>
        public void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = FtpParseDirectory(destFilePath);
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// FTP目录
        /// </summary>
        /// <param name="destFilePath">目标文件路径</param>
        /// <returns></returns>
        public string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }

        /// <summary>
        /// 创建目录  
        /// </summary>
        /// <param name="localFile">本地文件</param>
        /// <returns></returns>
        public Boolean FtpMakeDir(string localFile)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpURI + localFile);
            req.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }


        public string UnicodeToUTF8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }

        public string UTF8ToGB2312(string str)
        {
            try
            {
                Encoding utf8 = Encoding.GetEncoding(65001);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");//Encoding.Default ,936
                byte[] temp = utf8.GetBytes(str);
                byte[] temp1 = Encoding.Convert(utf8, gb2312, temp);
                string result = gb2312.GetString(temp1);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
        }

        public string GB2312ToUTF8(string str)
        {
            try
            {
                Encoding uft8 = Encoding.GetEncoding(65001);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] temp = gb2312.GetBytes(str);
                
                byte[] temp1 = Encoding.Convert(gb2312, uft8, temp);

                string result = uft8.GetString(temp1);
                return result;
            }
            catch (Exception ex)//(UnsupportedEncodingException ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
        }


        public class FtpResult
        {
            public bool success { get; set; }
            public string strMsg { get; set; }

            public string fileName { get; set; }

        }

    }//Class_end
}
