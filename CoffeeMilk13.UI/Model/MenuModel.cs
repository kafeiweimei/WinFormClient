/***
*	Title："WinFormClient" 项目
*		主题：菜单模型
*	Description：
*		功能：XXX
*	Date：2024/10/31 17:10:16
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Model
{
    internal class MenuModel
    {
        //菜单名称
        private string _menuName = string.Empty;

        //菜单命名空间
        private string _menuNameSpace = string.Empty;

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Description("菜单名称")]
        public string MenuName { get => _menuName; set => _menuName = value; }

        /// <summary>
        /// 菜单命名空间
        /// </summary>
        [Description("菜单命名空间")]
        public string MenuNameSpace { get => _menuNameSpace; set => _menuNameSpace = value; }
    }
}
