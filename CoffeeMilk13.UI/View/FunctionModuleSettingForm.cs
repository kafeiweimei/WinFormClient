using CoffeeMilk13.UI.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class FunctionModuleSettingForm : DevExpress.XtraEditors.XtraForm
    {
        #region 基础参数
        //当前选中的功能模块名称
        private string _CurSelectedFunctionModuleName = string.Empty;
        //需要加载显示的功能模块数据表
        private DataTable _FunctionModuleDataTable = new DataTable();
        //需加载的功能模块字段列表
        private List<string> _FunctionModuleFieldList = new List<string>() { "功能模块名称列表" };

        //当前选中的功能模块图片名称
        private string _CurSelectedFuncModuleImgName = string.Empty;

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
            LoadFunctionModuleImages();
            AddFieldToDataTable(ref _FunctionModuleDataTable);
            LoadFunctionModuleNameListInfo();
            LoadAllMenuNameListOfFunctionModuleName();

            //主动调用一次
            LoadMenuNameListOfFunctionModuleName(_CurSelectedFunctionModuleName);
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
            //禁用编辑
            treeList_FuntionModuleNameList.OptionsBehavior.Editable = false;
            treeList_MenuNameListOfFunctionModule.OptionsBehavior.Editable = false;

            //禁止拖拽节点
            treeList_FuntionModuleNameList.OptionsDragAndDrop.ExpandNodeOnDrag = false;
            treeList_MenuNameListOfFunctionModule.OptionsDragAndDrop.ExpandNodeOnDrag = false;

            //显示行号
            TreeListHelper.SetTreeListLineNumbers(treeList_FuntionModuleNameList);
            TreeListHelper.SetTreeListLineNumbers(treeList_MenuNameListOfFunctionModule);

            // 设置选中行的样式
            TreeListHelper.SetTreeListRowSelectedEffect(treeList_FuntionModuleNameList);
            //SetTreeListRowSelectedEffect(treeList_MenuNameListOfFunctionModule);


            treeList_MenuNameListOfFunctionModule.OptionsView.ShowCheckBoxes = true;
            TreeListHelper.SetTreeListCheckBoxSelectedEvent(treeList_MenuNameListOfFunctionModule);

        }

        /// <summary>
        /// 加载功能模块的图片内容
        /// </summary>
        private void LoadFunctionModuleImages()
        {
            // 创建图像列表
            ImageList imageList = new ImageList();
            int imgLength = 32;
            int imgWidth = 32;
            imageList.ImageSize = new Size(imgLength, imgWidth); // 设置图像大小
            string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\FuncModuleImg");

            // 检查资源文件夹是否存在
            if (Directory.Exists(resourcesPath))
            {
                // 获取所有图像文件
                string[] imageFiles = Directory.GetFiles(resourcesPath, "*.png"); // 只加载 PNG 文件，您可以根据需要更改扩展名

                foreach (string imagePath in imageFiles)
                {
                    // 获取文件名（不带路径和扩展名）
                    string fileName = Path.GetFileNameWithoutExtension(imagePath);
                    // 添加图像到图像列表
                    using (Image originalImage = Image.FromFile(imagePath))
                    {
                        // 创建放大的图像
                        Image resizedImage = new Bitmap(originalImage, new Size(imgLength, imgWidth)); // 设置图片像素
                        imageList.Images.Add(fileName, resizedImage);
                    }
                    // 添加项到 ImageListBoxControl
                    imageListBoxControl1.Items.Add(new ImageListBoxItem(fileName, fileName));
                }

                // 设置 ImageListBoxControl 的图像列表
                imageListBoxControl1.ImageList = imageList;

                // 确保每个项都能显示图像
                foreach (var item in imageListBoxControl1.Items)
                {
                    var imageItem = item as ImageListBoxItem;
                    if (imageItem != null)
                    {
                        imageItem.ImageIndex = imageList.Images.IndexOfKey(imageItem.Value.ToString());
                    }
                }
            }
            else
            {
                PopupMessage.ShowError("功能模块的图标文件夹不存在");
            }
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
            treeList_FuntionModuleNameList.RefreshDataSource();
            treeList_FuntionModuleNameList.Refresh();

        }

        /// <summary>
        /// 加载功能模块名称对应的所有菜单列表
        /// </summary>
        private void LoadAllMenuNameListOfFunctionModuleName()
        {
            _MenuNameListOfFunctionModuleDataTable?.Clear();
           
            DataTableHelper.AddOneColumnDatasToDataTable2(Global.Global_Parameter.tmpMenuDic.Keys.ToList<string>(),
                _MenuNameFieldListOfFunctionModule[0], ref _MenuNameListOfFunctionModuleDataTable);

            treeList_MenuNameListOfFunctionModule.DataSource = _MenuNameListOfFunctionModuleDataTable;
            treeList_MenuNameListOfFunctionModule.Refresh();
        }

        /// <summary>
        /// 加载功能模块名称对应的菜单列表
        /// </summary>
        /// <param name="functionModuleName">功能模块名称</param>
        private void LoadMenuNameListOfFunctionModuleName(string functionModuleName)
        {
            if (string.IsNullOrWhiteSpace(functionModuleName)) return;

            _MenuNameListOfFunctionModuleDataTable?.Clear();
            LoadAllMenuNameListOfFunctionModuleName();

            if (!Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName) ||
               Global.Global_Parameter.tmpFuncModuleDic[functionModuleName] == null)
            {
                for (int i = 0; i < treeList_MenuNameListOfFunctionModule.Nodes.Count; i++)
                {
                    treeList_MenuNameListOfFunctionModule.Nodes[i].CheckState = CheckState.Unchecked;
                }
            }
            else
            {
                for (int i = 0; i < Global.Global_Parameter.tmpFuncModuleDic[functionModuleName].Count; i++)
                {
                    string curFunctionModuleMenuName = Global.Global_Parameter.tmpFuncModuleDic[functionModuleName].ElementAt(i).Key;
                    for (int j = 0; j < treeList_MenuNameListOfFunctionModule.Nodes.Count; j++)
                    {
                        string curMenuName = treeList_MenuNameListOfFunctionModule.Nodes[j].GetDisplayText(0);
                        if (curFunctionModuleMenuName.Equals(curMenuName))
                        {
                            treeList_MenuNameListOfFunctionModule.Nodes[j].CheckState = CheckState.Checked;
                        }
                    }
                }
            }
           
        }

        /// <summary>
        /// 根据配置内容让让imageListBoxControl组件的图片被选中
        /// </summary>
        private void SelectedImageListBoxControlItemBySetting()
        {
            if (Global.Global_Parameter.tmpFuncModuleAndImgDic!=null && Global.Global_Parameter.tmpFuncModuleAndImgDic?.Count>0 &&
                !string.IsNullOrEmpty(_CurSelectedFunctionModuleName))
            {
                string funcModuleNameImg = Global.Global_Parameter.tmpFuncModuleAndImgDic[_CurSelectedFunctionModuleName];
                SelectedImageListBoxControlItemByName(funcModuleNameImg);
            }
        }

        /// <summary>
        /// 根据图片名称让imageListBoxControl组件的图片被选中
        /// </summary>
        /// <param name="imageName">图片名称</param>
        private void SelectedImageListBoxControlItemByName(string imageName)
        {
            // 遍历所有项，查找匹配的项并选中
            foreach (var item in imageListBoxControl1.Items)
            {
                var imageItem = item as ImageListBoxItem;
                if (imageItem != null && imageItem.Value.ToString() == imageName)
                {
                    imageListBoxControl1.SelectedItem = imageItem; // 选中该项
                    break; // 找到后退出循环
                }
            }
        }

        #endregion

        private void simpleButton_Add_Click(object sender, EventArgs e)
        {
            string functionModuleName = textEdit_FunctionModuleName.Text.Trim();
            string funcModuleNameImg = _CurSelectedFuncModuleImgName;
            if (!string.IsNullOrWhiteSpace(functionModuleName) && !string.IsNullOrEmpty(funcModuleNameImg))
            {
                //将功能菜单名称添加到字典中
                if (Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName) ||
                    Global.Global_Parameter.tmpFuncModuleAndImgDic.ContainsKey(functionModuleName))
                {
                    PopupMessage.ShowWarning($"已存在【{functionModuleName}】模块，请重新输入一个唯一的模块名称");
                    return;
                }

                ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpFuncModuleDic, functionModuleName,null);
                //将功能模块的图片添加到字典中
                ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpFuncModuleAndImgDic, functionModuleName, funcModuleNameImg);

                LoadFunctionModuleNameListInfo();

            }
        }

        private void simpleButton_Modify_Click(object sender, EventArgs e)
        {
            string functionModuleName = textEdit_FunctionModuleName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(functionModuleName))
            {
                //将功能菜单名称到字典中修改
                if (Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName)||
                    Global.Global_Parameter.tmpFuncModuleAndImgDic.ContainsKey(functionModuleName))
                {
                    PopupMessage.ShowWarning($"已存在【{functionModuleName}】模块，请重新输入一个唯一的模块名称");
                    return;
                }

                if (Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(_CurSelectedFunctionModuleName) &&
                    Global.Global_Parameter.tmpFuncModuleAndImgDic.ContainsKey(_CurSelectedFunctionModuleName))
                {
                    var oldValue = Global.Global_Parameter.tmpFuncModuleDic[_CurSelectedFunctionModuleName];
                    Global.Global_Parameter.tmpFuncModuleDic.Remove(_CurSelectedFunctionModuleName);

                    string funcModuleNameImg = _CurSelectedFuncModuleImgName;
                    Global.Global_Parameter.tmpFuncModuleAndImgDic.Remove(_CurSelectedFunctionModuleName);

                    ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpFuncModuleDic, functionModuleName, oldValue);
                    ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpFuncModuleAndImgDic, functionModuleName, funcModuleNameImg);
                    LoadFunctionModuleNameListInfo();
                }


            }
        }

        private void simpleButton_Delete_Click(object sender, EventArgs e)
        {
            string functionModuleName = textEdit_FunctionModuleName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(functionModuleName))
            {
                //将功能菜单名称到字典中删除
                if (Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(functionModuleName)&&
                    Global.Global_Parameter.tmpFuncModuleAndImgDic.ContainsKey(functionModuleName))
                {
                    bool result = PopupMessage.ShowAskQuestion($"确定要删除【{functionModuleName}】模块吗？");
                    if (result)
                    {
                        Global.Global_Parameter.tmpFuncModuleDic.Remove(functionModuleName);
                        Global.Global_Parameter.tmpFuncModuleAndImgDic.Remove(functionModuleName);
                        LoadFunctionModuleNameListInfo();
                    }
                }
                else
                {
                    PopupMessage.ShowWarning($"不存在【{functionModuleName}】模块，请重新输入一个存在的模块名称");
                }

            }

        }

        private void simpleButton_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_CurSelectedFunctionModuleName)||
                !Global.Global_Parameter.tmpFuncModuleDic.ContainsKey(_CurSelectedFunctionModuleName)) return;

            //获取当前选中的功能模块及对应该功能模块勾选的菜单
            for (int i = 0; i < treeList_MenuNameListOfFunctionModule.Nodes.Count; i++)
            {
                var node = treeList_MenuNameListOfFunctionModule.Nodes[i];
                if (node.Checked)
                {
                    string curSelectedMenuName = node.GetDisplayText(0);
                    if (Global.Global_Parameter.tmpFuncModuleDic[_CurSelectedFunctionModuleName]==null || 
                        !Global.Global_Parameter.tmpFuncModuleDic[_CurSelectedFunctionModuleName].ContainsKey(curSelectedMenuName))
                    {
                        if (!Global.Global_Parameter.tmpMenuDic.ContainsKey(curSelectedMenuName))
                        {
                            continue;
                        }
                        string menuNameSpace = Global.Global_Parameter.tmpMenuDic[curSelectedMenuName];
                        if (Global.Global_Parameter.tmpFuncModuleDic[_CurSelectedFunctionModuleName]==null)
                        {
                            Global.Global_Parameter.tmpFuncModuleDic[_CurSelectedFunctionModuleName] = new Dictionary<string, string>();
                        }
                        ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpFuncModuleDic[_CurSelectedFunctionModuleName], curSelectedMenuName, menuNameSpace);
                    }
                }
                
               
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
                _CurSelectedFunctionModuleName = e.Node.GetDisplayText(0);
                LoadMenuNameListOfFunctionModuleName(e.Node.GetDisplayText(0));
                textEdit_FunctionModuleName.Text = _CurSelectedFunctionModuleName;
                SelectedImageListBoxControlItemBySetting();
            }
        }

        /// <summary>
        /// 当前选中的功能图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取当前选中的项
            var selectedItem = imageListBoxControl1.SelectedItem as ImageListBoxItem;
            if (selectedItem != null)
            {
                // 获取选中项的名称
                string itemName = selectedItem.Value.ToString();
                _CurSelectedFuncModuleImgName = itemName;

                // 获取选中项的图像索引
                int imageIndex = selectedItem.ImageIndex;


            }
        }




    }//Class_end
}