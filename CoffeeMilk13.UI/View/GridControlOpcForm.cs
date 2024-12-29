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
    public partial class GridControlOpcForm : DevExpress.XtraEditors.XtraForm
    {

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

            this.Controls[0].Focus();
        }

        #endregion

        public GridControlOpcForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion
        }


        #region 窗体控件方法

        private void GridControlOpcForm_Load(object sender, EventArgs e)
        {
            InitPara();
        }

        private void GridControlOpcForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }


        #region 修改背景颜色
        private bool modifyCellBackColor = false;
        private bool modifyColumnBackColor = false;
        private bool modifySingleRowBackColor = false;
        private bool modifySingleRowBackColor2 = false;
        private int appointRowIndex = -1;
        private bool modifyMutiRowBackColor = false;

        /// <summary>
        /// 修改指定标题头背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ModifyHeaderBackColor_Click(object sender, EventArgs e)
        {
            //设置标题头背景颜色
            GridControlHelper.SetGridViewHeaderBackColor(gridView1, 0, Color.BlueViolet);
            GridControlHelper.SetGridViewHeaderBackColor(gridView1, 3, Color.OrangeRed);
            GridControlHelper.SetGridViewHeaderBackColor(gridView1, 5, Color.LightGreen);


            GridControlHelper.SetGridViewHeaderBackColor(gridView1, "Name", Color.BlueViolet);
            GridControlHelper.SetGridViewHeaderBackColor(gridView1, "Email", Color.OrangeRed);
            GridControlHelper.SetGridViewHeaderBackColor(gridView1, "Work", Color.LightGreen);

        }


        /// <summary>
        /// 修改表格背景颜色事件【(绘制事件)可实现更复杂的操作】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            //修改指定单元格的颜色
            if (modifyCellBackColor && e.Column.FieldName == "Work")
            {
                string strName = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["Work"]);
                //实现修改指定格的颜色
                if (strName.Equals("技术主管"))
                {
                    e.Appearance.BackColor = Color.SkyBlue;
                    e.Appearance.BackColor2 = Color.LightCyan;
                }

            }

            //修改指定列的颜色
            if (modifyColumnBackColor && e.Column.FieldName == "Sex")
            {
                string strName = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["Sex"]);
                //实现修改指定列的颜色
                if (!string.IsNullOrEmpty(strName))
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }

            }


            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                //修改指定值对应行的背景颜色
                if (modifySingleRowBackColor && dr["Work"].ToString() == "技术主管")
                {
                    e.Appearance.BackColor = Color.SkyBlue;
                }

                //修改指定行对应的背景颜色
                if (modifySingleRowBackColor2 && appointRowIndex >= 0 && appointRowIndex - 1 == e.RowHandle)
                {
                    e.Appearance.BackColor = Color.Olive;
                }

                //修改指定行背景颜色
                if (modifyMutiRowBackColor && e.RowHandle >= 6 && e.RowHandle <= 8)
                {
                    e.Appearance.BackColor = Color.Pink;
                }


            }


        }


        /// <summary>
        /// 修改表格背景颜色事件【(样式事件)可实现简单的操作】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //修改指定单元格的颜色
            if (modifyCellBackColor && e.Column.FieldName == "Work")
            {
                string strName = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["Work"]);
                //实现修改指定格的颜色
                if (strName.Equals("技术主管"))
                {
                    e.Appearance.BackColor = Color.SkyBlue;
                    e.Appearance.BackColor2 = Color.LightCyan;
                }

            }

            //修改指定列的颜色
            if (modifyColumnBackColor && e.Column.FieldName == "Sex")
            {
                string strName = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["Sex"]);
                //实现修改指定列的颜色
                if (!string.IsNullOrEmpty(strName))
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }

            }


            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                //修改指定值对应行的背景颜色
                if (modifySingleRowBackColor && dr["Work"].ToString() == "技术主管")
                {
                    e.Appearance.BackColor = Color.SkyBlue;
                }

                //修改指定行对应的背景颜色
                if (modifySingleRowBackColor2 && appointRowIndex >= 0 && appointRowIndex - 1 == e.RowHandle)
                {
                    e.Appearance.BackColor = Color.Olive;
                }

                //修改指定行背景颜色
                if (modifyMutiRowBackColor && e.RowHandle >= 6 && e.RowHandle <= 8)
                {
                    e.Appearance.BackColor = Color.Pink;
                }


            }
        }

        /// <summary>
        /// 修改指定单元格背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ModifyCellBackColor_Click(object sender, EventArgs e)
        {
            //修改方式一：
            modifyCellBackColor = true;
            modifyColumnBackColor = false;
            modifySingleRowBackColor = false;
            modifyMutiRowBackColor = false;

            gridView1.RefreshData();

        }


        /// <summary>
        /// 修改指定列背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ModifyColumnBackColor_Click(object sender, EventArgs e)
        {
            //修改方式一：
            modifyCellBackColor = false;
            modifyColumnBackColor = true;
            modifySingleRowBackColor = false;
            modifyMutiRowBackColor = false;
            gridView1.RefreshData();

            //修改方式二（推荐）：
            GridControlHelper.SetGridColumnBackColor(gridView1, 1, Color.SkyBlue, Color.DeepPink, Color.Yellow);
        }

        /// <summary>
        /// 修改指定行背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ModifyRowBackColor_Click(object sender, EventArgs e)
        {
            //修改方式一：
            modifyCellBackColor = false;
            modifyColumnBackColor = false;
            modifySingleRowBackColor = true;
            modifyMutiRowBackColor = false;
            gridView1.RefreshData();

            //修改方式二：
            modifyCellBackColor = false;
            modifyColumnBackColor = false;
            modifySingleRowBackColor = true;
            modifySingleRowBackColor2 = true;
            appointRowIndex = 2;
            modifyMutiRowBackColor = false;
            gridView1.RefreshData();

        }

        /// <summary>
        /// 修改多行背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ModifyMutiRowBackcolor_Click(object sender, EventArgs e)
        {
            modifyCellBackColor = false;
            modifyColumnBackColor = false;
            modifySingleRowBackColor = false;
            modifyMutiRowBackColor = true;
            gridView1.RefreshData();
        }

        /// <summary>
        /// 设置奇偶行颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_SetOddEvenRowColor_Click(object sender, EventArgs e)
        {
            GridControlHelper.SetOddEvenRowColor(gridView1, Color.FromArgb(204, 204, 255), Color.FromArgb(153, 204, 255));
        }

        #endregion


        /// <summary>
        /// 获取表格字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetGridHeaderFields_Click(object sender, EventArgs e)
        {
            List<string> tmpFieldlist = GridControlHelper.GetAllFieldOfGrirdView(gridView1);
            string tmpStr = null;
            foreach (var item in tmpFieldlist)
            {
                tmpStr += " " + item;
            }
            labelControl_TipInfo.Text = tmpStr;
        }

        /// <summary>
        /// 获取表格标题名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void simpleButton_GetGridHeaderNames_Click(object sender, EventArgs e)
        {
            List<string> tmpCaptionlist = GridControlHelper.GetAllCaptionOfGrirdView(gridView1);
            string tmpStr = null;
            foreach (var item in tmpCaptionlist)
            {
                tmpStr += " " + item;
            }
            labelControl_TipInfo.Text = tmpStr;
        }

        /// <summary>
        /// 修改表格标题头名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ModifyHeaderName_Click(object sender, EventArgs e)
        {
            GridControlHelper.ModifyGridViewTitleHeader(gridView1, 2, "修改年龄标题名称");

            GridControlHelper.ModifyGridViewTitleHeader(gridView1, "Email", "修改邮箱标题名称");
        }

        /// <summary>
        /// 导出表格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ExportGridData_Click(object sender, EventArgs e)
        {
            GridControlHelper.ExportDatasToExcelFile(gridView1);
        }

        /// <summary>
        /// 编辑表格任意数据[开启]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_EnableEditGridAllData_Click(object sender, EventArgs e)
        {
            labelControl_TipInfo.Text = "现在可以编辑表格的任意数据";
            WinformUIHelper.IsEditAllColumnGridView(gridView1, true);
        }

        /// <summary>
        /// 编辑表格任意数据[关闭]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_DisableEditGridAllData_Click(object sender, EventArgs e)
        {
            labelControl_TipInfo.Text = "现在无法编辑表格的任意内容！！！";
            WinformUIHelper.IsEditAllColumnGridView(gridView1, false);
        }

        /// <summary>
        /// 编辑表格单列数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_EditGridSingleColumnDatas_Click(object sender, EventArgs e)
        {
            labelControl_TipInfo.Text = "现在只可以编辑【邮箱】列的内容";
            WinformUIHelper.IsEditAppointColumnData(gridView1, "Email", true);
        }

        /// <summary>
        ///  编辑表格多列数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_EditGridMutiColumnDatas_Click(object sender, EventArgs e)
        {
            labelControl_TipInfo.Text = "现在只可以编辑【姓名】、【地址】、【职位】列的内容";
            List<string> editColumnFieldNameList = new List<string>() { "Name", "Address", "Work" };
            WinformUIHelper.IsEditMutiColumnData(gridView1, editColumnFieldNameList, true);
        }

        #endregion



        #region   私有方法

        /// <summary>
        /// 参数初始化
        /// </summary>
        private void InitPara()
        {
            GridSettings();
            LoadDatasToGrid();
        }

        /// <summary>
        /// 加载数据到表格中
        /// </summary>
        /// <returns></returns>
        private void LoadDatasToGrid()
        {
            //模拟数据
            List<PeopleInfo> peopeoInfos = new List<PeopleInfo>()
            {
                new PeopleInfo{ Id="SL009",Name="谭维维",Age=23,Sex="男",Email="3625783421@qq.com",Address="测试地址1",Work="产品经理"},
                new PeopleInfo{ Id="SL008",Name="司一航",Age=22,Sex="男",Email="3625783422@qq.com",Address="测试地址2",Work="销售专员"},
                new PeopleInfo{ Id="SL007",Name="周  倩",Age=25,Sex="女",Email="3625783423@qq.com",Address="测试地址3",Work="技术主管"},
                new PeopleInfo{ Id="SL006",Name="王一星",Age=21,Sex="男",Email="3625783424@qq.com",Address="测试地址4",Work="设备主管"},
                new PeopleInfo{ Id="SL005",Name="策俊逸",Age=24,Sex="男",Email="3625783425@qq.com",Address="测试地址5",Work="项目经理"},
                new PeopleInfo{ Id="SL004",Name="周  茜",Age=22,Sex="女",Email="3625783426@qq.com",Address="测试地址6",Work="人资专员"},
                new PeopleInfo{ Id="SL003",Name="司王成",Age=26,Sex="男",Email="3625783427@qq.com",Address="测试地址7",Work="车间主任"},
                new PeopleInfo{ Id="SL002",Name="杨思凡",Age=24,Sex="男",Email="3625783428@qq.com",Address="测试地址8",Work="生产员工"},
                new PeopleInfo{ Id="SL001",Name="策一方",Age=23,Sex="男",Email="3625783429@qq.com",Address="测试地址9",Work="售后员工"},
             };

            DataTable dt = DataTableHelper.ListToDataTable(peopeoInfos);

            gridControl1.DataSource = dt;
        }

        /// <summary>
        /// 表格设置
        /// </summary>
        private void GridSettings()
        {
            //禁用表格编辑
            WinformUIHelper.IsAllowEditGridView(gridView1, false);
        }


















        #endregion


    }//Class_end


    //人员信息模型类
    internal class PeopleInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Work { get; set; }

        public override string ToString()
        {
            string strTmp = $"{Id},{Name},{Age}," +
                $"{Sex},{Email},{Address},{Work}";
            return strTmp;
        }
    }

}