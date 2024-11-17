/***
*	Title："Winfrom" 项目
*		主题：GridControl帮助类
*	Description：
*		功能：
*		    0、官网：https://docs.devexpress.com/WindowsForms/115548/controls-and-libraries/data-grid/appearance-and-conditional-formatting
*		    1、设置表格标题背景颜色
*		    2、设置表格标题边框颜色
*		    3、设置表格单元格边框颜色
*		    4、设置选中行颜色
*		    5、设置奇偶行背景颜色
*		    6、设置表格指定列的背景色
*		    7、获取到GridView的所有字段
*		    8、获取到GridView的指定字段
*		    9、获取到GridView的所有备注名称
*		    10、修改表格指定的标题头名称
*		    11、修改表格标题头名称
*		    12、修改表格标题的宽度
*		    13、设置指定行列的值
*		    14、清空选中行内容
*		    15、给GridControl组件填充内容
*		    16、导出表格数据为Excel文件
*		    17、设置自动生成序号
*		    18、清空表格
*		    19、禁止所有列表格列排序
*		    20、禁止指定列表格列排序
*		    21、设置表格是否可以编辑
*		    22、是否编辑指定的多列内容
*		    23、设置表格指定标题对齐格式
*		    24、设置表格指定列对齐格式
*		    25、设置表格所有单元格都保留2位小数
*		    26、设置表格指定单元格都保留2位小数
*		    27、设置表格指定单元格都使用百分比
*		    28、给表格指定单元格都保留2位小数后添加%号
*		    29、填充一行数据到表格指定行（起始列）
*		    
*	Date：2021
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.Utils
{
    class GridControlHelper
    {

        /// <summary>
        /// 设置表格标题背景颜色
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnIndex">表格列索引</param>
        /// <param name="color">颜色</param>
        public static void SetGridViewHeaderBackColor(GridView gridView,
            int columnIndex, Color color)
        {
            if (gridView != null && gridView.Columns.Count>0 && columnIndex >= 0)
            {
                gridView.Columns[columnIndex].AppearanceHeader.BackColor = color;
            }
        }

        /// <summary>
        /// 设置表格标题背景颜色
        /// </summary>
        /// <param name="gridView">BandedGridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="color">背景颜色</param>
        public static void SetGridViewHeaderBackColor(BandedGridView gridView,
            int startColumnIndex, int endColumnIndex, Color color)
        {
            if (gridView != null && startColumnIndex >= 0 && endColumnIndex > 0)
            {
                for (int i = startColumnIndex; i <= endColumnIndex; i++)
                {
                    GridBand curGridBand = gridView.Bands[i];
                    curGridBand.AppearanceHeader.BackColor = color;
                    if (curGridBand.Children.View.Bands.Count > 0)
                    {
                        foreach (GridBand item in curGridBand.Children)
                        {
                            item.AppearanceHeader.BackColor = color;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 设置表格标题边框颜色
        /// </summary>
        /// <param name="gridView">BandedGridView组件</param>
        /// <param name="color">背景颜色</param>
        public static void SetGridViewHeaderBorderLineBackColor(BandedGridView gridView, Color color)
        {
            if (gridView != null)
            {
                for (int i = 0; i <= gridView.Bands.Count - 1; i++)
                {
                    GridBand curGridBand = gridView.Bands[i];
                    curGridBand.AppearanceHeader.BorderColor = color;
                    curGridBand.AppearanceHeader.Options.UseBorderColor = true;

                    if (curGridBand.Children.View.Bands.Count > 0)
                    {
                        foreach (GridBand item in curGridBand.Children)
                        {
                            item.AppearanceHeader.BorderColor = color;
                            item.AppearanceHeader.Options.UseBorderColor = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置表格单元格边框颜色
        /// </summary>
        /// <param name="gridView">GridView组件</param>
        /// <param name="color">需设置的颜色</param>
        /// <param name="isSetting">是否设置</param>
        public static void SetGridViewBorderLineBackColor(GridView gridView, Color color, bool isSetting = true)
        {
            //获取表格边框原来的颜色
            Color originalColor = gridView.Appearance.VertLine.BackColor;
            gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            if (isSetting)
            {
                gridView.Appearance.VertLine.BackColor = color;
                gridView.Appearance.HorzLine.BackColor = color;
                gridView.Appearance.VertLine.Options.UseBackColor = isSetting;
                gridView.Appearance.HorzLine.Options.UseBackColor = isSetting;
            }
            else
            {
                gridView.Appearance.VertLine.BackColor = originalColor;
                gridView.Appearance.HorzLine.BackColor = originalColor;
                gridView.Appearance.VertLine.Options.UseBackColor = isSetting;
                gridView.Appearance.HorzLine.Options.UseBackColor = isSetting;
            }

        }


        /// <summary>
        /// 设置表格标题背景颜色
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnIndex">表格列索引</param>
        /// <param name="color">颜色</param>
        public static void SetGridViewHeaderBackColor(GridView gridView,
            string columnName, Color color)
        {
            if (gridView != null && gridView.Columns.Count > 0 && !string.IsNullOrEmpty(columnName))
            {
                gridView.Columns[columnName].AppearanceHeader.BackColor = color;
            }
        }

        /// <summary>
        /// 设置选中行颜色
        /// </summary>
        /// <param name="gridView">gridView表格</param>
        /// <param name="selectedRowColor">选中行的背景颜色</param>
        /// <param name="focusedColor">字体颜色</param>
        public static void SetSelectedRowColor(GridView gridView, Color selectedRowBackColor, Color fontColor)
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;

            gridView.Appearance.FocusedRow.BackColor = selectedRowBackColor;
            gridView.Appearance.FocusedRow.ForeColor = fontColor;
            gridView.Appearance.FocusedRow.Font = new Font(gridView.Appearance.Row.Font, FontStyle.Bold);

            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;
        }



        /// <summary>
        /// 设置奇偶行背景颜色，统一风格
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="oddColor">奇数行颜色</param>
        /// <param name="evenColor">偶数行颜色</param>
        public static void SetOddEvenRowColor(GridView gridView, Color oddColor, Color evenColor)
        {
            gridView.Appearance.OddRow.BackColor = oddColor;
            gridView.Appearance.EvenRow.BackColor = evenColor;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
        }


        /// <summary>
        /// 设置表格指定列的背景颜色
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="backColor">列的背景颜色1</param>
        /// <param name="backColor2">列的背景颜色2</param>
        /// <param name="foreColor">聚焦时颜色</param>
        public static void SetAppointColumnBackColor(GridView gridView,
            int startColumnIndex, int endColumnIndex, Color backColor, Color backColor2, Color foreColor)
        {
            if (gridView == null || startColumnIndex < 0 || endColumnIndex < 0 || startColumnIndex > endColumnIndex) return;

            for (int i = startColumnIndex; i <= endColumnIndex; i++)
            {
                SetGridColumnBackColor(gridView, i, backColor, backColor2, foreColor);
            }

        }

        /// <summary>
        /// 设置表格指定列的背景色
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="backColor">列的背景颜色1</param>
        /// <param name="backColor2">列的背景颜色2</param>
        /// <param name="foreColor">聚焦时颜色</param>
        public static void SetGridColumnBackColor(GridView gridView,int columnIndex, 
            Color backColor, Color backColor2, Color foreColor)
        {
            if (gridView != null && columnIndex >= 0)
            {
                GridColumn colID = gridView.Columns[columnIndex];
                colID.AppearanceCell.BackColor = backColor;
                colID.AppearanceCell.BackColor2 = backColor2;
                colID.AppearanceCell.ForeColor = foreColor;

            }
        }

        /// <summary>
        /// 设置表格指定列的背景色
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnFieldName">列字段名称</param>
        /// <param name="backColor">列的背景颜色1</param>
        /// <param name="backColor2">列的背景颜色2</param>
        /// <param name="foreColor">聚焦时颜色</param>
        public static void SetGridColumnBackColor(GridView gridView, string columnFieldName,
            Color backColor, Color backColor2, Color foreColor)
        {
            if (gridView != null && !string.IsNullOrEmpty(columnFieldName))
            {
                GridColumn colID = gridView.Columns[columnFieldName];
                colID.AppearanceCell.BackColor = backColor;
                colID.AppearanceCell.BackColor2 = backColor2;
                colID.AppearanceCell.ForeColor = foreColor;

            }
        }


        /// <summary>
        /// 获取到GridView的所有字段
        /// </summary>
        /// <param name="gridView">GridView组件</param>
        /// <returns></returns>
        public static List<string> GetAllFieldOfGrirdView(GridView gridView)
        {
            List<string> tmpList = new List<string>();
            if (gridView != null && gridView.Columns.Count > 0)
            {
                int count = gridView.Columns.Count;
                for (int i = 0; i < count; i++)
                {
                    tmpList.Add(gridView.Columns[i].FieldName);
                }
            }

            return tmpList;
        }

        /// <summary>
        /// 获取到GridView的指定字段
        /// </summary>
        /// <param name="gridView">GridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <returns></returns>
        public static List<string> GetAppointFieldOfGrirdView(GridView gridView, int startColumnIndex, int endColumnIndex)
        {
            if (gridView == null || gridView.Columns.Count <= 0 ||
                startColumnIndex < 0 || endColumnIndex < 0 || startColumnIndex > endColumnIndex) return null;

            List<string> tmpList = new List<string>();
            int count = gridView.Columns.Count;
            for (int i = startColumnIndex; i <= endColumnIndex; i++)
            {
                tmpList.Add(gridView.Columns[i].FieldName);
            }

            return tmpList;
        }

        /// <summary>
        /// 获取到GridView的所有备注名称
        /// </summary>
        /// <param name="gridView">GridView组件</param>
        /// <returns></returns>
        public static List<string> GetAllCaptionOfGrirdView(GridView gridView)
        {
            List<string> tmpList = new List<string>();
            if (gridView != null && gridView.Columns.Count > 0)
            {
                int count = gridView.Columns.Count;
                for (int i = 0; i < count; i++)
                {
                    tmpList.Add(gridView.Columns[i].Caption);
                }
            }

            return tmpList;
        }

        /// <summary>
        /// 修改表格指定的标题头名称
        /// </summary>
        /// <param name="gridView">GirdView表格</param>
        /// <param name="columnIndex">需要修改列标题名称的索引</param>
        /// <param name="headerName">修改后的列标题的名称</param>
        public static void ModifyGridViewTitleHeader(GridView gridView, int columnIndex, string headerName)
        {
            if (gridView != null && columnIndex > 0 && !string.IsNullOrEmpty(headerName))
            {
                gridView.Columns[columnIndex].Caption = headerName;
            }
        }

        /// <summary>
        /// 修改表格指定的标题头名称
        /// </summary>
        /// <param name="gridView">GirdView表格</param>
        /// <param name="columnName">需要修改列标题名称的字段名</param>
        /// <param name="headerName">修改后的列标题的名称</param>
        public static void ModifyGridViewTitleHeader(GridView gridView, string columnName, string headerName)
        {
            if (gridView != null && !string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(headerName))
            {
                gridView.Columns[columnName].Caption = headerName;
            }
        }

        /// <summary>
        /// 修改表格标题头名称
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="startColumnIndex">开始列的索引</param>
        /// <param name="titleHeaderNameList"></param>
        public static void ModifyGridViewAllTitleHeader(GridView gridView, int startColumnIndex,
            List<string> titleHeaderNameList)
        {
            if (gridView != null && startColumnIndex > 0 && titleHeaderNameList != null && titleHeaderNameList.Count > 0)
            {
                //int count = titleHeaderNameList.Count;
                int count = titleHeaderNameList.Count + (startColumnIndex - 1);
                for (int i = startColumnIndex; i <= count; i++)
                {
                    int index = 0;
                    if (startColumnIndex > 0)
                    {
                        index = i - startColumnIndex;
                    }
                    gridView.Columns[i].Caption = titleHeaderNameList[index];
                }
            }
        }

        /// <summary>
        /// 修改表格标题头名称
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="startColumnIndex">开始列的索引</param>
        /// <param name="titleHeaderNameList"></param>
        public static void ModifyGridViewAllTitleHeader(BandedGridView gridView, int startColumnIndex,
            List<string> titleHeaderNameList)
        {
            if (gridView != null && startColumnIndex > 0 && titleHeaderNameList != null && titleHeaderNameList.Count > 0)
            {
                //int count = titleHeaderNameList.Count;
                int count = titleHeaderNameList.Count + (startColumnIndex - 1);
                for (int i = startColumnIndex; i <= count; i++)
                {
                    int index = 0;
                    if (startColumnIndex > 0)
                    {
                        index = i - startColumnIndex;
                    }
                    //string tmp = gridView.Bands[i].Name;
                    gridView.Bands[i].Caption = titleHeaderNameList[index];
                }

            }
        }

        /// <summary>
        /// 修改表格标题头名称
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="startColumnIndex">开始列的索引</param>
        /// <param name="endColumnIndex">结束列的索引</param>
        /// <param name="bandWidth">列的宽度</param>
        /// <param name="titleHeaderNameList"></param>
        public static void ModifyGridViewAllTitleHeader2(BandedGridView gridView, int startColumnIndex, int endColumnIndex,
            int bandWidth, List<string> titleHeaderNameList)
        {
            if (gridView != null && startColumnIndex > 0 && endColumnIndex > 0 && bandWidth > 0
                && titleHeaderNameList != null && titleHeaderNameList.Count > 0)
            {
                for (int i = startColumnIndex; i < endColumnIndex; i++)
                {
                    int index = 0;
                    if (startColumnIndex > 0)
                    {
                        index = i - startColumnIndex;
                    }
                    //string tmp = gridView.Bands[i].Name;
                    gridView.Bands[i].Caption = titleHeaderNameList[index];
                    gridView.Bands[i].Width = bandWidth;
                }
            }
        }

        /// <summary>
        /// 手动设置表格的宽度
        /// </summary>
        /// <param name="gridView"></param>
        public static void MaualSetGridViewWidth(GridView gridView, int startColumnIndex, int endColumnIndex,
            int width)
        {
            if (gridView != null && startColumnIndex >= 0 && endColumnIndex > 0 && width > 0)
            {
                int count = gridView.Columns.Count();
                for (int i = startColumnIndex; i < endColumnIndex; i++)
                {
                    gridView.Columns[i].OptionsColumn.FixedWidth = true;
                    gridView.Columns[i].Width = width;
                }
            }
        }

        /// <summary>
        /// 修改表格标题的宽度
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="startColumnIndex">开始列的索引</param>
        /// <param name="endColumnIndex">结束列的索引</param>
        /// <param name="bandWidth">列的宽度</param>
        public static void ModifyGridViewBandsWidth(BandedGridView gridView, int startColumnIndex, int endColumnIndex,
            int bandWidth)
        {
            if (gridView != null && startColumnIndex >= 0 && endColumnIndex > 0 && bandWidth > 0)
            {
                for (int i = startColumnIndex; i < endColumnIndex; i++)
                {
                    //string tmp = gridView.Bands[i].Name;
                    gridView.Bands[i].Width = bandWidth;
                }
            }
        }


        /// <summary>
        /// 设置指定行列的值
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnFieldName">列字段的名称</param>
        /// <param name="value">需要指定的值</param>
        /// <param name="gridView">gridView组件</param>
        public static void SetAppointRowColumnValue(int rowIndex, string columnFieldName, double value,
            GridView gridView)
        {
            gridView.SetRowCellValue(rowIndex, columnFieldName, value);
        }

        /// <summary>
        /// 设置指定行列的值
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnFieldName">列字段的名称</param>
        /// <param name="value">需要指定的值</param>
        /// <param name="bandedGridView">bandedGridView组件</param>
        public static void SetAppointRowColumnValue(int rowIndex, string columnFieldName, double value,
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView)
        {
            bandedGridView.SetRowCellValue(rowIndex, columnFieldName, value);
        }

        /// <summary>
        /// 清空选中行内容
        /// </summary>
        /// <param name="curSelectedRowIndex">当前选中行的索引</param>
        /// <param name="allFieldName">表格所有字段名称</param>
        /// <param name="bandedGridView">bandedGridView组件</param>
        public static bool ClearCurSelectedRowData(int curSelectedRowIndex, List<string> allFieldName, int startColumnIndex, int endColumnIndex,
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView)
        {
            if (curSelectedRowIndex < 0 || allFieldName == null || allFieldName.Count < 0 ||
                startColumnIndex < 0 || endColumnIndex < 0 || startColumnIndex > endColumnIndex ||
                bandedGridView == null) return false;

            bool result = false;
            try
            {

                int count = allFieldName.Count;
                for (int i = startColumnIndex; i <= endColumnIndex; i++)
                {
                    bandedGridView.SetRowCellValue(curSelectedRowIndex, allFieldName[i], "");
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }

            return result;
        }


        /// <summary>
        /// 给GridControl组件填充内容
        /// </summary>
        /// <param name="gridControl">gridControl组件名称</param>
        /// <param name="gridView">gridView组件名称</param>
        /// <param name="dataTable">dataTable数据</param>
        public static void FillDatasToGridControl(GridControl gridControl, GridView gridView, DataTable dataTable)
        {
            gridControl.DataSource = dataTable;
            gridControl.Refresh();
            gridView.BestFitColumns();
        }


        /// <summary>
        /// 导出表格数据为Excel文件
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        public static void ExportDatasToExcelFile(GridView gridView)
        {
            if (gridView==null)
            {
                MessageBox.Show("表格为空！导出失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridView.RowCount > 65535)
            {
                MessageBox.Show("当前导出数据不能大于65535行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filter = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf(".") + 1);
                if (filter == "xls")
                {
                    XlsExportOptions options = new XlsExportOptions();
                    options.TextExportMode = TextExportMode.Value;
                    options.ExportMode = XlsExportMode.SingleFile;
                    gridView.ExportToXls(saveFileDialog.FileName, options);
                }
                else
                {
                    XlsxExportOptions options = new XlsxExportOptions();
                    options.TextExportMode = TextExportMode.Value;
                    options.ExportMode = XlsxExportMode.SingleFile;
                    gridView.ExportToXlsx(saveFileDialog.FileName, options);
                }

                MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
        }


        /// <summary>
        /// 设置自动生成序号
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="width">宽度</param>
        public static void AutoGeneraterRowNumber(GridView gridView, int width = 36)
        {
            gridView.OptionsView.ShowIndicator = true;
            gridView.IndicatorWidth = width;
        }

        /// <summary>
        /// 清空表格
        /// </summary>
        /// <param name="gridControl">gridControl组件名称</param>
        public static void ClearGridControl(GridControl gridControl)
        {
            gridControl.DataSource = null;
            gridControl.Refresh();
        }


        /// <summary>
        /// 禁止所有列表格列排序
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="disable">禁用（false:表示禁用）</param>
        public static void DisableAllColumnSort(GridView gridView, bool disable)
        {
            gridView.OptionsCustomization.AllowSort = disable;
        }

        /// <summary>
        /// 禁止指定列表格列排序
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="disable">禁用（false:表示禁用）</param>
        public static void DisableAppointColumnSort(GridView gridView, int columnIndex, bool disable)
        {
            if (columnIndex >= 0)
            {
                if (disable)
                {
                    gridView.Columns[columnIndex].OptionsColumn.AllowSort = DefaultBoolean.True;
                }
                else
                {
                    gridView.Columns[columnIndex].OptionsColumn.AllowSort = DefaultBoolean.False;
                }
            }
        }

        /// <summary>
        /// 设置表格是否可以编辑
        /// </summary>
        /// <param name="gridView">GridView组件</param>
        /// <param name="isEdit">是否编辑（true：表示可以编辑,false：表示关闭编辑）</param>
        public static void IsAllowEditGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView, bool isEdit = true)
        {
            gridView.OptionsBehavior.Editable = isEdit;
            gridView.OptionsBehavior.ReadOnly = !isEdit;
        }

        /// <summary>
        /// 是否编辑指定的多列内容
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="needEditColumnFieldNameList">需要编辑列的字段名称列表</param>
        /// <param name="isEdit">是否可编辑(true:表示可以编辑)</param>
        public static void IsEditMutiColumnData(DevExpress.XtraGrid.Views.Grid.GridView gridView, List<string> needEditColumnFieldNameList, bool isEdit = true)
        {
            if (needEditColumnFieldNameList == null || needEditColumnFieldNameList.Count <= 0) return;

            //设置表格允许编辑
            IsAllowEditGridView(gridView, isEdit);

            //只允许编辑指定的列字段

            if (gridView.Columns.Count > 0)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
                {
                    if (needEditColumnFieldNameList.Contains(gridColumn.FieldName))
                    {
                        gridColumn.OptionsColumn.AllowEdit = isEdit;
                    }
                    else
                    {
                        gridColumn.OptionsColumn.AllowEdit = !isEdit;
                    }
                }
            }

        }


        /// <summary>
        /// 设置表格指定标题对齐格式
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="alignment">对齐类型</param>
        public static void SetAppointHeaderAlignment(GridView gridView,
            int startColumnIndex, int endColumnIndex, HorzAlignment alignment)
        {
            for (int i = startColumnIndex; i <= endColumnIndex; i++)
            {
                gridView.Columns[i].AppearanceHeader.TextOptions.HAlignment = alignment;
            }

        }

        ///<summary>
        /// 设置表格指定标题对齐格式
        /// </summary>
        /// <param name="bandedGridView">gridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="alignment">对齐类型</param>
        public static void SetAppointHeaderAlignment2(BandedGridView bandedGridView,
            int startColumnIndex, int endColumnIndex, HorzAlignment alignment)
        {
            for (int i = startColumnIndex; i <= endColumnIndex; i++)
            {
                bandedGridView.Bands[i].AppearanceHeader.TextOptions.HAlignment = alignment;
            }

        }

        /// <summary>
        /// 设置表格指定标题对齐格式
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnName">列名称</param>
        /// <param name="alignment">对齐类型</param>
        public static void SetAppointHeaderAlignment(GridView gridView, string columnName, HorzAlignment alignment)
        {
            gridView.Columns[columnName].AppearanceHeader.TextOptions.HAlignment = alignment;
        }

        /// <summary>
        /// 设置表格指定列对齐格式
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="alignment">对齐类型</param>
        public static void SetAppointColumnAlignment(GridView gridView, int columnIndex, HorzAlignment alignment)
        {
            gridView.Columns[columnIndex].AppearanceCell.TextOptions.HAlignment = alignment;
        }

        /// <summary>
        /// 设置表格指定列对齐格式
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="alignment">对齐类型</param>
        public static void SetAppointColumnAlignment(GridView gridView,
            int startColumnIndex, int endColumnIndex, HorzAlignment alignment)
        {
            for (int i = startColumnIndex; i <= endColumnIndex; i++)
            {
                gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = alignment;
            }
        }

        /// <summary>
        /// 设置表格指定列对齐格式
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnName">列名称</param>
        /// <param name="alignment">对齐类型</param>
        public static void SetAppointColumnAlignment(GridView gridView, string columnName, HorzAlignment alignment)
        {
            gridView.Columns[columnName].AppearanceCell.TextOptions.HAlignment = alignment;
        }

        /// <summary>
        /// 设置表格所有单元格都保留2位小数
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        public static void ResreserveTwoBit(GridView gridView)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                int count = gridView.Columns.Count;
                for (int i = 0; i < count; i++)
                {
                    gridView.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    gridView.Columns[i].DisplayFormat.FormatString = "F2";

                }
            }
        }

        /// <summary>
        /// 设置表格指定单元格都保留2位小数
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        public static void ResreserveTwoBit(GridView gridView, int startColumnIndex, int endColumnIndex)
        {
            if (gridView != null && gridView.Columns.Count > 0 &&
                startColumnIndex > 0 && endColumnIndex > 0 &&
                endColumnIndex <= gridView.Columns.Count)
            {
                //int count = gridView.Columns.Count;
                for (int i = startColumnIndex; i <= endColumnIndex; i++)
                {
                    gridView.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    gridView.Columns[i].DisplayFormat.FormatString = "F2";

                }
            }
        }

        /// <summary>
        /// 设置表格指定单元格都使用百分比
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        public static void SetPercentage(GridView gridView, int startColumnIndex, int endColumnIndex)
        {
            if (gridView != null && gridView.Columns.Count > 0 &&
                startColumnIndex > 0 && endColumnIndex > 0 &&
                endColumnIndex <= gridView.Columns.Count)
            {
                //int count = gridView.Columns.Count;
                for (int i = startColumnIndex; i <= endColumnIndex; i++)
                {
                    gridView.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    gridView.Columns[i].DisplayFormat.FormatString = "P2";

                }
            }
        }


        /// <summary>
        /// 设置表格指定单元格都使用百分比
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <param name="columnName">列名称</param>
        public static void SetPercentage(GridView gridView, string columnName)
        {
            if (gridView != null && gridView.Columns.Count > 0 && !string.IsNullOrEmpty(columnName))
            {
                gridView.Columns[columnName].DisplayFormat.FormatType = FormatType.Numeric;
                gridView.Columns[columnName].DisplayFormat.FormatString = "P2";
            }
        }


        /// <summary>
        /// 给表格指定单元格都保留2位小数后添加%号
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="startColumnIndex"></param>
        /// <param name="endColumnIndex"></param>
        public static void SetResreserveTwoBitAndPercentageChar(GridView gridView, int startColumnIndex, int endColumnIndex)
        {
            if (gridView != null && gridView.Columns.Count > 0 &&
               startColumnIndex > 0 && endColumnIndex > 0 &&
               endColumnIndex <= gridView.Columns.Count)
            {
                for (int i = startColumnIndex; i <= endColumnIndex; i++)
                {
                    gridView.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    gridView.Columns[i].DisplayFormat.FormatString = $"{0:N2}'%'";

                }
            }
        }


        /// <summary>
        /// 给表格指定单元格都保留2位小数后添加%号
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="columnName"></param>
        public static void SetResreserveTwoBitAndPercentageChar(GridView gridView, string columnName)
        {
            if (gridView != null && gridView.Columns.Count > 0 && !string.IsNullOrEmpty(columnName))
            {
                gridView.Columns[columnName].DisplayFormat.FormatType = FormatType.Numeric;
                gridView.Columns[columnName].DisplayFormat.FormatString = $"{0:N2}'%'";
            }
        }

        /// <summary>
        /// 填充一行数据到表格指定行（起始列）
        /// </summary>
        /// <param name="gridControl">gridControl组件</param>
        /// <param name="curSelectedRowIndex">当前选择行的索引</param>
        /// <param name="startFillGridColumnIndex">开始填充到表格列的索引</param>
        /// <param name="needFillGridDataRow">需要填充到表格的行数据</param>
        public static void FillDataRowToGrid(GridControl gridControl, int curSelectedRowIndex, int startFillGridColumnIndex, DataRow needFillGridDataRow)
        {
            if (gridControl == null || curSelectedRowIndex < 0 || startFillGridColumnIndex < 0 ||
                needFillGridDataRow == null) return;

            DataTable dt = (DataTable)(gridControl.DataSource);

            int columnCount = needFillGridDataRow.ItemArray.Length;

            for (int i = 0; i < columnCount; i++)
            {
                dt.Rows[curSelectedRowIndex][startFillGridColumnIndex] = needFillGridDataRow.ItemArray[i].ToString();
                startFillGridColumnIndex++;
            }

            gridControl.DataSource = dt;
        }

    }//Class_end

}
