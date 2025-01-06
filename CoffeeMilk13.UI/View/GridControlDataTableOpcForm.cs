using CoffeeMilk13.UI.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.View
{
    public partial class GridControlDataTableOpcForm : DevExpress.XtraEditors.XtraForm
    {
        #region   基础参数
        //数据DataTable
        private DataTable _dataTableOneRow;
        private DataTable _dataTableMutiRow = new DataTable();
        private DataTable _newDataTable;

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

            this.Controls[0].Focus();
        }

        #endregion

        public GridControlDataTableOpcForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion
        }

        private void GridControlDataTableOpcForm_Load(object sender, EventArgs e)
        {
            this.Resize += GridControlDataTableOpcForm_Resize;
        }

        #region 窗体控件方法
        private void GridControlDataTableOpcForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        /// <summary>
        /// 1-将实体类列表转为DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_EntityToDataTable_Click(object sender, EventArgs e)
        {
            PeopleInfo peopleInfo = GetVirtualEntityData();
            //将实体类转为DataTable
            DataTable dt = DataTableHelper.EntityToDataTable(peopleInfo);
            _dataTableOneRow = dt;

            if (dt != null && dt.Rows.Count > 0)
            {
                labelControl_TipInfo.Text = "将实体类转为DataTable 成功！！！";
                ShowInfo(dt.ToString());
            }
        }

        /// <summary>
        /// 1-将DataTable数据填充到表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_DataTableToGrid_Click(object sender, EventArgs e)
        {
            if (_dataTableOneRow == null || _dataTableOneRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【1-将实体类转为DataTable】按钮";
                return;
            }
            gridControl1.DataSource = _dataTableOneRow;
            gridControl1.Refresh();
            gridView1.BestFitColumns();
        }

        /// <summary>
        /// 1-将DataTable转为实体类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_DataTableToEntity_Click(object sender, EventArgs e)
        {
            if (_dataTableOneRow == null || _dataTableOneRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【1-将实体类转为DataTable】按钮";
                return;
            }

            PeopleInfo peopleInfo = DataTableHelper.DataTableToEntity<PeopleInfo>(_dataTableOneRow, 0);

            string str = peopleInfo.ToString();

            ShowInfo(str);
        }

        /// <summary>
        /// 2-将实体类列表转为DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_EntityListToDataTable_Click(object sender, EventArgs e)
        {
            List<string> fieldNameList = DataTableHelper.GetEntityFieldList<PeopleInfo>();
            DataTableHelper.AddFieldNameToDataTable(fieldNameList, ref _dataTableMutiRow);
            _dataTableMutiRow.Columns["Age"].DataType = Type.GetType("System.Double");

            List<PeopleInfo> peopleInfoList = GetVirtualEntityListData();
            //将实体类列表转为DataTable
            DataTable dt = DataTableHelper.ListToDataTable(peopleInfoList);
            _dataTableMutiRow = dt;

            if (dt != null && dt.Rows.Count > 0)
            {
                labelControl_TipInfo.Text = "将实体类列表转为DataTable 成功！！！";
            }
        }

        /// <summary>
        /// 2-将DataTable数据填充到表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_DataTableToGrid2_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }
            gridControl1.DataSource = _dataTableMutiRow;
            gridControl1.Refresh();
            gridView1.BestFitColumns();
        }

        /// <summary>
        /// 2-将DataTable转为实体列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_DataTableToEntityList_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }

            List<PeopleInfo> peopleInfos = DataTableHelper.DataTableToList<PeopleInfo>(_dataTableMutiRow);

            string str = null;
            foreach (var item in peopleInfos)
            {
                str += item.ToString() + "\r\n";
            }

            ShowInfo(str);
        }

        /// <summary>
        /// 3-复制DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_CopyDataTable_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }


            string str = null;
            if (_newDataTable == null)
            {
                str = $"复制开始：_newDataTable 的数据行数为：{0}\r\n";
            }
            else
            {
                str += $"复制开始：_newDataTable 的数据" +
                     $"行数为：{_newDataTable.Rows.Count},直接清空\r\n";
                _newDataTable?.Clear();
            }

            DataTableHelper.CopyDataTableDatas(_dataTableMutiRow, ref _newDataTable);
            str += $"复制结束：_newDataTable 的数据行数为：{_newDataTable?.Rows?.Count}";

            ShowInfo(str);
        }

        /// <summary>
        /// 3-给DataTable添加字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_AddFieldToDataTable_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }

            List<string> fieldNameList = DataTableHelper.GetAllFieldNameOfDataTable(_dataTableMutiRow);
            string str = GetOneStringOfList(fieldNameList);
            string tips = $"在添加字段前：_dataTableMutiRow 的所有字段为：{str} \r\n";
            ShowInfo(tips);

            //需要给DataTable添加的字段
            List<string> newFieldNameList = new List<string> { "Company", "Technology", "Experience" };
            DataTableHelper.AddFieldNameToDataTable(newFieldNameList, ref _dataTableMutiRow);

            List<string> fieldNameList2 = DataTableHelper.GetAllFieldNameOfDataTable(_dataTableMutiRow);
            string str2 = GetOneStringOfList(fieldNameList2);
            tips += $"在添加字段后：_dataTableMutiRow 的所有字段为：{str2}";
            ShowInfo(tips);

        }

        /// <summary>
        /// 3-给Datatable添加一列内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_AddOneColumnToDataTable_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }

            List<string> tmpList = new List<string>() { "测试公司1", "测试公司2",
                "测试公司3", "测试公司4", "测试公司5" };
            DataTableHelper.AddOneColumnDatasToDataTable(tmpList, "Company", ref _dataTableMutiRow);

            //刷新表格
            gridControl1.DataSource = _dataTableMutiRow;
            gridControl1.Refresh();
            gridView1.BestFitColumns();
        }

        /// <summary>
        /// 给DataTable指定行添加一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_AddOneRowDataToDataTable_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }

            List<string> tmpDataList = new List<string>() {"TEST002","张依依","27","女",
                "3615241691@qq.com", "北京市朝阳区0016","技术总监" };
            //List<string> fieldNameList =DataTableHelper.GetEntityFieldList<PeopleInfo>();
            List<string> fieldNameList = new List<string>() { "Id", "Name", "Age", "Sex", "Email", "Address", "Work" };
            int needInsertRowIndex = 3;
            ShowInfo($"从0开始，向第【{needInsertRowIndex}】行添加的数据是：{GetOneStringOfList(tmpDataList)}");
            DataTableHelper.AddSingleRowToAppointRowOfDataTable(tmpDataList, fieldNameList, ref _dataTableMutiRow, needInsertRowIndex);
        }

        /// <summary>
        /// 3-给Datatable末尾添加一行内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_AddOneRowDataToDataTableTail_Click(object sender, EventArgs e)
        {
            if (_dataTableMutiRow == null || _dataTableMutiRow.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = "请先点击【2-将实体类列表转为DataTable】按钮";
                return;
            }

            List<string> tmpDataList = new List<string>() {"TEST006","张茜","26","女",
                "3615241693@qq.com", "上海市浦东区006","高级顾问" };

            List<string> fieldNameList = DataTableHelper.GetEntityFieldList<PeopleInfo>();
            //List<string> fieldNameList = new List<string>() { "Id", "Name", "Age", "Sex", "Email", "Address", "Work" };
            ShowInfo($"给表格【末尾】行添加的数据是：{GetOneStringOfList(tmpDataList)}");
            DataTableHelper.AddListDatasToDataTable(tmpDataList, fieldNameList, ref _dataTableMutiRow);
        }

        /// <summary>
        /// 4-获取到指定列的所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetOneColumnAllData_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = $"请先给表格填充数据，需要点击【2-将DataTable数据填充到表格】按钮";
                return;
            }

            int columnIndex = 1;
            List<string> tmpList = DataTableHelper.GetIndexColumnValueItems(dt, columnIndex);

            string str = GetOneStringOfList(tmpList);
            ShowInfo($"从0开始，获取到【{columnIndex}】列的所有数据为：\r\n {str}");
        }

        /// <summary>
        /// 4-获取到指定两列的所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetTwoColumnAllData_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = $"请先给表格填充数据，需要点击【2-将DataTable数据填充到表格】按钮";
                return;
            }

            Dictionary<string, string> tmpDic = DataTableHelper.GetTwoIndexColumnValueItems(dt, "Name", "Sex");

            string str = GetOneStingOfDictionary(tmpDic);
            ShowInfo($"获取到【Name】【Sex】列的所有数据为：\r\n {str}");
        }

        /// <summary>
        /// 4-获取N行M列的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetSingleRowAndColumnData_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = $"请先给表格填充数据，需要点击【2-将DataTable数据填充到表格】按钮";
                return;
            }
            int rowIndex=3,columnIndex = 6;
            string str = DataTableHelper.GetRowColumnValue(dt, rowIndex, columnIndex);

            ShowInfo($"从0开始，获取到【{rowIndex}】行【{columnIndex}】列的数据为：\r\n {str}");
        }

        /// <summary>
        /// 4-获取单行多列的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetSingleRowMutiColumnDatas_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = $"请先给表格填充数据，需要点击【2-将DataTable数据填充到表格】按钮";
                return;
            }

            int rowIndex = 2, startColumnIndex = 1, endColumnIndex = 3;
            List<string> tmpList = DataTableHelper.GetRowAndMutiColumnValues(dt, rowIndex, startColumnIndex, endColumnIndex);

            string str = GetOneStringOfList(tmpList);
            ShowInfo($"从0开始，获取到第【{rowIndex}】行,从【{startColumnIndex}】列到【{endColumnIndex}】列的数据为：\r\n {str}");
        }

        /// <summary>
        /// 4-获取多行单列的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetMutiRowSingleColumnDatas_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                labelControl_TipInfo.Text = $"请先给表格填充数据，需要点击【2-将DataTable数据填充到表格】按钮";
                return;
            }

            int columnIndex = 1, startRowIndex = 1, endRowIndex = 3;
            List<string> tmpList = DataTableHelper.GetColumnAndMutiRowValues(dt, columnIndex, startRowIndex, endRowIndex);

            string str = GetOneStringOfList(tmpList);
            ShowInfo($"从0开始，获取到【{columnIndex}】列，从【{startRowIndex}】行到【{endRowIndex}】行的数据为：" + str);
        }

        /// <summary>
        /// 5-给指定列添加进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_AddProgressbarOfColumn_Click(object sender, EventArgs e)
        {
            GridControlHelper.SetPercentage(gridView1, "Age");
            //GridControlHelper.SetResreserveTwoBitAndPercentageChar(gridView1, "Age");
            //GridControlHelper.DrawProgressBarToColumn(gridView1, "Age", 0.6,Brushes.OrangeRed,Brushes.LawnGreen);
            GridControlHelper.DrawProgressBarToColumn(gridView1, "Age", 0.6, new SolidBrush(Color.FromArgb(236, 65, 65)), new SolidBrush(Color.FromArgb(45, 115, 186)));
        }

        /// <summary>
        /// 6-获取表格过滤或排序后数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_GetFilterOrSortDataOfGrid_Click(object sender, EventArgs e)
        {
            DataTable dt = WinformUIHelper.GetFilterOrSortDatasOfGridView(gridView1);

            gridControl1.DataSource = dt;
            gridControl1.Refresh();
            gridView1.BestFitColumns();
        }

        /// <summary>
        /// 7-删除DataTable空白行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_DeleteEmptyRowOfDataTable_Click(object sender, EventArgs e)
        {
            DataTable dt = GetHaveEmptyRowDataTable();

            DataTable newDt = DataTableHelper.DeleteEmptyRow(dt);

            //DataTable newDt = DataTableHelper.FilterBlankRow(dt);
        }

        /// <summary>
        /// 8-多线程下调用UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_CallbackUIOfMutiThred_Click(object sender, EventArgs e)
        {
            PopupMessage.label = this.labelControl_TipInfo;
            System.Threading.Thread thread = new System.Threading.Thread(new ThreadStart(ShowTips));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 9-定时滚动表格内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_FixedTimeRollGrid_Click(object sender, EventArgs e)
        {
            //启用定时器
            timer1.Enabled = true;
            //时间间隔
            timer1.Interval = 1000;//单位是毫秒（表示：1秒执行一次）
            //启动定时器
            timer1.Start();
        }

        /// <summary>
        /// 10-导出当前表格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ExportGridDatas_Click(object sender, EventArgs e)
        {
            GridControlHelper.ExportDatasToExcelFile(gridView1);
        }


        #region 自动滑动表格

        /// <summary>
        /// 1-timer1定时器的触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            AutoSlideGridInfo(gridView1);
        }

        /// <summary>
        /// 2-自动滑动表格滑动条方法
        /// </summary>
        /// <param name="gridView"></param>
        private void AutoSlideGridInfo(GridView gridView)
        {
            if (gridView == null) return;
            gridView.FocusedRowHandle += 1;

            if (gridView.IsLastRow)
            {
                //移动上第一行
                gridView.MoveFirst();
            }
            else
            {

                //移动到下一行
                gridView.MoveNextPage();
            }
        }

        /// <summary>
        /// 3-计算表格行高
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            //自定义行高
            if (e.RowHandle >= 0)
            {
                e.RowHeight = 35;
            }
        }

        #endregion 

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取到虚拟实体类数据
        /// </summary>
        /// <returns></returns>
        private PeopleInfo GetVirtualEntityData()
        {
            PeopleInfo peopleInfo = new PeopleInfo();
            peopleInfo.Id = "TEST001";
            peopleInfo.Name = "祁东威";
            peopleInfo.Age = 26;
            peopleInfo.Sex = "男";
            peopleInfo.Email = "3615241689@qq.com";
            peopleInfo.Address = "北京市朝阳区001号";
            peopleInfo.Work = "职业经理";

            return peopleInfo;
        }


        /// <summary>
        ///获取到虚拟实体列表数据
        /// </summary>
        /// <returns></returns>
        private List<PeopleInfo> GetVirtualEntityListData()
        {
            //模拟数据
            List<PeopleInfo> peopeoInfos = new List<PeopleInfo>()
            {
                new PeopleInfo{ Id="SL009",Name="谭维维",Age=0.18,Sex="男",Email="3625783421@qq.com",Address="测试地址1",Work="产品经理"},
                new PeopleInfo{ Id="SL008",Name="司一航",Age=0.26,Sex="男",Email="3625783422@qq.com",Address="测试地址2",Work="销售专员"},
                new PeopleInfo{ Id="SL007",Name="周  倩",Age=0.19,Sex="女",Email="3625783423@qq.com",Address="测试地址3",Work="技术主管"},
                new PeopleInfo{ Id="SL006",Name="王一星",Age=0.21,Sex="男",Email="3625783424@qq.com",Address="测试地址4",Work="设备主管"},
                new PeopleInfo{ Id="SL005",Name="策俊逸",Age=0.24,Sex="男",Email="3625783425@qq.com",Address="测试地址5",Work="项目经理"},
                new PeopleInfo{ Id="SL004",Name="周  茜",Age=0.22,Sex="女",Email="3625783426@qq.com",Address="测试地址6",Work="人资专员"},
                new PeopleInfo{ Id="SL003",Name="司王成",Age=0.98,Sex="男",Email="3625783427@qq.com",Address="测试地址7",Work="车间主任"},
                new PeopleInfo{ Id="SL002",Name="杨思凡",Age=1.23,Sex="男",Email="3625783428@qq.com",Address="测试地址8",Work="生产员工"},
                new PeopleInfo{ Id="SL001",Name="策一方",Age=1,Sex="男",Email="3625783429@qq.com",Address="测试地址9",Work="售后员工"},

                new PeopleInfo{ Id="SL009",Name="谭维维",Age=18,Sex="男",Email="3625783421@qq.com",Address="测试地址10",Work="产品经理"},
                new PeopleInfo{ Id="SL008",Name="司一航",Age=26,Sex="男",Email="3625783422@qq.com",Address="测试地址11",Work="销售专员"},
                new PeopleInfo{ Id="SL007",Name="周  倩",Age=30,Sex="女",Email="3625783423@qq.com",Address="测试地址12",Work="技术主管"},
                new PeopleInfo{ Id="SL006",Name="王一星",Age=21,Sex="男",Email="3625783424@qq.com",Address="测试地址13",Work="设备主管"},
                new PeopleInfo{ Id="SL005",Name="策俊逸",Age=24,Sex="男",Email="3625783425@qq.com",Address="测试地址14",Work="项目经理"},
                new PeopleInfo{ Id="SL004",Name="周  茜",Age=22,Sex="女",Email="3625783426@qq.com",Address="测试地址15",Work="人资专员"},
                new PeopleInfo{ Id="SL003",Name="司王成",Age=46,Sex="男",Email="3625783427@qq.com",Address="测试地址16",Work="车间主任"},
                new PeopleInfo{ Id="SL002",Name="杨思凡",Age=33,Sex="男",Email="3625783428@qq.com",Address="测试地址17",Work="生产员工"},
                new PeopleInfo{ Id="SL001",Name="策一方",Age=100,Sex="男",Email="3625783429@qq.com",Address="测试地址18",Work="售后员工"},

                new PeopleInfo{ Id="SL009",Name="谭维维",Age=18,Sex="男",Email="3625783421@qq.com",Address="测试地址19",Work="产品经理"},
                new PeopleInfo{ Id="SL008",Name="司一航",Age=26,Sex="男",Email="3625783422@qq.com",Address="测试地址20",Work="销售专员"},
                new PeopleInfo{ Id="SL007",Name="周  倩",Age=30,Sex="女",Email="3625783423@qq.com",Address="测试地址21",Work="技术主管"},
                new PeopleInfo{ Id="SL006",Name="王一星",Age=21,Sex="男",Email="3625783424@qq.com",Address="测试地址22",Work="设备主管"},
                new PeopleInfo{ Id="SL005",Name="策俊逸",Age=24,Sex="男",Email="3625783425@qq.com",Address="测试地址23",Work="项目经理"},
                new PeopleInfo{ Id="SL004",Name="周  茜",Age=22,Sex="女",Email="3625783426@qq.com",Address="测试地址24",Work="人资专员"},
                new PeopleInfo{ Id="SL003",Name="司王成",Age=46,Sex="男",Email="3625783427@qq.com",Address="测试地址25",Work="车间主任"},
                new PeopleInfo{ Id="SL002",Name="杨思凡",Age=33,Sex="男",Email="3625783428@qq.com",Address="测试地址26",Work="生产员工"},
                new PeopleInfo{ Id="SL001",Name="策一方",Age=100,Sex="男",Email="3625783429@qq.com",Address="测试地址27",Work="售后员工"},
            };

            return peopeoInfos;
        }

        /// <summary>
        /// 获取到List内容组成一个字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string GetOneStringOfList(List<string> list)
        {
            string str = null;
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    str += $"\r\n {item}";
                }
            }
            return str;
        }


        /// <summary>
        /// 获取到Dic内容组成一个字符串
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        private string GetOneStingOfDictionary(Dictionary<string, string> dic)
        {
            string str = null;
            if (dic != null && dic.Count > 0)
            {
                foreach (var item in dic)
                {
                    str += $"\r\n{item.Key}   {item.Value}";
                }
            }

            return str;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="str"></param>
        private void ShowInfo(string str)
        {
            memoEdit_ShowInfo.Text = str;
        }

        /// <summary>
        /// 构造含有空白行的DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable GetHaveEmptyRowDataTable()
        {
            DataTable dt = new DataTable();
            //List<string> fieldNameList = new List<string>() { "编号", "姓名", "年龄", "性别" };
            //DataTableHelper.AddFieldNameToDataTable(fieldNameList, ref dt);
            //List<string> listData = new List<string>() { "20220101", "李雪健", "66", "男" };

            List<string> fieldNameList = new List<string>() { "编号" };
            DataTableHelper.AddFieldNameToDataTable(fieldNameList, ref dt);
            List<string> listData = new List<string>() { "20220101" };
            DataTableHelper.AddSingleRowToAppointRowOfDataTable(listData, fieldNameList, ref dt, 0);
            DataTableHelper.AddMutiEmptyRowToDataTable(10, ref dt);


            //DataTableHelper.AddEmptyRowToDataTable(1,ref dt);
            //DataTableHelper.AddEmptyRowToDataTable(2, ref dt);
            //DataTableHelper.AddEmptyRowToDataTable(3, ref dt);
            //DataTableHelper.AddEmptyRowToDataTable(4, ref dt);
            //DataTableHelper.AddEmptyRowToDataTable(5, ref dt);

            return dt;
        }


        /// <summary>
        /// 显示提示信息
        /// </summary>
        public void ShowTips()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                PopupMessage.ShowTipInfoOfMutiThread($"多线程调用UI测试{i}");
                if (i == 9)
                {
                    PopupMessage.ClearTipInfoOfMutiThread();
                }
            }

        }

        #endregion


    }//Class_end
}