/***
*	Title："基础工具" 项目
*		主题：弹出提示框
*	Description：
*		功能：
*		    1、显示对话提示框
*		    2、显示系统异常提示框
*		    3、显示警告信息提示框
*		    4、显示错误信息提示框
*		    5、显示信息提示框
*		    6、提供多线程调用LabelControl组件显示信息
*	Date：2022/7/31 17:49:02
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMilk13.UI.Utils
{
    public class PopupMessage
    {
        public static LabelControl label { get; set; }
        public static string tipMessages { get; set; }

        /// <summary>
        /// 显示对话提示框
        /// </summary>
        /// <param name="msg">对话消息</param>
        /// <returns></returns>
        public static bool ShowAskQuestion(string msg)
        {
            DialogResult r;
            r = XtraMessageBox.Show(msg.Replace("\\r\\n", "\r\n"), "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            return r == DialogResult.Yes;
        }

        /// <summary>
        /// 显示系统异常提示框
        /// </summary>
        /// <param name="ex">异常消息</param>
        public static void ShowException(Exception ex)
        {
            var s = ex.Message;
            var innerMsg = string.Empty;

            if (ex.InnerException != null)
            {
                innerMsg = ex.InnerException.Message;
                s += "\n" + innerMsg;
            }

            ShowError(s);
        }


        /// <summary>
        /// 显示警告信息提示框
        /// </summary>
        /// <param name="msg">警告内容</param>
        public static void ShowWarning(string msg)
        {
            XtraMessageBox.Show(msg.Replace("\\r\\n", "\r\n"), "警告",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示错误信息提示框
        /// </summary>
        /// <param name="msg">错误消息内容</param>
        public static void ShowError(string msg)
        {
            XtraMessageBox.Show(msg.Replace("\\r\\n", "\r\n"), "错误",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示信息提示框
        /// </summary>
        /// <param name="msg">本次显示的消息</param>
        public static void ShowInfo(string msg)
        {
            XtraMessageBox.Show(msg.Replace("\\r\\n", "\r\n"), "信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }


        /// <summary>
        /// 显示提示信息（多线程）
        /// </summary>
        /// <param name="tipMessage">需要显示的提示信息</param>
        /// <param name="tipStatus">提示信息状态</param>
        public static void ShowTipInfoOfMutiThread(string tipMessage, TipStatus tipStatus=TipStatus.Failed)
        {
            try
            {
                if (label != null)
                {
                    if (label.InvokeRequired)
                    {
                        DelTipMessage delTipMessage = ShowTipInfoOfMutiThread;

                        label.Invoke(delTipMessage,tipMessage,tipStatus);
                    }
                    else
                    {
                        label.Text = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]:{tipMessage}";
                        switch (tipStatus)
                        {
                            case TipStatus.Success:
                                label.ForeColor = Color.Green;
                                break;
                            case TipStatus.Failed:
                                label.ForeColor = Color.Red;
                                break;
                            case TipStatus.Waring:
                                label.ForeColor = Color.Orange;
                                break;
                            default:
                                break;
                        }
                    }
                }

                tipMessages = tipMessage;

            }
            catch (Exception)
            {
            }

        }

        /// <summary>
        /// 清空提示信息（多线程）
        /// </summary>
        public static void ClearTipInfoOfMutiThread()
        {
            if (label!=null)
            {
                if (label.InvokeRequired)
                {
                    ClearTipInfo clearTipInfo = ClearTipInfoOfMutiThread;
                    label.Invoke(clearTipInfo);
                }
                else
                {
                    label.Text = "";
                    tipMessages = "";
                }
            }
        }

        /// <summary>
        /// 提示消息委托
        /// </summary>
        /// <param name="tipMessage">需要显示的提示信息</param>
        /// <param name="tipStatus">提示信息的状态</param>
        private delegate void DelTipMessage(string tipMessage,TipStatus tipStatus);

        /// <summary>
        /// 清空消息
        /// </summary>
        private delegate void ClearTipInfo();

        /// <summary>
        /// 提示状态
        /// </summary>
        public enum TipStatus
        {
            Success=0,
            Failed=1,
            Waring=2
        }

    }//Class_end
}
