/***
*	Title："WinFormClient" 项目
*		主题：OPCDA帮助类
*	Description：
*		功能：
*		    1、获取到OPC服务器
*		    2、打开OPCServe连接
*		    3、获取到OPC服务器的所有节点内容
*		    4、进行OPCGroups设置
*		    5、进行OPCGroup设置
*		    6、关闭OPCServe连接
*	Date：2025/3/31 18:02:53
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.SCADA.OPCDA
{
    public class MyOPCDAHelper
    {
        #region   基础参数
        //OPCServer服务器
        private OPCServer oPCServer;
        //OPC浏览对象
        private OPCBrowser oPcBrower;

        #endregion

        //构造函数
        public MyOPCDAHelper()
        {
            oPCServer = new OPCServer();
        }

        /// <summary>
        /// 获取到OPCDAServer
        /// </summary>
        public OPCServer GetOpcDAServer
        {
            get
            {
                return oPCServer;
            }
        }

        /// <summary>
        /// 获取到OPC服务器
        /// </summary>
        /// <param name="serverNode">服务器节点（即服务器的IP地址）</param>
        /// <returns>返回该服务器节点对应的所有服务器列表</returns>
        public Array GetOPCServerList(string serverNode)
        {
            try
            {
                object serverListObj = oPCServer.GetOPCServers(serverNode);

                Array serverList = (Array)serverListObj;

                return serverList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("获取服务器列表出错！！！" + ex.Message, "一般错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="serverName">服务器的名称</param>
        /// <param name="serverIP">服务器的IP地址</param>
        /// <returns>true:表示连接成功</returns>
        public bool OpenConnect(string serverName, string serverIP)
        {
            bool success = false;
            if (!string.IsNullOrEmpty(serverIP) && !string.IsNullOrEmpty(serverName))
            {
                try
                {
                    if (oPCServer == null)
                    {
                        oPCServer = new OPCServer();
                    }
                    oPCServer.Connect(serverName, serverIP);
                    success = true;

                }
                catch (Exception ex)
                {
                    success = false;
                    //MessageBox.Show(ex.Message, "严重错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }

            return success;
        }


        /// <summary>
        /// 获取到OPC服务器的所有节点内容
        /// </summary>
        /// <returns>返回OPC服务器的所有节点内容</returns>
        public OPCBrowser GetAllBrowser()
        {
            try
            {
                oPcBrower = oPCServer.CreateBrowser();
                oPcBrower.ShowBranches();
                oPcBrower.ShowLeafs(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message, "严重错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }

            return oPcBrower;

        }

        /// <summary>
        /// OPCGroups设置
        /// </summary>
        /// <param name="oPCGroups">需要设置的OPCGroups</param>
        public void OPCGroupsSettings(ref OPCGroups oPCGroups)
        {
            oPCGroups = oPCServer.OPCGroups;
            oPCGroups.DefaultGroupDeadband = 0;
            oPCGroups.DefaultGroupIsActive = true;
        }

        /// <summary>
        /// OPCGroup设置
        /// </summary>
        /// <param name="oPCGroups">OPCGroups</param>
        /// <param name="oPCGroup">OPCGroup</param>
        /// <param name="oPCGroupName">oPCGroupName</param>
        /// <param name="updateRate">更新频率</param>
        public void OPCGroupSettings(OPCGroups oPCGroups, ref OPCGroup oPCGroup, string oPCGroupName, int updateRate = 250)
        {
            if (oPCGroups != null &&
                !string.IsNullOrEmpty(oPCGroupName) && updateRate > 0)
            {
                oPCGroup = oPCGroups.Add(oPCGroupName);
                oPCGroup.IsActive = true;
                oPCGroup.IsSubscribed = true;
                oPCGroup.UpdateRate = updateRate;
            }
        }



        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns>true:表示关闭</returns>
        public bool CloseConnect()
        {
            bool success = false;

            try
            {
                if (oPCServer != null)
                {
                    oPCServer.Disconnect();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                success = false;
                //MessageBox.Show(ex.Message, "严重错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }

            return success;

        }


    }//Class_end
}
