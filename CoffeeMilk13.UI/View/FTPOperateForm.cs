using CoffeeMilk13.UI.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.View
{
    public partial class FTPOperateForm : DevExpress.XtraEditors.XtraForm
    {
        #region   基础参数
        FtpHelper ftpHelper;

        #endregion 

        #region 控件大小随窗体大小等比例缩放

        private readonly float x; //定义当前窗体的宽度
        private readonly float y; //定义当前窗体的高度

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0) setTag(con);
            }
        }

        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    var mytag = con.Tag.ToString().Split(';');
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(Convert.ToSingle(mytag[0]) * newx); //宽度
                    con.Height = Convert.ToInt32(Convert.ToSingle(mytag[1]) * newy); //高度
                    con.Left = Convert.ToInt32(Convert.ToSingle(mytag[2]) * newx); //左边距
                    con.Top = Convert.ToInt32(Convert.ToSingle(mytag[3]) * newy); //顶边距
                    var currentSize = Convert.ToSingle(mytag[4]) * newy; //字体大小                   
                    if (currentSize > 0) con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    con.Focus();
                    if (con.Controls.Count > 0) setControls(newx, newy, con);
                }
        }


        /// <summary>
        /// 重置窗体布局
        /// </summary>
        private void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            setControls(newx, newy, this);
        }

        #endregion

        public FTPOperateForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion

        }

        private void FTPOperateForm_Load(object sender, EventArgs e)
        {
            this.Shown += Form_Shown;
            this.Resize += Form_Resize;

            InitPara();
        }



        #region 窗体控件方法

        private void Form_Shown(object sender, EventArgs e)
        {
            //this.ActiveControl = textEdit_FTPServerIP;
            textEdit_FTPServerIP.Focus();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        private void simpleButton_GetFtpServerDirAndFiles_Click(object sender, EventArgs e)
        {
            SetFtpConnectPara();

            string[] curFilesAllDetail =  ftpHelper.GetDirAndFileDetail();

            ShowFtpAllFile(curFilesAllDetail);
        }

        private void simpleButton_GetFtpServerFloders_Click(object sender, EventArgs e)
        {
            SetFtpConnectPara();

            string[] curFolderAllDetail = ftpHelper.GetDirectoryList();
            ShowFtpAllFile(curFolderAllDetail);
        }

        private void simpleButton_GetFtpServerFiles_Click(object sender, EventArgs e)
        {
            SetFtpConnectPara();

            string[] curFilesAllDetail =  ftpHelper.GetFileList("*.*");

            ShowFtpAllFile(curFilesAllDetail);
        }

        private void simpleButton_UploadFile_Click(object sender, EventArgs e)
        {
            SetFtpConnectPara();

            string needUploadFile = memoEdit_SelectedFile.Text.Trim();
            if (string.IsNullOrEmpty(needUploadFile))
            {
                PopupMessage.ShowError("请选择需要上传的文件！！！");
                return;
            }

            List<string> needUploadFileList = new List<string>();
            needUploadFileList.Add(needUploadFile);
            List<FtpHelper.FtpResult> res = ftpHelper.UploadFile(needUploadFileList, @"ftpUploadTest/");
            if (res==null || res.Count<=0)
            {
                PopupMessage.ShowWarning($"没有文件上传");
                return;
            }
            if (!res[0].success)
            {
                PopupMessage.ShowError($"上传【{needUploadFile}】文件失败，失败信息是：{res[0].strMsg}");
                return;
            }

            PopupMessage.ShowInfo($"上传【{needUploadFile}】文件成功");

        }

        private void simpleButton_DownloadFile_Click(object sender, EventArgs e)
        {
            SetFtpConnectPara();
            string needDownloadFilename = textEdit_Filename.Text;

            string fileDownloadPath = AppDomain.CurrentDomain.BaseDirectory + "FTPServerDownloadFiles";
            if (!Directory.Exists(fileDownloadPath))
            {
                Directory.CreateDirectory(fileDownloadPath);
            }
            string fileDownloadPathAndName = Path.Combine(fileDownloadPath,needDownloadFilename);


            bool result = ftpHelper.Download(fileDownloadPathAndName, needDownloadFilename,out string msg);

            if (!result)
            {
                PopupMessage.ShowError($"下载FTP的【{needDownloadFilename}】文件到【{fileDownloadPath}】结果是【{result}】" +
                    $"失败原因是【{msg}】");
                return;
            }

            PopupMessage.ShowInfo($"下载FTP的【{needDownloadFilename}】文件到【{fileDownloadPath}】成功");
        }

        private void simpleButton_DeleteFile_Click(object sender, EventArgs e)
        {
            SetFtpConnectPara();

            string needDeleteFilename = textEdit_Filename.Text;
            bool result = ftpHelper.Delete(needDeleteFilename,out string msg);

            if (!result)
            {
                PopupMessage.ShowError($"删除FTP的【{needDeleteFilename}】文件，结果是【{result}】" +
                    $"失败原因是【{msg}】");
                return;
            }

            PopupMessage.ShowInfo($"删除FTP的【{needDeleteFilename}】文件成功");

        }

        private void simpleButton_SelectFile_Click(object sender, EventArgs e)
        {
            string selectedFile = FolderFileHelper.GetSelectFile();
            memoEdit_SelectedFile.Text = selectedFile;
        }



        #endregion


        #region   私有方法

        private void InitPara()
        {
            textEdit_FTPServerIP.Text = "192.168.166.128";
            textEdit_FTPAccount.Text = "ftpuser";
            textEdit_FTPPassword.Text = "Qwer123";
            textEdit_FtpConnectFolder.Text = "ftpUploadTest/";
        }

        /// <summary>
        /// 设置FTP的连接参数
        /// </summary>
        private void SetFtpConnectPara()
        {
            string ftpServerIP = textEdit_FTPServerIP.Text.Trim();
            string ftpAccount = textEdit_FTPAccount.Text.Trim();
            string ftpPwd = textEdit_FTPPassword.Text.Trim();
            string ftpConFolder = textEdit_FtpConnectFolder.Text.Trim();

            ftpHelper = new FtpHelper(ftpServerIP,ftpConFolder,ftpAccount,ftpPwd);
        }

        //显示服务器默认路径下的内容
        private void ShowFtpAllFile(string[] ftpAllFiles)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ftpAllFiles.Length; i++)
            {
                string str = $"{ftpAllFiles[i]}\r\n";
                sb.Append(str);
            }

            memoEdit_FTPServerFiles.Text = sb.ToString();
        }




        #endregion


    }//Class_end
}