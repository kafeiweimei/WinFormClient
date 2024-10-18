using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeMilk13.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ////是否启用全局的动画效果（优先级大于单个窗体的效果）
            //WindowsFormsSettings.AnimationMode = AnimationMode.EnableAll;
            Application.Run(new View.LoginForm());
        }
    }
}
