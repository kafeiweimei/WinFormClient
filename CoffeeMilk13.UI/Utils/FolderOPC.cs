/***
*	Title："WinFormClient" 项目
*		主题：文件夹操作
*	Description：
*		功能：
*		    1、获取到文件夹下的所有文件(不含子目录文件)
*		    2、获取到文件夹下的所有文件(含子目录文件)
*		    3、获取到文件夹下的指定拓展名的所有文件(含子目录文件)
*	Date：2025/4/4 19:07:54
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Utils
{
    public class FolderOPC
    {
        #region   基础参数
        //获取到文件夹下的所有文件(含子目录)的缓存文件列表
        private static List<FileInfo> _ListTmp = new List<FileInfo>();
        //递归获取指定类型文件(含子目录)的缓存文件列表
        private static List<FileInfo> _FileList = new List<FileInfo>();

        #endregion



        #region   公有方法

        /// <summary>
        /// 通用的获取文件夹(或包含子文件夹)(或有文件拓展名称)指定方式的所有文件
        /// </summary>
        /// <param name="filePath">文件夹路径</param>
        /// <param name="folderOfFilesStyle">获取文件夹的所有文件下不同方式</param>
        /// <returns>返回文件列表</returns>
        public static List<FileInfo> GetFolderOfDifferentStyleFiles(string folderPath, FolderOfFilesStyle folderOfFilesStyle, string extName = "NONE")
        {
            List<FileInfo> tmpfiles = new List<FileInfo>();
            switch (folderOfFilesStyle)
            {
                case FolderOfFilesStyle.NoSubFolder:

                    if (extName.ToUpper().Equals("NONE"))
                    {
                        FileInfo[] fileInfos = GetFolderOfFile(folderPath);
                        if (fileInfos != null && fileInfos.Length > 0)
                        {
                            foreach (var item in fileInfos)
                            {
                                tmpfiles.Add(item);
                            }
                        }
                    }
                    else
                    {
                        tmpfiles = GetFolderOfFile(folderPath, extName);
                    }
                    break;

                case FolderOfFilesStyle.YesSubFolder:
                    if (extName.ToUpper().Equals("NONE"))
                    {
                        tmpfiles = GetFolderAndSubFolderOfFile(folderPath);
                    }
                    else
                    {
                        tmpfiles = GetFolderAndSubFolderOfFile(folderPath, extName);
                    }
                    break;

                default:
                    break;
            }
            return tmpfiles;
        }


        /// <summary>
        /// 获取到文件夹下的所有文件(不含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <returns>返回当前目录下的所有文件</returns>
        public static FileInfo[] GetFolderOfFile(string strFolder)
        {
            return GetFolderIncludeFile(strFolder);
        }

        /// <summary>
        /// 获取到文件夹下的指定拓展名的所有文件(不含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <param name="extName">文件拓展名（比如:".txt",".mp4",".PDF"等）</param>
        /// <returns>返回当前目录下所包含的所有文件</returns>
        public static List<FileInfo> GetFolderOfFile(string strFolder, string extName)
        {
            return GetFolderIncludeFile(strFolder, extName);
        }

        /// <summary>
        /// 获取到文件夹下的所有文件(含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <returns>返回当前目录及其子目录下所包含的所有文件</returns>
        public static List<FileInfo> GetFolderAndSubFolderOfFile(string strFolder)
        {
            _ListTmp?.Clear();
            return GetFolderAndSubFolderIncludeFile(strFolder);
        }

        /// <summary>
        /// 获取到文件夹下的指定拓展名的所有文件(含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <param name="extName">文件拓展名（比如:".txt",".mp4",".PDF"等）</param>
        /// <returns>返回当前目录及其子目录下所包含的所有文件</returns>
        public static List<FileInfo> GetFolderAndSubFolderOfFile(string strFolder, string extName)
        {
            _FileList?.Clear();
            return GetFolderAndSubFolderIncludeFile(strFolder, extName);
        }

        #endregion


        #region   私有方法

        /// <summary>
        /// 获取到文件夹下的所有文件(不含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <returns>返回当前目录下的所有文件</returns>
        private static FileInfo[] GetFolderIncludeFile(string strFolder)
        {
            if (!string.IsNullOrEmpty(strFolder))
            {
                DirectoryInfo Folders = new DirectoryInfo(strFolder);
                FileInfo[] File = Folders.GetFiles();//获取所在目录的文件
                return File;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取到文件夹下的指定拓展名的所有文件(不含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <param name="extName">文件拓展名（比如:".txt",".mp4",".PDF"等）</param>
        /// <returns>返回当前目录下指定文件拓展名后所包含的所有文件</returns>
        private static List<FileInfo> GetFolderIncludeFile(string strFolder, string extName)
        {
            List<FileInfo> tmpFileList = new List<FileInfo>();
            if (!string.IsNullOrEmpty(strFolder) && !string.IsNullOrEmpty(extName))
            {
                DirectoryInfo Folders = new DirectoryInfo(strFolder);
                FileInfo[] File = Folders.GetFiles();//获取所在目录的文件
                foreach (FileInfo f in File) //显示当前目录所有文件   
                {
                    if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                    {
                        tmpFileList.Add(f);
                    }
                }
                return tmpFileList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取到文件夹下的所有文件(含子目录文件)
        /// </summary>
        /// <param name="strFolder">需要遍历的文件夹(绝对路径)</param>
        /// <returns>返回当前目录及其子目录下所包含的所有文件</returns>
        private static List<FileInfo> GetFolderAndSubFolderIncludeFile(string strFolder)
        {
            if (!string.IsNullOrEmpty(strFolder))
            {
                try
                {
                    DirectoryInfo Folders = new DirectoryInfo(strFolder);
                    DirectoryInfo[] DirInfo = Folders.GetDirectories();//获取所在目录的文件夹
                    FileInfo[] File = Folders.GetFiles();//获取所在目录的文件

                    foreach (FileInfo fileInfo in File) //遍历文件
                    {
                        //result += "dirName:" + fileItem.DirectoryName + "    fileName:" + fileItem.Name + "\n";
                        _ListTmp.Add(fileInfo);
                    }
                    //遍历文件夹
                    foreach (DirectoryInfo NextFolder in DirInfo)
                    {
                        GetFolderAndSubFolderIncludeFile(NextFolder.FullName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                _ListTmp = null;
            }
            return _ListTmp;
        }

        /// <summary>
        /// 获取到文件夹下的指定拓展名的所有文件(含子目录文件)
        /// </summary>
        /// <param name="strFolder">指定文件夹的路径</param>
        /// <param name="extName">文件拓展名（比如:".txt",".mp4",".PDF"等）</param>
        /// <returns>返回当前目录及其子目录下指定文件拓展名后所包含的所有文件</returns>
        private static List<FileInfo> GetFolderAndSubFolderIncludeFile(string strFolder, string extName)
        {
            if (!string.IsNullOrEmpty(strFolder) && !string.IsNullOrEmpty(extName))
            {
                try
                {
                    string[] dir = Directory.GetDirectories(strFolder); //文件夹列表   
                    DirectoryInfo fdir = new DirectoryInfo(strFolder);
                    FileInfo[] file = fdir.GetFiles();

                    if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空                   
                    {
                        foreach (FileInfo f in file) //显示当前目录所有文件   
                        {
                            if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                            {
                                _FileList.Add(f);
                            }
                        }
                        foreach (string d in dir)
                        {
                            GetFolderAndSubFolderIncludeFile(d, extName);//递归   
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                _FileList = null;
            }

            return _FileList;
        }

        #endregion

        //获取文件夹的所有文件下不同方式
        public enum FolderOfFilesStyle
        {
            NoSubFolder,    //不含子目录
            YesSubFolder,   //含子目录
        }

    }//Class_end
}
