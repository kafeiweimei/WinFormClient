using CoffeeMilk13.UI.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
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
    public partial class GridControlCustomPageForm : DevExpress.XtraEditors.XtraForm
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

        public GridControlCustomPageForm()
        {
            InitializeComponent();

            #region   初始化控件缩放

            x = Width;
            y = Height;
            setTag(this);

            #endregion
        }

        private void GridControlCustomPageForm_Load(object sender, EventArgs e)
        {
            this.Resize += GridControlCustomPageForm_Resize;

            InitGridControl();
        }

        private void GridControlCustomPageForm_Shown(object sender, EventArgs e)
        {
            BeginInvoke(new Action(InitSplitPageInfo));
        }


        #region 窗体控件方法

        private void GridControlCustomPageForm_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        private void simpleButton_Query_Click(object sender, EventArgs e)
        {
            #region   分页查询

            int curPage = GetCurPageIndex();

            //绑定当前页面数据
            //BindCurPageDatas_DB(formPageControl1, GetCurPageIndex(), _pageSize);

            FillGridByPage_Test(GetCurPageIndex(), _pageSize, _totalSize = peopeoInfos.Count());

            #endregion
        }

        private void simpleButton_Clear_Click(object sender, EventArgs e)
        {
            formPageControl1.ResetPageInfo(1,2,0);
        }

        private void simpleButton_Export_Click(object sender, EventArgs e)
        {
            GridControlHelper.ExportDatasToExcelFile(gridView1);
        }

        #endregion


        #region   私有方法

        /// <summary>
        /// 模拟一个人员数据列表
        /// </summary>
        /// <returns></returns>
        private List<TestPeopleInfo> GetPeopeoInfos()
        {
            List<TestPeopleInfo> peopeoInfos = new List<TestPeopleInfo>()
            {
                new TestPeopleInfo{ ID="CK001",Name="杨万里",Sex="男",IdCard="523033199001026780"},
                new TestPeopleInfo{ ID="CK002",Name="杨新宇",Sex="男",IdCard="523033199001026781"},
                new TestPeopleInfo{ ID="CK003",Name="钟一明",Sex="男",IdCard="523033199001026782"},
                new TestPeopleInfo{ ID="CK004",Name="张艺上",Sex="男",IdCard="523033199001026783"},
                new TestPeopleInfo{ ID="CK004",Name="齐伟伟",Sex="男",IdCard="523033199001026784"},
                new TestPeopleInfo{ ID="CK006",Name="胡一统",Sex="男",IdCard="523033199001026785"},
                new TestPeopleInfo{ ID="CK007",Name="马国富",Sex="男",IdCard="523033199001026786"},
                new TestPeopleInfo{ ID="CK008",Name="李宝军",Sex="男",IdCard="523033199001026787"},
                new TestPeopleInfo{ ID="CK009",Name="软文策",Sex="男",IdCard="523033199001026788"},
            };

            //TestPeopleInfo peopeoInfo = new TestPeopleInfo()
            //{
            //    ID = "CK001",
            //    Name = "杨万里",
            //    Sex = "男",
            //    IdCard = "523033199001026780"
            //};

            //string str = ClassHelper.GetAllProperties(peopeoInfo);

            ////解析实体类
            //ClassHelper.AnalyAllPropertiesString(str);

            return peopeoInfos;
        }

        /// <summary>
        /// 表格初始化
        /// </summary>
        private void InitGridControl()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ID", "编号");
            dic.Add("Name", "姓名");
            dic.Add("Sex", "性别");
            dic.Add("IdCard", "身份证号");

            ////绑定表格表头列和标题【无分页】
            //GridControlHelper.BindHeaderAndDataToGridControl(dic,gridControl1, GetPeopeoInfos());


            //设置标题头的ShowGroupPanel
            GridControlHelper.SettingShowHeaderGroup(gridView1, "测试人员信息表", true);

            //绑定当前页面数据
            //BindCurPageDatas_DB(formPageControl1, GetCurPageIndex(), _pageSize);

            FillGridByPage_Test(GetCurPageIndex(), _pageSize, _totalSize = peopeoInfos.Count());



            //设置自动序号
            GridControlHelper.AutoGeneraterRowNumber(gridView1);
            //设置表格头字体颜色
            GridControlHelper.SettingGridHeaderFontColor(gridView1, Color.Orange);


            //////绑定表头列、标题、数据
            ////gridControlOpc.BindHeaderAndDataToGridControl(dic,gridControl1,GetPeopeoInfos());

            //////隐藏指定列
            ////gridControlOpc.HideAppointColumn(gridView1, 0);
            ////gridControlOpc.HideAppointColumn(gridView1, "ID");



            ////自动适配所有字段列宽度
            //gridControlOpc.AutoMatchAllColumnWidth(gridView1);


            ////自动适配某列字段宽度
            ////gridControlOpc.AutoMatchSingleColumnWidth(gridView1,0);
            //gridControlOpc.AutoMatchSingleColumnWidth(gridView1, "IdCard");

            ////设置奇偶行颜色
            //gridControlOpc.SettingOddEvenRowDefaultColor(gridView1);

            ////设置选择行颜色
            //gridControlOpc.SettingSelectedRowDefaultColor(gridView1);

            ////设置表格是否允许编辑
            //gridControlOpc.SettingGridIsEdit(gridView1, false);


            //设置表格全选
            GridControlHelper.SettingGridRowsMutiSelect(gridView1);


            //设置某列是否可编辑
            List<string> needEditColumnList = new List<string>()
            {
                "Name","IdCard"
            };
            GridControlHelper.IsEditMutiColumnData(gridView1, needEditColumnList);


        }

        #endregion

        #region   表格分页
        //模拟数据
        List<TestPeopleInfo> peopeoInfos = new List<TestPeopleInfo>()
            {
                new TestPeopleInfo{ ID="SL009",Name="谭维维",Sex="男",IdCard="523033100001"},
                new TestPeopleInfo{ ID="SL008",Name="司一航",Sex="男",IdCard="523033100002"},
                new TestPeopleInfo{ ID="SL007",Name="周  倩",Sex="男",IdCard="523033100003"},
                new TestPeopleInfo{ ID="SL006",Name="王一星",Sex="男",IdCard="523033100004"},
                new TestPeopleInfo{ ID="SL005",Name="策俊逸",Sex="男",IdCard="523033100005"},
                new TestPeopleInfo{ ID="SL004",Name="周  茜",Sex="男",IdCard="523033100006"},
                new TestPeopleInfo{ ID="SL003",Name="司王成",Sex="男",IdCard="523033100007"},
                new TestPeopleInfo{ ID="SL002",Name="杨思凡",Sex="男",IdCard="523033100008"},
                new TestPeopleInfo{ ID="SL001",Name="策一方",Sex="男",IdCard="523033100009"},
            };

        private int _curPage = 1;
        private int _pageSize = 2;
        private int _totalSize = 0;

        /// <summary>
        /// 初始化分页信息
        /// </summary>
        private void InitSplitPageInfo()
        {
            //设置每页显示的数量
            formPageControl1.GetComboxEditOfPageSize.Text = _pageSize.ToString();

            //注册表格分页
            RegistSplitPage(_totalSize, _pageSize, _curPage);
        }

        /// <summary>
        /// 注册表格分页
        /// </summary>
        /// <typeparam name="T">数据实体类</typeparam>
        /// <param name="totalSize">数据总条数</param>
        /// <param name="pageSize">每页显示的数据条数（需要大于 0）</param>
        /// <param name="curPageIndex">当前页码（一般默认为 1）</param>
        private void RegistSplitPage(int totalSize, int pageSize, int curPageIndex = 1)
        {
            _curPage = curPageIndex;
            _pageSize = pageSize;
            _totalSize = totalSize;

            formPageControl1.pageDataEvent -= FormPageControl_pageEvent;
            formPageControl1.pageSizeEvent -= FormPageControl_pageSizeEvent;

            formPageControl1.pageDataEvent += FormPageControl_pageEvent;
            formPageControl1.SettingSinglePageSize(_pageSize);
            formPageControl1.pageSizeEvent += FormPageControl_pageSizeEvent;

            formPageControl1.RefreshPage(_curPage, _pageSize, _totalSize);

        }


        /// <summary>
        /// 表格分页事件
        /// </summary>
        /// <param name="curPage">当前页面索引</param>
        /// <param name="pageSize">当前页面显示的数据行数</param>
        private void FormPageControl_pageEvent(int curPage, int pageSize)
        {
            if (_totalSize <= 0 || _curPage < 1 || _pageSize <= 0) return;

            _curPage = curPage;
            _pageSize = pageSize;

            //绑定当前页面数据
            //BindCurPageDatas_DB(formPageControl1, _curPage, _pageSize);
            FillGridByPage_Test(_curPage, _pageSize, _totalSize=peopeoInfos.Count());

        }

        /// <summary>
        /// 绑定当前页面数据【数据库使用方法】
        /// </summary>
        /// <param name="customPageEdit">自定义的分页组件名称</param>
        /// <param name="curpage">当前页索引</param>
        /// <param name="pageSize">当前页面显示的数据行数</param>
        public void BindCurPageDatas_DB(CustomControl.FormPageControl formPageControl, int curpage, int pageSize)
        {

            //获取指定页码、页码大小的数据库报表数据
            DataTable dt = new DataTable();//这里的数据需要从数据库获取
                            
            GridControlHelper.FillDatasToGridControl(gridControl1, gridView1, dt);
            int tmpTotalSize = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                int.TryParse(dt.Rows[0][0].ToString(), out tmpTotalSize);
            }
            _totalSize = tmpTotalSize;

            //刷新分页信息
            formPageControl.RefreshPage(curpage, pageSize, tmpTotalSize);

        }


        /// <summary>
        /// 测试通过指定页面填充表格(一次加载数据到缓存，然后进行分页)
        /// </summary>
        /// <param name="curPage">当前页面索引</param>
        /// <param name="pageSize">当前页面显示的数据行数</param>
        /// <param name="totalSize">当前需要显示的数据总数</param>
        private void FillGridByPage_Test(int curPage, int pageSize, int totalSize)
        {
            if (curPage < 1 || pageSize <= 0
                || _totalSize < 1 || _totalSize < curPage) return;

            List<TestPeopleInfo> tmpData = new List<TestPeopleInfo>();

            int curPageIndex = (curPage - 1) * pageSize;
            int curPageSizeIndex = curPage * pageSize;

            if (pageSize > totalSize || curPageSizeIndex > totalSize)
            {
                curPageSizeIndex = totalSize;
            }
            for (int i = curPageIndex; i < curPageSizeIndex; i++)
            {
                tmpData.Add(peopeoInfos[i]);
            }

            BindCurPageDatas(gridControl1,
                formPageControl1, curPage, pageSize, totalSize, tmpData);
        }

        /// <summary>
        /// 绑定当前页面数据
        /// </summary>
        /// <typeparam name="T">数据实体类</typeparam>
        /// <param name="gridControl">gridControl组件名称</param>
        /// <param name="gridPageOpcTools">自定义的分页组件名称</param>
        /// <param name="curpage">当前页索引</param>
        /// <param name="pageSize">当前页面显示的数据行数</param>
        /// <param name="totalSize">需要显示的数据总数</param>
        /// <param name="dataList">数据列表</param>
        public void BindCurPageDatas<T>(GridControl gridControl,
            CustomControl.FormPageControl formPageControl, int curpage,
            int pageSize, int totalSize, List<T> dataList) where T : class
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ID", "编号");
            dic.Add("Name", "姓名");
            dic.Add("Sex", "性别");
            dic.Add("IdCard", "身份证号");

            DataTable dt = new DataTable();
            GridControlHelper.BindHeaderToGridControl(dic,ref dt);

            GridControlHelper.BindDataToGridControl(gridControl, dataList,dt);
            gridControl.MainView.PopulateColumns();
            formPageControl.RefreshPage(curpage, pageSize, totalSize);

        }


        /// <summary>
        /// 选择页码事件
        /// </summary>
        /// <param name="pageSize">当前页码显示的数据条数</param>
        private void FormPageControl_pageSizeEvent(int pageSize)
        {
            _pageSize = pageSize;
        }

        /// <summary>
        /// 获取到当前页码
        /// </summary>
        /// <returns></returns>
        private int GetCurPageIndex()
        {
            //获取当前输入的页码
            int tmpCurPageIndex = _curPage;
            tmpCurPageIndex = formPageControl1.GetInputPageIndex();
            return tmpCurPageIndex;
        }




        #endregion


    }//Class_end

    //人员信息模型类
    internal class TestPeopleInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string IdCard { get; set; }
    }
}