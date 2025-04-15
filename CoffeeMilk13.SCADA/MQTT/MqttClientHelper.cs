/***
*	Title："WinFormClient" 项目
*		主题：MQTT客户端帮助类(使用EMQX作为MQTT Broker)
*	Description：
*		功能：详细链接请查看【https://blog.csdn.net/xiaochenXIHUA/article/details/147235635】
*		    1、连接MQTT的Broker
*		    2、断开与MQTT的Broker连接
*		    3、订阅主题消息
*		    4、取消订阅的主题消息
*		    5、发布主题消息
*	Date：2025/4/15 
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.SCADA.MQTT
{
    internal class MqttClientHelper
    {
        #region   基础参数
        private MqttClientInfo mqttClientInfo;
        private IMqttClient mqttClient;
        private MqttClientOptions options;

        //连接结果
        private MqttClientConnectResult connResult = new MqttClientConnectResult();

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mqttClientInfo">MQTT的客户端参数信息</param>
        public MqttClientHelper(MqttClientInfo mqttClientInfo)
        {
            this.mqttClientInfo = mqttClientInfo;

            var mqttClientFactory = new MqttFactory();
            mqttClient = mqttClientFactory.CreateMqttClient();

            options = new MqttClientOptionsBuilder()
            .WithTcpServer(mqttClientInfo.BrokerIP, mqttClientInfo.BrokerPort)
            .WithCredentials(mqttClientInfo.UserName, mqttClientInfo.Password)
            .WithClientId(mqttClientInfo.ClientId)
            .WithCleanSession()
            .Build();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mqttClientInfo">MQTT的客户端参数信息</param>
        /// <param name="certFilePathAndName">证书文件路径和名称（如：D:\broker.emqx.io-ca.pfx）</param>
        /// <param name="certPassword">证书密码</param>
        public MqttClientHelper(MqttClientInfo mqttClientInfo, string certFilePathAndName, string certPassword)
        {
            this.mqttClientInfo = mqttClientInfo;

            var mqttClientFactory = new MqttFactory();
            mqttClient = mqttClientFactory.CreateMqttClient();

            options = new MqttClientOptionsBuilder()
            .WithTcpServer(mqttClientInfo.BrokerIP, mqttClientInfo.BrokerPort)
            .WithCredentials(mqttClientInfo.UserName, mqttClientInfo.Password)
            .WithClientId(mqttClientInfo.ClientId)
            .WithCleanSession()
            .WithTlsOptions(
                o =>
                {
                    var certificate = new X509Certificate2(certFilePathAndName, certPassword, X509KeyStorageFlags.Exportable);

            //启用TLS加密
            o.UseTls(true);
            //允许未安装的证书
            o.WithAllowUntrustedCertificates(true);
            //忽略证书链（自签名证书没有证书链）
            o.WithIgnoreCertificateChainErrors(true);
            //忽略主机名
            o.WithCertificateValidationHandler(x => true);
                    o.WithSslProtocols(SslProtocols.Tls12);
                    o.WithClientCertificates(new List<X509Certificate2>
                    {
                //new X509Certificate2(certificate.Export(X509ContentType.Pfx))
                new X509Certificate2(certFilePathAndName,certPassword)
                    });

                    o.Build();
                }
            )
            .Build();
        }

        /// <summary>
        /// 连接MQTT的Broker
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<MqttClientConnectResult> ConnectBroker()
        {
            try
            {
                connResult = await mqttClient.ConnectAsync(options);
                return connResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 断开与MQTT的Broker连接
        /// </summary>
        /// <returns>断开结果（true：表示断开连接成功）</returns>
        public async Task<bool> DisConnectBroker()
        {
            bool res = false;
            if (connResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                res = await mqttClient.TryDisconnectAsync();
            }
            else
            {
                Console.WriteLine("当前未连接，不用断开！");
            }

            return res;
        }

        /// <summary>
        /// 订阅主题消息
        /// </summary>
        /// <param name="topicName">主题名称</param>
        /// <param name="mqttQuality">发布者与订阅者消息传递的保证级别
        /// （QoS 0 AtMostOnce– 最多交付一次【 可能丢失消息】）
        /// （QoS 1 AtLeastOnce– 至少交付一次【可以保证收到消息，但消息可能重复】）
        /// （QoS 2 –ExactlyOnce 只交付一次【可以保证消息既不丢失也不重复】）
        /// </param>
        /// <returns>返回该主题对应的消息</returns>
        public async Task<string> SubscribeTopicMsg(string topicName,
            MqttQualityOfServiceLevel mqttQuality = MqttQualityOfServiceLevel.AtMostOnce)
        {
            if (string.IsNullOrEmpty(topicName)) return null;

            string recMsg = null;
            if (connResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                Console.WriteLine($"客户端【{mqttClientInfo.ClientId}】连接【{mqttClientInfo.BrokerIP}】【{mqttClientInfo.BrokerPort}】MQTTBroker 成功");

                await mqttClient.SubscribeAsync(topicName, mqttQuality);

                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    var tmpMsg = e.ApplicationMessage.Payload;
                    recMsg = Encoding.UTF8.GetString(tmpMsg);
                    Console.WriteLine($"获取到订阅的主题【{topicName}】消息是: {recMsg}\n");
                    return Task.CompletedTask;
                };
            }
            else
            {
                Console.WriteLine("当前未连接，请连接后重试！");
                //recMsg = "当前未连接，请连接后重试！";
            }

            return recMsg;
        }

        /// <summary>
        /// 取消订阅的主题消息
        /// </summary>
        /// <param name="topicName">主题名称</param>
        /// <returns>返回取消的结果</returns>
        public async Task<MqttClientUnsubscribeResult> CancleSubscibeTopMsg(string topicName)
        {
            if (string.IsNullOrEmpty(topicName)) { return null; }

            MqttClientUnsubscribeResult res = null;
            if (connResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                res = await mqttClient.UnsubscribeAsync(topicName);
            }
            else
            {
                Console.WriteLine("当前未连接，请连接后重试！");
            }

            return res;
        }

        /// <summary>
        /// 发布主题消息
        /// </summary>
        /// <param name="topicName">主题</param>
        /// <param name="publisMsg">需发布的消息</param>
        /// <param name="isRetain">是否保留发布的消息（true：表示保留）</param>
        /// <param name="mqttQuality">发布者与订阅者消息传递的保证级别
        /// （QoS 0 AtMostOnce– 最多交付一次【 可能丢失消息】）
        /// （QoS 1 AtLeastOnce– 至少交付一次【可以保证收到消息，但消息可能重复】）
        /// （QoS 2 –ExactlyOnce 只交付一次【可以保证消息既不丢失也不重复】）
        /// </param>
        /// <returns>返回主题发布的结果</returns>
        public async Task<MqttClientPublishResult> PublishTopicMsg(string topicName, string publisMsg, bool isRetain = false,
            MqttQualityOfServiceLevel mqttQuality = MqttQualityOfServiceLevel.AtLeastOnce)
        {
            if (string.IsNullOrEmpty(topicName) || string.IsNullOrEmpty(publisMsg))
            {
                return null;
            }

            MqttClientPublishResult res = null;
            if (connResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                var tmpmsg = new MqttApplicationMessageBuilder()
               .WithTopic(topicName)
               .WithPayload(publisMsg)
               .WithQualityOfServiceLevel(mqttQuality)
               .WithRetainFlag(isRetain)
               .Build();

                res = await mqttClient.PublishAsync(tmpmsg);
            }
            else
            {
                Console.WriteLine("当前未连接，请连接后重试！");
            }

            return res;
        }

    }//Class_end

    //MQTT的Broker信息
    internal struct MqttClientInfo
    {

        public string BrokerIP { get; set; }
        public int BrokerPort { get; set; }
        /// <summary>
        /// 客户端的名称必须唯一
        /// </summary>
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
