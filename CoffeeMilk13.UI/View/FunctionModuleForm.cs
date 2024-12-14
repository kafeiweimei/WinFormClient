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
    public partial class FunctionModuleForm : DevExpress.XtraEditors.XtraForm
    {
        #region 基础参数
        public static MainForm mainForm = null;

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

        public FunctionModuleForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            x = Width;
            y = Height;
            setTag(this);

            #endregion
        }

        private void FunctionModuleForm_Load(object sender, EventArgs e)
        {
            FormParaSetting();

            LoadFuncModuleOfSettings();

            ShowAppInfo();
        }

        /// <summary>
        /// 窗体参数设置
        /// </summary>
        private void FormParaSetting()
        {
            //设置窗体最大化
            this.WindowState = FormWindowState.Maximized;

            #region flowLayoutPanel设置

            //设置流布局面板填充窗体
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Margin= new Padding(66);

            #endregion

        }

        /// <summary>
        /// 创建多个功能模块按钮【手动添加测试】
        /// </summary>
        private void CreateMutiFuncModuleBtn()
        {
            //先清空所有示例控件
            flowLayoutPanel1.Controls.Clear();

            //手动添加
            for (int i = 0; i < 36; i++)
            {
                string btnName = $"代码添加功能模块{i}";
                string btnText = $"代码添加功能模块{i}";

                Image image = Properties.Resources.系统服务;
                if (i%2==0)
                {
                    image = Properties.Resources.功能菜单;
                }
                
                CreateFuncModuleBtn(btnName,btnText, image);
            }
        }

        /// <summary>
        /// 加载配置的功能模块
        /// </summary>
        private void LoadFuncModuleOfSettings()
        {

            if (Global.Global_Parameter.tmpFuncModuleDic != null && Global.Global_Parameter.tmpFuncModuleDic?.Count > 0)
            {
                //先清空所有示例控件
                flowLayoutPanel1.Controls.Clear();

                //加载配置好的功能模块
                for (int i = 0; i < Global.Global_Parameter.tmpFuncModuleDic.Count; i++)
                {
                    string btnName = Global.Global_Parameter.tmpFuncModuleDic.ElementAt(i).Key;
                    string btnText = Global.Global_Parameter.tmpFuncModuleDic.ElementAt(i).Key;
                    Image image = Properties.Resources.bubble3d_32x32;
                    if (Global.Global_Parameter.tmpFuncModuleAndImgDic != null && Global.Global_Parameter.tmpFuncModuleAndImgDic?.Count > 0 &&
                        Global.Global_Parameter.tmpFuncModuleAndImgDic.ContainsKey(btnName))
                    {
                        string imageName = Global.Global_Parameter.tmpFuncModuleAndImgDic[btnName];
                        image = GetImageObjByImageName(imageName);
                    }
                   
                    CreateFuncModuleBtn(btnName, btnText, image);
                }
            }
            else
            {
                //直接加载界面设计的控件
            }

        }

        /// <summary>
        /// 根据图片名称获取到图片对象
        /// </summary>
        /// <param name="imageName">图片名称</param>
        /// <returns></returns>
        private Image GetImageObjByImageName(string imageName)
        {
            if (string.IsNullOrEmpty(imageName)) return null;
            string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\FuncModuleImg");
            string imgPathAndName = $"{resourcesPath}\\{imageName}.png";
            Image imageObj = Image.FromFile(imgPathAndName);

            return imageObj;
            
        }

        /// <summary>
        /// 创建功能模块按钮
        /// </summary>
        /// <param name="btnName">功能模块名称【必须唯一】</param>
        /// <param name="btnText">功能模块显示名称</param>
        /// <param name="image">功能模块显示图片</param>
        private void CreateFuncModuleBtn(string btnName,string btnText,Image image)
        {
            SimpleButton simpleButton = new SimpleButton();
            simpleButton.Name = btnName;
            simpleButton.Text = btnText;
            simpleButton.ImageOptions.Image = image;
            simpleButton.ImageOptions.ImageToTextAlignment = ImageAlignToText.TopCenter;
            int imgSize = 256;
            int fontSize = 40;
            simpleButton.Size = new Size(imgSize + fontSize, imgSize + fontSize);
            //simpleButton.Location = new Point(33, 33);
            simpleButton.Margin = new Padding(96);
            flowLayoutPanel1.Controls.Add(simpleButton);

            simpleButton.Click += (object sender, EventArgs e) =>
            {
                Global.Global_Parameter.curSelectedFuncModuleName = simpleButton.Text;
                Utils.WinformUIHelper.OpenForm(ref mainForm);
                this.Hide();
            };

        }

        /// <summary>
        /// 显示客户端的信息
        /// </summary>
        private void ShowAppInfo()
        {
            string info = $"版本号：{Utils.AppAssemblyInfo.Version} 版权：{Utils.AppAssemblyInfo.CompanyName }  {Utils.AppAssemblyInfo.Copyright}";

            barStaticItem1.Caption = info;

            barStaticItem1.ItemClick += OpenUrlLink;


        }

        private void OpenUrlLink(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = $"http://{Utils.AppAssemblyInfo.CompanyName}";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void FunctionModuleForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        private void FunctionModuleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool isExit = PopupMessage.ShowAskQuestion("确定关闭系统？");
            if (isExit)
            {
                try
                {
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    
                }
            }

        }
    }
}