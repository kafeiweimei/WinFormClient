/***
*	Title："基础工具" 项目
*		主题：自定义分页组件
*	Description：
*		功能：
*		    1、获取首页信息
*		    2、获取上一页信息
*		    3、获取下一页信息
*		    4、获取最后一页信息
*		    5、选择每页显示的数据大小
*		    6、可输入页码
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.CustomControl
{
    public partial class FormPageControl : UserControl
    {
        #region   基础参数
        //数据总数
        private int _allCount = 0;
        //每页显示的条数
        private int _pageSize = 0;
        //当前页
        private int _curPage = 1;
        //获取页面数据委托
        public delegate void GetPageDataEvents(int curPage, int pageSize);
        //定义页面数据委托的事件
        public event GetPageDataEvents pageDataEvent;

        //定义页面数据大小委托
        public delegate void GetPageSizeEvents(int pageSize);
        //定义页面数据大小的事件
        public event GetPageSizeEvents pageSizeEvent;
 
        #endregion


        public FormPageControl()
        {
            InitializeComponent();
        }

        private void FormPageControl_Load(object sender, EventArgs e)
        {
            //设置可选页码初始化内容
            SettingPageSize();
            textEdit_CurPageIndex.Text = _curPage.ToString();
        }

        #region   公有方法
        /// <summary>
        /// 获取当前输入的页码
        /// </summary>
        /// <returns></returns>
        public int GetInputPageIndex()
        {
            string strPageIndex = textEdit_CurPageIndex.Text;
            if (string.IsNullOrEmpty(strPageIndex)) return 1;

            int tmpPageIndex = 1;

            int.TryParse(strPageIndex, out tmpPageIndex);
            _curPage = tmpPageIndex;
            return tmpPageIndex;
        }

        /// <summary>
        /// 获取到页面总数
        /// </summary>
        /// <returns>返回页面总数</returns>
        public int GetPageCount()
        {
            int pageCount = 0;

            if (_allCount <= 0 && _pageSize <= 0) return 0;

            if (_allCount % _pageSize == 0)
            {
                pageCount = _allCount / _pageSize;
            }
            else
            {
                pageCount = _allCount / _pageSize + 1;
            }

            return pageCount;
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="curPageParam">当前页</param>
        /// <param name="pageSizeParam">每页显示的数据条数</param>
        /// <param name="allCountParam">所有的数据总数</param>
        public void RefreshPage(int curPageParam, int pageSizeParam, int allCountParam)
        {
            _allCount = allCountParam;
            _pageSize = pageSizeParam;
            _curPage = curPageParam;

            textEdit_CurPageIndex.Text = _curPage.ToString();
            labelControl_PageInfo.Text = $"(共【{_allCount}】条记录，每页【{_pageSize}】条，共【{GetPageCount()}】页)";


            if (_curPage == 0)
            {
                if (GetPageCount() > 0)
                {
                    _curPage = 1;
                    if (pageDataEvent != null)
                    {
                        pageDataEvent(_curPage, _pageSize);
                    }

                }
            }

            if (_curPage > GetPageCount())
            {
                _curPage = GetPageCount();
                if (pageDataEvent != null)
                {
                    pageDataEvent(_curPage, _pageSize);
                }

            }
        }

        /// <summary>
        /// 设置每页显示的数据行数
        /// </summary>
        /// <param name="pageSize">当前页显示的数据行数</param>
        public void SettingSinglePageSize(int pageSize)
        {
            SettingSinglePageSize(comboBoxEdit_PageSize, pageSize);
        }

        /// <summary>
        /// 获取到该页码下拉框控件
        /// </summary>
        public ComboBoxEdit GetComboxEditOfPageSize
        {
            get { return comboBoxEdit_PageSize; }
        }

        /// <summary>
        /// 显示隐藏页码信息
        /// </summary>
        /// <param name="isEnable">是否显示页码信息（true：表示显示）</param>
        public void IsShowPageInfo(bool isEnable = true)
        {
            if (isEnable)
            {
                labelControl_PageInfo.Show();
            }
            else
            {
                labelControl_PageInfo.Hide();
            }
        }

        /// <summary>
        /// 重置分页信息
        /// </summary>
        /// <param name="curPageParam">当前页</param>
        /// <param name="pageSizeParam">每页显示的数据条数</param>
        /// <param name="allCountParam">所有的数据总数</param>
        public void ResetPageInfo(int curPageParam, int pageSizeParam, int allCountParam)
        {
            _allCount = allCountParam;
            _pageSize = pageSizeParam;
            _curPage = curPageParam;

            textEdit_CurPageIndex.Text = _curPage.ToString();
            labelControl_PageInfo.Text = $"(共【{_allCount}】条记录，每页【{_pageSize}】条，共【{GetPageCount()}】页)";
        }


        #endregion

        #region   私有方法

        private void simpleButton_FirstPage_Click(object sender, EventArgs e)
        {
            BtnEvents(sender, e);
        }

        private void simpleButton_PreviousPage_Click(object sender, EventArgs e)
        {
            BtnEvents(sender, e);
        }

        private void simpleButton_NextPage_Click(object sender, EventArgs e)
        {
            BtnEvents(sender, e);
        }

        private void simpleButton_LastPage_Click(object sender, EventArgs e)
        {
            BtnEvents(sender, e);
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEvents(object sender, EventArgs e)
        {
            if (pageDataEvent != null)
            {
                DevExpress.XtraEditors.SimpleButton btm = sender as DevExpress.XtraEditors.SimpleButton;
                string btmTag = btm.Name.ToString();

                //首页按钮单击事件触发
                if (btmTag == "simpleButton_FirstPage")
                {
                    _curPage = 1;
                    pageDataEvent(_curPage, _pageSize);
                }

                //上一页按钮单击事件被触发
                if (btmTag == "simpleButton_PreviousPage")
                {
                    if (_curPage == 1)
                    {
                        return;
                    }
                    if (_curPage <= GetPageCount())
                    {
                        _curPage -= 1;
                        pageDataEvent(_curPage, _pageSize);
                    }
                }
                if (btmTag == "simpleButton_NextPage")
                {
                    if (_curPage == GetPageCount())
                    {
                        return;
                    }
                    if (_curPage < GetPageCount())
                    {
                        _curPage += 1;
                        pageDataEvent(_curPage, _pageSize);
                    }
                }
                if (btmTag == "simpleButton_LastPage")
                {
                    _curPage = GetPageCount();
                    pageDataEvent(_curPage, _pageSize);
                }


            }
        }

        /// <summary>
        /// 设置每页显示数据行数
        /// </summary>
        /// <param name="comboBoxEdit">comboBoxEdit组件</param>
        /// <param name="pageSize">页面显示的大小</param>
        private void SettingSinglePageSize(ComboBoxEdit comboBoxEdit, int pageSize)
        {
            if (pageSize <= 0) return;

            if (!comboBoxEdit.Properties.Items.Contains(pageSize))
            {
                comboBoxEdit.Properties.Items.Add(pageSize);
            }

            comboBoxEdit_PageSize.Text = pageSize.ToString();
        }


        /// <summary>
        /// 页码改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEdit_PageSize_TextChanged(object sender, EventArgs e)
        {
            int pageSize = 0;

            int.TryParse(comboBoxEdit_PageSize.Text, out pageSize);
            if (pageSize > 0)
            {
                _pageSize = pageSize;
            }
            if (pageSizeEvent != null)
            {
                pageSizeEvent(pageSize);
            }

        }



        /// <summary>
        /// 设置页码内容列表
        /// </summary>
        /// <param name="isInput">页码下拉框是否能输入（true：表示可以输入）</param>
        private void SettingPageSize(bool isInput = true)
        {
            //设置该页码ComboxEdit是否能输入，只能选择
            if (isInput)
            {
                comboBoxEdit_PageSize.Properties.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                comboBoxEdit_PageSize.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }

            //设置可选的页码大小
            List<int> pageSizeList = new List<int>()
            {
                10,30,50,70,90,100,1000,10000
            };

            AddInfoToComboxEdit(comboBoxEdit_PageSize, pageSizeList, false);
        }

        /// <summary>
        /// 给ComboxEdit组件添加内容
        /// </summary>
        /// <param name="comboBoxEdit">comboBoxEdit组件</param>
        /// <param name="infoList">信息列表</param>
        /// <param name="showFirstValue">是否显示第一个值（true：表示显示）</param>
        /// <returns>返回添加结果（true:表示添加成功）</returns>
        public static bool AddInfoToComboxEdit<T>(ComboBoxEdit comboBoxEdit, List<T> infoList,
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



        #endregion
    }//Class_end
}
