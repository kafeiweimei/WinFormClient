/***
*	Title："WinFormClient" 项目
*		主题：【公共层】全局参数
*	Description：
*		功能：
*		    1、定义整个项目的枚举类型
*		    2、定义整个项目的委托
*		    3、定义整个项目的系统常量
*	Date：2024
*	Version：0.1版本
*	Author：CoffeeMilk13
*	Modify Recoder：
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Global
{
    class Global_Parameter
    {
        #region    1-项目名称、版本、使用公司、开发公司等基础属性
        public const string ProjectName = "WinFormClient";
        public const string ProjectVersion = "V-0.1";
        public const string ProjectUseCompany = "CoffeeMilk13科技有限公司";
        public const string ProjectDevelopCompany = "CoffeeMilk13科技有限公司";

        #endregion

        #region    2-日志路径
        public const string LOGBASEPATH = @"C:/CoffeeMilk13/";
        public const string LOGFILENAME = "WinFormClient.txt";

        #endregion

        #region   3-配置文件名称
        //IP地址列表文件名称
        public const string IPLISTNAME = "IPAddressList.xml";

        #endregion

        #region   临时字典
        //临时字典
        public static Dictionary<string, string> tmpMenuDic = new Dictionary<string, string>();

        #endregion


    }//Class_end
}
