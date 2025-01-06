
namespace CoffeeMilk13.UI.View
{
    partial class GridControlOpcForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Age = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Work = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_EditGridMutiColumnDatas = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_EditGridSingleColumnDatas = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DisableEditGridAllData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_EnableEditGridAllData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ExportGridData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ModifyHeaderName = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetGridHeaderNames = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_GetGridHeaderFields = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_SetOddEvenRowColor = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ModifyMutiRowBackcolor = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ModifyRowBackColor = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ModifyColumnBackColor = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ModifyCellBackColor = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_ModifyHeaderBackColor = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_TipInfo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1281, 409);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1277, 405);
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
            this.Work});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton_EditGridMutiColumnDatas);
            this.panelControl2.Controls.Add(this.simpleButton_EditGridSingleColumnDatas);
            this.panelControl2.Controls.Add(this.simpleButton_DisableEditGridAllData);
            this.panelControl2.Controls.Add(this.simpleButton_EnableEditGridAllData);
            this.panelControl2.Controls.Add(this.simpleButton_ExportGridData);
            this.panelControl2.Controls.Add(this.simpleButton_ModifyHeaderName);
            this.panelControl2.Controls.Add(this.simpleButton_GetGridHeaderNames);
            this.panelControl2.Controls.Add(this.simpleButton_GetGridHeaderFields);
            this.panelControl2.Controls.Add(this.simpleButton_SetOddEvenRowColor);
            this.panelControl2.Controls.Add(this.simpleButton_ModifyMutiRowBackcolor);
            this.panelControl2.Controls.Add(this.simpleButton_ModifyRowBackColor);
            this.panelControl2.Controls.Add(this.simpleButton_ModifyColumnBackColor);
            this.panelControl2.Controls.Add(this.simpleButton_ModifyCellBackColor);
            this.panelControl2.Controls.Add(this.simpleButton_ModifyHeaderBackColor);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 443);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1281, 139);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton_EditGridMutiColumnDatas
            // 
            this.simpleButton_EditGridMutiColumnDatas.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_EditGridMutiColumnDatas.Appearance.Options.UseFont = true;
            this.simpleButton_EditGridMutiColumnDatas.Location = new System.Drawing.Point(782, 103);
            this.simpleButton_EditGridMutiColumnDatas.Name = "simpleButton_EditGridMutiColumnDatas";
            this.simpleButton_EditGridMutiColumnDatas.Size = new System.Drawing.Size(193, 31);
            this.simpleButton_EditGridMutiColumnDatas.TabIndex = 13;
            this.simpleButton_EditGridMutiColumnDatas.Text = "编辑表格多列数据";
            this.simpleButton_EditGridMutiColumnDatas.Click += new System.EventHandler(this.simpleButton_EditGridMutiColumnDatas_Click);
            // 
            // simpleButton_EditGridSingleColumnDatas
            // 
            this.simpleButton_EditGridSingleColumnDatas.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_EditGridSingleColumnDatas.Appearance.Options.UseFont = true;
            this.simpleButton_EditGridSingleColumnDatas.Location = new System.Drawing.Point(571, 103);
            this.simpleButton_EditGridSingleColumnDatas.Name = "simpleButton_EditGridSingleColumnDatas";
            this.simpleButton_EditGridSingleColumnDatas.Size = new System.Drawing.Size(193, 31);
            this.simpleButton_EditGridSingleColumnDatas.TabIndex = 12;
            this.simpleButton_EditGridSingleColumnDatas.Text = "编辑表格单列数据";
            this.simpleButton_EditGridSingleColumnDatas.Click += new System.EventHandler(this.simpleButton_EditGridSingleColumnDatas_Click);
            // 
            // simpleButton_DisableEditGridAllData
            // 
            this.simpleButton_DisableEditGridAllData.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_DisableEditGridAllData.Appearance.Options.UseFont = true;
            this.simpleButton_DisableEditGridAllData.Location = new System.Drawing.Point(360, 103);
            this.simpleButton_DisableEditGridAllData.Name = "simpleButton_DisableEditGridAllData";
            this.simpleButton_DisableEditGridAllData.Size = new System.Drawing.Size(193, 31);
            this.simpleButton_DisableEditGridAllData.TabIndex = 11;
            this.simpleButton_DisableEditGridAllData.Text = "编辑表格任意数据[关闭]";
            this.simpleButton_DisableEditGridAllData.Click += new System.EventHandler(this.simpleButton_DisableEditGridAllData_Click);
            // 
            // simpleButton_EnableEditGridAllData
            // 
            this.simpleButton_EnableEditGridAllData.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_EnableEditGridAllData.Appearance.Options.UseFont = true;
            this.simpleButton_EnableEditGridAllData.Location = new System.Drawing.Point(12, 103);
            this.simpleButton_EnableEditGridAllData.Name = "simpleButton_EnableEditGridAllData";
            this.simpleButton_EnableEditGridAllData.Size = new System.Drawing.Size(193, 31);
            this.simpleButton_EnableEditGridAllData.TabIndex = 10;
            this.simpleButton_EnableEditGridAllData.Text = "编辑表格任意数据[开启]";
            this.simpleButton_EnableEditGridAllData.Click += new System.EventHandler(this.simpleButton_EnableEditGridAllData_Click);
            // 
            // simpleButton_ExportGridData
            // 
            this.simpleButton_ExportGridData.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ExportGridData.Appearance.Options.UseFont = true;
            this.simpleButton_ExportGridData.Location = new System.Drawing.Point(571, 61);
            this.simpleButton_ExportGridData.Name = "simpleButton_ExportGridData";
            this.simpleButton_ExportGridData.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ExportGridData.TabIndex = 9;
            this.simpleButton_ExportGridData.Text = "导出表格数据";
            this.simpleButton_ExportGridData.Click += new System.EventHandler(this.simpleButton_ExportGridData_Click);
            // 
            // simpleButton_ModifyHeaderName
            // 
            this.simpleButton_ModifyHeaderName.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ModifyHeaderName.Appearance.Options.UseFont = true;
            this.simpleButton_ModifyHeaderName.Location = new System.Drawing.Point(388, 61);
            this.simpleButton_ModifyHeaderName.Name = "simpleButton_ModifyHeaderName";
            this.simpleButton_ModifyHeaderName.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ModifyHeaderName.TabIndex = 8;
            this.simpleButton_ModifyHeaderName.Text = "修改表格标题头名称";
            this.simpleButton_ModifyHeaderName.Click += new System.EventHandler(this.simpleButton_ModifyHeaderName_Click);
            // 
            // simpleButton_GetGridHeaderNames
            // 
            this.simpleButton_GetGridHeaderNames.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_GetGridHeaderNames.Appearance.Options.UseFont = true;
            this.simpleButton_GetGridHeaderNames.Location = new System.Drawing.Point(201, 61);
            this.simpleButton_GetGridHeaderNames.Name = "simpleButton_GetGridHeaderNames";
            this.simpleButton_GetGridHeaderNames.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_GetGridHeaderNames.TabIndex = 7;
            this.simpleButton_GetGridHeaderNames.Text = "获取表格标题的名称";
            this.simpleButton_GetGridHeaderNames.Click += new System.EventHandler(this.simpleButton_GetGridHeaderNames_Click);
            // 
            // simpleButton_GetGridHeaderFields
            // 
            this.simpleButton_GetGridHeaderFields.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_GetGridHeaderFields.Appearance.Options.UseFont = true;
            this.simpleButton_GetGridHeaderFields.Location = new System.Drawing.Point(12, 61);
            this.simpleButton_GetGridHeaderFields.Name = "simpleButton_GetGridHeaderFields";
            this.simpleButton_GetGridHeaderFields.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_GetGridHeaderFields.TabIndex = 6;
            this.simpleButton_GetGridHeaderFields.Text = "获取表格标题的字段";
            this.simpleButton_GetGridHeaderFields.Click += new System.EventHandler(this.simpleButton_GetGridHeaderFields_Click);
            // 
            // simpleButton_SetOddEvenRowColor
            // 
            this.simpleButton_SetOddEvenRowColor.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_SetOddEvenRowColor.Appearance.Options.UseFont = true;
            this.simpleButton_SetOddEvenRowColor.Location = new System.Drawing.Point(944, 14);
            this.simpleButton_SetOddEvenRowColor.Name = "simpleButton_SetOddEvenRowColor";
            this.simpleButton_SetOddEvenRowColor.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_SetOddEvenRowColor.TabIndex = 5;
            this.simpleButton_SetOddEvenRowColor.Text = "设置奇偶行颜色";
            this.simpleButton_SetOddEvenRowColor.Click += new System.EventHandler(this.simpleButton_SetOddEvenRowColor_Click);
            // 
            // simpleButton_ModifyMutiRowBackcolor
            // 
            this.simpleButton_ModifyMutiRowBackcolor.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ModifyMutiRowBackcolor.Appearance.Options.UseFont = true;
            this.simpleButton_ModifyMutiRowBackcolor.Location = new System.Drawing.Point(757, 14);
            this.simpleButton_ModifyMutiRowBackcolor.Name = "simpleButton_ModifyMutiRowBackcolor";
            this.simpleButton_ModifyMutiRowBackcolor.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ModifyMutiRowBackcolor.TabIndex = 4;
            this.simpleButton_ModifyMutiRowBackcolor.Text = "修改多行背景";
            this.simpleButton_ModifyMutiRowBackcolor.Click += new System.EventHandler(this.simpleButton_ModifyMutiRowBackcolor_Click);
            // 
            // simpleButton_ModifyRowBackColor
            // 
            this.simpleButton_ModifyRowBackColor.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ModifyRowBackColor.Appearance.Options.UseFont = true;
            this.simpleButton_ModifyRowBackColor.Location = new System.Drawing.Point(571, 14);
            this.simpleButton_ModifyRowBackColor.Name = "simpleButton_ModifyRowBackColor";
            this.simpleButton_ModifyRowBackColor.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ModifyRowBackColor.TabIndex = 3;
            this.simpleButton_ModifyRowBackColor.Text = "修改指定行背景";
            this.simpleButton_ModifyRowBackColor.Click += new System.EventHandler(this.simpleButton_ModifyRowBackColor_Click);
            // 
            // simpleButton_ModifyColumnBackColor
            // 
            this.simpleButton_ModifyColumnBackColor.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ModifyColumnBackColor.Appearance.Options.UseFont = true;
            this.simpleButton_ModifyColumnBackColor.Location = new System.Drawing.Point(388, 14);
            this.simpleButton_ModifyColumnBackColor.Name = "simpleButton_ModifyColumnBackColor";
            this.simpleButton_ModifyColumnBackColor.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ModifyColumnBackColor.TabIndex = 2;
            this.simpleButton_ModifyColumnBackColor.Text = "修改指定列背景";
            this.simpleButton_ModifyColumnBackColor.Click += new System.EventHandler(this.simpleButton_ModifyColumnBackColor_Click);
            // 
            // simpleButton_ModifyCellBackColor
            // 
            this.simpleButton_ModifyCellBackColor.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ModifyCellBackColor.Appearance.Options.UseFont = true;
            this.simpleButton_ModifyCellBackColor.Location = new System.Drawing.Point(201, 14);
            this.simpleButton_ModifyCellBackColor.Name = "simpleButton_ModifyCellBackColor";
            this.simpleButton_ModifyCellBackColor.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ModifyCellBackColor.TabIndex = 1;
            this.simpleButton_ModifyCellBackColor.Text = "修改指定单元格背景";
            this.simpleButton_ModifyCellBackColor.Click += new System.EventHandler(this.simpleButton_ModifyCellBackColor_Click);
            // 
            // simpleButton_ModifyHeaderBackColor
            // 
            this.simpleButton_ModifyHeaderBackColor.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.simpleButton_ModifyHeaderBackColor.Appearance.Options.UseFont = true;
            this.simpleButton_ModifyHeaderBackColor.Location = new System.Drawing.Point(12, 14);
            this.simpleButton_ModifyHeaderBackColor.Name = "simpleButton_ModifyHeaderBackColor";
            this.simpleButton_ModifyHeaderBackColor.Size = new System.Drawing.Size(165, 31);
            this.simpleButton_ModifyHeaderBackColor.TabIndex = 0;
            this.simpleButton_ModifyHeaderBackColor.Text = "修改指定标题头背景";
            this.simpleButton_ModifyHeaderBackColor.Click += new System.EventHandler(this.simpleButton_ModifyHeaderBackColor_Click);
            // 
            // labelControl_TipInfo
            // 
            this.labelControl_TipInfo.Appearance.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_TipInfo.Appearance.Options.UseFont = true;
            this.labelControl_TipInfo.Location = new System.Drawing.Point(12, 415);
            this.labelControl_TipInfo.Name = "labelControl_TipInfo";
            this.labelControl_TipInfo.Size = new System.Drawing.Size(80, 21);
            this.labelControl_TipInfo.TabIndex = 2;
            this.labelControl_TipInfo.Text = "提示信息";
            // 
            // GridControlOpcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 582);
            this.Controls.Add(this.labelControl_TipInfo);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "GridControlOpcForm";
            this.Text = "Grid表格常用操作";
            this.Load += new System.EventHandler(this.GridControlOpcForm_Load);
            this.Resize += new System.EventHandler(this.GridControlOpcForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyHeaderBackColor;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyCellBackColor;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyColumnBackColor;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyRowBackColor;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyMutiRowBackcolor;
        private DevExpress.XtraEditors.SimpleButton simpleButton_SetOddEvenRowColor;
        private DevExpress.XtraEditors.LabelControl labelControl_TipInfo;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetGridHeaderFields;
        private DevExpress.XtraEditors.SimpleButton simpleButton_GetGridHeaderNames;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn Age;
        private DevExpress.XtraGrid.Columns.GridColumn Sex;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn Work;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ModifyHeaderName;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ExportGridData;
        private DevExpress.XtraEditors.SimpleButton simpleButton_EnableEditGridAllData;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DisableEditGridAllData;
        private DevExpress.XtraEditors.SimpleButton simpleButton_EditGridSingleColumnDatas;
        private DevExpress.XtraEditors.SimpleButton simpleButton_EditGridMutiColumnDatas;
    }
}