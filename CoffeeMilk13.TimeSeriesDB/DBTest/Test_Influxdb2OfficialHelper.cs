/***
*	Title："WinFormClient" 项目
*		主题：测试【InfluxDB2.X官方提供的数据库操作类】
*	Description：
*		功能：XXX
*	Date：2025/3/24 10:52:38
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using CoffeeMilk13.TimeSeriesDB.DBHelper;
using CoffeeMilk13.TimeSeriesDB.Model;
using CoffeeMilk13.TimeSeriesDB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.TimeSeriesDB.DBTest
{
    public class Test_Influxdb2OfficialHelper
    {

        public static void Test()
        {

            //ConnInfluxDBWriteDatas();

            //ConnInfluxDBWriteDatas();

            //ConnInfluxDBReadDatas();

            ConnInfluxDBOPC();

        }

        /// <summary>
        /// 连接InfluxDB写入数据
        /// </summary>
        private static void ConnInfluxDBWriteDatas()
        {
            /*实例化InfluxDB客户端方式一*/
            ////InfluxdbOfficialHelper influxdbOfficialHelper = new InfluxdbOfficialHelper("http://192.168.3.208:8086", "_HRvTWIr840UEF__9w==");
            //InfluxdbOfficialHelper influxdbOfficialHelper = new InfluxdbOfficialHelper("http://192.168.3.208:8086", "3WSssP_h7-catrJ9CECUetIjesVLMkbkeZvByQJBkFrdGEK6gYdGXRDA5owq2jHSIe7G_HRvTWIr840UEF__9w==");
            //Console.WriteLine("----------------值类型【类】测试--------------------");
            //InfluxDBConPara influxDBConPara2 = influxdbOfficialHelper.GetInfluxDBConPara;
            //influxdbOfficialHelper.ToSting();
            //influxDBConPara2.Url = "修改URL";
            //influxDBConPara2.Token = "修改Token";
            //influxDBConPara2.User = "修改用户";
            //influxDBConPara2.Pwd = "修改密码";
            //influxDBConPara2.BucketName = "修改数据库";
            //influxDBConPara2.Org = "修改Org";
            //influxdbOfficialHelper.ToSting();

            /*实例化InfluxDB客户端方式二*/
            Influxdb2OfficialHelper influxdbOfficialHelper = new Influxdb2OfficialHelper("http://192.168.3.208:8086", "coffeemilk", "123456");


            /*写入数据测试*/

            ////1-写入行数据（通过Line协议）（单条）
            //long timeStamp = TimeHelper.GetNowTimeStamp_Unix();
            //Random random = new Random();
            //int tmp = random.Next(10, 99);
            //string lineData = $"MeterDevice,id=JLY23032{tmp} name=\"XXX计量仪器\",totalHeight=160,curHeight={tmp} {timeStamp}";
            //bool res = influxdbOfficialHelper.WriteDataOfLineProtocol("Demo", "ck", lineData);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{lineData}】结果是【{res}】");

            ////1-写入行数据（通过Line协议）（多条）
            //List<string> lineDataList = new List<string>();
            //lineDataList.Add($"MeterDevice,id=JLY23032{random.Next(10,99)} name=\"XXX计量仪器\",totalHeight=160,curHeight={random.Next(10, 99)} {TimeHelper.GetNowTimeStamp_Unix()}");
            //lineDataList.Add($"MeterDevice,id=JLY23032{random.Next(10, 99)} name=\"XXX计量仪器\",totalHeight=160,curHeight={random.Next(10, 99)} {TimeHelper.GetNowTimeStamp_Unix()}");
            //lineDataList.Add($"MeterDevice,id=JLY23032{random.Next(10, 99)} name=\"XXX计量仪器\",totalHeight=160,curHeight={random.Next(10, 99)} {TimeHelper.GetNowTimeStamp_Unix()}");
            //bool resList = influxdbOfficialHelper.WriteDatasOfLineProtocol("Demo","ck",lineDataList);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{PrintList(lineDataList)}】结果是【{resList}】");


            ////2 - 写入点数据（通过数据点）（单条）【注意：这里字段的数值使用(decimal、double、float)可以正常上传显示】
            //var point = InfluxDB.Client.Writes.PointData.Measurement("MeterDevice")
            //        .Tag("id", $"JLY23032{new Random().Next(10, 99)}")
            //        .Field("name", "XXX计量仪器")
            //        .Field("totalHeight", (double)160)
            //        .Field("curHeight", (double)(new Random().Next(10, 99)))
            //        .Timestamp(DateTime.UtcNow, InfluxDB.Client.Api.Domain.WritePrecision.Ms);

            //bool res = influxdbOfficialHelper.WriteDataOfPoint("Demo","ck",point);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{point.ToLineProtocol()}】结果是【{res}】");

            ////2-写入点数据（通过数据点）（多条）
            //List<InfluxDB.Client.Writes.PointData> pointList = new List<InfluxDB.Client.Writes.PointData>();
            //pointList.Add(GetPointData());
            //pointList.Add(GetPointData());
            //pointList.Add(GetPointData());

            //bool resList = influxdbOfficialHelper.WriteDatasOfPoint("Demo", "ck", pointList);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{PrintList(pointList)}】结果是【{resList}】");


            //3-写入数据（通过POCO和对应的类）（单条）
            MDevice mDevice = new MDevice()
            {
                Id = $"JLY23032{new Random(Guid.NewGuid().GetHashCode()).Next(10, 99)}",
                Name = "\"XXX计量仪器\"",
                TotalHeight=160,
                curHeight= new Random(Guid.NewGuid().GetHashCode()).Next(10, 99),
                Time=DateTime.Now
                
            };

            bool res = influxdbOfficialHelper.WriteDataOfPocoAndClass("Demo", "ck", mDevice);
            Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{mDevice.ToString()}】结果是【{res}】");

            //3-写入数据（通过POCO和对应的类）（多条）
            List<MDevice> entityList = new List<MDevice>();
            entityList.Add(GetEntityData());
            entityList.Add(GetEntityData());
            entityList.Add(GetEntityData());

            bool resList = influxdbOfficialHelper.WriteDatasOfPocoAndClass("Demo", "ck", entityList);
            Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{PrintList(entityList)}】结果是【{resList}】");
        }


        /// <summary>
        /// 连接InfluxDB写入数据2
        /// </summary>
        private static void ConnInfluxDBWriteDatas2()
        {
            /*实例化InfluxDB客户端方式一*/
            //InfluxdbOfficialHelper influxdbOfficialHelper = new InfluxdbOfficialHelper("http://192.168.3.208:8086", "_HRvTWIr840UEF__9w==");
            //InfluxdbOfficialHelper influxdbOfficialHelper = new InfluxdbOfficialHelper("http://192.168.3.208:8086", 
            //    "3WSssP_h7-catrJ9CECUetIjesVLMkbkeZvByQJBkFrdGEK6gYdGXRDA5owq2jHSIe7G_HRvTWIr840UEF__9w==","Demo","ck");

            /*实例化InfluxDB客户端方式二*/
            Influxdb2OfficialHelper influxdbOfficialHelper = new Influxdb2OfficialHelper("http://192.168.3.208:8086","coffeemilk", "123456", "Demo", "ck");



            /*写入数据测试*/

            ////1-写入行数据（单条）
            //long timeStamp = TimeHelper.GetNowTimeStamp_Unix();
            //Random random = new Random();
            //int tmp = random.Next(10, 99);
            //string lineData = $"MeterDevice,id=JLY23032{tmp} name=\"XXX计量仪器\",totalHeight=160,curHeight={tmp} {timeStamp}";
            //bool res = influxdbOfficialHelper.WriteDataOfLineProtocol(lineData);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{lineData}】结果是【{res}】");

            ////1-写入行数据（多条）
            //List<string> lineDataList = new List<string>();
            //lineDataList.Add($"MeterDevice,id=JLY23032{random.Next(10, 99)} name=\"XXX计量仪器\",totalHeight=160,curHeight={random.Next(10, 99)} {TimeHelper.GetNowTimeStamp_Unix()}");
            //lineDataList.Add($"MeterDevice,id=JLY23032{random.Next(10, 99)} name=\"XXX计量仪器\",totalHeight=160,curHeight={random.Next(10, 99)} {TimeHelper.GetNowTimeStamp_Unix()}");
            //lineDataList.Add($"MeterDevice,id=JLY23032{random.Next(10, 99)} name=\"XXX计量仪器\",totalHeight=160,curHeight={random.Next(10, 99)} {TimeHelper.GetNowTimeStamp_Unix()}");
            //bool resList = influxdbOfficialHelper.WriteDatasOfLineProtocol(lineDataList);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{PrintList(lineDataList)}】结果是【{resList}】");

            ////2 - 写入点数据（通过数据点）（单条）【注意：这里字段的数值使用(decimal、double、float)可以正常上传显示】
            //var point = InfluxDB.Client.Writes.PointData.Measurement("MeterDevice")
            //        .Tag("id", $"JLY23032{new Random().Next(10, 99)}")
            //        .Field("name", "XXX计量仪器")
            //        .Field("totalHeight", (double)160)
            //        .Field("curHeight", (double)(new Random().Next(10, 99)))
            //        .Timestamp(DateTime.UtcNow, InfluxDB.Client.Api.Domain.WritePrecision.Ms);

            //bool res = influxdbOfficialHelper.WriteDataOfPoint(point);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{point.ToLineProtocol()}】结果是【{res}】");

            ////2-写入点数据（通过数据点）（多条）
            //List<InfluxDB.Client.Writes.PointData> pointList = new List<InfluxDB.Client.Writes.PointData>();
            //pointList.Add(GetPointData());
            //pointList.Add(GetPointData());
            //pointList.Add(GetPointData());

            //bool resList = influxdbOfficialHelper.WriteDatasOfPoint(pointList);
            //Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{PrintList(pointList)}】结果是【{resList}】");

            //3-写入数据（通过POCO和对应的类）（单条）
            MDevice mDevice = new MDevice()
            {
                Id = $"JLY23032{new Random(Guid.NewGuid().GetHashCode()).Next(10, 99)}",
                Name = "\"XXX计量仪器\"",
                TotalHeight = 160,
                curHeight = new Random(Guid.NewGuid().GetHashCode()).Next(10, 99),
                Time = DateTime.Now

            };

            bool res = influxdbOfficialHelper.WriteDataOfPocoAndClass(mDevice);
            Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{mDevice.ToString()}】结果是【{res}】");

            //3-写入数据（通过POCO和对应的类）（多条）
            List<MDevice> entityList = new List<MDevice>();
            entityList.Add(GetEntityData());
            entityList.Add(GetEntityData());
            entityList.Add(GetEntityData());

            bool resList = influxdbOfficialHelper.WriteDatasOfPocoAndClass(entityList);
            Console.WriteLine($"\n当前写入【{influxdbOfficialHelper.GetInfluxDBConPara.Url}】的数据【{PrintList(entityList)}】结果是【{resList}】");

        }


        /// <summary>
        /// 连接InfluxDB读取数据
        /// </summary>
        private async static void ConnInfluxDBReadDatas()
        {
            /*实例化InfluxDB客户端方式一*/
            //InfluxdbOfficialHelper influxdbOfficialHelper = new InfluxdbOfficialHelper("http://192.168.3.208:8086", "_HRvTWIr840UEF__9w==");
            //InfluxdbOfficialHelper influxdbOfficialHelper = new InfluxdbOfficialHelper("http://192.168.3.208:8086", 
            //    "3WSssP_h7-catrJ9CECUetIjesVLMkbkeZvByQJBkFrdGEK6gYdGXRDA5owq2jHSIe7G_HRvTWIr840UEF__9w==","Demo","ck");

            /*实例化InfluxDB客户端方式二*/
            Influxdb2OfficialHelper influxdbOfficialHelper = new Influxdb2OfficialHelper("http://192.168.3.208:8086", "coffeemilk", "123456", "Demo", "ck");

            //string sql = $"from(bucket: \"Demo\")" +
            //    $"|> range(start: -1h)" +
            //    $"|> filter(fn: (r) => r._measurement == \"MeterDevice\")" +
            //    $"|> filter(fn: (r) => r._field == \"co\" or r._field == \"totalHeight\" or r._field == \"curHeight\")";

            string sql = $"from(bucket: \"Demo\")" +
                            $"|> range(start: -1m)" +
                            $"|> filter(fn: (r) => r._measurement == \"MeterDevice\")" +
                            $"|> filter(fn: (r) => r._field==\"name\" or r._field == \"curHeight\" or r._field == \"totalHeight\")";

            //读取数据（通过自建实体）
            List<MDevice2> resList2 = await influxdbOfficialHelper.GetDatas<MDevice2>(sql);
            resList2.ForEach(item =>
            {
                Console.WriteLine($"\n[{item.ToString()}]");

            });

            //读取数据（通过FluxTable）
            List<InfluxDB.Client.Core.Flux.Domain.FluxTable> resList = await influxdbOfficialHelper.GetDatas(sql);
            if (resList.Count > 0)
            {
                string tmpStr = null;
                resList.ForEach((rowObj) =>
                {
                    var row = rowObj.Records;

                    row.ForEach(item =>
                    {
                        tmpStr = new StringBuilder()
                            .Append($"\n开始时间[{item.GetStart()}] ")
                            .Append($"结束时间[{item.GetStop()}] ")
                            .Append($"插入时间[{item.GetTime()}] ")
                            .Append($"字段[{item.GetField()}] ")
                            .Append($"值[{item.GetValue()}] ")
                            .ToString();

                        Console.WriteLine(tmpStr);

                    });


                });
            }

            //读取数据（原生数据）
            string strRaw = await influxdbOfficialHelper.GetDataString(sql);
            Console.WriteLine($"\n执行【\n{sql}\n】获取到的字符串内容是【\n\n{strRaw}\n】");

        }

        //链接InfluxDB操作
        private async static void ConnInfluxDBOPC()
        {
            Influxdb2OfficialHelper influxdb2OfficialHelper = new Influxdb2OfficialHelper("http://192.168.3.208:8086", "coffeemilk", "123456", "Demo", "ck");

            //获取组织
            var orgObj = await influxdb2OfficialHelper.GetOrg("ck");
            Console.WriteLine($"\n当前【{influxdb2OfficialHelper.GetInfluxDBConPara.Url}】的组织【ck】对应的组织ID是【{orgObj?.Id}】");

            //获取组织包含的所有Bucket
            var bucketList = await influxdb2OfficialHelper.GetAllBucketOfOrg("ck");
            Console.WriteLine($"\n组织【ck】包含的所有Bucket是：【{PrintList(bucketList)}】");

            //创建组织
            string tmpOrgName = "cx11";
            var org = await influxdb2OfficialHelper.CreateOrg(tmpOrgName);
            if (org!=null)
            {
                Console.WriteLine($"\n当前创建的组织【{tmpOrgName}】成功！！！");
            }

            //创建Bucket
            string bucketName = $"DB2Test{new Random(Guid.NewGuid().GetHashCode()).Next(0,9)}";
            string orgName = "cx1";
            InfluxDB.Client.Api.Domain.Bucket bucket = await influxdb2OfficialHelper.CreateBucket(bucketName,orgName);
            if (bucket != null)
            {
                Console.WriteLine($"\n当前创建bucket=【{bucketName}】,隶属于【{orgName}】组织 成功!!!");
            }
            else
            {
                Console.WriteLine($"\n当前创建bucket=【{bucketName}】,隶属于【{orgName}】组织 失败了-----");
            }

            //设置权限
            bool enableRead = true;
            bool enableWrite = true;
            var authorization = await influxdb2OfficialHelper.SetPermissionOfBucket(bucketName,orgName,enableRead,enableWrite);
            if (authorization!=null)
            {
                Console.WriteLine($"\n给bucket=【{bucketName}】及其对应的组织org=【{orgName}】设置读权限【{enableRead}】写权限【{enableWrite}】" +
                    $"后对应的Token是【{authorization.Token}】");
            }



        }


        #region   私有方法
        private static string PrintList(List<string> list)
        {
            if (list.Count<=0)
            {
                return null;
            }

            string str = null;

            //foreach (var item in list)
            //{
            //    str +=item+ "\n";
            //}

            list.ForEach((string item) => { str += "\n" + item;});

            return str;
        }

        /// <summary>
        /// 获取单点数据
        /// </summary>
        /// <returns></returns>
        private static InfluxDB.Client.Writes.PointData GetPointData()
        {
            //【注意：这里字段的数值使用(decimal、double、float)可以正常上传显示】
            var point = InfluxDB.Client.Writes.PointData.Measurement("MeterDevice")
                .Tag("id", $"JLY23032{new Random(Guid.NewGuid().GetHashCode()).Next(10, 99)}")
                .Field("name", "XXX计量仪器")
                .Field("totalHeight", (double)160)
                .Field("curHeight", (double)(new Random(Guid.NewGuid().GetHashCode()).Next(10, 99)))
                .Timestamp(DateTime.UtcNow, InfluxDB.Client.Api.Domain.WritePrecision.Ms);

            return point;
        }

        private static string PrintList(List<InfluxDB.Client.Writes.PointData> list)
        {
            if (list.Count <= 0)
            {
                return null;
            }

            string str = null;

            //foreach (var item in list)
            //{
            //    str += item + "\n";
            //}

            list.ForEach((pointData) => { str += "\n" + pointData.ToLineProtocol(); });

            return str;
        }

        /// <summary>
        /// 获取需写入的数据
        /// </summary>
        /// <returns></returns>
        private static MDevice GetEntityData()
        {
            MDevice mDevice = new MDevice()
            {
                Id = $"JLY23032{new Random(Guid.NewGuid().GetHashCode()).Next(10, 99)}",
                Name = "XXX计量仪器",
                TotalHeight = 160,
                curHeight = new Random(Guid.NewGuid().GetHashCode()).Next(10, 99),
                Time = DateTime.Now

            };

            return mDevice;
        }

        private static string PrintList(List<MDevice> list)
        {
            if (list.Count <= 0)
            {
                return null;
            }

            string str = null;

            //foreach (var item in list)
            //{
            //    str += item + "\n";
            //}

            list.ForEach((item) => { str += "\n" + item.ToString(); });

            return str;
        }
        //写入InfluxDB数据模型
        [InfluxDB.Client.Core.Measurement("MeterDevice")]
        private class MDevice
        {
            [InfluxDB.Client.Core.Column("id", IsTag = true)] public string Id { get; set; }

            [InfluxDB.Client.Core.Column("name")] public string Name { get; set; }

            [InfluxDB.Client.Core.Column("totalHeight")] public double TotalHeight { get; set; }

            [InfluxDB.Client.Core.Column("curHeight")] public double curHeight { get; set; }

            [InfluxDB.Client.Core.Column(IsTimestamp = true)] public DateTime Time { get; set; }

            public override string ToString()
            {
                //string str = $"MeterDevice,id={Id} name={Name},totalHeight={TotalHeight},curHeight={curHeight} {Time}";
                string str2 = new StringBuilder(GetType().Name)
                    .Append($"id={Id}")
                    .Append($"name={Name}")
                    .Append($"totalHeight={TotalHeight}")
                    .Append($"curHeight={curHeight}")
                    .Append($"Time={Time}").ToString();
                return str2;
            }
        }


        //读取InfluxDB数据模型
        [InfluxDB.Client.Core.Measurement("MeterDevice")]
        private class MDevice2
        {
            //唯一键Tag
            [InfluxDB.Client.Core.Column("id", IsTag = true)] public string Id { get; set; }

            //这里获取到所有的字段名称
            [InfluxDB.Client.Core.Column("_field")] public string FieldDesc { get; set; }

            //这里获取到字段名称对应的值
            [InfluxDB.Client.Core.Column("_value")] public string Value { get; set; }

            [InfluxDB.Client.Core.Column("start",IsTimestamp = true)] public DateTime StartTime { get; set; }
            [InfluxDB.Client.Core.Column("stop",IsTimestamp = true)] public DateTime StopTime { get; set; }
            [InfluxDB.Client.Core.Column("time",IsTimestamp = true)] public DateTime Time { get; set; }

            public override string ToString()
            {
                string str2 = new StringBuilder(GetType().Name)
                    .Append($" id={Id} ")
                    .Append($"name={FieldDesc} ")
                    .Append($"Value={Value} ")
                    .Append($"StartTime={StartTime} ")
                    .Append($"StopTime={StopTime} ")
                    .Append($"Time={Time} ").ToString();
                return str2;
            }
        }

        private static string PrintList(List<InfluxDB.Client.Api.Domain.Bucket> bucketList)
        {
            if (bucketList.Count<=0)
            {
                return null;
            }
            string str = null;
            bucketList.ForEach(bucktet => { str +="\n"+ bucktet.Name; });
            return str;
        }

        #endregion 

    }//Class_end
}
