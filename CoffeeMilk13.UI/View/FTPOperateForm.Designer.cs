
namespace CoffeeMilk13.UI.View
{
    partial class FTPOperateForm
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
            this.simpleButton_SelectFile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Filename = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_GetFtpServerFiles = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetFtpServerFloders = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit_FTPServerFiles = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton_GetFtpServerDirAndFiles = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_FtpConnectFolder = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_FTPPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_FTPAccount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_FTPServerIP = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_DeleteFile = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DownloadFile = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_UploadFile = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit_SelectedFile = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Filename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_FTPServerFiles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FtpConnectFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FTPPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FTPAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FTPServerIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_SelectedFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_SelectFile
            // 
            this.simpleButton_SelectFile.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_SelectFile.Appearance.Options.UseFont = true;
            this.simpleButton_SelectFile.Location = new System.Drawing.Point(23, 55);
            this.simpleButton_SelectFile.Name = "simpleButton_SelectFile";
            this.simpleButton_SelectFile.Size = new System.Drawing.Size(138, 31);
            this.simpleButton_SelectFile.TabIndex = 3;
            this.simpleButton_SelectFile.Text = "选择文件";
            this.simpleButton_SelectFile.Click += new System.EventHandler(this.simpleButton_SelectFile_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(451, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 21);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "所选文件：";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.textEdit_Filename);
            this.groupControl1.Controls.Add(this.simpleButton_GetFtpServerFiles);
            this.groupControl1.Controls.Add(this.simpleButton_GetFtpServerFloders);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.memoEdit_FTPServerFiles);
            this.groupControl1.Controls.Add(this.simpleButton_GetFtpServerDirAndFiles);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.textEdit_FtpConnectFolder);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.textEdit_FTPPassword);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.textEdit_FTPAccount);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.textEdit_FTPServerIP);
            this.groupControl1.Controls.Add(this.simpleButton_DeleteFile);
            this.groupControl1.Controls.Add(this.simpleButton_DownloadFile);
            this.groupControl1.Controls.Add(this.simpleButton_UploadFile);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1257, 291);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "连接FTP服务器操作";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(527, 254);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(80, 21);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "文件名称：";
            // 
            // textEdit_Filename
            // 
            this.textEdit_Filename.Location = new System.Drawing.Point(624, 256);
            this.textEdit_Filename.Name = "textEdit_Filename";
            this.textEdit_Filename.Size = new System.Drawing.Size(612, 20);
            this.textEdit_Filename.TabIndex = 19;
            // 
            // simpleButton_GetFtpServerFiles
            // 
            this.simpleButton_GetFtpServerFiles.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_GetFtpServerFiles.Appearance.Options.UseFont = true;
            this.simpleButton_GetFtpServerFiles.Location = new System.Drawing.Point(378, 187);
            this.simpleButton_GetFtpServerFiles.Name = "simpleButton_GetFtpServerFiles";
            this.simpleButton_GetFtpServerFiles.Size = new System.Drawing.Size(229, 31);
            this.simpleButton_GetFtpServerFiles.TabIndex = 18;
            this.simpleButton_GetFtpServerFiles.Text = "获取FTP服务器文件";
            this.simpleButton_GetFtpServerFiles.Click += new System.EventHandler(this.simpleButton_GetFtpServerFiles_Click);
            // 
            // simpleButton_GetFtpServerFloders
            // 
            this.simpleButton_GetFtpServerFloders.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_GetFtpServerFloders.Appearance.Options.UseFont = true;
            this.simpleButton_GetFtpServerFloders.Location = new System.Drawing.Point(378, 141);
            this.simpleButton_GetFtpServerFloders.Name = "simpleButton_GetFtpServerFloders";
            this.simpleButton_GetFtpServerFloders.Size = new System.Drawing.Size(229, 31);
            this.simpleButton_GetFtpServerFloders.TabIndex = 17;
            this.simpleButton_GetFtpServerFloders.Text = "获取FTP服务器文件夹";
            this.simpleButton_GetFtpServerFloders.Click += new System.EventHandler(this.simpleButton_GetFtpServerFloders_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(625, 76);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(140, 21);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "FTP服务器的内容：";
            // 
            // memoEdit_FTPServerFiles
            // 
            this.memoEdit_FTPServerFiles.Location = new System.Drawing.Point(624, 100);
            this.memoEdit_FTPServerFiles.Name = "memoEdit_FTPServerFiles";
            this.memoEdit_FTPServerFiles.Size = new System.Drawing.Size(612, 144);
            this.memoEdit_FTPServerFiles.TabIndex = 7;
            // 
            // simpleButton_GetFtpServerDirAndFiles
            // 
            this.simpleButton_GetFtpServerDirAndFiles.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_GetFtpServerDirAndFiles.Appearance.Options.UseFont = true;
            this.simpleButton_GetFtpServerDirAndFiles.Location = new System.Drawing.Point(378, 87);
            this.simpleButton_GetFtpServerDirAndFiles.Name = "simpleButton_GetFtpServerDirAndFiles";
            this.simpleButton_GetFtpServerDirAndFiles.Size = new System.Drawing.Size(229, 31);
            this.simpleButton_GetFtpServerDirAndFiles.TabIndex = 16;
            this.simpleButton_GetFtpServerDirAndFiles.Text = "获取FTP服务器文件夹和文件";
            this.simpleButton_GetFtpServerDirAndFiles.Click += new System.EventHandler(this.simpleButton_GetFtpServerDirAndFiles_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(877, 44);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 21);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "FTP目录：";
            // 
            // textEdit_FtpConnectFolder
            // 
            this.textEdit_FtpConnectFolder.Location = new System.Drawing.Point(959, 46);
            this.textEdit_FtpConnectFolder.Name = "textEdit_FtpConnectFolder";
            this.textEdit_FtpConnectFolder.Size = new System.Drawing.Size(277, 20);
            this.textEdit_FtpConnectFolder.TabIndex = 15;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(629, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 21);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "密码：";
            // 
            // textEdit_FTPPassword
            // 
            this.textEdit_FTPPassword.Location = new System.Drawing.Point(683, 46);
            this.textEdit_FTPPassword.Name = "textEdit_FTPPassword";
            this.textEdit_FTPPassword.Size = new System.Drawing.Size(175, 20);
            this.textEdit_FTPPassword.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(378, 44);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 21);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "账号：";
            // 
            // textEdit_FTPAccount
            // 
            this.textEdit_FTPAccount.Location = new System.Drawing.Point(432, 45);
            this.textEdit_FTPAccount.Name = "textEdit_FTPAccount";
            this.textEdit_FTPAccount.Size = new System.Drawing.Size(175, 20);
            this.textEdit_FTPAccount.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(23, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 21);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "FTP服务器IP：";
            // 
            // textEdit_FTPServerIP
            // 
            this.textEdit_FTPServerIP.Location = new System.Drawing.Point(136, 45);
            this.textEdit_FTPServerIP.Name = "textEdit_FTPServerIP";
            this.textEdit_FTPServerIP.Size = new System.Drawing.Size(216, 20);
            this.textEdit_FTPServerIP.TabIndex = 9;
            // 
            // simpleButton_DeleteFile
            // 
            this.simpleButton_DeleteFile.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_DeleteFile.Appearance.Options.UseFont = true;
            this.simpleButton_DeleteFile.Location = new System.Drawing.Point(26, 197);
            this.simpleButton_DeleteFile.Name = "simpleButton_DeleteFile";
            this.simpleButton_DeleteFile.Size = new System.Drawing.Size(138, 31);
            this.simpleButton_DeleteFile.TabIndex = 8;
            this.simpleButton_DeleteFile.Text = "删除文件";
            this.simpleButton_DeleteFile.Click += new System.EventHandler(this.simpleButton_DeleteFile_Click);
            // 
            // simpleButton_DownloadFile
            // 
            this.simpleButton_DownloadFile.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_DownloadFile.Appearance.Options.UseFont = true;
            this.simpleButton_DownloadFile.Location = new System.Drawing.Point(26, 141);
            this.simpleButton_DownloadFile.Name = "simpleButton_DownloadFile";
            this.simpleButton_DownloadFile.Size = new System.Drawing.Size(138, 31);
            this.simpleButton_DownloadFile.TabIndex = 7;
            this.simpleButton_DownloadFile.Text = "下载文件";
            this.simpleButton_DownloadFile.Click += new System.EventHandler(this.simpleButton_DownloadFile_Click);
            // 
            // simpleButton_UploadFile
            // 
            this.simpleButton_UploadFile.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_UploadFile.Appearance.Options.UseFont = true;
            this.simpleButton_UploadFile.Location = new System.Drawing.Point(26, 87);
            this.simpleButton_UploadFile.Name = "simpleButton_UploadFile";
            this.simpleButton_UploadFile.Size = new System.Drawing.Size(138, 31);
            this.simpleButton_UploadFile.TabIndex = 6;
            this.simpleButton_UploadFile.Text = "上传文件";
            this.simpleButton_UploadFile.Click += new System.EventHandler(this.simpleButton_UploadFile_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.memoEdit_SelectedFile);
            this.groupControl2.Controls.Add(this.simpleButton_SelectFile);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(12, 343);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1257, 227);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "本地操作";
            // 
            // memoEdit_SelectedFile
            // 
            this.memoEdit_SelectedFile.Location = new System.Drawing.Point(451, 64);
            this.memoEdit_SelectedFile.Name = "memoEdit_SelectedFile";
            this.memoEdit_SelectedFile.Size = new System.Drawing.Size(785, 158);
            this.memoEdit_SelectedFile.TabIndex = 6;
            // 
            // FTPOperateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 582);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FTPOperateForm";
            this.Text = "FTPOperateForm";
            this.Load += new System.EventHandler(this.FTPOperateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Filename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_FTPServerFiles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FtpConnectFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FTPPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FTPAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_FTPServerIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_SelectedFile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_SelectFile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_UploadFile;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DownloadFile;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteFile;
        private DevExpress.XtraEditors.MemoEdit memoEdit_SelectedFile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit_FTPServerIP;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit_FTPPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit_FTPAccount;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEdit_FtpConnectFolder;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetFtpServerDirAndFiles;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit memoEdit_FTPServerFiles;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetFtpServerFloders;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetFtpServerFiles;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textEdit_Filename;
    }
}