/***
*	Title："WinFormClient" 项目
*		主题：文件夹和文件帮助类
*	Description：
*		功能：
*		    1、获取到指定目录下的文件内容【仅限当前目录下的内容不包含子目录】
*		    2、获取选择的目录
*		    3、获取到选择的文件
*		    4、【打开】获取到选中的文件路径和文件名称
*		    5、【保存】获取到选中的文件路径和文件名称
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
using System.Windows.Forms;

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



        /// <summary>
        /// 获取选择的目录
        /// </summary>
        /// <returns>返回选择的目录</returns>
        public static string GetSelectDirectory()
        {
            string filePath = null;
            FolderBrowserDialog dir = new FolderBrowserDialog();

            if (dir.ShowDialog() == DialogResult.OK)
            {
                filePath = dir.SelectedPath;
            }

            return filePath;

        }

        /// <summary>
        /// 获取到选择的文件
        /// </summary>
        /// <returns>返回文件路径及其文件名称</returns>
        public static string GetSelectFile()
        {
            string file = null;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                file = fileDialog.FileName;//返回文件的完整路径                
            }

            return file;
        }

        /// <summary>
        /// 【打开】获取到选中的文件路径和文件名称
        /// </summary>
        /// <param name="titleName">标题名称</param>
        /// <param name="filterFormat">过滤格式（指定可以选择的文件类型）</param>
        /// <returns></returns>
        public static string OpenSelectedFilePathAndName(string titleName = "导入Excel文件",
            string filterFormat = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx")
        {
            string filePathAndName = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = titleName;
            openFileDialog.Filter = filterFormat;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathAndName = openFileDialog.FileName;
            }
            return filePathAndName;
        }

        /// <summary>
        /// 【保存】获取到选中的文件路径和文件名称
        /// </summary>
        /// <param name="titleName">标题名称</param>
        /// <param name="filterFormat">过滤格式（指定可以选择的文件类型）</param>
        /// <returns></returns>
        public static string SaveSelectedFilePathAndName(string titleName = "导出Excel文件",
            string filterFormat = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx")
        {
            string filePathAndName = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = titleName;
            saveFileDialog.Filter = filterFormat;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathAndName = saveFileDialog.FileName;
            }
            return filePathAndName;
        }


 

    }
}
