using DevExpress.XtraCharts;
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
    public partial class ChartForm : DevExpress.XtraEditors.XtraForm
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
        }

        #endregion

        public ChartForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion

        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            this.Resize += ChartForm_Resize;
        }

        #region 窗体控件方法

        private void ChartForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }


        private void simpleButton_BarChart_Click(object sender, EventArgs e)
        {
            ClearChart(chartControl_Bar);

            Dictionary<string, Dictionary<string, double>> needFillTmpDatas = GetVirtualDatas();
            //填充数据
            if (needFillTmpDatas != null && needFillTmpDatas.Count > 0)
            {
                foreach (var item in needFillTmpDatas)
                {
                    string seriesName = item.Key;
                    Dictionary<string, double> curSeriesDataDic = item.Value;

                    FillDataToBarChart(seriesName, curSeriesDataDic, chartControl_Bar);

                }
            }

            ChartSettingsOfLineChart(chartControl_Bar, "折线图示例", "日期",
                Convert.ToDateTime(DateTime.Now.Date.AddDays(-7)), Convert.ToDateTime(DateTime.Now.Date),
                "数值（单位：个）", 0, 100);
        }

        private void simpleButton_LineChart_Click(object sender, EventArgs e)
        {
            ClearChart(chartControl_Line);

            Dictionary<string, Dictionary<string, double>> needFillTmpDatas = GetVirtualDatas();
            //填充数据
            if (needFillTmpDatas != null && needFillTmpDatas.Count > 0)
            {
                foreach (var item in needFillTmpDatas)
                {
                    string seriesName = item.Key;
                    Dictionary<string, double> curSeriesDataDic = item.Value;

                    FillDataToLineChart(seriesName, curSeriesDataDic, chartControl_Line);

                }
            }

            ChartSettingsOfLineChart(chartControl_Line, "折线图示例", "日期",
                Convert.ToDateTime(DateTime.Now.Date.AddDays(-7)), Convert.ToDateTime(DateTime.Now.Date),
                "数值（单位：个）", 0, 100);
        }

        private void simpleButton_PieChart_Click(object sender, EventArgs e)
        {
            ClearChart(chartControl_Pie);

            Dictionary<string, Dictionary<string, double>> needFillTmpDatas = GetVirtualDatas();
            //填充数据
            if (needFillTmpDatas != null && needFillTmpDatas.Count > 0)
            {
                foreach (var item in needFillTmpDatas)
                {
                    string seriesName = item.Key;
                    Dictionary<string, double> curSeriesDataDic = item.Value;

                    FillDataToPieChart(seriesName, curSeriesDataDic, chartControl_Pie,ViewType.Pie);

                }
            }

            ChartSettingsOfPieChart(chartControl_Pie, "饼图示例");
        }

        #endregion


        #region   私有方法


        /// <summary>
        /// 清空图表
        /// </summary>
        /// <param name="chartControl">图表</param>
        private void ClearChart(ChartControl chartControl)
        {
            if (chartControl != null)
            {
                chartControl.DataSource = null;
                chartControl.Series?.Clear();
                chartControl.ClearCache();
                chartControl.ClearSelection();
            }

        }

        #region 柱状图

        /// <summary>
        /// 填充数据到柱状图表
        /// </summary>
        /// <param name="seriesName">图例类型名称</param>
        /// <param name="curSeriesAllDataDic">图例类型对应的所有数据</param>
        /// <param name="chartControl">线性图表</param>
        /// <param name="viewType">线性图表类型</param>
        private void FillDataToBarChart(string seriesName,
            Dictionary<string, double> curSeriesAllDataDic,
            ChartControl chartControl, ViewType viewType = ViewType.Bar)
        {
            if (chartControl == null ||
                curSeriesAllDataDic == null && curSeriesAllDataDic.Count == 0) return;

            //添加一个类型的数据
            Series series = new Series(seriesName, viewType);

            foreach (var item in curSeriesAllDataDic)
            {
                series.Points.Add(new SeriesPoint(item.Key, item.Value));
            }
            chartControl.Series.Add(series);
            //图例的样式设置
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.ResolveOverlappingMode = ResolveOverlappingMode.HideOverlapped;
            series.Label.TextPattern = "{V:.#}";
            
        }

        /// <summary>
        /// 柱状图表设置
        /// </summary>
        /// <param name="chartControl">图表控件</param>
        /// <param name="titleName">图表标题名称</param>
        /// <param name="axisXName">X轴名称</param>
        /// <param name="axisXMinValue">X轴的最小值</param>
        /// <param name="axisXMaxValue">X轴的最大值</param>
        /// <param name="axisYName">Y轴名称</param>
        /// <param name="axisYMinValue">Y轴的最小值</param>
        /// <param name="axisYMaxValue">Y轴的最大值</param>
        private void ChartSettingsOfBarChart(ChartControl chartControl, string titleName,
            string axisXName, object axisXMinValue, object axisXMaxValue,
            string axisYName, object axisYMinValue, object axisYMaxValue)
        {
            if (chartControl.Titles.Count < 1)
            {
                chartControl.Titles.Add(new ChartTitle());
                chartControl.Titles[0].Text = titleName;
            }
            Controls.Add(chartControl);
            chartControl.Show();

            //显示图例复选框
            chartControl.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;

            XYDiagram diagram = (XYDiagram)chartControl.Diagram;
            if (diagram != null)
            {
                //允许缩放X轴
                diagram.EnableAxisXZooming = true;
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Title.Alignment = StringAlignment.Far;
                diagram.AxisX.Title.Text = axisXName;
                //要开启滚动条需设置自动范围为false
                diagram.AxisX.VisualRange.Auto = false;
                //启用X轴滚动条
                diagram.EnableAxisXScrolling = true;

                //在不拉动滚动条的时候，X轴显示的数据个数（固定X轴的长度）
                diagram.AxisX.WholeRange.SetMinMaxValues(axisXMinValue, axisXMaxValue);

                // Define the whole range for the Y-axis. 
                diagram.AxisY.WholeRange.Auto = false;
                diagram.AxisY.WholeRange.SetMinMaxValues(axisYMinValue, axisYMaxValue);


                //允许缩放Y轴
                diagram.EnableAxisYZooming = true;
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Title.Alignment = StringAlignment.Far;
                diagram.AxisY.Title.Text = axisYName;

                chartControl.CrosshairOptions.ShowArgumentLabels = true;
                chartControl.CrosshairOptions.ShowValueLine = true;
            }
        }

        #endregion

        #region 线性图表

        /// <summary>
        /// 填充数据到线性图表
        /// </summary>
        /// <param name="seriesName">图例类型名称</param>
        /// <param name="curSeriesAllDataDic">图例类型对应的所有数据</param>
        /// <param name="chartControl">线性图表</param>
        /// <param name="viewType">线性图表类型</param>
        private void FillDataToLineChart(string seriesName,
            Dictionary<string, double> curSeriesAllDataDic,
            ChartControl chartControl, ViewType viewType = ViewType.Line)
        {
            if (chartControl == null ||
                curSeriesAllDataDic == null && curSeriesAllDataDic.Count == 0) return;

            //添加一个类型的数据
            Series series = new Series(seriesName, viewType);

            foreach (var item in curSeriesAllDataDic)
            {
                series.Points.Add(new SeriesPoint(item.Key, item.Value));
            }
            chartControl.Series.Add(series);
            //图例的样式设置
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.ResolveOverlappingMode = ResolveOverlappingMode.HideOverlapped;
            series.Label.TextPattern = "{V:.#}";
            ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Circle;
            ((LineSeriesView)series.View).LineStyle.DashStyle = DashStyle.Solid;
        }

        /// <summary>
        /// 线性图表设置
        /// </summary>
        /// <param name="chartControl">图表控件</param>
        /// <param name="titleName">图表标题名称</param>
        /// <param name="axisXName">X轴名称</param>
        /// <param name="axisXMinValue">X轴的最小值</param>
        /// <param name="axisXMaxValue">X轴的最大值</param>
        /// <param name="axisYName">Y轴名称</param>
        /// <param name="axisYMinValue">Y轴的最小值</param>
        /// <param name="axisYMaxValue">Y轴的最大值</param>
        private void ChartSettingsOfLineChart(ChartControl chartControl, string titleName,
            string axisXName, object axisXMinValue, object axisXMaxValue,
            string axisYName, object axisYMinValue, object axisYMaxValue)
        {
            if (chartControl.Titles.Count < 1)
            {
                chartControl.Titles.Add(new ChartTitle());
                chartControl.Titles[0].Text = titleName;
            }
            Controls.Add(chartControl);
            chartControl.Show();

            //显示图例复选框
            chartControl.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;

            XYDiagram diagram = (XYDiagram)chartControl.Diagram;
            if (diagram != null)
            {
                //允许缩放X轴
                diagram.EnableAxisXZooming = true;
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Title.Alignment = StringAlignment.Far;
                diagram.AxisX.Title.Text = axisXName;
                //要开启滚动条需设置自动范围为false
                diagram.AxisX.VisualRange.Auto = false;
                //启用X轴滚动条
                diagram.EnableAxisXScrolling = true;

                //在不拉动滚动条的时候，X轴显示的数据个数（固定X轴的长度）
                diagram.AxisX.WholeRange.SetMinMaxValues(axisXMinValue, axisXMaxValue);

                // Define the whole range for the Y-axis. 
                diagram.AxisY.WholeRange.Auto = false;
                diagram.AxisY.WholeRange.SetMinMaxValues(axisYMinValue, axisYMaxValue);


                //允许缩放Y轴
                diagram.EnableAxisYZooming = true;
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Title.Alignment = StringAlignment.Far;
                diagram.AxisY.Title.Text = axisYName;

                chartControl.CrosshairOptions.ShowArgumentLabels = true;
                chartControl.CrosshairOptions.ShowValueLine = true;
            }
        }

        #endregion

        #region 饼图

        /// <summary>
        /// 填充数据到饼图表
        /// </summary>
        /// <param name="seriesName">图例类型名称</param>
        /// <param name="curSeriesAllDataDic">图例类型对应的所有数据</param>
        /// <param name="chartControl">线性图表</param>
        /// <param name="viewType">线性图表类型</param>
        private void FillDataToPieChart(string seriesName,
            Dictionary<string, double> curSeriesAllDataDic,
            ChartControl chartControl, ViewType viewType = ViewType.Line)
        {
            if (chartControl == null ||
                curSeriesAllDataDic == null && curSeriesAllDataDic.Count == 0) return;

            //添加一个类型的数据
            Series series = new Series(seriesName, viewType);

            foreach (var item in curSeriesAllDataDic)
            {
                series.Points.Add(new SeriesPoint(item.Key, item.Value));
            }
            chartControl.Series.Add(series);
            //图例的样式设置
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

        }

        /// <summary>
        /// 饼图表设置
        /// </summary>
        /// <param name="chartControl">图表控件</param>
        /// <param name="titleName">图表标题名称</param>
        /// <param name="axisXName">X轴名称</param>
        /// <param name="axisXMinValue">X轴的最小值</param>
        /// <param name="axisXMaxValue">X轴的最大值</param>
        /// <param name="axisYName">Y轴名称</param>
        /// <param name="axisYMinValue">Y轴的最小值</param>
        /// <param name="axisYMaxValue">Y轴的最大值</param>
        private void ChartSettingsOfPieChart(ChartControl chartControl, string titleName)
        {
            if (chartControl.Titles.Count < 1)
            {
                chartControl.Titles.Add(new ChartTitle());
                chartControl.Titles[0].Text = titleName;
            }
            Controls.Add(chartControl);
            chartControl.Show();

            //显示图例复选框
            chartControl.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
            

            chartControl.CrosshairOptions.ShowArgumentLabels = true;
            chartControl.CrosshairOptions.ShowValueLine = true;
            chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;


        }

        #endregion 

        /// <summary>
        /// 获取虚拟数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Dictionary<string, double>> GetVirtualDatas()
        {
            Dictionary<string, Dictionary<string, double>> tmpDatas =
               new Dictionary<string, Dictionary<string, double>>();

            Dictionary<string, double> tmpADic = new Dictionary<string, double>();
            tmpADic.Add(DateTime.Now.Date.AddDays(-7).ToString(), 36.5);
            tmpADic.Add(DateTime.Now.Date.AddDays(-6).ToString(), 22.3);
            tmpADic.Add(DateTime.Now.Date.AddDays(-5).ToString(), 21.1);
            tmpADic.Add(DateTime.Now.Date.AddDays(-4).ToString(), 25.8);
            tmpADic.Add(DateTime.Now.Date.AddDays(-3).ToString(), 32.3);
            tmpADic.Add(DateTime.Now.Date.AddDays(-2).ToString(), 42.0);
            tmpADic.Add(DateTime.Now.Date.AddDays(-1).ToString(), 35.5);
            tmpDatas.Add("类型A", tmpADic);

            Dictionary<string, double> tmpBDic = new Dictionary<string, double>();
            tmpBDic.Add(DateTime.Now.Date.AddDays(-7).ToString(), 66.5);
            tmpBDic.Add(DateTime.Now.Date.AddDays(-6).ToString(), 51.2);
            tmpBDic.Add(DateTime.Now.Date.AddDays(-5).ToString(), 44.6);
            tmpBDic.Add(DateTime.Now.Date.AddDays(-4).ToString(), 35.8);
            tmpBDic.Add(DateTime.Now.Date.AddDays(-3).ToString(), 42.3);
            tmpBDic.Add(DateTime.Now.Date.AddDays(-2).ToString(), 32.0);
            tmpBDic.Add(DateTime.Now.Date.AddDays(-1).ToString(), 55.5);
            tmpDatas.Add("类型B", tmpBDic);

            return tmpDatas;
        }


        #endregion


    }//Class_end
}