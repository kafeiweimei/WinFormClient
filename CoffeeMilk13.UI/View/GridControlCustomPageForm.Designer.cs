
namespace CoffeeMilk13.UI.View
{
    partial class GridControlCustomPageForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton_Query = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Export = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.formPageControl1 = new CoffeeMilk13.UI.CustomControl.FormPageControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1257, 458);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // simpleButton_Query
            // 
            this.simpleButton_Query.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.simpleButton_Query.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Query.Appearance.Options.UseBackColor = true;
            this.simpleButton_Query.Appearance.Options.UseFont = true;
            this.simpleButton_Query.Location = new System.Drawing.Point(882, 12);
            this.simpleButton_Query.Name = "simpleButton_Query";
            this.simpleButton_Query.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Query.TabIndex = 13;
            this.simpleButton_Query.Text = "查询";
            this.simpleButton_Query.Click += new System.EventHandler(this.simpleButton_Query_Click);
            // 
            // simpleButton_Export
            // 
            this.simpleButton_Export.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButton_Export.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Export.Appearance.Options.UseBackColor = true;
            this.simpleButton_Export.Appearance.Options.UseFont = true;
            this.simpleButton_Export.Location = new System.Drawing.Point(1124, 12);
            this.simpleButton_Export.Name = "simpleButton_Export";
            this.simpleButton_Export.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Export.TabIndex = 14;
            this.simpleButton_Export.Text = "导出";
            this.simpleButton_Export.Click += new System.EventHandler(this.simpleButton_Export_Click);
            // 
            // simpleButton_Clear
            // 
            this.simpleButton_Clear.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.simpleButton_Clear.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Clear.Appearance.Options.UseBackColor = true;
            this.simpleButton_Clear.Appearance.Options.UseFont = true;
            this.simpleButton_Clear.Location = new System.Drawing.Point(1003, 12);
            this.simpleButton_Clear.Name = "simpleButton_Clear";
            this.simpleButton_Clear.Size = new System.Drawing.Size(92, 34);
            this.simpleButton_Clear.TabIndex = 15;
            this.simpleButton_Clear.Text = "清空";
            this.simpleButton_Clear.Click += new System.EventHandler(this.simpleButton_Clear_Click);
            // 
            // formPageControl1
            // 
            this.formPageControl1.Location = new System.Drawing.Point(0, 534);
            this.formPageControl1.Name = "formPageControl1";
            this.formPageControl1.Size = new System.Drawing.Size(1493, 42);
            this.formPageControl1.TabIndex = 1;
            // 
            // GridControlCustomPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 582);
            this.Controls.Add(this.simpleButton_Clear);
            this.Controls.Add(this.simpleButton_Export);
            this.Controls.Add(this.simpleButton_Query);
            this.Controls.Add(this.formPageControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "GridControlCustomPageForm";
            this.Text = "GridControlCustomPageForm";
            this.Load += new System.EventHandler(this.GridControlCustomPageForm_Load);
            this.Shown += new System.EventHandler(this.GridControlCustomPageForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Query;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Export;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Clear;
        private CustomControl.FormPageControl formPageControl1;
    }
}