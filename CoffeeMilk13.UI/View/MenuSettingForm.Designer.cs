
namespace CoffeeMilk13.UI.View
{
    partial class MenuSettingForm
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
            this.textEdit_MenuName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_MenuName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_MenuNameSpace = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_MenuNameSpace = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton_Add = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Modify = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Export = new DevExpress.XtraEditors.SimpleButton();
            this.MenuNameSpace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MenuName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MenuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MenuNameSpace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_MenuName
            // 
            this.textEdit_MenuName.Location = new System.Drawing.Point(5, 33);
            this.textEdit_MenuName.Name = "textEdit_MenuName";
            this.textEdit_MenuName.Properties.Appearance.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_MenuName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_MenuName.Size = new System.Drawing.Size(414, 24);
            this.textEdit_MenuName.TabIndex = 0;
            // 
            // labelControl_MenuName
            // 
            this.labelControl_MenuName.Appearance.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_MenuName.Appearance.Options.UseFont = true;
            this.labelControl_MenuName.Location = new System.Drawing.Point(5, 8);
            this.labelControl_MenuName.Name = "labelControl_MenuName";
            this.labelControl_MenuName.Size = new System.Drawing.Size(84, 19);
            this.labelControl_MenuName.TabIndex = 1;
            this.labelControl_MenuName.Text = "菜单名称";
            // 
            // labelControl_MenuNameSpace
            // 
            this.labelControl_MenuNameSpace.Appearance.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_MenuNameSpace.Appearance.Options.UseFont = true;
            this.labelControl_MenuNameSpace.Location = new System.Drawing.Point(542, 8);
            this.labelControl_MenuNameSpace.Name = "labelControl_MenuNameSpace";
            this.labelControl_MenuNameSpace.Size = new System.Drawing.Size(126, 19);
            this.labelControl_MenuNameSpace.TabIndex = 3;
            this.labelControl_MenuNameSpace.Text = "菜单命名空间";
            // 
            // textEdit_MenuNameSpace
            // 
            this.textEdit_MenuNameSpace.Location = new System.Drawing.Point(542, 33);
            this.textEdit_MenuNameSpace.Name = "textEdit_MenuNameSpace";
            this.textEdit_MenuNameSpace.Properties.Appearance.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_MenuNameSpace.Properties.Appearance.Options.UseFont = true;
            this.textEdit_MenuNameSpace.Size = new System.Drawing.Size(734, 24);
            this.textEdit_MenuNameSpace.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 100);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1274, 479);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.AppearanceCell.Options.HighPriority = true;
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // simpleButton_Add
            // 
            this.simpleButton_Add.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.simpleButton_Add.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Add.Appearance.Options.UseBackColor = true;
            this.simpleButton_Add.Appearance.Options.UseFont = true;
            this.simpleButton_Add.Location = new System.Drawing.Point(863, 60);
            this.simpleButton_Add.Name = "simpleButton_Add";
            this.simpleButton_Add.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Add.TabIndex = 5;
            this.simpleButton_Add.Text = "添加";
            this.simpleButton_Add.Click += new System.EventHandler(this.simpleButton_Add_Click);
            // 
            // simpleButton_Modify
            // 
            this.simpleButton_Modify.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.simpleButton_Modify.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Modify.Appearance.Options.UseBackColor = true;
            this.simpleButton_Modify.Appearance.Options.UseFont = true;
            this.simpleButton_Modify.Location = new System.Drawing.Point(970, 60);
            this.simpleButton_Modify.Name = "simpleButton_Modify";
            this.simpleButton_Modify.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Modify.TabIndex = 6;
            this.simpleButton_Modify.Text = "修改";
            // 
            // simpleButton_Delete
            // 
            this.simpleButton_Delete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.simpleButton_Delete.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Delete.Appearance.Options.UseBackColor = true;
            this.simpleButton_Delete.Appearance.Options.UseFont = true;
            this.simpleButton_Delete.Location = new System.Drawing.Point(1077, 60);
            this.simpleButton_Delete.Name = "simpleButton_Delete";
            this.simpleButton_Delete.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Delete.TabIndex = 7;
            this.simpleButton_Delete.Text = "删除";
            // 
            // simpleButton_Export
            // 
            this.simpleButton_Export.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButton_Export.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Export.Appearance.Options.UseBackColor = true;
            this.simpleButton_Export.Appearance.Options.UseFont = true;
            this.simpleButton_Export.Location = new System.Drawing.Point(1184, 60);
            this.simpleButton_Export.Name = "simpleButton_Export";
            this.simpleButton_Export.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Export.TabIndex = 8;
            this.simpleButton_Export.Text = "导出";
            // 
            // MenuNameSpace
            // 
            this.MenuNameSpace.Caption = "菜单命名空间";
            this.MenuNameSpace.Name = "MenuNameSpace";
            // 
            // MenuName
            // 
            this.MenuName.Caption = "菜单名称";
            this.MenuName.Name = "MenuName";
            // 
            // MenuSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 582);
            this.Controls.Add(this.simpleButton_Export);
            this.Controls.Add(this.simpleButton_Delete);
            this.Controls.Add(this.simpleButton_Modify);
            this.Controls.Add(this.simpleButton_Add);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl_MenuNameSpace);
            this.Controls.Add(this.textEdit_MenuNameSpace);
            this.Controls.Add(this.labelControl_MenuName);
            this.Controls.Add(this.textEdit_MenuName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuSettingForm";
            this.Text = "菜单设置";
            this.Load += new System.EventHandler(this.MenuSettingForm_Load);
            this.Resize += new System.EventHandler(this.MenuSettingForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MenuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MenuNameSpace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_MenuName;
        private DevExpress.XtraEditors.LabelControl labelControl_MenuName;
        private DevExpress.XtraEditors.LabelControl labelControl_MenuNameSpace;
        private DevExpress.XtraEditors.TextEdit textEdit_MenuNameSpace;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Add;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Modify;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Delete;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Export;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn MenuNameSpace;
        private DevExpress.XtraGrid.Columns.GridColumn MenuName;
    }
}