/***
*	Title："WinFormClient" 项目
*		主题：测试OPCUA帮助类
*	Description：
*		功能：对应的OPCUA服务（KEPServerEX 6 ）环境搭建请参考《https://blog.csdn.net/xiaochenXIHUA/article/details/117070003》
*	Date：2025/3/13 19:59:41
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using CoffeeMilk13.SCADA.OPCUA;
using Opc.Ua.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMilk13.SCADA.Test
{
    class Test_OPCUAHelper
    {
        #region   基础参数
        MyOpcUaHelper myOpcUaHelper = new MyOpcUaHelper();
        ConcurrentDictionary<string,string> collectDeviceDatas = new ConcurrentDictionary<string,string>();
        List<string> needSubDeviceAllNodeNameList = new List<string>()
            {
                "ns=2;s=模拟器示例.函数.Ramp1",
                "ns=2;s=模拟器示例.函数.Ramp2",
                "ns=2;s=模拟器示例.函数.Ramp3",
                "ns=2;s=模拟器示例.函数.Ramp4",
                "ns=2;s=模拟器示例.函数.Ramp5",
                "ns=2;s=模拟器示例.函数.Ramp6",
                "ns=2;s=模拟器示例.函数.Ramp7",
                "ns=2;s=模拟器示例.函数.Ramp8",
                "ns=2;s=模拟器示例.函数.Random1",
                "ns=2;s=模拟器示例.函数.Random2",
                "ns=2;s=模拟器示例.函数.Random3",
                "ns=2;s=模拟器示例.函数.Random4",
                "ns=2;s=模拟器示例.函数.Random5",
                "ns=2;s=模拟器示例.函数.Random6",
                "ns=2;s=模拟器示例.函数.Random7",
                "ns=2;s=模拟器示例.函数.Random8",
                "ns=2;s=模拟器示例.函数.Sine1",
                "ns=2;s=模拟器示例.函数.Sine2",
                "ns=2;s=模拟器示例.函数.Sine3",
                "ns=2;s=模拟器示例.函数.Sine4",
                "ns=2;s=模拟器示例.函数.User1",
                "ns=2;s=模拟器示例.函数.User2",
                "ns=2;s=模拟器示例.函数.User3",
                "ns=2;s=模拟器示例.函数.User4"
            };
        #endregion


        //打开连接
        public void OpenConn(string opcuaurl= "opc.tcp://127.0.0.1:49320")
        {
            Console.WriteLine($"--开始连接【{opcuaurl}】--");
            ////匿名连接
            //myOpcUaHelper.OpenConnectOfAnonymous(opcuaurl,ReadNodeInfo);

            //账号密码连接
            //myOpcUaHelper.OpenConnectOfAccount(opcuaurl, "testOPCUA", "123456",ReadNodeInfo);
            myOpcUaHelper.OpenConnectOfAccount(opcuaurl, "testOPCUA", "123456", ReadNodeInfoAsync);


        }

        /// <summary>
        /// 点位信息读取（同步方式）
        /// </summary>
        /// <param name="connState">连接状态</param>
        private void ReadNodeInfo(bool connState)
        {
            if (!connState)
            {
                Console.WriteLine($"当前没有连接到OPCUA服务器，请连接后重试！");
                return;
            }

            //单点位名称
            string nodeName1 = "ns=2;s=模拟器示例.函数.Ramp1";
            string nodeName2 = "ns=2;s=模拟器示例.函数.User1";

            //多点位名称列表
            List<Opc.Ua.NodeId> nodeNameList = new List<Opc.Ua.NodeId>()
            {
                "ns=2;s=模拟器示例.函数.Ramp2",
                "ns=2;s=模拟器示例.函数.Ramp3",
                "ns=2;s=模拟器示例.函数.Ramp6",
                "ns=2;s=模拟器示例.函数.Ramp8",
                "ns=2;s=模拟器示例.函数.Sine2",
                "ns=2;s=模拟器示例.函数.User1",
                "ns=2;s=模拟器示例.函数.User2",
                "ns=2;s=模拟器示例.函数.User3",
                "ns=2;s=模拟器示例.函数.User4"
            };


            int readNum = 16;

            while(readNum>=0)
            {
                Thread.Sleep(1000);
                readNum--;
                Console.WriteLine($"\n---同步读取【单点位】数据值---");
                //同步读取当前点位的值
                var nodeName1_Obj = myOpcUaHelper.GetCurrentNodeValue(nodeName1);
                Console.WriteLine($"【{nodeName1}】的值是：{nodeName1_Obj?.Value}");

                var nodeName2_Obj = myOpcUaHelper.GetCurrentNodeValue(nodeName2);
                Console.WriteLine($"【{nodeName2}】的值是：{nodeName2_Obj?.Value}");

                Console.WriteLine($"\n---同步读取【多点位】数据值---");
                Dictionary<string,Opc.Ua.DataValue> nodeNameDataDic= myOpcUaHelper.GetBatchNodeDatasOfSync(nodeNameList);
                foreach (var item in nodeNameDataDic)
                {
                    Console.WriteLine($"【{item.Key}】的值是：{item.Value}");
                }


                
            }
           

        }

        /// <summary>
        /// 点位信息读取（异步方式）
        /// </summary>
        /// <param name="connState">连接状态</param>
        private async void ReadNodeInfoAsync(bool connState)
        {
            if (!connState)
            {
                Console.WriteLine($"当前没有连接到OPCUA服务器，请连接后重试！");
                return;
            }

            //单点位名称
            string nodeName1 = "ns=2;s=模拟器示例.函数.Ramp1";
            string nodeName2 = "ns=2;s=模拟器示例.函数.User1";

            //多点位名称列表
            List<Opc.Ua.NodeId> nodeNameList = new List<Opc.Ua.NodeId>()
            {
                "ns=2;s=模拟器示例.函数.Ramp2",
                "ns=2;s=模拟器示例.函数.Ramp3",
                "ns=2;s=模拟器示例.函数.Ramp6",
                "ns=2;s=模拟器示例.函数.Ramp8",
                "ns=2;s=模拟器示例.函数.Sine2",
                "ns=2;s=模拟器示例.函数.User1",
                "ns=2;s=模拟器示例.函数.User2",
                "ns=2;s=模拟器示例.函数.User3",
                "ns=2;s=模拟器示例.函数.User4"
            };


            //int readNum = 16;

            //while (readNum >= 0)
            //{
            //    Thread.Sleep(1000);
            //    readNum--;
            //    Console.WriteLine($"\n---异步读取【单点位】数据值---");
            //    //异步读取当前点位的值
            //    var nodeName1_Value = await myOpcUaHelper.GetCurrentNodeValueOfAsync<Int32>(nodeName1);
            //    Console.WriteLine($"【{nodeName1}】的值是：{nodeName1_Value}");

            //    var nodeName2_Value = await myOpcUaHelper.GetCurrentNodeValueOfAsync<string>(nodeName2);
            //    Console.WriteLine($"【{nodeName2}】的值是：{nodeName2_Value}");

            //    Console.WriteLine($"\n---异步读取【多点位】数据值---");
            //    Dictionary<string, Opc.Ua.DataValue> nodeNameDataDic = await myOpcUaHelper.GetBatchNodeDatasOfAsync(nodeNameList);
            //    foreach (var item in nodeNameDataDic)
            //    {
            //        Console.WriteLine($"【{item.Key}】的值是：{item.Value}");
            //    }

            //}

            //获取到当前节点的关联节点
            var relatedNodes = myOpcUaHelper.GetAllRelationNodeOfNodeId(nodeName1);
            foreach (var item in relatedNodes)
            {
                Console.WriteLine($"【{nodeName1}】的关联节点有：{item.NodeId}");
            }

            //获取到当前节点的所有属性
            var allAttribute = myOpcUaHelper.GetCurrentNodeAttributes(nodeName1);
            foreach (var item in allAttribute)
            {
                Console.WriteLine($"【{nodeName1}】的所有属性是：{item.Name}");
            }

            string needWriteNodeName1 = "ns=2;s=通道 1.设备 1.标记 1";
            string needWriteNodeName2 = "ns=2;s=通道 1.设备 1.标记 2";
            UInt16 needWriteValue = 999;
            //在给对应的点位写入信息前需确认该点位是否支持写（否则只读的节点会报错）
            bool result1 = myOpcUaHelper.WriteSingleNodeIdOfSync(needWriteNodeName1, needWriteValue);
            Console.WriteLine($"给【{needWriteNodeName1}】节点写入值【{needWriteValue}】的结果是【{result1}】");
            bool result2 = myOpcUaHelper.WriteSingleNodeIdOfSync(needWriteNodeName2, needWriteValue);
            Console.WriteLine($"给【{needWriteNodeName2}】节点写入值【{needWriteValue}】的结果是【{result2}】");

           
            string[] needWriteNodeArray = new string[] 
            {
                "ns=2;s=通道 1.设备 1.标记 1",
                "ns=2;s=通道 1.设备 1.标记 2"
            };

            object[] needWriteNodeValue = new object[] { (UInt16)666,(UInt16)777} ;
            //批量写入节点
            bool result = myOpcUaHelper.BatchWriteNodeIds(needWriteNodeArray,needWriteNodeValue);
            Console.WriteLine($"【{outPrintArray(needWriteNodeArray)}】批量写入值【{outPrintArray(needWriteNodeValue)}】结果是【{result}】");

            //异步写入单节点数据
            bool writeResult = await myOpcUaHelper.WriteSingleNodeIdOfAsync<UInt16>(needWriteNodeName1,333);
            Console.WriteLine($"给【{needWriteNodeName1}】节点写入值【{333}】的结果是【{writeResult}】");

            ////读取单节点的历史记录数据
            //DateTime startTime = new DateTime(2025,3,14,8,0,0);
            //DateTime endTime = new DateTime(2025,3,14,18,0,0);
            //List<Int32>historyDatas = myOpcUaHelper.ReadSingleNodeIdHistoryDatas<Int32>(needWriteNodeName1,startTime,endTime);
            //foreach (var item in historyDatas)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //单节点数据订阅
            string needSubNodeName = "模拟器示例函数User1节点的实时数据";
            AddInfoToConcurrentDic(ref collectDeviceDatas,needSubNodeName,"");
            myOpcUaHelper.SingleNodeIdDatasSubscription(needSubNodeName, nodeName2,SubscribeNodeData);

            //批量节点数据订阅
            string primaryKey = "模拟器示例函数";
            List<string> needSubDeviceAllNodeNameList = new List<string>()
            {
                "ns=2;s=模拟器示例.函数.Ramp1",
                "ns=2;s=模拟器示例.函数.Ramp2",
                "ns=2;s=模拟器示例.函数.Ramp3",
                "ns=2;s=模拟器示例.函数.Ramp4",
                "ns=2;s=模拟器示例.函数.Ramp5",
                "ns=2;s=模拟器示例.函数.Ramp6",
                "ns=2;s=模拟器示例.函数.Ramp7",
                "ns=2;s=模拟器示例.函数.Ramp8",
                "ns=2;s=模拟器示例.函数.Random1",
                "ns=2;s=模拟器示例.函数.Random2",
                "ns=2;s=模拟器示例.函数.Random3",
                "ns=2;s=模拟器示例.函数.Random4",
                "ns=2;s=模拟器示例.函数.Random5",
                "ns=2;s=模拟器示例.函数.Random6",
                "ns=2;s=模拟器示例.函数.Random7",
                "ns=2;s=模拟器示例.函数.Random8",
                "ns=2;s=模拟器示例.函数.Sine1",
                "ns=2;s=模拟器示例.函数.Sine2",
                "ns=2;s=模拟器示例.函数.Sine3",
                "ns=2;s=模拟器示例.函数.Sine4",
                "ns=2;s=模拟器示例.函数.User1",
                "ns=2;s=模拟器示例.函数.User2",
                "ns=2;s=模拟器示例.函数.User3",
                "ns=2;s=模拟器示例.函数.User4"
            };

            myOpcUaHelper.BatchNodeIdDatasSubscription(primaryKey,needSubDeviceAllNodeNameList.ToArray(), SubscirbeBathNodeDatas);

        }

        int tmpNum1 = 16;
        int tmpNum2 = 72;
        /// <summary>
        /// 订阅节点数据【单节点数据订阅】
        /// </summary>
        private void SubscribeNodeData(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            Opc.Ua.MonitoredItemNotification notification = args.NotificationValue as Opc.Ua.MonitoredItemNotification;
            if (key.Equals("模拟器示例函数User1节点的实时数据") && notification != null)
            {
                var value =  notification.Value.ToString();
                Console.WriteLine($"【{key}】的值是【{value}】");
                tmpNum1--;
            }

            if (tmpNum1 <= 0)
            {
                //取消节点的订阅事件
                bool cancleSub = myOpcUaHelper.CancelSingleNodeIdDatasSubscription(key);

                Console.WriteLine($"取消【{key}】节点的订阅结果：{cancleSub}");
            }
        }

        //批量节点数据订阅
        private void SubscirbeBathNodeDatas(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            Opc.Ua.MonitoredItemNotification notification = args.NotificationValue as Opc.Ua.MonitoredItemNotification;

            switch (key)
            {
                case "模拟器示例函数":

                    if (notification != null)
                    {
                        for (int i = 0; i < needSubDeviceAllNodeNameList.Count; i++)
                        {
                            if (needSubDeviceAllNodeNameList[i] == monitoredItem.StartNodeId)
                            {
                                Console.WriteLine($"【{key}】设备下的节点【{needSubDeviceAllNodeNameList[i]}】值是【{notification.Value}】");
                            }
                        }
                        tmpNum2--;
                    }

                    break;
                default:
                    break;
            }

            if (tmpNum2 <= 0)
            {
                //取消节点的订阅事件
                bool cancleSub = myOpcUaHelper.CancelSingleNodeIdDatasSubscription(key);

                Console.WriteLine($"取消【{key}】节点的订阅结果：{cancleSub}");
            }

        }


        private StringBuilder outPrintArray<T>(T[] array)
        {
            StringBuilder ret = new StringBuilder();
            foreach (var item in array)
            {
                ret.Append($"{item} ");
            }
            return ret;
        }

        private void AddInfoToConcurrentDic<T>(ref ConcurrentDictionary<string,T> concurrentDic, string key,T value)
        {
            if (!concurrentDic.ContainsKey(key))
            {
                concurrentDic.TryAdd(key,value);
            }
            else
            {
                concurrentDic[key] = value;
            }

        }

    }//Class_end
}
