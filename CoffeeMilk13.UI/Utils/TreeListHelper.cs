/***
*	Title："WinFormClient" 项目
*		主题：TreeList帮助类
*	Description：
*		功能：
*		    1、设置TreeList显示行号
*		    2、设置TreeList行选中效果
*		    3、设置TreeList的复选框选中事件
*		    
*	Date：2024/11/28 18:11:46
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.Utils
{
    public class TreeListHelper
    {
        /// <summary>
        /// 设置TreeList显示行号
        /// </summary>
        /// <param name="treeList">treeList控件</param>
        public static void SetTreeListLineNumbers(DevExpress.XtraTreeList.TreeList treeList)
        {
            if (treeList == null) return;

            // 显示默认的行指示器（行号）
            treeList.OptionsView.ShowIndicator = true;

            // 设置行号列的宽度
            treeList.IndicatorWidth = 36;

            // 自定义行号显示
            treeList.CustomDrawNodeIndicator += (s, e) =>
            {
                if (e.Node != null)
                {
                    // 显示从1开始的行号
                    e.Info.DisplayText = (treeList.GetVisibleIndexByNode(e.Node) + 1).ToString();

                    // 可选：设置行号样式
                    //e.Appearance.Font = new Font(treeList.Font, FontStyle.Bold);
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            };



        }

        /// <summary>
        /// 设置TreeList行选中效果
        /// </summary>
        /// <param name="treeList">treeList控件</param>
        public static void SetTreeListRowSelectedEffect(DevExpress.XtraTreeList.TreeList treeList)
        {
            if (treeList == null) return;
            ////焦点行字体加粗
            //treeList.Appearance.FocusedRow.Font = new Font(treeList.Font, FontStyle.Bold);
            //treeList.Appearance.FocusedRow.Options.UseFont = true;

            //// 1. 启用焦点行显示
            //treeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            //treeList.OptionsSelection.EnableAppearanceFocusedRow = true;
            //treeList.OptionsSelection.EnableAppearanceFocusedCell = false;

            //// 2. 设置选中行的样式
            //treeList.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 105, 194);  // 背景色
            //treeList.Appearance.FocusedRow.ForeColor = Color.FromArgb(206, 112, 1);  // 文字颜色
            //treeList.Appearance.FocusedRow.Options.UseBackColor = true;
            //treeList.Appearance.FocusedRow.Options.UseForeColor = true;

            ////// 3. 设置多选模式下的样式（如果需要）
            ////treeList.OptionsSelection.MultiSelect = true;  // 启用多选
            ////treeList.Appearance.SelectedRow.BackColor = Color.LightBlue;    // 多选时其他选中行的背景色
            ////treeList.Appearance.SelectedRow.ForeColor = Color.Black;        // 多选时其他选中行的文字颜色
            ////treeList.Appearance.SelectedRow.Options.UseBackColor = true;
            ////treeList.Appearance.SelectedRow.Options.UseForeColor = true;

            //// 4. 设置鼠标悬停效果（可选）
            ////treeList.OptionsView.EnableAppearanceHotTracking = true;
            //treeList.Appearance.HotTrackedRow.BackColor = Color.LightYellow;
            //treeList.Appearance.HotTrackedRow.Options.UseBackColor = true;

            // 使用CustomDrawNodeCell事件来自定义每个单元格的外观
            treeList.CustomDrawNodeCell += (sender, e) =>
            {
                // 如果当前节点被勾选，改变字体颜色
                if (e.Node.IsSelected == true)
                {
                    e.Appearance.ForeColor = Color.FromArgb(0, 105, 194);  // 设置为蓝色或其他颜色
                    e.Appearance.Options.UseForeColor = true;

                    // 获取当前节点的字体（如果没有设置则使用TreeList的默认字体）
                    Font currentFont = e.Appearance.Font ?? treeList.Appearance.Row.Font ?? treeList.Font;
                    e.Appearance.Font = new Font(
                       currentFont.FontFamily,    // 保持原字体
                       currentFont.Size,          // 保持原字体大小
                       FontStyle.Bold             // 设置为粗体
                        );
                    e.Appearance.Options.UseFont = true;

                }
            };

        }

        /// <summary>
        /// 设置TreeList的复选框选中事件
        /// </summary>
        /// <param name="treeList">treeList控件</param>
        public static void SetTreeListCheckBoxSelectedEvent(DevExpress.XtraTreeList.TreeList treeList)
        {
            if (treeList == null) return;
            
            // 启用复选框
            treeList.OptionsView.ShowCheckBoxes = true;
            
            ////启用行高自适应
            //treeList.OptionsBehavior.AutoNodeHeight = true;
            //treeList.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            //treeList.Appearance.Row.Options.UseTextOptions = true;

            // 使用CustomDrawNodeCell事件来自定义每个单元格的外观
            treeList.CustomDrawNodeCell += (sender, e) =>
            {
                // 如果当前节点被勾选，改变字体颜色
                if (e.Node.CheckState == CheckState.Checked)
                {
                    e.Appearance.ForeColor = Color.FromArgb(0, 105, 194);  // 设置为蓝色或其他颜色
                    e.Appearance.Options.UseForeColor = true;

                    // 获取当前节点的字体（如果没有设置则使用TreeList的默认字体）
                    Font currentFont = e.Appearance.Font ?? treeList.Appearance.Row.Font ?? treeList.Font;
                    e.Appearance.Font = new Font(
                       currentFont.FontFamily,    // 保持原字体
                       currentFont.Size,          // 保持原字体大小
                       FontStyle.Bold             // 设置为粗体
                        );
                    e.Appearance.Options.UseFont = true;

                }
            };

            // 处理复选框选中事件，用于刷新显示
            treeList.AfterCheckNode += (sender, e) =>
            {
                // 刷新TreeList以更新显示
                treeList.Refresh();
            };
        }

        /// <summary>
        /// 取消TreeList的复选框选择效果（选中和不选中都失效）
        /// </summary>
        /// <param name="treeList">treeList控件</param>
        public static void CancelTreeListCheckBoxSelectedEvent(DevExpress.XtraTreeList.TreeList treeList)
        {
            if (treeList == null) return;

            treeList.BeforeCheckNode += (sender, e) =>
            {
                e.CanCheck = false;
            };
        }

        /// <summary>
        /// 获取TreeList的复选框勾选内容
        /// </summary>
        /// <param name="treeList">treeList控件</param>
        /// <returns></returns>
        public static List<string> GetCheckBoxSelectedContent(DevExpress.XtraTreeList.TreeList treeList)
        {
            if (treeList == null) return null;

            List<string> tmpList = new List<string>();

            for (int i = 0; i < treeList.Nodes.Count; i++)
            {
                string curDisplayText = treeList.Nodes[i].GetDisplayText(0);
                if (!tmpList.Contains(curDisplayText))
                {
                    tmpList.Add(curDisplayText);
                }
            }

            return tmpList;
        }

    }//Class_end
}
