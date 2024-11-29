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
    public partial class RoleSettingForm : DevExpress.XtraEditors.XtraForm
    {
        #region 基础参数
        //当前选中的角色名称
        private string _CurSelectedRoleName = string.Empty;
        //需要加载显示的角色数据表
        private DataTable _RoleDataTable = new DataTable();
        //需加载的角色字段列表
        private List<string> _RoleFieldList = new List<string>() { "角色名称列表" };

        //当前选中的功能模块名称
        private string _CurSelectedFunctionModuleName = string.Empty;
        //需要加载显示的角色对应的功能模块名称数据表
        private DataTable _FunctionModuleNameListOfRoleDataTable = new DataTable();
        //需加载的角色对应的功能模块字段列表
        private List<string> _FunctionModuleFieldListOfRole = new List<string>() { "角色对应的功能模块列表" };

        //需要加载显示的功能模块对应的菜单名称数据表
        private DataTable _MenuNameListOfFunctionModuleDataTable = new DataTable();
        //需加载的功能模块对应的菜单字段列表
        private List<string> _MenuNameFieldListOfFunctionModule = new List<string>() { "功能模块对应的菜单列表" };


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

        public RoleSettingForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion

        }

        private void RoleSettingForm_Load(object sender, EventArgs e)
        {
            InitPara();
            AddFieldToDataTable(_RoleFieldList,ref _RoleDataTable);
            AddFieldToDataTable(_FunctionModuleFieldListOfRole, ref _FunctionModuleNameListOfRoleDataTable);
            AddFieldToDataTable(_MenuNameFieldListOfFunctionModule, ref _MenuNameListOfFunctionModuleDataTable);

            LoadAllRoleNameListInfo();
            LoadAllFunctionModuleListOfRole();
            LoadAllMenuNameListOfFunctionModule(_CurSelectedFunctionModuleName);

            //主动调用一次
            LoadFunctionModuleListOfRole(_CurSelectedRoleName);
        }

        private void RoleSettingForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();

        }

        /// <summary>
        /// 参数初始化
        /// </summary>
        private void InitPara()
        {
            //禁用编辑
            treeList_RoleNameList.OptionsBehavior.Editable = false;
            treeList_FunctionModuleListOfRole.OptionsBehavior.Editable = false;
            treeList_MenuListOfFunctionModule.OptionsBehavior.Editable = false;

            //禁止拖拽节点
            treeList_RoleNameList.OptionsDragAndDrop.ExpandNodeOnDrag = false;
            treeList_FunctionModuleListOfRole.OptionsDragAndDrop.ExpandNodeOnDrag = false;
            treeList_MenuListOfFunctionModule.OptionsDragAndDrop.ExpandNodeOnDrag = false;

            //显示行号
            TreeListHelper.SetTreeListLineNumbers(treeList_RoleNameList);
            TreeListHelper.SetTreeListLineNumbers(treeList_FunctionModuleListOfRole);
            TreeListHelper.SetTreeListLineNumbers(treeList_MenuListOfFunctionModule);

            // 设置选中行的样式
            TreeListHelper.SetTreeListRowSelectedEffect(treeList_RoleNameList);

            //设置复选框选中事件
            TreeListHelper.SetTreeListCheckBoxSelectedEvent(treeList_FunctionModuleListOfRole);
            TreeListHelper.SetTreeListCheckBoxSelectedEvent(treeList_MenuListOfFunctionModule);

        }

        /// <summary>
        /// 给功能模块数据表添加字段名称
        /// </summary>
        /// <param name="dt">数据表</param>
        private void AddFieldToDataTable(List<string> fieldList, ref DataTable dt)
        {
            DataTableHelper.AddFieldNameToDataTable(fieldList, ref dt);
        }

        /// <summary>
        /// 加载所有角色名称列表内容
        /// </summary>
        private void LoadAllRoleNameListInfo()
        {
            _RoleDataTable?.Clear();
            DataTableHelper.AddOneColumnDatasToDataTable2(Global.Global_Parameter.tmpRoleDic.Keys.ToList<string>(),
                   _RoleFieldList[0], ref _RoleDataTable);

            treeList_RoleNameList.DataSource = _RoleDataTable;
            treeList_RoleNameList.RefreshDataSource();
            treeList_RoleNameList.Refresh();
        }

        /// <summary>
        /// 加载角色对应的所有功能模块列表
        /// </summary>
        private void LoadAllFunctionModuleListOfRole()
        {
            _FunctionModuleNameListOfRoleDataTable?.Clear();
            DataTableHelper.AddOneColumnDatasToDataTable2(Global.Global_Parameter.tmpFuncModuleDic.Keys.ToList<string>(),
                    _FunctionModuleFieldListOfRole[0], ref _FunctionModuleNameListOfRoleDataTable);

            treeList_FunctionModuleListOfRole.DataSource = _FunctionModuleNameListOfRoleDataTable;
            treeList_FunctionModuleListOfRole.RefreshDataSource();
            treeList_FunctionModuleListOfRole.Refresh();
        }

        /// <summary>
        /// 加载功能模块名称对应的所有菜单列表
        /// </summary>
        /// <param name="functionModuleName">功能模块名称</param>
        private void LoadAllMenuNameListOfFunctionModule(string functionModuleName)
        {
            if (string.IsNullOrWhiteSpace(functionModuleName)) return;

            if (!Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName) ||
                Global.Global_Parameter.tmpFuncModuleDic[functionModuleName] == null) return;

            if (_MenuNameListOfFunctionModuleDataTable.Rows.Count<=0)
            {
                DataTableHelper.AddOneColumnDatasToDataTable2(Global.Global_Parameter.tmpMenuDic.Keys.ToList<string>(),
               _MenuNameFieldListOfFunctionModule[0], ref _MenuNameListOfFunctionModuleDataTable);
            }

            treeList_MenuListOfFunctionModule.DataSource = _MenuNameListOfFunctionModuleDataTable;
            treeList_MenuListOfFunctionModule.RefreshDataSource();
            treeList_MenuListOfFunctionModule.Refresh();
        }


        /// <summary>
        /// 加载角色对应的功能模块列表
        /// </summary>
        /// <param name="roleName"></param>
        private void LoadFunctionModuleListOfRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return;

            _FunctionModuleNameListOfRoleDataTable?.Clear();
            LoadAllFunctionModuleListOfRole();

            if (!Global.Global_Parameter.tmpRoleDic.ContainsKey(roleName) || Global.Global_Parameter.tmpRoleDic[roleName] == null)
            {
                for (int i = 0; i < treeList_FunctionModuleListOfRole.Nodes.Count; i++)
                {
                    treeList_FunctionModuleListOfRole.Nodes[i].CheckState = CheckState.Unchecked;
                }
            }
            else
            {
                for (int i = 0; i < Global.Global_Parameter.tmpRoleDic[roleName].Count; i++)
                {
                    string curRoleFunctionModuleName = Global.Global_Parameter.tmpRoleDic[roleName].ElementAt(i).Key;

                    for (int j = 0; j < treeList_FunctionModuleListOfRole.Nodes.Count; j++)
                    {
                        string curFunctionModuleName = treeList_FunctionModuleListOfRole.Nodes[j].GetDisplayText(0);

                        if (curFunctionModuleName.Equals(curRoleFunctionModuleName))
                        {
                            treeList_FunctionModuleListOfRole.Nodes[j].CheckState = CheckState.Checked;

                        }
                    }

                }
            }
           
        }


        /// <summary>
        /// 加载功能模块名称对应的菜单列表
        /// </summary>
        /// <param name="roleName">功能模块名称</param>
        /// <param name="functionModuleName">功能模块名称</param>
        private void LoadMenuNameListOfFunctionModule(string roleName,string functionModuleName)
        {
            if (string.IsNullOrEmpty(roleName) ||string.IsNullOrWhiteSpace(functionModuleName)) return;

            _MenuNameListOfFunctionModuleDataTable?.Clear();

            LoadAllMenuNameListOfFunctionModule(functionModuleName);

            if (!Global.Global_Parameter.tmpRoleDic.ContainsKey(roleName) || Global.Global_Parameter.tmpRoleDic[roleName] == null ||
                !Global.Global_Parameter.tmpRoleDic[roleName].ContainsKey(functionModuleName) ||
                Global.Global_Parameter.tmpRoleDic[roleName][functionModuleName] == null)
            {
                for (int i = 0; i < treeList_MenuListOfFunctionModule.Nodes.Count; i++)
                {
                    treeList_MenuListOfFunctionModule.Nodes[i].CheckState = CheckState.Unchecked;
                }
            }
            else
            {
                for (int i = 0; i < Global.Global_Parameter.tmpRoleDic[roleName][functionModuleName].Count; i++)
                {
                    string curRoleFunctionModuleMenuName = Global.Global_Parameter.tmpRoleDic[roleName][functionModuleName].ElementAt(i).Key;
                    for (int j = 0; j < treeList_MenuListOfFunctionModule.Nodes.Count; j++)
                    {
                        string curMenuName = treeList_MenuListOfFunctionModule.Nodes[j].GetDisplayText(0);
                        if (curRoleFunctionModuleMenuName.Equals(curMenuName))
                        {
                            treeList_MenuListOfFunctionModule.Nodes[j].CheckState = CheckState.Checked;
                        }
                    }
                }
            }
           
        }

        private void simpleButton_Modify_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton_Delete_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton_Save_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton_Add_Click(object sender, EventArgs e)
        {
            string roleName = textEdit_RoleName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                //将角色名称添加到字典中
                if (Global.Global_Parameter.tmpRoleDic.ContainsKey(roleName))
                {
                    PopupMessage.ShowWarning($"已存在【{roleName}】角色，请重新输入一个唯一的角色名称");
                    return;
                }

                ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpRoleDic, roleName, null);
                LoadAllRoleNameListInfo();

            }
        }

        private void treeList_RoleNameList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //上一个选择的节点
            if (e.OldNode != null)
            {
                _CurSelectedRoleName = string.Empty;
                //GetDisplayText：获取节点显示的文本
                //PopupMessage.ShowInfo($"上一个节点ID：{e.OldNode.Id},节点名称：{e.OldNode.GetDisplayText(0)}");
            }
            //当前选择的节点
            if (e.Node != null)
            {
                //PopupMessage.ShowInfo($"节点ID：{e.Node.Id},节点名称：{e.Node.GetDisplayText(0)}");

                _CurSelectedRoleName = e.Node.GetDisplayText(0);
                LoadFunctionModuleListOfRole(e.Node.GetDisplayText(0));
                

            }
        }

        private void treeList_FunctionModuleListOfRole_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //上一个选择的节点
            if (e.OldNode != null)
            {
                _CurSelectedFunctionModuleName = string.Empty;
                //GetDisplayText：获取节点显示的文本
                //PopupMessage.ShowInfo($"上一个节点ID：{e.OldNode.Id},节点名称：{e.OldNode.GetDisplayText(0)}");
            }
            //当前选择的节点
            if (e.Node != null)
            {
                //PopupMessage.ShowInfo($"节点ID：{e.Node.Id},节点名称：{e.Node.GetDisplayText(0)}");

                _CurSelectedFunctionModuleName = e.Node.GetDisplayText(0);
                LoadMenuNameListOfFunctionModule(_CurSelectedRoleName, e.Node.GetDisplayText(0));

            }
        }


    }
}