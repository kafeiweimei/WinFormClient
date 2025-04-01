/***
*	Title："WinFormClient" 项目
*		主题：测试OPCDA帮助类
*	Description：
*		功能：XXX
*	Date：2025/3/31 18:53:03
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using CoffeeMilk13.SCADA.OPCDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.SCADA.Test
{
    public class Test_OPCDAHelper
    {

        #region   基础参数

        private string serverIP="127.0.0.1";
        private string serverName = "";//我这里默认是【Kepware.KEPServerEX.V6】

        //OPC服务帮助类
        private MyOPCDAHelper myOPCDAHelper=new MyOPCDAHelper();
        //连接状态
        private bool connectStatus = false;

        #region   读取数据参数
        //OPC变量组集合
        private OPCAutomation.OPCGroups oPCGroups;
        //OPC变量组
        private OPCAutomation.OPCGroup oPCGroup;

        //OPC数据项实体列表
        private List<OPCBrowserItem> oPCBrowserItems = new List<OPCBrowserItem>();
        //OPC服务句柄
        private Array ServerHandles;
        //错误
        private Array Errors;
        //事务ID
        private int TransactionID = 1;
        //取消ID
        private int CancelID = 1;

        #endregion

        #endregion

        /// <summary>
        /// 获取到需读取项的实时数据
        /// </summary>
        public void GetNeedReadItemsRealData(bool startRead)
        {
            while (startRead)
            {
                if (oPCBrowserItems.Count > 0)
                {
                    oPCGroup.AsyncRead(oPCBrowserItems.Count, ref ServerHandles,
                   out Errors, TransactionID, out CancelID);
                }
            }
            
        }

        public void GetAllServerItems()
        {
            //1-打开连接
            //根据服务器IP获取对应的OPCDA服务名称
            Array serverNameArray = myOPCDAHelper.GetOPCServerList(serverIP);

            if (serverNameArray==null)
            {
                Console.WriteLine($"无法获取到【{serverIP}】服务器对应的OPCDA服务名称，请检查该服务器上的OPCDA服务已经配置好打开");
                return;
            }

            Console.WriteLine($"【{serverIP}】下的OPCDA服务名称有：");
            foreach (var item in serverNameArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.Read();
            serverName = serverNameArray.GetValue(1).ToString();

            connectStatus = myOPCDAHelper.OpenConnect(serverName, serverIP);
            if (connectStatus)
            {
                Console.WriteLine($"连接【{serverIP}】的【{serverName}】服务成功");

                //2-获取到服务器的所有节点内容
                OPCAutomation.OPCBrowser oPCBrower = myOPCDAHelper.GetAllBrowser();
                Console.WriteLine($"获取到【{serverIP}】的【{serverName}】所有节点内容为：" +
                    $"\n{PrintList(oPCBrower)}");

                //3-OPCGroups与OPCGroup设置
                myOPCDAHelper.OPCGroupsSettings(ref oPCGroups);
                myOPCDAHelper.OPCGroupSettings(oPCGroups, ref oPCGroup, "OPCDA连接Kepware测试");
                foreach (var item in oPCBrower)
                {
                    OPCBrowserItem bi = new OPCBrowserItem();
                    bi.ItemID = item.ToString();
                    oPCBrowserItems.Add(bi);

                }
                SetNeedReadDataItems(oPCBrowserItems);

                //4-数据的实时读取
                oPCGroup.AsyncReadComplete += OPCGroup_AsyncReadComplete;



            }
        }

        //设置需读取数据的项
        private void SetNeedReadDataItems(List<OPCBrowserItem> oPCBrowserItemList)
        {
            if (oPCBrowserItemList == null || oPCBrowserItemList.Count<=0)
            {
                return;
            }

            int count = oPCBrowserItemList.Count;

            List<string> ItemIDList = new List<string>();
            List<int> ClientHandleList = new List<int>();

            ItemIDList.Add("0");
            ClientHandleList.Add(0);

            for (int i = 0; i < count; i++)
            {
                string tmpItemID = oPCBrowserItemList[i].ItemID;
                ItemIDList.Add(tmpItemID);
                ClientHandleList.Add(i);
            }

            //集合类型转为Array类型
            Array ItemIDs = ItemIDList.ToArray();
            Array ClientHandles = ClientHandleList.ToArray();

            oPCGroup.OPCItems.AddItems(ItemIDs.Length - 1, ref ItemIDs, ref ClientHandles,
                                     out ServerHandles, out Errors);



        }

        private string PrintList(OPCAutomation.OPCBrowser oPCBrowser)
        {
            StringBuilder sb = new StringBuilder();

            if (oPCBrowser==null || oPCBrowser.Count<=0)
            {
                return null;
            }

            foreach (var item in oPCBrowser)
            {
                sb.Append($"\n{item}");
            }

            return sb.ToString();
        }

        //读取数据
        private void OPCGroup_AsyncReadComplete(int TransactionID, int NumItems, ref Array ClientHandles,
    ref Array ItemValues, ref Array Qualities, ref Array TimeStamps, ref Array Errors)
        {

            //解析数据(特别注意：因为getvalue没有0,所以i是从1开始)
            for (int i = 1; i <= NumItems; i++)
            {
                object value = ItemValues.GetValue(i);

                if (value != null)
                {
                    int clientHandle = Convert.ToInt32(ClientHandles.GetValue(i));

                    for (int j = 0; j < oPCBrowserItems.Count; j++)
                    {
                        if (j == clientHandle)
                        {
                            oPCBrowserItems[j].Value = value?.ToString();
                            oPCBrowserItems[j].UpdateTime = TimeStamps.GetValue(i).ToString();
                            oPCBrowserItems[j].Quality = Qualities.GetValue(i).ToString();

                        }
                    }

                }

            }

            Console.WriteLine($"\n{PrintList(oPCBrowserItems)}");
        }

        private string PrintList(List<OPCBrowserItem> oPCBrowserItems)
        {
            if (oPCBrowserItems==null && oPCBrowserItems.Count<=0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in oPCBrowserItems)
            {
               sb.Append($"\n{item.ToString()}");
            }

            return sb.ToString();
        }

        class OPCBrowserItem
        {
            //变量ID
            public string ItemID { get; set; }
            //变量值
            public string Value { get; set; }
            //更新时间
            public string UpdateTime { get; set; }
            //质量
            public string Quality { get; set; }

            public override string ToString()
            {
                string str = $"变量名称【{ItemID}】变量值【{Value}】更新时间【{UpdateTime}】质量【{Quality}】";
                return str;
            }
        }

    }//Class_end
}
