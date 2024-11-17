using CoffeeMilk13.UI.Utils;
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
    public partial class MainForm : DevExpress.XtraBars.TabForm
    {
        #region 基础参数
        //功能模块窗体
        public static FunctionModuleForm functionModuleForm = null;
        //当前选中的功能模块名称
        private string curSelectedFuncModuleName = string.Empty;
        //当前选中的功能菜单名称
        private string curSelectedFuncMenuName = string.Empty;

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


        public MainForm()
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormParaSetting();
            FunctionModuleMenu();
            ListMenuOfCurSelectedFuncModule();

            CreateNewTagPageEvent();
            CloseCurSelectedTagPageEvent();
        }

        private void tabFormControl1_Click(object sender, EventArgs e)
        {
           
        }



        /// <summary>
        /// 窗体参数设置
        /// </summary>
        private void FormParaSetting()
        {
            //设置窗体最大化
            this.WindowState = FormWindowState.Maximized;
            #region TabFormControl参数设置

            //是否允许拖动标签页
            tabFormControl1.AllowMoveTabs = true;
            //是否允许将标签页拖出当前窗口
            tabFormControl1.AllowMoveTabsToOuterForm = false;
            //是否允许标签页排序动画(主要用于设备新能差的情况可以关闭，也可全局设置)
            tabFormControl1.AllowTabAnimation = true;
            //标签栏左侧与窗体的间距
            tabFormControl1.LeftTabIndent = 36;
            //标签栏右侧与窗体的间距
            tabFormControl1.LeftTabIndent = 36;
            //设置标签页的最大宽度
            tabFormControl1.MaxTabWidth = 200;
            //设置标签页的最小宽度(<100的情况下还是默认为100，主要是用于预留图标和关闭按钮使用)
            tabFormControl1.MinTabWidth = 0;
            //是否显示顶部的标签添加按钮
            tabFormControl1.ShowAddPageButton = false;
            //是否显示顶部的标签名称（用于处理标签名称非常长无法再标签内显示完全）
            tabFormControl1.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;

            ////标签页左侧、右侧、标题后的内容连接(可使用代码进行控制)
            //var leftItemLinks = tabFormControl1.TabLeftItemLinks;
            //var rightItemLinks = tabFormControl1.TabRightItemLinks;
            //var titleItemLinks = tabFormControl1.TitleItemLinks;


            //将标签页清空
            tabFormControl1.Pages.Clear();
            //是否显示所有标签页的关闭按钮
            tabFormControl1.ShowTabCloseButtons = false;

            #endregion


            #region BarEditItem组件参数设置(跟随窗体调整自动适配)
            //BarEditItem的参考链接【https://docs.devexpress.com/WindowsForms/DevExpress.XtraBars.BarEditItem.AutoFillWidth】
            bar2.OptionsBar.MultiLine = false;
            bar2.OptionsBar.UseWholeRow = true;
            barEditItem_Message.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Standard;
            barEditItem_Message.AutoFillWidth = true;
            barEditItem_Message.MaxWidth = this.Width - 60;
            barEditItem_Message.EditValue = "这里显示一些提示信息";

            repositoryItemTextEdit3.Appearance.ForeColor = Color.Orange;
            #endregion
        }

        /// <summary>
        /// 功能模块菜单
        /// </summary>
        private void FunctionModuleMenu()
        {
            barListItem_FunctionModule.Strings.Add("功能模块1");
            barListItem_FunctionModule.Strings.Add("功能模块2");
            barListItem_FunctionModule.Strings.Add("系统管理");
        }

        /// <summary>
        /// 当前选中的功能模块对应的列表菜单
        /// </summary>
        private void ListMenuOfCurSelectedFuncModule()
        {
            barListItem_FunctionList.Strings.Add("功能模块设置");
            barListItem_FunctionList.Strings.Add("菜单设置");
            barListItem_FunctionList.Strings.Add("角色设置");
            barListItem_FunctionList.Strings.Add("权限设置");
            barListItem_FunctionList.Strings.Add("其他设置");
        }

        /// <summary>
        /// 创建新标签页事件
        /// </summary>
        private void CreateNewTagPageEvent()
        {
            tabFormControl1.PageCreated += (sender, e) =>
            {
                switch (curSelectedFuncMenuName)
                {
                    case "功能模块设置":
                        e.Page.Text = "功能模块设置";
                        ShowFormOfPage(new FunctionModuleSettingForm(), e.Page);
                        break;
                    case "菜单设置":
                        e.Page.Text = "菜单设置";
                        ShowFormOfPage(new MenuSettingForm(), e.Page);
                        break;
                    case "角色设置":
                        e.Page.Text = "角色设置";
                        ShowFormOfPage(new RoleSettingForm(), e.Page);
                        break;
                    case "权限设置":
                        e.Page.Text = "权限";
                        ShowFormOfPage(new AuthoritySettingForm(), e.Page);
                        break;
                    default:
                        //XtraMessageBox.Show($"当前没配置:{e.Page} 菜单");
                        break;
                }

                ////1-根据窗体的命名空间和名称创建该窗体(比如：ChartForm窗体的命名空间是Dev_WinfromTest)
                //var form = Utils.WinformUIHelper.LoadForm("CoffeeMilk13.UI.View.MenuSettingForm");

                ////2-打开该窗体
                //Utils.WinformUIHelper.OpenForm(ref form);
            };
        }



        /// <summary>
        /// 关闭当前选中标签页事件
        /// </summary>
        private void CloseCurSelectedTagPageEvent()
        {
            tabFormControl1.PageClosed += (sender, e) =>
            {
                string curSelectedPageTitle = e.Page.Text;
            };
        }


        /// <summary>
        /// 在标签页显示传入的窗体
        /// </summary>
        /// <typeparam name="TForm">窗体类型</typeparam>
        /// <param name="form">窗体</param>
        /// <param name="tabFormPage">标签页</param>
        private void ShowFormOfPage<TForm>(TForm form, DevExpress.XtraBars.TabFormPage tabFormPage) where TForm : Form, new()
        {
            if (form == null || form.IsDisposed)
            {
                form = new TForm();
            }

            //设置窗体不会被移动
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Parent = tabFormPage.ContentContainer;
            form.Dock= DockStyle.Fill;
            form.Show();

        }

        /// <summary>
        /// 功能模块的单个内容选定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barListItem_FunctionModule_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarListItem barListItem = (DevExpress.XtraBars.BarListItem)sender;
            string curSelectedItemName = barListItem.Strings[e.Index];
            //XtraMessageBox.Show($"当前选中的模块是：{curSelectedItemName}");
            barListItem_FunctionList.Caption = curSelectedItemName;
            curSelectedFuncModuleName = curSelectedItemName;
        }

        /// <summary>
        /// 功能列表内容选定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barListItem_FunctionList_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarListItem barListItem = (DevExpress.XtraBars.BarListItem)sender;
            string curSelectedItemtText = barListItem.Strings[e.Index];
            //MessageBox.Show($"当前选中的功能是：{curSelectedItemtText}");
            curSelectedFuncMenuName = curSelectedItemtText;

            //新增一个标签页面(不包含才增加)
            int tabPageCount = tabFormControl1.Pages.Count;
            if (tabPageCount > 0)
            {
                bool existCurSelectedItemText = false;
                for (int i = 0; i < tabPageCount; i++)
                {
                    DevExpress.XtraBars.TabFormPage tabFormPage = tabFormControl1.Pages[i];
                    if (tabFormPage.Text.Equals(curSelectedItemtText))
                    {
                        existCurSelectedItemText = true;
                        tabFormControl1.SelectedPage = tabFormPage;
                        break;
                    }
                }

                if (existCurSelectedItemText==false)
                {
                    tabFormControl1.AddNewPage();
                }
            }
            else
            {
                tabFormControl1.AddNewPage();
            }
           
            
           
        }

        /// <summary>
        /// 清空按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem_ClearAllTabPage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult mark = XtraMessageBox.Show($"是否确定关闭当前已经打开的所有页面？","系统提示",MessageBoxButtons.OKCancel);
            if (mark.Equals(DialogResult.OK))
            {
                //清空所有已经打开的页面
                tabFormControl1.Pages.Clear();
            }
        }

        /// <summary>
        /// 当前选中页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabFormControl1_SelectedPageChanged(object sender, DevExpress.XtraBars.TabFormSelectedPageChangedEventArgs e)
        {
            if (e.Page == null || e.PrevPage==null)
            {
                return;
            }
            //注意：需要界面初始化的时候全局配置关闭所有标签页的关闭按钮和当前选中页的关闭按钮显示
            //关闭上一个标签页的关闭按钮
            e.PrevPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            //显示当前选中标签页的关闭按钮
            e.Page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
        }

        /// <summary>
        /// 重载窗体大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        /// <summary>
        /// 功能模块按钮双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barListItem_FunctionModule_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //返回功能模块窗口
            Utils.WinformUIHelper.OpenForm(ref functionModuleForm);
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool isExit = PopupMessage.ShowAskQuestion("确定关闭系统？");
            if (isExit)
            {
                Application.Exit();
            }
           
        }
    }
}