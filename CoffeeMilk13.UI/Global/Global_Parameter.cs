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


        #endregion

        #region   临时字典
        //临时菜单字典
        public static Dictionary<string, string> tmpMenuDic = new Dictionary<string, string>
        {
            ["功能模块设置"] = "CoffeeMilk13.UI.View.FunctionModuleSettingForm",
            ["菜单设置"] = "CoffeeMilk13.UI.View.MenuSettingForm",
            ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
        };
        //临时功能模块字典
        public static Dictionary<string, Dictionary<string, string>> tmpFuncModuleDic = new Dictionary<string, Dictionary<string, string>>
        {
            ["系统功能"] =tmpMenuDic,
            //["系统功能"]=new Dictionary<string, string> 
            //{ 
            //    ["功能模块设置"]="CoffeeMilk13.UI.View.FunctionModuleSettingForm",
            //    ["菜单设置"] = "CoffeeMilk13.UI.View.MenuSettingForm",
            //    ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
            //},
            ["业务功能2"] = new Dictionary<string, string>
            {
                ["菜单21"] = "CoffeeMilk13.UI.View.FunctionModuleSettingForm2",
                ["菜单22"] = "CoffeeMilk13.UI.View.MenuSettingForm2",
                ["菜单23"] = "CoffeeMilk13.UI.View.AuthoritySettingForm2"
            },
            ["业务功能3"] = new Dictionary<string, string>
            {
                ["菜单31"] = "CoffeeMilk13.UI.View.FunctionModuleSettingForm3",
                ["菜单32"] = "CoffeeMilk13.UI.View.MenuSettingForm3",
                ["菜单33"] = "CoffeeMilk13.UI.View.AuthoritySettingForm3"
            },


        };
        

        #endregion


    }//Class_end
}
