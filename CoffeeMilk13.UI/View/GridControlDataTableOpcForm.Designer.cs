
namespace CoffeeMilk13.UI.View
{
    partial class GridControlDataTableOpcForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Age = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Work = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Technology = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Experience = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memoEdit_ShowInfo = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl_ShowInfo = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_EntityToDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_ExportGridDatas = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_FixedTimeRollGrid = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_CallbackUIOfMutiThred = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DeleteEmptyRowOfDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetFilterOrSortDataOfGrid = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_AddProgressbarOfColumn = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetMutiRowSingleColumnDatas = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetSingleRowMutiColumnDatas = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetSingleRowAndColumnData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetTwoColumnAllData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetOneColumnAllData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_AddOneRowDataToDataTableTail = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_AddOneRowDataToDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_AddOneColumnDataToDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_AddFieldToDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_CopyDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DataTableToEntityList = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DataTableToGrid2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_EntityListToDataTable = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DataTableToEntity = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DataTableToGrid = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_TipInfo = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_ShowInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 5);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(820, 329);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.UserName,
            this.Age,
            this.Sex,
            this.Email,
            this.Address,
            this.Work,
            this.Company,
            this.Technology,
            this.Experience});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridView1_CalcRowHeight);
            // 
            // Id
            // 
            this.Id.Caption = "编号";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            // 
            // UserName
            // 
            this.UserName.Caption = "姓名";
            this.UserName.FieldName = "Name";
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 1;
            // 
            // Age
            // 
            this.Age.Caption = "年龄";
            this.Age.FieldName = "Age";
            this.Age.Name = "Age";
            this.Age.Visible = true;
            this.Age.VisibleIndex = 2;
            // 
            // Sex
            // 
            this.Sex.Caption = "性别";
            this.Sex.FieldName = "Sex";
            this.Sex.Name = "Sex";
            this.Sex.Visible = true;
            this.Sex.VisibleIndex = 3;
            // 
            // Email
            // 
            this.Email.Caption = "邮箱";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 4;
            // 
            // Address
            // 
            this.Address.Caption = "地址";
            this.Address.FieldName = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.VisibleIndex = 5;
            // 
            // Work
            // 
            this.Work.Caption = "职位";
            this.Work.FieldName = "Work";
            this.Work.Name = "Work";
            this.Work.Visible = true;
            this.Work.VisibleIndex = 6;
            // 
            // Company
            // 
            this.Company.Caption = "公司";
            this.Company.FieldName = "Company";
            this.Company.Name = "Company";
            this.Company.Visible = true;
            this.Company.VisibleIndex = 7;
            // 
            // Technology
            // 
            this.Technology.Caption = "技术";
            this.Technology.FieldName = "Technology";
            this.Technology.Name = "Technology";
            this.Technology.Visible = true;
            this.Technology.VisibleIndex = 8;
            // 
            // Experience
            // 
            this.Experience.Caption = "经验";
            this.Experience.FieldName = "Experience";
            this.Experience.Name = "Experience";
            this.Experience.Visible = true;
            this.Experience.VisibleIndex = 9;
            // 
            // memoEdit_ShowInfo
            // 
            this.memoEdit_ShowInfo.Location = new System.Drawing.Point(5, 22);
            this.memoEdit_ShowInfo.Name = "memoEdit_ShowInfo";
            this.memoEdit_ShowInfo.Size = new System.Drawing.Size(442, 312);
            this.memoEdit_ShowInfo.TabIndex = 1;
            // 
            // labelControl_ShowInfo
            // 
            this.labelControl_ShowInfo.Appearance.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_ShowInfo.Appearance.Options.UseFont = true;
            this.labelControl_ShowInfo.Location = new System.Drawing.Point(5, 3);
            this.labelControl_ShowInfo.Name = "labelControl_ShowInfo";
            this.labelControl_ShowInfo.Size = new System.Drawing.Size(68, 18);
            this.labelControl_ShowInfo.TabIndex = 2;
            this.labelControl_ShowInfo.Text = "信息展示";
            // 
            // simpleButton_EntityToDataTable
            // 
            this.simpleButton_EntityToDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_EntityToDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_EntityToDataTable.Location = new System.Drawing.Point(5, 5);
            this.simpleButton_EntityToDataTable.Name = "simpleButton_EntityToDataTable";
            this.simpleButton_EntityToDataTable.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_EntityToDataTable.TabIndex = 3;
            this.simpleButton_EntityToDataTable.Text = "1-将实体类转为DataTable";
            this.simpleButton_EntityToDataTable.Click += new System.EventHandler(this.simpleButton_EntityToDataTable_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(-2, -1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(828, 337);
            this.panelControl1.TabIndex = 5;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.memoEdit_ShowInfo);
            this.panelControl2.Controls.Add(this.labelControl_ShowInfo);
            this.panelControl2.Location = new System.Drawing.Point(832, -1);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(450, 337);
            this.panelControl2.TabIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.simpleButton_ExportGridDatas);
            this.panelControl3.Controls.Add(this.simpleButton_FixedTimeRollGrid);
            this.panelControl3.Controls.Add(this.simpleButton_CallbackUIOfMutiThred);
            this.panelControl3.Controls.Add(this.simpleButton_DeleteEmptyRowOfDataTable);
            this.panelControl3.Controls.Add(this.simpleButton_GetFilterOrSortDataOfGrid);
            this.panelControl3.Controls.Add(this.simpleButton_AddProgressbarOfColumn);
            this.panelControl3.Controls.Add(this.simpleButton_GetMutiRowSingleColumnDatas);
            this.panelControl3.Controls.Add(this.simpleButton_GetSingleRowMutiColumnDatas);
            this.panelControl3.Controls.Add(this.simpleButton_GetSingleRowAndColumnData);
            this.panelControl3.Controls.Add(this.simpleButton_GetTwoColumnAllData);
            this.panelControl3.Controls.Add(this.simpleButton_GetOneColumnAllData);
            this.panelControl3.Controls.Add(this.simpleButton_AddOneRowDataToDataTableTail);
            this.panelControl3.Controls.Add(this.simpleButton_AddOneRowDataToDataTable);
            this.panelControl3.Controls.Add(this.simpleButton_AddOneColumnDataToDataTable);
            this.panelControl3.Controls.Add(this.simpleButton_AddFieldToDataTable);
            this.panelControl3.Controls.Add(this.simpleButton_CopyDataTable);
            this.panelControl3.Controls.Add(this.simpleButton_DataTableToEntityList);
            this.panelControl3.Controls.Add(this.simpleButton_DataTableToGrid2);
            this.panelControl3.Controls.Add(this.simpleButton_EntityListToDataTable);
            this.panelControl3.Controls.Add(this.simpleButton_DataTableToEntity);
            this.panelControl3.Controls.Add(this.simpleButton_DataTableToGrid);
            this.panelControl3.Controls.Add(this.simpleButton_EntityToDataTable);
            this.panelControl3.Location = new System.Drawing.Point(-2, 366);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1284, 217);
            this.panelControl3.TabIndex = 7;
            // 
            // simpleButton_ExportGridDatas
            // 
            this.simpleButton_ExportGridDatas.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_ExportGridDatas.Appearance.Options.UseFont = true;
            this.simpleButton_ExportGridDatas.Location = new System.Drawing.Point(250, 162);
            this.simpleButton_ExportGridDatas.Name = "simpleButton_ExportGridDatas";
            this.simpleButton_ExportGridDatas.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_ExportGridDatas.TabIndex = 24;
            this.simpleButton_ExportGridDatas.Text = "10-导出当前表格数据";
            this.simpleButton_ExportGridDatas.Click += new System.EventHandler(this.simpleButton_ExportGridDatas_Click);
            // 
            // simpleButton_FixedTimeRollGrid
            // 
            this.simpleButton_FixedTimeRollGrid.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_FixedTimeRollGrid.Appearance.Options.UseFont = true;
            this.simpleButton_FixedTimeRollGrid.Location = new System.Drawing.Point(5, 162);
            this.simpleButton_FixedTimeRollGrid.Name = "simpleButton_FixedTimeRollGrid";
            this.simpleButton_FixedTimeRollGrid.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_FixedTimeRollGrid.TabIndex = 23;
            this.simpleButton_FixedTimeRollGrid.Text = "9-定时滚动表格内容";
            this.simpleButton_FixedTimeRollGrid.Click += new System.EventHandler(this.simpleButton_FixedTimeRollGrid_Click);
            // 
            // simpleButton_CallbackUIOfMutiThred
            // 
            this.simpleButton_CallbackUIOfMutiThred.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_CallbackUIOfMutiThred.Appearance.Options.UseFont = true;
            this.simpleButton_CallbackUIOfMutiThred.Location = new System.Drawing.Point(737, 116);
            this.simpleButton_CallbackUIOfMutiThred.Name = "simpleButton_CallbackUIOfMutiThred";
            this.simpleButton_CallbackUIOfMutiThred.Size = new System.Drawing.Size(274, 31);
            this.simpleButton_CallbackUIOfMutiThred.TabIndex = 22;
            this.simpleButton_CallbackUIOfMutiThred.Text = "8-多线程下调用UI";
            this.simpleButton_CallbackUIOfMutiThred.Click += new System.EventHandler(this.simpleButton_CallbackUIOfMutiThred_Click);
            // 
            // simpleButton_DeleteEmptyRowOfDataTable
            // 
            this.simpleButton_DeleteEmptyRowOfDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_DeleteEmptyRowOfDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_DeleteEmptyRowOfDataTable.Location = new System.Drawing.Point(494, 116);
            this.simpleButton_DeleteEmptyRowOfDataTable.Name = "simpleButton_DeleteEmptyRowOfDataTable";
            this.simpleButton_DeleteEmptyRowOfDataTable.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_DeleteEmptyRowOfDataTable.TabIndex = 21;
            this.simpleButton_DeleteEmptyRowOfDataTable.Text = "7-删除DataTable空白行";
            this.simpleButton_DeleteEmptyRowOfDataTable.Click += new System.EventHandler(this.simpleButton_DeleteEmptyRowOfDataTable_Click);
            // 
            // simpleButton_GetFilterOrSortDataOfGrid
            // 
            this.simpleButton_GetFilterOrSortDataOfGrid.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_GetFilterOrSortDataOfGrid.Appearance.Options.UseFont = true;
            this.simpleButton_GetFilterOrSortDataOfGrid.Location = new System.Drawing.Point(250, 116);
            this.simpleButton_GetFilterOrSortDataOfGrid.Name = "simpleButton_GetFilterOrSortDataOfGrid";
            this.simpleButton_GetFilterOrSortDataOfGrid.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_GetFilterOrSortDataOfGrid.TabIndex = 20;
            this.simpleButton_GetFilterOrSortDataOfGrid.Text = "6-获取表格过滤或排序后数据";
            this.simpleButton_GetFilterOrSortDataOfGrid.Click += new System.EventHandler(this.simpleButton_GetFilterOrSortDataOfGrid_Click);
            // 
            // simpleButton_AddProgressbarOfColumn
            // 
            this.simpleButton_AddProgressbarOfColumn.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_AddProgressbarOfColumn.Appearance.Options.UseFont = true;
            this.simpleButton_AddProgressbarOfColumn.Location = new System.Drawing.Point(5, 116);
            this.simpleButton_AddProgressbarOfColumn.Name = "simpleButton_AddProgressbarOfColumn";
            this.simpleButton_AddProgressbarOfColumn.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_AddProgressbarOfColumn.TabIndex = 19;
            this.simpleButton_AddProgressbarOfColumn.Text = "5-给指定列添加进度条";
            this.simpleButton_AddProgressbarOfColumn.Click += new System.EventHandler(this.simpleButton_AddProgressbarOfColumn_Click);
            // 
            // simpleButton_GetMutiRowSingleColumnDatas
            // 
            this.simpleButton_GetMutiRowSingleColumnDatas.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_GetMutiRowSingleColumnDatas.Appearance.Options.UseFont = true;
            this.simpleButton_GetMutiRowSingleColumnDatas.Location = new System.Drawing.Point(1036, 116);
            this.simpleButton_GetMutiRowSingleColumnDatas.Name = "simpleButton_GetMutiRowSingleColumnDatas";
            this.simpleButton_GetMutiRowSingleColumnDatas.Size = new System.Drawing.Size(243, 31);
            this.simpleButton_GetMutiRowSingleColumnDatas.TabIndex = 18;
            this.simpleButton_GetMutiRowSingleColumnDatas.Text = "4-获取多行单列的内容";
            this.simpleButton_GetMutiRowSingleColumnDatas.Click += new System.EventHandler(this.simpleButton_GetMutiRowSingleColumnDatas_Click);
            // 
            // simpleButton_GetSingleRowMutiColumnDatas
            // 
            this.simpleButton_GetSingleRowMutiColumnDatas.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_GetSingleRowMutiColumnDatas.Appearance.Options.UseFont = true;
            this.simpleButton_GetSingleRowMutiColumnDatas.Location = new System.Drawing.Point(1036, 79);
            this.simpleButton_GetSingleRowMutiColumnDatas.Name = "simpleButton_GetSingleRowMutiColumnDatas";
            this.simpleButton_GetSingleRowMutiColumnDatas.Size = new System.Drawing.Size(243, 31);
            this.simpleButton_GetSingleRowMutiColumnDatas.TabIndex = 17;
            this.simpleButton_GetSingleRowMutiColumnDatas.Text = "4-获取单行多列的内容";
            this.simpleButton_GetSingleRowMutiColumnDatas.Click += new System.EventHandler(this.simpleButton_GetSingleRowMutiColumnDatas_Click);
            // 
            // simpleButton_GetSingleRowAndColumnData
            // 
            this.simpleButton_GetSingleRowAndColumnData.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_GetSingleRowAndColumnData.Appearance.Options.UseFont = true;
            this.simpleButton_GetSingleRowAndColumnData.Location = new System.Drawing.Point(1036, 42);
            this.simpleButton_GetSingleRowAndColumnData.Name = "simpleButton_GetSingleRowAndColumnData";
            this.simpleButton_GetSingleRowAndColumnData.Size = new System.Drawing.Size(243, 31);
            this.simpleButton_GetSingleRowAndColumnData.TabIndex = 16;
            this.simpleButton_GetSingleRowAndColumnData.Text = "4-获取N行M列的内容";
            this.simpleButton_GetSingleRowAndColumnData.Click += new System.EventHandler(this.simpleButton_GetSingleRowAndColumnData_Click);
            // 
            // simpleButton_GetTwoColumnAllData
            // 
            this.simpleButton_GetTwoColumnAllData.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_GetTwoColumnAllData.Appearance.Options.UseFont = true;
            this.simpleButton_GetTwoColumnAllData.Location = new System.Drawing.Point(1036, 5);
            this.simpleButton_GetTwoColumnAllData.Name = "simpleButton_GetTwoColumnAllData";
            this.simpleButton_GetTwoColumnAllData.Size = new System.Drawing.Size(243, 31);
            this.simpleButton_GetTwoColumnAllData.TabIndex = 15;
            this.simpleButton_GetTwoColumnAllData.Text = "4-获取到指定两列的所有数据";
            this.simpleButton_GetTwoColumnAllData.Click += new System.EventHandler(this.simpleButton_GetTwoColumnAllData_Click);
            // 
            // simpleButton_GetOneColumnAllData
            // 
            this.simpleButton_GetOneColumnAllData.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_GetOneColumnAllData.Appearance.Options.UseFont = true;
            this.simpleButton_GetOneColumnAllData.Location = new System.Drawing.Point(737, 79);
            this.simpleButton_GetOneColumnAllData.Name = "simpleButton_GetOneColumnAllData";
            this.simpleButton_GetOneColumnAllData.Size = new System.Drawing.Size(274, 31);
            this.simpleButton_GetOneColumnAllData.TabIndex = 14;
            this.simpleButton_GetOneColumnAllData.Text = "4-获取到指定列的所有数据";
            this.simpleButton_GetOneColumnAllData.Click += new System.EventHandler(this.simpleButton_GetOneColumnAllData_Click);
            // 
            // simpleButton_AddOneRowDataToDataTableTail
            // 
            this.simpleButton_AddOneRowDataToDataTableTail.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_AddOneRowDataToDataTableTail.Appearance.Options.UseFont = true;
            this.simpleButton_AddOneRowDataToDataTableTail.Location = new System.Drawing.Point(737, 42);
            this.simpleButton_AddOneRowDataToDataTableTail.Name = "simpleButton_AddOneRowDataToDataTableTail";
            this.simpleButton_AddOneRowDataToDataTableTail.Size = new System.Drawing.Size(274, 31);
            this.simpleButton_AddOneRowDataToDataTableTail.TabIndex = 13;
            this.simpleButton_AddOneRowDataToDataTableTail.Text = "3-给Datatable末尾添加一行内容";
            this.simpleButton_AddOneRowDataToDataTableTail.Click += new System.EventHandler(this.simpleButton_AddOneRowDataToDataTableTail_Click);
            // 
            // simpleButton_AddOneRowDataToDataTable
            // 
            this.simpleButton_AddOneRowDataToDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_AddOneRowDataToDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_AddOneRowDataToDataTable.Location = new System.Drawing.Point(737, 5);
            this.simpleButton_AddOneRowDataToDataTable.Name = "simpleButton_AddOneRowDataToDataTable";
            this.simpleButton_AddOneRowDataToDataTable.Size = new System.Drawing.Size(274, 31);
            this.simpleButton_AddOneRowDataToDataTable.TabIndex = 12;
            this.simpleButton_AddOneRowDataToDataTable.Text = "3-给Datatable指定行添加一行内容";
            this.simpleButton_AddOneRowDataToDataTable.Click += new System.EventHandler(this.simpleButton_AddOneRowDataToDataTable_Click);
            // 
            // simpleButton_AddOneColumnDataToDataTable
            // 
            this.simpleButton_AddOneColumnDataToDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_AddOneColumnDataToDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_AddOneColumnDataToDataTable.Location = new System.Drawing.Point(494, 79);
            this.simpleButton_AddOneColumnDataToDataTable.Name = "simpleButton_AddOneColumnDataToDataTable";
            this.simpleButton_AddOneColumnDataToDataTable.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_AddOneColumnDataToDataTable.TabIndex = 11;
            this.simpleButton_AddOneColumnDataToDataTable.Text = "3-给Datatable添加一列内容";
            this.simpleButton_AddOneColumnDataToDataTable.Click += new System.EventHandler(this.simpleButton_AddOneColumnToDataTable_Click);
            // 
            // simpleButton_AddFieldToDataTable
            // 
            this.simpleButton_AddFieldToDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_AddFieldToDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_AddFieldToDataTable.Location = new System.Drawing.Point(494, 42);
            this.simpleButton_AddFieldToDataTable.Name = "simpleButton_AddFieldToDataTable";
            this.simpleButton_AddFieldToDataTable.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_AddFieldToDataTable.TabIndex = 10;
            this.simpleButton_AddFieldToDataTable.Text = "3-给DataTable添加字段";
            this.simpleButton_AddFieldToDataTable.Click += new System.EventHandler(this.simpleButton_AddFieldToDataTable_Click);
            // 
            // simpleButton_CopyDataTable
            // 
            this.simpleButton_CopyDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_CopyDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_CopyDataTable.Location = new System.Drawing.Point(494, 5);
            this.simpleButton_CopyDataTable.Name = "simpleButton_CopyDataTable";
            this.simpleButton_CopyDataTable.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_CopyDataTable.TabIndex = 9;
            this.simpleButton_CopyDataTable.Text = "3-复制DataTable";
            this.simpleButton_CopyDataTable.Click += new System.EventHandler(this.simpleButton_CopyDataTable_Click);
            // 
            // simpleButton_DataTableToEntityList
            // 
            this.simpleButton_DataTableToEntityList.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_DataTableToEntityList.Appearance.Options.UseFont = true;
            this.simpleButton_DataTableToEntityList.Location = new System.Drawing.Point(250, 79);
            this.simpleButton_DataTableToEntityList.Name = "simpleButton_DataTableToEntityList";
            this.simpleButton_DataTableToEntityList.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_DataTableToEntityList.TabIndex = 8;
            this.simpleButton_DataTableToEntityList.Text = "2-将DataTable转为实体列表";
            this.simpleButton_DataTableToEntityList.Click += new System.EventHandler(this.simpleButton_DataTableToEntityList_Click);
            // 
            // simpleButton_DataTableToGrid2
            // 
            this.simpleButton_DataTableToGrid2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_DataTableToGrid2.Appearance.Options.UseFont = true;
            this.simpleButton_DataTableToGrid2.Location = new System.Drawing.Point(250, 42);
            this.simpleButton_DataTableToGrid2.Name = "simpleButton_DataTableToGrid2";
            this.simpleButton_DataTableToGrid2.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_DataTableToGrid2.TabIndex = 7;
            this.simpleButton_DataTableToGrid2.Text = "2-将DataTable数据填充到表格";
            this.simpleButton_DataTableToGrid2.Click += new System.EventHandler(this.simpleButton_DataTableToGrid2_Click);
            // 
            // simpleButton_EntityListToDataTable
            // 
            this.simpleButton_EntityListToDataTable.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_EntityListToDataTable.Appearance.Options.UseFont = true;
            this.simpleButton_EntityListToDataTable.Location = new System.Drawing.Point(250, 5);
            this.simpleButton_EntityListToDataTable.Name = "simpleButton_EntityListToDataTable";
            this.simpleButton_EntityListToDataTable.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_EntityListToDataTable.TabIndex = 6;
            this.simpleButton_EntityListToDataTable.Text = "2-将实体类列表转为DataTable";
            this.simpleButton_EntityListToDataTable.Click += new System.EventHandler(this.simpleButton_EntityListToDataTable_Click);
            // 
            // simpleButton_DataTableToEntity
            // 
            this.simpleButton_DataTableToEntity.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_DataTableToEntity.Appearance.Options.UseFont = true;
            this.simpleButton_DataTableToEntity.Location = new System.Drawing.Point(5, 79);
            this.simpleButton_DataTableToEntity.Name = "simpleButton_DataTableToEntity";
            this.simpleButton_DataTableToEntity.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_DataTableToEntity.TabIndex = 5;
            this.simpleButton_DataTableToEntity.Text = "1-将DataTable转为实体类";
            this.simpleButton_DataTableToEntity.Click += new System.EventHandler(this.simpleButton_DataTableToEntity_Click);
            // 
            // simpleButton_DataTableToGrid
            // 
            this.simpleButton_DataTableToGrid.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_DataTableToGrid.Appearance.Options.UseFont = true;
            this.simpleButton_DataTableToGrid.Location = new System.Drawing.Point(5, 42);
            this.simpleButton_DataTableToGrid.Name = "simpleButton_DataTableToGrid";
            this.simpleButton_DataTableToGrid.Size = new System.Drawing.Size(220, 31);
            this.simpleButton_DataTableToGrid.TabIndex = 4;
            this.simpleButton_DataTableToGrid.Text = "1-将DataTable数据填充到表格";
            this.simpleButton_DataTableToGrid.Click += new System.EventHandler(this.simpleButton_DataTableToGrid_Click);
            // 
            // labelControl_TipInfo
            // 
            this.labelControl_TipInfo.Appearance.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_TipInfo.Appearance.Options.UseFont = true;
            this.labelControl_TipInfo.Location = new System.Drawing.Point(12, 342);
            this.labelControl_TipInfo.Name = "labelControl_TipInfo";
            this.labelControl_TipInfo.Size = new System.Drawing.Size(68, 18);
            this.labelControl_TipInfo.TabIndex = 3;
            this.labelControl_TipInfo.Text = "信息提示";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GridControlDataTableOpcForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 582);
            this.Controls.Add(this.labelControl_TipInfo);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "GridControlDataTableOpcForm";
            this.Text = "Grid表格与DataTable操作";
            this.Load += new System.EventHandler(this.GridControlDataTableOpcForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_ShowInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit memoEdit_ShowInfo;
        private DevExpress.XtraEditors.LabelControl labelControl_ShowInfo;
        private DevExpress.XtraEditors.SimpleButton simpleButton_EntityToDataTable;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl_TipInfo;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DataTableToGrid;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn Age;
        private DevExpress.XtraGrid.Columns.GridColumn Sex;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn Work;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DataTableToEntity;
        private DevExpress.XtraEditors.SimpleButton simpleButton_EntityListToDataTable;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DataTableToGrid2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DataTableToEntityList;
        private DevExpress.XtraEditors.SimpleButton simpleButton_CopyDataTable;
        private DevExpress.XtraEditors.SimpleButton simpleButton_AddFieldToDataTable;
        private DevExpress.XtraEditors.SimpleButton simpleButton_AddOneColumnDataToDataTable;
        private DevExpress.XtraGrid.Columns.GridColumn Company;
        private DevExpress.XtraGrid.Columns.GridColumn Technology;
        private DevExpress.XtraGrid.Columns.GridColumn Experience;
        private DevExpress.XtraEditors.SimpleButton simpleButton_AddOneRowDataToDataTable;
        private DevExpress.XtraEditors.SimpleButton simpleButton_AddOneRowDataToDataTableTail;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetOneColumnAllData;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetTwoColumnAllData;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetSingleRowAndColumnData;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetSingleRowMutiColumnDatas;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetMutiRowSingleColumnDatas;
        private DevExpress.XtraEditors.SimpleButton simpleButton_AddProgressbarOfColumn;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetFilterOrSortDataOfGrid;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DeleteEmptyRowOfDataTable;
        private DevExpress.XtraEditors.SimpleButton simpleButton_CallbackUIOfMutiThred;
        private DevExpress.XtraEditors.SimpleButton simpleButton_FixedTimeRollGrid;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ExportGridDatas;
    }
}