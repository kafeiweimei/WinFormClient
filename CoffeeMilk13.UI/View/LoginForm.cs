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
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        #region 基础参数
        public static MainForm mainForm = null;
        public static FunctionModuleForm functionModuleForm = null;
        public static MenuSettingForm menuSettingForm = null;

        #endregion


        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
            ShowAppInfo();

            //加载轮播图片
            LoadImages();
           
        }


        /// <summary>
        /// 加载轮播图片
        /// </summary>
        private void LoadImages()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + @"\images\LoopImg\";


            FileInfo[] fileInfos = Utils.FolderFileHelper.GetDirectoryFiles(strPath, "*.jpg");

            foreach (var item in fileInfos)
            {
                imageSlider1.Images.Add(Image.FromFile(item.FullName));
            }

        }

        /// <summary>
        /// 显示客户端的信息
        /// </summary>
        private void ShowAppInfo()
        {
            string versionStyle = $"版本号：{Utils.AppAssemblyInfo.Version}";
            labelControl_Version.Text = versionStyle;

            string copyrightStyle = $"{Utils.AppAssemblyInfo.CompanyName }{Utils.AppAssemblyInfo.Copyright}";
            labelControl_Company.Text = copyrightStyle;

            string tmp = Utils.AppAssemblyInfo.Description;

        }

        private void simpleButton_Login_Click(object sender, EventArgs e)
        {

            //Utils.WinformUIHelper.OpenForm(ref mainForm);
            //this.Hide();

            Utils.WinformUIHelper.OpenForm(ref functionModuleForm);
            this.Hide();

            //Utils.WinformUIHelper.OpenForm(ref menuSettingForm);
            //this.Hide();


        }
    }
}