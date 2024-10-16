/***
*	Title："WinFormClient" 项目
*		主题：程序的程序集信息
*	Description：
*		功能：XXX
*	Date：2024/10/16 14:57:21
*	Version：0.1版本
*	Author：CoffeeMilk13
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.Utils
{
    public class AppAssemblyInfo
    {
        //获取路径
        public static string Path
        {
            get { return Application.ExecutablePath; }
        }
         
        //获取标题
        public static string Title
        {
            get 
            {
                try
                {
                    return ((AssemblyTitleAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0])).Title;
                }
                catch(Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        //获取说明
        public static string Description
        {
            get
            {
                try
                {
                    return ((AssemblyDescriptionAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0])).Description;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        //获取公司
        public static string CompanyName
        {
            get { return Application.CompanyName; }
        }

        //获取产品名称
        public static string ProductName
        {
            get { return Application.ProductName; }
        }

        //获取版权
        public static string Copyright
        {
            get
            {
                try
                {
                    return ((AssemblyCopyrightAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0])).Copyright;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        //获取版本信息
        public static string Version
        {
            get { return Application.ProductVersion; }
        }



    }
}
