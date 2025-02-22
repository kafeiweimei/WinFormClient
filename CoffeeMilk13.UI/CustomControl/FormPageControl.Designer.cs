
namespace CoffeeMilk13.UI.CustomControl
{
    partial class FormPageControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton_FirstPage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_PreviousPage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_NextPage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_LastPage = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_CurPageIndex = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_PageInfo = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit_PageSize = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CurPageIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_PageSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_FirstPage
            // 
            this.simpleButton_FirstPage.Location = new System.Drawing.Point(17, 5);
            this.simpleButton_FirstPage.Name = "simpleButton_FirstPage";
            this.simpleButton_FirstPage.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_FirstPage.TabIndex = 0;
            this.simpleButton_FirstPage.Text = "首  页";
            this.simpleButton_FirstPage.Click += new System.EventHandler(this.simpleButton_FirstPage_Click);
            // 
            // simpleButton_PreviousPage
            // 
            this.simpleButton_PreviousPage.Location = new System.Drawing.Point(129, 5);
            this.simpleButton_PreviousPage.Name = "simpleButton_PreviousPage";
            this.simpleButton_PreviousPage.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_PreviousPage.TabIndex = 1;
            this.simpleButton_PreviousPage.Text = "上一页";
            this.simpleButton_PreviousPage.Click += new System.EventHandler(this.simpleButton_PreviousPage_Click);
            // 
            // simpleButton_NextPage
            // 
            this.simpleButton_NextPage.Location = new System.Drawing.Point(433, 5);
            this.simpleButton_NextPage.Name = "simpleButton_NextPage";
            this.simpleButton_NextPage.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_NextPage.TabIndex = 2;
            this.simpleButton_NextPage.Text = "下一页";
            this.simpleButton_NextPage.Click += new System.EventHandler(this.simpleButton_NextPage_Click);
            // 
            // simpleButton_LastPage
            // 
            this.simpleButton_LastPage.Location = new System.Drawing.Point(556, 5);
            this.simpleButton_LastPage.Name = "simpleButton_LastPage";
            this.simpleButton_LastPage.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_LastPage.TabIndex = 3;
            this.simpleButton_LastPage.Text = "尾  页";
            this.simpleButton_LastPage.Click += new System.EventHandler(this.simpleButton_LastPage_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(249, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "第";
            // 
            // textEdit_CurPageIndex
            // 
            this.textEdit_CurPageIndex.EditValue = "";
            this.textEdit_CurPageIndex.Location = new System.Drawing.Point(267, 10);
            this.textEdit_CurPageIndex.Name = "textEdit_CurPageIndex";
            this.textEdit_CurPageIndex.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit_CurPageIndex.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit_CurPageIndex.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit_CurPageIndex.Size = new System.Drawing.Size(100, 20);
            this.textEdit_CurPageIndex.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(373, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "页";
            // 
            // labelControl_PageInfo
            // 
            this.labelControl_PageInfo.Location = new System.Drawing.Point(857, 11);
            this.labelControl_PageInfo.Name = "labelControl_PageInfo";
            this.labelControl_PageInfo.Size = new System.Drawing.Size(249, 14);
            this.labelControl_PageInfo.TabIndex = 7;
            this.labelControl_PageInfo.Text = "（共【0】条记录，每页【0】条，共【0】页）";
            // 
            // comboBoxEdit_PageSize
            // 
            this.comboBoxEdit_PageSize.Location = new System.Drawing.Point(665, 10);
            this.comboBoxEdit_PageSize.Name = "comboBoxEdit_PageSize";
            this.comboBoxEdit_PageSize.Properties.Appearance.Options.UseTextOptions = true;
            this.comboBoxEdit_PageSize.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.comboBoxEdit_PageSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_PageSize.Size = new System.Drawing.Size(153, 20);
            this.comboBoxEdit_PageSize.TabIndex = 8;
            this.comboBoxEdit_PageSize.TextChanged += new System.EventHandler(this.comboBoxEdit_PageSize_TextChanged);
            // 
            // FormPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxEdit_PageSize);
            this.Controls.Add(this.labelControl_PageInfo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit_CurPageIndex);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton_LastPage);
            this.Controls.Add(this.simpleButton_NextPage);
            this.Controls.Add(this.simpleButton_PreviousPage);
            this.Controls.Add(this.simpleButton_FirstPage);
            this.Name = "FormPageControl";
            this.Size = new System.Drawing.Size(1280, 36);
            this.Load += new System.EventHandler(this.FormPageControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CurPageIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_PageSize.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton_FirstPage;
        private DevExpress.XtraEditors.SimpleButton simpleButton_PreviousPage;
        private DevExpress.XtraEditors.SimpleButton simpleButton_NextPage;
        private DevExpress.XtraEditors.SimpleButton simpleButton_LastPage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_CurPageIndex;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl_PageInfo;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_PageSize;
    }
}
