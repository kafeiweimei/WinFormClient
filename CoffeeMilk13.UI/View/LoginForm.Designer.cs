
namespace CoffeeMilk13.UI.View
{
    partial class LoginForm
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
            this.labelControl_Company = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_Version = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.simpleButton_Login = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_Password = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_Account = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Accout = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Accout.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl_Company);
            this.panelControl1.Controls.Add(this.labelControl_Version);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 286);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(790, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl_Company
            // 
            this.labelControl_Company.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl_Company.Appearance.Font = new System.Drawing.Font("思源黑体 CN", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelControl_Company.Appearance.Options.UseFont = true;
            this.labelControl_Company.Location = new System.Drawing.Point(361, 6);
            this.labelControl_Company.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl_Company.Name = "labelControl_Company";
            this.labelControl_Company.Size = new System.Drawing.Size(76, 28);
            this.labelControl_Company.TabIndex = 3;
            this.labelControl_Company.Text = "开发公司";
            // 
            // labelControl_Version
            // 
            this.labelControl_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl_Version.Appearance.Font = new System.Drawing.Font("思源黑体 CN", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_Version.Appearance.Options.UseFont = true;
            this.labelControl_Version.Location = new System.Drawing.Point(12, 6);
            this.labelControl_Version.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl_Version.Name = "labelControl_Version";
            this.labelControl_Version.Size = new System.Drawing.Size(57, 28);
            this.labelControl_Version.TabIndex = 2;
            this.labelControl_Version.Text = "版本号";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.imageSlider1);
            this.panelControl2.Controls.Add(this.simpleButton_Login);
            this.panelControl2.Controls.Add(this.labelControl_Password);
            this.panelControl2.Controls.Add(this.textEdit_Password);
            this.panelControl2.Controls.Add(this.labelControl_Account);
            this.panelControl2.Controls.Add(this.textEdit_Accout);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(790, 286);
            this.panelControl2.TabIndex = 1;
            // 
            // imageSlider1
            // 
            this.imageSlider1.AllowLooping = true;
            this.imageSlider1.AnimationTime = 1600;
            this.imageSlider1.AutoSlide = DevExpress.XtraEditors.Controls.AutoSlide.Forward;
            this.imageSlider1.AutoSlideInterval = 2000;
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomOutside;
            this.imageSlider1.Location = new System.Drawing.Point(34, 54);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(217, 166);
            this.imageSlider1.TabIndex = 3;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // simpleButton_Login
            // 
            this.simpleButton_Login.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.simpleButton_Login.Appearance.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_Login.Appearance.Options.UseBackColor = true;
            this.simpleButton_Login.Appearance.Options.UseFont = true;
            this.simpleButton_Login.AppearancePressed.ForeColor = System.Drawing.Color.DarkOrange;
            this.simpleButton_Login.AppearancePressed.Options.UseForeColor = true;
            this.simpleButton_Login.Location = new System.Drawing.Point(361, 183);
            this.simpleButton_Login.Name = "simpleButton_Login";
            this.simpleButton_Login.Size = new System.Drawing.Size(406, 37);
            this.simpleButton_Login.TabIndex = 2;
            this.simpleButton_Login.Text = "登录";
            // 
            // labelControl_Password
            // 
            this.labelControl_Password.Appearance.Font = new System.Drawing.Font("思源黑体 CN Heavy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelControl_Password.Appearance.Options.UseFont = true;
            this.labelControl_Password.Location = new System.Drawing.Point(284, 123);
            this.labelControl_Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl_Password.Name = "labelControl_Password";
            this.labelControl_Password.Size = new System.Drawing.Size(46, 33);
            this.labelControl_Password.TabIndex = 1;
            this.labelControl_Password.Text = "密码";
            // 
            // textEdit_Password
            // 
            this.textEdit_Password.Location = new System.Drawing.Point(361, 125);
            this.textEdit_Password.Name = "textEdit_Password";
            this.textEdit_Password.Properties.Appearance.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit_Password.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Password.Properties.AutoHeight = false;
            this.textEdit_Password.Properties.UseSystemPasswordChar = true;
            this.textEdit_Password.Size = new System.Drawing.Size(406, 37);
            this.textEdit_Password.TabIndex = 1;
            // 
            // labelControl_Account
            // 
            this.labelControl_Account.Appearance.Font = new System.Drawing.Font("思源黑体 CN Heavy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelControl_Account.Appearance.Options.UseFont = true;
            this.labelControl_Account.Location = new System.Drawing.Point(284, 54);
            this.labelControl_Account.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl_Account.Name = "labelControl_Account";
            this.labelControl_Account.Size = new System.Drawing.Size(46, 33);
            this.labelControl_Account.TabIndex = 0;
            this.labelControl_Account.Text = "工号";
            // 
            // textEdit_Accout
            // 
            this.textEdit_Accout.Location = new System.Drawing.Point(361, 56);
            this.textEdit_Accout.Name = "textEdit_Accout";
            this.textEdit_Accout.Properties.Appearance.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit_Accout.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Accout.Properties.AutoHeight = false;
            this.textEdit_Accout.Size = new System.Drawing.Size(406, 37);
            this.textEdit_Accout.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 326);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.EnableAcrylicAccent = true;
            this.Font = new System.Drawing.Font("思源黑体 CN", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.Image = global::CoffeeMilk13.UI.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "牛奶咖啡13系统";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Accout.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl_Account;
        private DevExpress.XtraEditors.TextEdit textEdit_Accout;
        private DevExpress.XtraEditors.TextEdit textEdit_Password;
        private DevExpress.XtraEditors.LabelControl labelControl_Version;
        private DevExpress.XtraEditors.LabelControl labelControl_Password;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Login;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.LabelControl labelControl_Company;
    }
}