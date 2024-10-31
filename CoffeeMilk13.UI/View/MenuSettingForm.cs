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
    public partial class MenuSettingForm : DevExpress.XtraEditors.XtraForm
    {
        #region 基础参数
        //需要显示数据的字段列表
        private Dictionary<string,string> _fieldAndDescNameDic = new Dictionary<string, string>();
        //需要加载显示数据的数据表
        private DataTable _dt = new DataTable();
        private Model.MenuModel _menuModel = new Model.MenuModel();
        

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

        public MenuSettingForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion


        }

        private void MenuSettingForm_Load(object sender, EventArgs e)
        {
            InitPara();
            AddFieldToDataTable(ref _dt);
            AddFieldAndDescToGridView(gridView1,_fieldAndDescNameDic);

        }

        private void MenuSettingForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        private void simpleButton_Add_Click(object sender, EventArgs e)
        {
            string menuName = textEdit_MenuName.Text.Trim();
            string menuNameSpace = textEdit_MenuNameSpace.Text.Trim();

            if (!string.IsNullOrWhiteSpace(menuName) && !string.IsNullOrWhiteSpace(menuNameSpace))
            {
                if (Global.Global_Parameter.tmpMenuDic.ContainsKey(menuName))
                {
                    PopupMessage.ShowWarning($"已存在【{menuName}】菜单，请重新输入一个唯一的菜单名称");
                    return;
                }

                ContainerHelper.AddOnlyInfoToDic(Global.Global_Parameter.tmpMenuDic,menuName,menuNameSpace);
                _dt?.Clear();
                foreach (var item in Global.Global_Parameter.tmpMenuDic)
                {
                    _dt.Rows.Add(item.Key,item.Value);
                }

                ShowDataToGridView(_dt);
            }

        }


        #region 私有方法

        /// <summary>
        /// 参数初始化
        /// </summary>
        private void InitPara()
        {
            //表格设置
            GridViewSettings();
        }

        /// <summary>
        /// 表格设置
        /// </summary>
        private void GridViewSettings()
        {
            //设置表格前显示序号的宽度
            gridView1.IndicatorWidth = 35;
            //禁用表格的列排序
            GridControlHelper.DisableAllColumnSort(gridView1, false);
            //设置表格标题居中
            GridControlHelper.SetAppointHeaderAlignment(gridView1, 0, gridView1.Columns.Count - 1, DevExpress.Utils.HorzAlignment.Center);
            
            // 设置行选中颜色
            GridControlHelper.SetSelectedRowColor(gridView1, Color.Aqua, Color.Orange);
            //设置表格不可编辑
            GridControlHelper.IsAllowEditGridView(gridView1, false);
            //表格列自动适配
            gridView1.BestFitColumns();
            ////设置表格的纵向单元格可以合并（true：表示可以）
            //gridView1.OptionsView.AllowCellMerge = true;
            ////打开横向滑动条
            //gridView1.OptionsView.ColumnAutoWidth = false;


        }

        /// <summary>
        /// 给数据表添加字段名称
        /// </summary>
        /// <param name="dt">数据表</param>
        private void AddFieldToDataTable(ref DataTable dt)
        {
            _fieldAndDescNameDic = DataTableHelper.GetEntityFieldAndDesc<Model.MenuModel>();
            
            DataTableHelper.AddFieldNameToDataTable(_fieldAndDescNameDic, ref dt);
        }

        /// <summary>
        /// 给GridView控件指定需要显示的字段名称
        /// </summary>
        /// <param name="gridView"></param>
        private void AddFieldAndDescToGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView, Dictionary<string, string> fieldAndDescNameDic)
        {
            gridView.Columns?.Clear();
            //for (int i = 0; i < gridView1.Columns.Count;)
            //{
            //    gridView1.Columns.RemoveAt(i);
            //}
            if (_fieldAndDescNameDic != null && _fieldAndDescNameDic.Count > 0)
            {
                foreach (var item in _fieldAndDescNameDic)
                {
                    gridView.Columns.AddField(item.Key);
                    gridView.Columns.ColumnByFieldName(item.Key);
                    gridView.Columns[item.Key].Caption = item.Value;
                    gridView.Columns[item.Key].Visible = true;
                    gridView.Columns[item.Key].AppearanceHeader.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    gridView.Columns[item.Key].AppearanceCell.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    gridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Default;
                }
            }
        }

        //显示数据到表格中
        private void ShowDataToGridView(DataTable dt)
        {
            gridControl1.DataSource = dt;

            gridControl1.Refresh();
            //gridView1.BestFitColumns();

        }


        #endregion

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                        {
                            e.Info.DisplayText = (e.RowHandle + 1).ToString();
                        }
                     else if (e.RowHandle < 0 && e.RowHandle > -1000)
                         {
                             e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                             e.Info.DisplayText = "G" + e.RowHandle.ToString();
                         }
                 }
        }
    }
}