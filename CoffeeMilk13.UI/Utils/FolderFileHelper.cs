/***
*	Title："WinFormClient" 项目
*		主题：文件夹和文件帮助类
*	Description：
*		功能：
*		    
*	Date：2024/10/16 13:55:53
*	Version：0.1版本
*	Author：CoffeeMilk13
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
    public class FolderFileHelper
    {
        /// <summary>
        /// 获取到指定目录下的文件内容【仅限当前目录下的内容不包含子目录】
        /// </summary>
        /// <param name="strPath">文件夹路径</param>
        /// <param name="fileExtand">文件类型（如：*.png、*.jpg）</param>
        /// <returns>返回当前文件夹下的所有指定类型文件</returns>
        internal static FileInfo[] GetDirectoryFiles(string strPath, string fileExtand)
        {
            if (!string.IsNullOrEmpty(strPath) && !string.IsNullOrEmpty(fileExtand))
            {
                //获取目录与子目录
                DirectoryInfo dir = new DirectoryInfo(strPath);
                //获取当前目录JPG文件列表 GetFiles获取指定目录中文件的名称(包括其路径)
                FileInfo[] fileInfo = dir.GetFiles(fileExtand);

                return fileInfo;
            }
            return null;

        }

       
 

    }
}
