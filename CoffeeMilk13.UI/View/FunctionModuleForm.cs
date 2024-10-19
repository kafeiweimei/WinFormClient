using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            CreateMutiFuncModuleBtn();
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

        //创建多个功能模块按钮
        private void CreateMutiFuncModuleBtn()
        {
            //先清空所有示例控件
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 36; i++)
            {
                string btnName = $"代码添加功能模块{i}";
                string btnText = $"代码添加功能模块{i}";

                Bitmap bitmap = Properties.Resources.系统服务;
                if (i%2==0)
                {
                   bitmap = Properties.Resources.功能菜单;
                }
                
                CreateFuncModuleBtn(btnName,btnText,bitmap);
            }
        }

        //创建功能模块按钮
        private void CreateFuncModuleBtn(string btnName,string btnText,Bitmap bitmap)
        {
            SimpleButton simpleButton = new SimpleButton();
            simpleButton.Name = btnName;
            simpleButton.Text = btnText;
            simpleButton.ImageOptions.Image = bitmap;
            simpleButton.ImageOptions.ImageToTextAlignment = ImageAlignToText.TopCenter;
            int imgSize = 256;
            int fontSize = 40;
            simpleButton.Size = new Size(imgSize + fontSize, imgSize + fontSize);
            //simpleButton.Location = new Point(33, 33);
            simpleButton.Margin = new Padding(96);
            flowLayoutPanel1.Controls.Add(simpleButton);

            simpleButton.Click += (object sender, EventArgs e) =>
            {
                Utils.WinformUIHelper.OpenForm(ref mainForm);
                this.Hide();
            };

        }

        private void FunctionModuleForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }


    }
}