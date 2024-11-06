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
    public partial class FunctionModuleSettingForm : DevExpress.XtraEditors.XtraForm
    {
        #region 基础参数
        //需要加载显示的功能模块数据表
        private DataTable _FunctionModuleDataTable = new DataTable();
        //需加载的功能模块字段列表
        private List<string> _FunctionModuleFieldList = new List<string>() { "功能模块名称列表" };

        //需要加载显示的功能模块对应的菜单名称数据表
        private DataTable _MenuNameListOfFunctionModuleDataTable = new DataTable();
        //需加载的模块对应的菜单字段列表
        private List<string> _MenuNameFieldListOfFunctionModule = new List<string>() { "功能模块对应的菜单名称列表" };


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

        public FunctionModuleSettingForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion
        }


        private void FunctionModuleSettingsForm_Load(object sender, EventArgs e)
        {
            InitPara();
            AddFieldToDataTable(ref _FunctionModuleDataTable);
            LoadFunctionModuleNameListInfo();

        }

        private void FunctionModuleSettingsForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }



        #region 私有方法

        /// <summary>
        /// 参数初始化
        /// </summary>
        private void InitPara()
        {
            treeList_MenuNameListOfFunctionModule.OptionsView.ShowCheckBoxes = true;
        }

        /// <summary>
        /// 给功能模块数据表添加字段名称
        /// </summary>
        /// <param name="dt">数据表</param>
        private void AddFieldToDataTable(ref DataTable dt)
        {
            DataTableHelper.AddFieldNameToDataTable(_FunctionModuleFieldList, ref dt);
        }

        /// <summary>
        /// 加载功能模块名称列表内容
        /// </summary>
        private void LoadFunctionModuleNameListInfo()
        {
            _FunctionModuleDataTable?.Clear();
            DataTableHelper.AddOneColumnDatasToDataTable2(Global.Global_Parameter.tmpFuncModuleDic.Keys.ToList<string>(),
                _FunctionModuleFieldList[0], ref _FunctionModuleDataTable);
            
            treeList_FuntionModuleNameList.DataSource = _FunctionModuleDataTable;
        }

        //加载功能模块名称对应的菜单列表
        private void LoadMenuNameListOfFunctionModuleName(string functionModuleName)
        {
            if (string.IsNullOrWhiteSpace(functionModuleName)) return;
           
            _MenuNameListOfFunctionModuleDataTable?.Clear();

            if (!Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName) ||
               Global.Global_Parameter.tmpFuncModuleDic[functionModuleName]==null) return;
           
            DataTableHelper.AddOneColumnDatasToDataTable2(Global.Global_Parameter.tmpFuncModuleDic[functionModuleName].Keys.ToList<string>(),
                _MenuNameFieldListOfFunctionModule[0], ref _MenuNameListOfFunctionModuleDataTable);

            treeList_MenuNameListOfFunctionModule.DataSource = _MenuNameListOfFunctionModuleDataTable;
        }


        #endregion

        private void simpleButton_Add_Click(object sender, EventArgs e)
        {
            string functionModuleName = textEdit_FunctionModuleName.Text;
            if (!string.IsNullOrWhiteSpace(functionModuleName))
            {
                //将功能菜单名称添加到字典中
                if (Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName))
                {
                    PopupMessage.ShowWarning($"已存在【{functionModuleName}】模块，请重新输入一个唯一的模块名称");
                    return;
                }

                ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpFuncModuleDic, functionModuleName,null);
                LoadFunctionModuleNameListInfo();



            }
        }

        private void treeList_FuntionModuleNameList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //上一个选择的节点
            if (e.OldNode != null)
            {
                //GetDisplayText：获取节点显示的文本
                //PopupMessage.ShowInfo($"上一个节点ID：{e.OldNode.Id},节点名称：{e.OldNode.GetDisplayText(0)}");
            }
            //当前选择的节点
            if (e.Node != null)
            {
                //PopupMessage.ShowInfo($"节点ID：{e.Node.Id},节点名称：{e.Node.GetDisplayText(0)}");
                LoadMenuNameListOfFunctionModuleName(e.Node.GetDisplayText(0));
            }
        }
    }
}