/***
*	Title："Winform" 项目
*		主题：Winform的UI帮助类
*	Description：
*		功能：
*		    1、给comboBox组件添加信息和获取选中的信息
*		    2、给lookUpEdit组件添加信息和获取选中的信息
*		    3、DateEdit组件操作：
*		                1-自定义DateEdit控件显示格式（显示【年-月-日 时:分:秒】）
*		                2-自定义DateEdit控件显示格式(只显示【年-月-日】)
*		                3-根据时间设置DateEdit初始值
*		                4-获取日期
*		                5-日期转换
*		                6-比较结束日期是否大于等于开始日期
*		                7-根据当前时间设置DateEdit初始值（白班【08:30-20:30】，夜班【20:30-08:30】）
*		                8-根据当前时间设置DateEdit初始值（白班【08:30-20:29:59】，夜班【20:30-08:29:59】）
*		    4、窗体控件操作：
*		                1-打开窗体
*		                2-获取指定窗体或面板下的指定类型的控件
*		                3-通过控件名称获取到控件
*		                
*		    5、GridView表格操作：
*		                1-设置表格是否可以编辑
*		                2-是否编辑表格所有列
*		                3-是否编辑指定的列内容
*		                4-是否编辑指定的多列内容
*		                5-获取表格过滤或排序后的数据
*		                
*		     6、SearchGridLookUpEdit 控件的多选事件设置
*		                
*		                
*	Date：2021
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.Utils
{
    public static class WinformUIHelper
    {

        #region   ComboxEdit、LookUpEdit组件

        /// <summary>
        /// 给ComboxEdit组件添加内容
        /// </summary>
        /// <param name="comboBoxEdit">comboBoxEdit组件</param>
        /// <param name="infoList">信息列表</param>
        /// <param name="showFirstValue">是否显示第一个值（true：表示显示）</param>
        /// <returns>返回添加结果（true:表示添加成功）</returns>
        public static bool AddInfoToComboxEdit(ComboBoxEdit comboBoxEdit, List<string> infoList,
            bool showFirstValue = true)
        {
            bool result = false;
            if (infoList != null && infoList.Count > 0)
            {
                comboBoxEdit.Properties.Items.Clear();
                foreach (var item in infoList)
                {
                    comboBoxEdit.Properties.Items.Add(item);
                }
                //默认显示第一个值
                if (showFirstValue)
                {
                    comboBoxEdit.SelectedIndex = 0;
                }
                else
                {
                    comboBoxEdit.SelectedIndex = -1;
                }

                result = true;
            }
            return result;
        }


        /// <summary>
        /// 给LookupEdit组件添加内容
        /// </summary>
        /// <param name="lookUpEdit">lookUpEdit组件</param>
        /// <param name="infoDic">信息字典</param>
        /// <param name="matchFieldName">匹配自动搜索的字段</param>
        /// <param name="manualInput">手动输入（true:表示开启）</param>
        /// <param name="showFirstValue">是否显示第一个值（true:表示显示）</param>
        /// <returns></returns>
        public static bool AddInfoToLookupEdit(LookUpEdit lookUpEdit,Dictionary<string,string> infoDic,
            string matchFieldName="",bool manualInput=true,bool showFirstValue=true)
        {
            bool result = false;
            if (infoDic!=null && infoDic.Count>0)
            {
                lookUpEdit.Properties.DataSource = infoDic;
                //实际需要使用的字段
                lookUpEdit.Properties.ValueMember = "Key";
                //显示的字段
                lookUpEdit.Properties.DisplayMember = "Value";
                //自动搜索datasouse，选择与之匹配的值，没有的情况下赋值null ,value的值必须与valuemember的数据类型一致。
                lookUpEdit.EditValue = matchFieldName;

                //自适应宽度
                lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                //默认允许手动输入
                if (manualInput)
                {
                    lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                }
                else
                {
                    lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                }

                //默认显示第一个值
                if (showFirstValue)
                {
                    lookUpEdit.ItemIndex = 0;
                }
                else
                {
                    lookUpEdit.Properties.NullText = "";
                    lookUpEdit.ItemIndex = -1;
                }
                result = true;
            }
            return result;
        }


        /// <summary>
        /// 给LookupEdit组件添加内容
        /// </summary>
        /// <param name="lookUpEdit">lookUpEdit组件</param>
        /// <param name="tmpList">信息字典</param>
        /// <param name="matchFieldName">匹配自动搜索的字段</param>
        /// <param name="manualInput">手动输入（true:表示开启）</param>
        /// <param name="showFirstValue">是否显示第一个值（true:表示显示）</param>
        /// <returns></returns>
        public static bool AddInfoToLookupEdit<T>(LookUpEdit lookUpEdit, List<T> tmpList,
            string matchFieldName = "", bool manualInput = true, bool showFirstValue = true)
        {
            bool result = false;
            if (tmpList != null && tmpList.Count > 0)
            {
                lookUpEdit.Properties.DataSource = tmpList;
                //实际需要使用的字段
                lookUpEdit.Properties.ValueMember = "Key";
                //显示的字段
                lookUpEdit.Properties.DisplayMember = "Value";
                //自动搜索datasouse，选择与之匹配的值，没有的情况下赋值null ,value的值必须与valuemember的数据类型一致。
                lookUpEdit.EditValue = matchFieldName;

                //自适应宽度
                lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                //默认允许手动输入
                if (manualInput)
                {
                    lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                }
                else
                {
                    lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                }

                //默认显示第一个值
                if (showFirstValue)
                {
                    lookUpEdit.ItemIndex = 0;
                }
                else
                {
                    lookUpEdit.Properties.NullText = "";
                    lookUpEdit.ItemIndex = -1;
                }
                result = true;
            }
            return result;
        }


        /// <summary>
        /// 给LookupEdit组件添加模型内容
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="lookUpEdit">lookUpEdit组件</param>
        /// <param name="tmpList">模型列表</param>
        /// <param name="modelFieldNameList">模型字段名称列表</param>
        /// <param name="modelFieldStartIndex">模型字段的起始索引</param>
        /// <param name="displayFieldName">下拉框显示内容的字段名称</param>
        /// <param name="valueFieldName">下拉框显示内容实际对应使用的字段名称</param>
        /// <param name="matchFieldName">下拉框搜索匹配的字段名称</param>
        /// <param name="manualInput">手动输入（true:表示开启）</param>
        /// <param name="showFirstValue">是否显示第一个值（true:表示显示）</param>
        /// <returns></returns>
        public static bool AddModelInfoToLookupEdit<T>(LookUpEdit lookUpEdit, List<T> tmpList,
            List<string> modelFieldNameList,int modelFieldStartIndex,
            string displayFieldName,string valueFieldName,string matchFieldName = "", 
            bool manualInput = true, bool showFirstValue = true)
        {
            bool result = false;
            if (tmpList != null && tmpList.Count > 0 && 
                modelFieldNameList!=null && modelFieldNameList.Count>0)
            {
                lookUpEdit.Properties.DataSource = tmpList;
                //实际需要使用的字段
                lookUpEdit.Properties.ValueMember = valueFieldName;
                //显示的字段
                lookUpEdit.Properties.DisplayMember = displayFieldName;
                //自动搜索datasouse，选择与之匹配的值，没有的情况下赋值null ,value的值必须与valuemember的数据类型一致。
                lookUpEdit.EditValue = matchFieldName;

                //自适应宽度
                lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                //填充列
                lookUpEdit.Properties.PopulateColumns();
                //设置列属性
                int count = (modelFieldStartIndex+modelFieldNameList.Count);
                for (int i = modelFieldStartIndex; i < count; i++)
                {
                    //lookUpEdit.Properties.Columns[0].Visible = false;
                    lookUpEdit.Properties.Columns[i].Caption = modelFieldNameList[i];
                }

                //lookUpEdit.Properties.Columns[1].Width = 120;
                //lookUpEdit.Properties.Columns[2].Width = 300;

                ////控制选择项的总宽度
                //lookUpEdit.Properties.PopupWidth = 200;

                //默认允许手动输入
                if (manualInput)
                {
                    lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                }
                else
                {
                    lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                }

                //默认显示第一个值
                if (showFirstValue)
                {
                    lookUpEdit.ItemIndex = 0;
                }
                else
                {
                    lookUpEdit.Properties.NullText = "";
                    lookUpEdit.ItemIndex = -1;
                }
                result = true;
            }
            return result;
        }


        /// <summary>
        /// 获取comboBoxEdit组件当前选择的内容
        /// </summary>
        /// <param name="comboBoxEdit">comboBoxEdit组件</param>
        /// <returns>返回当前选择的键值对</returns>
        public static Dictionary<string, string> GetComboxInfoOfSelected(ComboBoxEdit comboBoxEdit)
        {
            Dictionary<string, string> tmpDic = new Dictionary<string, string>();
            if (comboBoxEdit != null)
            {
                if (comboBoxEdit.SelectedItem != null)
                {
                    string key = comboBoxEdit.EditValue.ToString();
                    string value = comboBoxEdit.Text.Trim();
                    tmpDic.Add(key, value);
                }
            }
            return tmpDic;
        }

        /// <summary>
        /// 获取lookUpEdit组件当前选择的内容
        /// </summary>
        /// <param name="lookUpEdit">lookUpEdit组件</param>
        /// <returns>返回当前选择的键值对</returns>
        public static Dictionary<string, string> GetLookUpEditInfoOfSelected(LookUpEdit lookUpEdit)
        {
            Dictionary<string, string> tmpDic = new Dictionary<string, string>();
            if (lookUpEdit != null)
            {
                if (lookUpEdit.EditValue != null)
                {
                    string key = lookUpEdit.EditValue.ToString();
                    string value = lookUpEdit.Text.Trim();
                    tmpDic.Add(key, value);
                }
            }
            return tmpDic;
        }


        #endregion

        #region   DateEdit组件

        /// <summary>
        /// 自定义DateEdit控件显示格式（显示【年-月-日 时:分:秒】）
        /// </summary>
        /// <param name="dateEdit">DateEdit控件</param>
        /// <param name="dateTime">传入的时间</param>
        public static void CustomDateEditFormat(this DateEdit dateEdit, DateTime dateTime)
        {
            // DateTime.Now.AddYears(-1);
            dateEdit.EditValue = dateTime;
            dateEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.EditFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.VistaDisplayMode = DefaultBoolean.True;
            dateEdit.Properties.VistaEditTime = DefaultBoolean.True;
            dateEdit.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm:ss";
            dateEdit.Properties.VistaTimeProperties.DisplayFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm:ss";
            dateEdit.Properties.VistaTimeProperties.EditFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm:ss";
        }

        /// <summary>
        /// 自定义DateEdit控件显示格式（显示【年-月-日 时:分:秒】）
        /// </summary>
        /// <param name="dateEdit"></param>
        public static void CustomDateEditFormat(this DateEdit dateEdit, string dateFormat = "yyyy-MM-dd HH:mm:ss")
        {
            dateEdit.Properties.DisplayFormat.FormatString = dateFormat;
            dateEdit.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.EditFormat.FormatString = dateFormat;
            dateEdit.Properties.EditFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.Mask.EditMask = dateFormat;
            dateEdit.Properties.VistaDisplayMode = DefaultBoolean.True;
            dateEdit.Properties.VistaEditTime = DefaultBoolean.True;
            dateEdit.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm:ss";
            dateEdit.Properties.VistaTimeProperties.DisplayFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm:ss";
            dateEdit.Properties.VistaTimeProperties.EditFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm:ss";
        }


        /// <summary>
        /// 自定义DateEdit控件显示格式(只显示【年-月-日】)
        /// </summary>
        /// <param name="dateEdit"></param>
        /// <param name="dateTime"></param>
        public static void CustomDateEditFormat2(this DateEdit dateEdit, DateTime dateTime)
        {
            // DateTime.Now.AddYears(-1);
            dateEdit.EditValue = dateTime;
            dateEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            dateEdit.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            dateEdit.Properties.EditFormat.FormatType = FormatType.DateTime;
            dateEdit.Properties.Mask.EditMask = "yyyy-MM-dd";
            dateEdit.Properties.VistaDisplayMode = DefaultBoolean.True;
            dateEdit.Properties.VistaEditTime = DefaultBoolean.True;

        }

        /// <summary>
        /// 根据时间设置DateEdit初始值
        /// </summary>
        /// <param name="dateEdit">开始日期</param>
        /// <param name="dateEdit">日期格式</param>
        public static void SetDateEditValue(DateEdit dateEdit, DateTime dateTime, string dateFormat)
        {
            CustomDateEditFormat(dateEdit, dateFormat);

            dateEdit.EditValue = dateTime;
        }

        /// <summary>
        /// 根据当前时间设置DateEdit初始值
        /// </summary>
        /// <param name="startDateEdit">开始日期</param>
        /// <param name="endDateEdit">结束日期</param>
        public static void SetDateEditValue(DateEdit startDateEdit, DateEdit endDateEdit)
        {
            int hour = DateTime.Now.Hour;
            if (8 <= hour && hour < 20)
            {

                startDateEdit.EditValue = Convert.ToDateTime(GetDate(startDateEdit,"yyyy-MM-dd") + " 08:00");
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(startDateEdit, "yyyy-MM-dd") + " 20:00");
            }
            else if (20 <= hour && hour <= 23)
            {
                startDateEdit.EditValue = Convert.ToDateTime(GetDate(startDateEdit, "yyyy-MM-dd") + " 20:00");
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(startDateEdit, "yyyy-MM-dd") + " 08:00").AddDays(1);
            }
            else if (0 <= hour && hour < 8)
            {
                startDateEdit.EditValue = Convert.ToDateTime(GetDate(startDateEdit, "yyyy-MM-dd") + " 20:00").AddDays(-1);
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(startDateEdit, "yyyy-MM-dd") + " 08:00");
            }
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="dateEdit">DateEdit控件</param>
        /// <param name="dateFormat">日期格式</param>
        /// <returns></returns>
        public static string GetDate(DateEdit dateEdit, string dateFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (dateEdit == null)
            {
                return DateTime.Now.ToString(dateFormat);
            }
            if (string.IsNullOrEmpty(dateEdit.Text.Trim()))
            {
                return null;
            }
            return dateEdit.DateTime.ToString(dateFormat);
        }

        /// <summary>
        /// 日期转换
        /// </summary>
        /// <param name="strDate">需要转换的日期（比如："2021-08-18" "2021-08-18 11:37:36"）</param>
        /// <param name="dateFormat">日期的格式（比如："yyyy-MM-dd HH:mm:ss"）</param>
        /// <returns></returns>
        public static DateTime DateConvert(string strDate, string dateFormat)
        {
            DateTime tmp = DateTime.ParseExact(strDate, dateFormat, System.Globalization.CultureInfo.InvariantCulture);

            return tmp;
        }

        /// <summary>
        /// 比较结束日期是否大于等于开始日期
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>返回比较结果（true:表示结束日期>=开始日期）</returns>
        public static bool CompareTwoDate(DateTime startDate,DateTime endDate)
        {
            bool result = false;

            TimeSpan secondsSpan = new TimeSpan(endDate.Ticks - startDate.Ticks);
            double calculateSeconds = secondsSpan.TotalMilliseconds;
            if (calculateSeconds >= 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 根据当前时间设置DateEdit初始值（白班【08:30-20:30】，夜班【20:30-08:30】）
        /// </summary>
        /// <param name="statDateEdit">开始日期</param>
        /// <param name="endDateEdit">结束日期</param>
        public static void SetDateEditValue_CX(DateEdit statDateEdit, DateEdit endDateEdit)
        {
            DateTime de = DateTime.Now;

            DateTime frontStartDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 08:30:00").AddDays(-1);
            DateTime startDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 08:30:00");
            DateTime endDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 20:30:00");
            DateTime secondEndDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 08:30:00").AddDays(1);

            double t0 = DateTimeHelper.DiffMinutesAndDecimal(frontStartDate, de);
            double t1 = DateTimeHelper.DiffMinutesAndDecimal(startDate, de);
            double t2 = DateTimeHelper.DiffMinutesAndDecimal(endDate, de);
            double t3 = DateTimeHelper.DiffMinutesAndDecimal(secondEndDate, de);

            if (t1 >= 0 && t2 < 0)
            {

                statDateEdit.EditValue = Convert.ToDateTime(GetDate(statDateEdit, "yyyy-MM-dd") + " 08:30:00");
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(endDateEdit, "yyyy-MM-dd") + " 20:30:00");
            }
            else if (t2 >= 0 && t3 < 0)
            {
                statDateEdit.EditValue = Convert.ToDateTime(GetDate(statDateEdit, "yyyy-MM-dd") + " 20:30:00");
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(endDateEdit, "yyyy-MM-dd") + " 08:30:00").AddDays(1);
            }
            else if (t0 >= 0 && t1 < 0)
            {
                statDateEdit.EditValue = Convert.ToDateTime(GetDate(statDateEdit, "yyyy-MM-dd") + " 20:30:00").AddDays(-1);
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(endDateEdit, "yyyy-MM-dd") + " 08:30:00");
            }
        }

        /// <summary>
        /// 根据当前时间设置DateEdit初始值（白班【08:30-20:29:59】，夜班【20:30-08:29:59】）
        /// </summary>
        /// <param name="statDateEdit">开始日期</param>
        /// <param name="endDateEdit">结束日期</param>
        public static void SetDateEditValue_CX2(DateEdit statDateEdit, DateEdit endDateEdit)
        {
            DateTime de = DateTime.Now;

            DateTime frontStartDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 08:30:00").AddDays(-1);
            DateTime startDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 08:30:00");
            DateTime endDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 20:30:00");
            DateTime secondEndDate = Convert.ToDateTime(de.ToString("yyyy-MM-dd") + " 08:30:00").AddDays(1);

            double t0 = DateTimeHelper.DiffMinutesAndDecimal(frontStartDate, de);
            double t1 = DateTimeHelper.DiffMinutesAndDecimal(startDate, de);
            double t2 = DateTimeHelper.DiffMinutesAndDecimal(endDate, de);
            double t3 = DateTimeHelper.DiffMinutesAndDecimal(secondEndDate, de);

            if (t1 >= 0 && t2 < 0)
            {
                statDateEdit.EditValue = Convert.ToDateTime(GetDate(statDateEdit, "yyyy-MM-dd") + " 08:30:00");
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(endDateEdit, "yyyy-MM-dd") + " 20:29:59");
            }
            else if (t2 >= 0 && t3 < 0)
            {
                statDateEdit.EditValue = Convert.ToDateTime(GetDate(statDateEdit, "yyyy-MM-dd") + " 20:30:00");
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(endDateEdit, "yyyy-MM-dd") + " 08:29:59").AddDays(1);
            }
            else if (t0 >= 0 && t1 < 0)
            {
                statDateEdit.EditValue = Convert.ToDateTime(GetDate(statDateEdit, "yyyy-MM-dd") + " 20:30:00").AddDays(-1);
                endDateEdit.EditValue = Convert.ToDateTime(GetDate(endDateEdit, "yyyy-MM-dd") + " 08:29:59");
            }
        }



        #endregion


        #region   窗体及其控件操作

        /// <summary>
        /// 获取窗体实例
        /// </summary>
        /// <param name="formNamspaceName">窗体命名空间和名称</param>
        /// <returns></returns>
        public static Form LoadForm(string formNamspaceName)
        {
            var newForm = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(formNamspaceName, false);

            return (Form)newForm;
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <typeparam name="TForm">需打开的窗体类型</typeparam>
        /// <param name="form">需打开的窗体</param>
        /// <param name="isMax">是否最大化（true:表示开启最大化）</param>
        public static void OpenForm<TForm>(ref TForm form,bool isMax = false) where TForm : Form, new() 
        {
            if (form == null || form.IsDisposed)
            {
                form = new TForm();
            }
            form.Show(); //显示子窗口
            if (isMax)
            {
                //窗体最大化显示
                form.WindowState = FormWindowState.Maximized;
            }

            form.Focus();  //子窗口获得焦点
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <typeparam name="TchildrenForm">需要打开的窗体类型</typeparam>
        /// <typeparam name="TparentForm">父窗体类型</typeparam>
        /// <param name="form">需要打开的窗体名称</param>
        /// <param name="parentForm">需要指定的父窗体名称</param>
        /// <param name="isParentRelationship">是否建立父子关系</param>
        public static void OpenForm<TchildrenForm,TparentForm>(ref TchildrenForm form, TparentForm parentForm=null,
            bool isMax=false,bool isParentRelationship=false) where TchildrenForm : XtraForm, new() where TparentForm : XtraForm
        {
          
            if (form == null || form.IsDisposed)
            {
                form = new TchildrenForm();
            }
            if (parentForm!=null)
            {
                if (isParentRelationship)
                {
                    //建立父子关系  
                    form.TopLevel = false;
                    form.Parent = parentForm;
                }
                else
                {
                    form.TopLevel = true;
                }
            }
            form.Show(); //显示子窗口
            if (isMax)
            {
                //窗体最大化显示
                form.WindowState = FormWindowState.Maximized;
            }

            form.Focus();  //子窗口获得焦点
        }

        /// <summary>
        /// 获取指定窗体或面板下的指定类型的控件
        /// </summary>
        /// <typeparam name="T">控件类型</typeparam>
        /// <param name="containChildControlWindow">包含子控件的窗体（比如窗体是[Controls]、panel是[panel.controls]）</param>
        /// <returns></returns>
        public static Stack<T> GetAllControlOfWindows<T>(Control.ControlCollection containChildControlWindow)
        {
            Stack<T> tmpStack = new Stack<T>();
            foreach (var control in containChildControlWindow)
            {
                if (control is T)
                {
                    tmpStack.Push((T)control);
                }

            }

            return tmpStack;
        }


        /// <summary>
        /// 通过控件名称获取到控件
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <param name="containChildControlWindow">包含子控件的窗体（比如窗体是[Controls]、panel是[panel.controls]）</param>
        /// <returns></returns>
        public static Control GetControlOfName(string controlName, Control.ControlCollection containChildControlWindow)
        {
            if (string.IsNullOrEmpty(controlName)) return null;

            foreach (Control item in containChildControlWindow)
            {
                if (item.Name.Equals(controlName))
                {
                    return item;
                }
            }

            return null;
        }


        #endregion


        #region   屏幕分辨率设置

        /// <summary>
        /// 获取屏幕分辨率
        /// </summary>
        /// <returns></returns>
        public static int[] GetScreenResolution()
        {
            int[] resolution = new int[2];
            double workWidth = SystemParameters.WorkArea.Width; // 屏幕工作区域宽度
            double workHeight = SystemParameters.WorkArea.Height; // 屏幕工作区域高度
            double screenWidth = SystemParameters.PrimaryScreenWidth; // 屏幕整体宽度
            double screenHeight = SystemParameters.PrimaryScreenHeight; // 屏幕整体高度
            int Width = (int)(workWidth * 0.8 + 0.5); // 设置窗体宽度
            int Height = (int)(workHeight * 0.8 + 0.5); // 设置窗体高度

            resolution[0] = Width;
            resolution[1] = Height;
            return resolution;

        }

        /// <summary>
        /// 获取原始的屏幕分别率
        /// </summary>
        /// <returns></returns>
        public static int[] GetOriginalScreenResolution()
        {
            int[] resolution = new int[2];
            Screen screen = Screen.PrimaryScreen;
            resolution[0] = screen.Bounds.Width;
            resolution[1] = screen.Bounds.Height;

            return resolution;
        }

        /// <summary>
        /// 根据屏幕分辨率设置不同的图表大小
        /// </summary>
        /// <returns></returns>
        public static int[] GetChartSizeOfScreen()
        {
            int[] resolution = new int[2];
            //获取屏幕分辨率
            int[] screenResoultion = GetOriginalScreenResolution();
            if (screenResoultion[0] >= 1920 && screenResoultion[1] >= 1080)
            {
                resolution[0] = 1860;
                resolution[1] = 760;
            }
            else
            {
                resolution[0] = 1320;
                resolution[1] = 520;
            }

            return resolution;
        }

        /// <summary>
        /// 根据屏幕分辨率设置不同的图表位置
        /// </summary>
        /// <returns></returns>
        public static int[] GetChartLocationOfScreen()
        {
            int[] location = new int[2];
            //获取屏幕分辨率
            int[] screenResoultion = GetOriginalScreenResolution();
            if (screenResoultion[0] >= 1920 && screenResoultion[1] >= 1080)
            {
                location[0] = 12;
                location[1] = 100;
            }
            else
            {
                location[0] = 12;
                location[1] = 75;
            }

            return location;
        }

        #endregion 


        #region   GridView表格操作

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
        /// 是否编辑表格所有列
        /// </summary>
        /// <param name="gridView">GridView表格</param>
        /// <param name="isEdit">是否可编辑(true:表示可以编辑)</param>
        public static void IsEditAllColumnGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView, bool isEdit = true)
        {
            //设置表格允许编辑
            IsAllowEditGridView(gridView, isEdit);

            //允许所有列可以编辑
            if (gridView.Columns.Count > 0)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
                {
                    gridColumn.OptionsColumn.AllowEdit = isEdit;
                }
            }

        }

        /// <summary>
        /// 是否编辑指定的列内容
        /// </summary>
        /// <param name="gridView">gridView控件</param>
        /// <param name="needEditColumnFieldName">需要编辑的列字段名称</param>
        /// <param name="isEdit">是否可编辑(true:表示可以编辑)</param>
        public static void IsEditAppointColumnData(DevExpress.XtraGrid.Views.Grid.GridView gridView, string needEditColumnFieldName, bool isEdit = true)
        {
            if (string.IsNullOrEmpty(needEditColumnFieldName)) return;

            //设置表格允许编辑
            IsAllowEditGridView(gridView, isEdit);

            //只允许编辑指定的列字段

            if (gridView.Columns.Count > 0)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
                {
                    if (gridColumn.FieldName.Equals(needEditColumnFieldName))
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

        #region   获取表格过滤或排序后的数据
        /// <summary>
        /// 获取GridView过滤或排序后的数据集
        /// </summary>
        /// <typeparam name="T">泛型类对象</typeparam>
        /// <param name="gridView">gridView组件</param>
        /// <returns></returns>
        public static IEnumerable<T> GetFilterOrSortDatasOfGridView<T>(DevExpress.XtraGrid.Views.Grid.GridView gridView) where T : class
        {
            var list = new List<T>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (gridView.IsGroupRow(i))
                    continue;
                var entity = gridView.GetRow(i) as T;
                if (entity == null)
                    continue;
                list.Add(entity);
            }
            return list;
        }

        /// <summary>
        /// 获取GridView过滤或排序后的数据集
        /// </summary>
        /// <param name="gridView">gridView组件</param>
        /// <returns></returns>
        public static DataTable GetFilterOrSortDatasOfGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            DataTable _dt = gridView.GridControl.DataSource as DataTable;
            if (_dt == null) return null;

            DataTable dt = _dt.Clone();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (gridView.IsGroupRow(i))
                    continue;
                var dr = gridView.GetDataRow(i);
                if (dr == null)
                    continue;
                dt.Rows.Add(dr.ItemArray);
            }
            return dt;
        }

        #endregion

        #endregion

        #region   SearchGridLookUpEdit 控件的多选事件设置
        /// <summary>
        /// 设置SearchGridLookUpEdit控件可以多选和基础数据
        /// </summary>
        /// <param name="gridLookUpEdit">gridLookUpEdit组件</param>
        /// <param name="dataSource">需要显示的数据源</param>
        /// <param name="displayMember">显示的字段名称</param>
        /// <param name="valueMember">实际使用的值名称</param>
        public static void SearchGridLookUpEditMultiSelectSettings(DevExpress.XtraEditors.GridLookUpEditBase gridLookUpEdit, object dataSource, string displayMember, string valueMember)
        {
            if (gridLookUpEdit == null || dataSource == null || string.IsNullOrEmpty(displayMember) || string.IsNullOrEmpty(valueMember)) return;

            gridLookUpEdit.Properties.DataSource = dataSource;
            gridLookUpEdit.Properties.DisplayMember = displayMember;
            gridLookUpEdit.Properties.ValueMember = valueMember;
            gridLookUpEdit.Text = "";
        }

        /// <summary>
        /// 设置SearchGridLookUpEdit控件多选事件
        /// </summary>
        /// <param name="searchLookUpEdit">searchLookUpEdit组件</param>
        /// <param name="sender">弹窗事件的Sender参数</param>
        /// <param name="e">弹窗事件的e参数</param>
        public static void SetSearchGridLookUpEditMultiSelectEvent(SearchLookUpEdit searchLookUpEdit, object sender, EventArgs e)
        {
            //获取到弹窗内容
            PopupSearchLookUpEditForm form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl layout = popup.Controls.OfType<LayoutControl>().FirstOrDefault();
            //设置SearchGridLookUpEdit控件多选事件
            SetSearchGridLookUpEditMultiSelect(searchLookUpEdit, layout);
        }

        /// <summary>
        /// 设置SearchGridLookUpEdit控件多选事件
        /// </summary>
        /// <param name="gridLookUpEdit">SearchGridLookUpEdit控件</param>
        /// <param name="layout">SearchGridLookUpEdit控件的弹窗控件</param>
        /// <param name="separator">勾选后显示的分隔符号</param>
        private static void SetSearchGridLookUpEditMultiSelect(DevExpress.XtraEditors.GridLookUpEditBase gridLookUpEdit, LayoutControl layout, string separator = ",")
        {
            if (gridLookUpEdit == null || layout == null) return;

            var view = gridLookUpEdit.Properties.PopupView as DevExpress.XtraGrid.Views.Grid.GridView;
            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            view.OptionsSelection.CheckBoxSelectorColumnWidth = 45;

            LabelControl searchResult = new LabelControl() { Text = "已选择 0 个项目" };
            //当前选择的内容列表
            List<string> curSelectedContent = new List<string>();

            //如果窗体内空间没有确认按钮，则自定义确认simplebutton，取消simplebutton，选中结果label
            if (layout.Controls.OfType<Control>().Where(ct => ct.Name == "btOK").FirstOrDefault() == null)
            {
                //得到空的空间
                EmptySpaceItem a = layout.Items.Where(it => it.TypeName == "EmptySpaceItem").FirstOrDefault() as EmptySpaceItem;

                //得到取消按钮的容器
                Control clearBtn = layout.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
                LayoutControlItem clearLCI = (LayoutControlItem)layout.GetItemByControl(clearBtn);
                //清空按钮事件
                clearBtn.Click += (s, e) =>
                {
                    curSelectedContent?.Clear();

                    gridLookUpEdit.EditValue = null;
                    gridLookUpEdit.Text = null;
                    view.ClearSelection();
                    gridLookUpEdit.RefreshEditValue();

                    searchResult.Text = "已选择 0 个项目";

                };

                //添加一个simplebutton控件作为(确认按钮)
                LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
                myLCI.TextVisible = false;
                SimpleButton btOK = new SimpleButton() { Name = "btOK", Text = "确定" };
                //确认按钮事件
                btOK.Click += (s, e) =>
                {
                    curSelectedContent?.Clear();
                    var indexs = view.GetSelectedRows();
                    if (indexs == null || indexs.Length < 1)
                    {
                        gridLookUpEdit.Text = "";
                        //关闭弹窗
                        gridLookUpEdit.ClosePopup();
                        return;
                    }

                    foreach (var index in indexs)
                    {
                        var value = view.GetRowCellDisplayText(index, gridLookUpEdit.Properties.DisplayMember);
                        curSelectedContent.Add(value);
                    }
                    gridLookUpEdit.RefreshEditValue();
                    //关闭弹窗
                    gridLookUpEdit.ClosePopup();
                    //显示选中的内容且进行拼接
                    gridLookUpEdit.Text = string.Join(separator, curSelectedContent.ToArray());
                };

                myLCI.Control = btOK;
                myLCI.SizeConstraintsType = SizeConstraintsType.Custom;//控件的大小设置为自定义
                myLCI.MaxSize = clearLCI.MaxSize;
                myLCI.MinSize = clearLCI.MinSize;
                myLCI.Move(clearLCI, DevExpress.XtraLayout.Utils.InsertType.Left);
                myLCI.BestFitWeight = 20;

                //添加一个label控件（选中结果显示）
                LayoutControlItem msgLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(a.Parent);
                msgLCI.TextVisible = false;
                msgLCI.Control = searchResult;
                msgLCI.Move(a, DevExpress.XtraLayout.Utils.InsertType.Left);
                msgLCI.BestFitWeight = 100;
            }

            //关闭下拉框的时候获取选中的集合
            gridLookUpEdit.CloseUp += (s, e) =>
            {
                curSelectedContent?.Clear();

                var indexs = view.GetSelectedRows();
                if (indexs == null || indexs.Length < 1)
                {
                    gridLookUpEdit.Text = "";
                    return;
                }

                foreach (var index in indexs)
                {
                    var value = view.GetRowCellDisplayText(index, gridLookUpEdit.Properties.DisplayMember);
                    curSelectedContent.Add(value);
                }
                gridLookUpEdit.RefreshEditValue();
                //显示选中的内容且进行拼接
                gridLookUpEdit.Text = string.Join(separator, curSelectedContent.ToArray());
            };

            //根据选中的集合设置显示文本并且用符号拼接起来
            gridLookUpEdit.Properties.CustomDisplayText += (s, e) =>
            {
                if (!gridLookUpEdit.IsPopupOpen)
                    e.DisplayText = string.Join(separator, curSelectedContent.ToArray());
            };

            //选择事件
            view.SelectionChanged += (s, e) =>
            {
                curSelectedContent?.Clear();

                var curSelectedCount = view.SelectedRowsCount;

                searchResult.Text = $"已选择 {curSelectedCount} 个项目";

            };


        }

        /// <summary>
        /// 获取选中的多行数据
        /// </summary>
        /// <param name="searchLookUpEdit">searchLookUpEdit组件</param>
        /// <returns></returns>
        public static List<string> GetSelectedMutiData(SearchLookUpEdit searchLookUpEdit)
        {
            if (searchLookUpEdit == null) return null;

            List<string> tmpList = new List<string>();
            var view = searchLookUpEdit.Properties.PopupView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view.OptionsSelection.MultiSelect)
            {
                var indexs = view.GetSelectedRows();
                if (indexs == null || indexs.Length < 1) return null;

                foreach (var index in indexs)
                {
                    var value = view.GetRowCellDisplayText(index, searchLookUpEdit.Properties.DisplayMember);
                    tmpList.Add(value);
                }

                return tmpList;
            }
            else
            {
                return null;
            }

        }

        #endregion 

    }//Class_end

}
