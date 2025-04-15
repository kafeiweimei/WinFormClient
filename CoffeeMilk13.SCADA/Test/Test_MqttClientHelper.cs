/***
*	Title："WinFormClient" 项目
*		主题：测试MQTT客户端帮助类
*	Description：
*		功能：XXX
*	Date：2025/4/16 0:01:26
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using CoffeeMilk13.SCADA.MQTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMilk13.SCADA.Test
{
    internal class Test_MqttClientHelper
    {
        public static async void Test()
        {
            MqttClientInfo mqttClientInfo = new MqttClientInfo();
            mqttClientInfo.BrokerIP = "192.168.3.37";
            mqttClientInfo.BrokerPort = 1883;
            mqttClientInfo.ClientId = $"测试_2504151259";
            mqttClientInfo.UserName = "test";
            mqttClientInfo.Password = "123456";

            MqttClientHelper mqttHelper = new MqttClientHelper(mqttClientInfo);

            //连接MQTTBroker
            await mqttHelper.ConnectBroker();


            string topic = "AppTest";

            Task task = new Task(async () =>
            {
                //发布10次消息
                for (int i = 0; i < 16; i++)
                {
                    Thread.Sleep(2000);
                    string value = new Random(Guid.NewGuid().GetHashCode()).Next(0, 99).ToString();
                    Console.WriteLine($"开始第【{i}】次发布主题是【{topic}】值为【{value}】的消息");
                    var res = await mqttHelper.PublishTopicMsg(topic, value);
                    Console.WriteLine($"第【{i}】次发布主题是【{topic}】值为【{value}】的结果是【{res.IsSuccess}】\n");
                }

            });

            task.Start();



            //订阅消息
            Task task2 = new Task(async () =>
            {
                var subscribeRes = await mqttHelper.SubscribeTopicMsg(topic);
            });
            task2.Start();


        }

        public static async void TestSSL()
        {
            MqttClientInfo mqttClientInfo = new MqttClientInfo();
            mqttClientInfo.BrokerIP = "192.168.3.37";
            mqttClientInfo.BrokerPort = 8883;
            mqttClientInfo.ClientId = $"test_25041651";
            mqttClientInfo.UserName = "test";
            mqttClientInfo.Password = "123456";
            string cert = $"{AppDomain.CurrentDomain.BaseDirectory}MQTT\\cert\\broker.pfx";

            MqttClientHelper mqttHelper = new MqttClientHelper(mqttClientInfo, cert, "123456");

            //连接MQTTBroker
            await mqttHelper.ConnectBroker();


            string topic = "AppTest";

            Task task = new Task(async () =>
            {
                //发布10次消息
                for (int i = 0; i < 16; i++)
                {
                    Thread.Sleep(2000);
                    string value = new Random(Guid.NewGuid().GetHashCode()).Next(0, 99).ToString();
                    Console.WriteLine($"开始第【{i}】次发布主题是【{topic}】值为【{value}】的消息");
                    var res = await mqttHelper.PublishTopicMsg(topic, value);
                    Console.WriteLine($"第【{i}】次发布主题是【{topic}】值为【{value}】的结果是【{res.IsSuccess}】\n");
                }

            });

            task.Start();



            //订阅消息
            Task task2 = new Task(async () =>
            {
                var subscribeRes = await mqttHelper.SubscribeTopicMsg(topic);
            });
            task2.Start();


        }



    }//Class_end
}
