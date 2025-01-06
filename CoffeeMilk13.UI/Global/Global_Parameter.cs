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

        #region     界面参数
        //当前选中的功能模块名称
        public static string curSelectedFuncModuleName = string.Empty;

        #endregion

        #region   临时字典
        //临时菜单字典
        public static Dictionary<string, string> tmpMenuDic = new Dictionary<string, string>
        {
            ["菜单设置"] = "CoffeeMilk13.UI.View.MenuSettingForm",
            ["功能模块设置"] = "CoffeeMilk13.UI.View.FunctionModuleSettingForm",
            ["角色设置"] = "CoffeeMilk13.UI.View.RoleSettingForm",
            ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm",
            ["测试菜单1"] = "CoffeeMilk13.UI.View.XtraForm1",
            ["Grid表格常用操作"] = "CoffeeMilk13.UI.View.GridControlOpcForm",
            ["Grid表格与DataTable操作"] = "CoffeeMilk13.UI.View.GridControlDataTableOpcForm"
        };

        //临时功能模块字典
        public static Dictionary<string, Dictionary<string, string>> tmpFuncModuleDic = new Dictionary<string, Dictionary<string, string>>
        {
            ["系统功能"] = tmpMenuDic,

            ["业务功能2"] = new Dictionary<string, string>
            {
                ["测试菜单1"] = "CoffeeMilk13.UI.View.XtraForm1",
                ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
            },
            ["业务功能3"] = new Dictionary<string, string>
            {
                ["菜单设置"] = "CoffeeMilk13.UI.View.MenuSettingForm",
                ["测试菜单1"] = "CoffeeMilk13.UI.View.XtraForm1",
                ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
            },


        };

        //临时功能模块及其对应图片字典
        public static Dictionary<string, string> tmpFuncModuleAndImgDic = new Dictionary<string, string>()
        {
            ["系统功能"]= "调整数据",
            ["业务功能2"]= "数据节点",
            ["业务功能3"]= "传输数据"
        };

        //临时角色字典
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> tmpRoleDic = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>()
        {
            ["超级管理员"] = tmpFuncModuleDic,
            ["运维人员"]=new Dictionary<string, Dictionary<string, string>>()
            {
                ["业务功能2"] = new Dictionary<string, string>
                {
                    ["测试菜单1"] = "CoffeeMilk13.UI.View.XtraForm1",
                    ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
                },
                ["业务功能3"] = new Dictionary<string, string>
                {
                    ["菜单设置"] = "CoffeeMilk13.UI.View.MenuSettingForm",
                    ["测试菜单1"] = "CoffeeMilk13.UI.View.XtraForm1",
                    ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
                }
            },
            ["操作工"] =new Dictionary<string, Dictionary<string, string>>()
            {
                ["业务功能3"] = new Dictionary<string, string>
                {
                    ["菜单设置"] = "CoffeeMilk13.UI.View.MenuSettingForm",
                    ["测试菜单1"] = "CoffeeMilk13.UI.View.XtraForm1",
                    ["权限设置"] = "CoffeeMilk13.UI.View.AuthoritySettingForm"
                },
            }

        };

        #endregion


    }//Class_end
}
