/***
*	Title："WinFormClient" 项目
*		主题：InfluxDB 2.X官方提供的数据库操作类
*	Description：
*		功能：InfluxDB 2.X中文官网【https://influxdb.org.cn/】提供的C#操作官方链接【https://github.com/influxdata/influxdb-client-csharp】
*		    
*		    <1>对外提供属性
*		        1、获取InfluxDB数据库的连接参数
*		        2、获取InfluxDB的客户端实例
*		        3、InfluxDB的网络状态(true：表示网络畅通)
*		        4、获取InfluxDB的授权状态(true:表示已经授权，可以进行数据的读写操作)
*		    
*		    <2>写数据(单条）（多条)
*		        1、检查网络连接与授权
*		        2、写数据（通过Line协议）
*		        3、写数据（通过数据点）
*		        4、写数据（通过POCO和对应的类）
*		    
*		    <3>读取数据
*		        1、读取数据（通过自建实体）
*		        2、读取数据（通过FluxTable）
*		        3、读取数据（原生数据）
*		    
*		    <4>管理InfluxDB
*		        1、获取指定组织
*		        2、获取组织包含的所有Bucket
*		        3、获取Bucket
*		        4、创建组织
*		        5、创建InfluxDB的Bucket
*		        6、给Bucket设置读写权限
*	Date：2025/3/24 9:41:56
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using CoffeeMilk13.TimeSeriesDB.Model;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.TimeSeriesDB.DBHelper
{
    public class Influxdb2OfficialHelper
    {
        #region   基础参数
        private InfluxDBClient influxDBClient;
        private InfluxDBConPara influxDBConPara;


        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">InfluxDB的URL(如：http://192.168.3.208:8086)</param>
        /// <param name="token">InfluxDB需连接的Bucket对应的Token</param>
        public Influxdb2OfficialHelper(string url,string token)
        {
            this.influxDBClient = new InfluxDBClient(url,token);

            influxDBConPara = new InfluxDBConPara();
            influxDBConPara.Url = url;
            influxDBConPara.Token = token;

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">InfluxDB的URL(如：http://192.168.3.208:8086)</param>
        /// <param name="token">InfluxDB需连接的Bucket对应的Token</param>
        /// <param name="bucketName">需连接的Bucket名称</param>
        /// <param name="org">组织名称</param>
        public Influxdb2OfficialHelper(string url, string token,string bucketName,string org)
        {
            this.influxDBClient = new InfluxDBClient(url, token);

            influxDBConPara = new InfluxDBConPara();
            influxDBConPara.Url = url;
            influxDBConPara.Token = token;
            influxDBConPara.BucketName = bucketName;
            influxDBConPara.Org = org;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">InfluxDB的URL(如：http://192.168.3.208:8086)</param>
        /// <param name="usrName">InfluxDB的登录用户名称</param>
        /// <param name="password">InfluxDB的登录用户密码</param>
        public Influxdb2OfficialHelper(string url, string usrName, string password)
        {
            this.influxDBClient = new InfluxDBClient(url, usrName, password);

            influxDBConPara = new InfluxDBConPara();
            influxDBConPara.Url = url;
            influxDBConPara.User = usrName;
            influxDBConPara.Pwd = password;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">InfluxDB的URL(如：http://192.168.3.208:8086)</param>
        /// <param name="usrName">InfluxDB的登录用户名称</param>
        /// <param name="password">InfluxDB的登录用户密码</param>
        /// <param name="bucketName">需连接的Bucket名称</param>
        /// <param name="org">组织名称</param>
        public Influxdb2OfficialHelper(string url,string usrName, string password, string bucketName, string org)
        {
            this.influxDBClient = new InfluxDBClient(url,usrName, password);

            influxDBConPara = new InfluxDBConPara();
            influxDBConPara.Url = url;
            influxDBConPara.User = usrName;
            influxDBConPara.Pwd = password;
            influxDBConPara.BucketName = bucketName;
            influxDBConPara.Org = org;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">InfluxDB的URL(如：http://192.168.3.208:8086)</param>
        /// <param name="usrName">InfluxDB的登录用户名称</param>
        /// <param name="password">InfluxDB的登录用户密码</param>
        /// <param name="retentionPolicy">保留策略</param>
        /// <param name="bucketName">需连接的Bucket名称</param>
        /// <param name="org">组织名称</param>
        public Influxdb2OfficialHelper(string url, string usrName, string password,string retentionPolicy, string bucketName,string org)
        {
            this.influxDBClient = new InfluxDBClient(url, usrName, password,bucketName,retentionPolicy);

            influxDBConPara = new InfluxDBConPara();
            influxDBConPara.Url = url;
            influxDBConPara.User = usrName;
            influxDBConPara.Pwd = password;
            influxDBConPara.BucketName = bucketName;
            influxDBConPara.Org = org;
        }

        #endregion


        #region   对外提供的属性
        /// <summary>
        /// 获取InfluxDB数据库的连接参数
        /// </summary>
        public InfluxDBConPara GetInfluxDBConPara 
        { 
            get 
            {
                return influxDBConPara;
            } 
        }

        /// <summary>
        /// 获取InfluxDB的客户端实例
        /// </summary>
        public InfluxDBClient GetInfluxDBClient
        {
            get
            {
                return influxDBClient;
            }
        }

        /// <summary>
        /// InfluxDB的网络状态(true：表示网络畅通)
        /// </summary>
        public bool GetNetworkConnectStatus
        {
            get
            {
                var conRes = influxDBClient.PingAsync().GetAwaiter();
                return conRes.GetResult();
            }
        }

        /// <summary>
        /// 获取InfluxDB的授权状态(true:表示已经授权，可以进行数据的读写操作)
        /// </summary>
        public bool GetAuthorizeStatus
        {
            get
            {
                try
                {
                    var auth = influxDBClient.GetAuthorizationsApi().FindAuthorizationsAsync().GetAwaiter();
                    if (auth.GetResult().Count>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                    throw new Exception(ex.Message);
                }
               
            }
        }

        #endregion


        #region   写入数据（单条）

        /// <summary>
        /// 检查网络连接与授权
        /// </summary>
        /// <returns>true:表示网络连通且授权通过</returns>
        public bool CheckNetworkAndAuth()
        {
            bool result = false;

            //1-查看网络连接是否正常
            var res = GetNetworkConnectStatus;
            if (!res)
            {
                return result;
                throw new Exception("无法连接influxDB数据库，请检查网络！");
            }

            //2-查看授权
            var auth = GetAuthorizeStatus;
            if (!auth)
            {
                return result;
                throw new Exception("无法获取授权，请检查Token或用户是否有权限");
            }

            result = true;
            return result;
        }

        /// <summary>
        /// 写数据（通过Line协议）
        /// </summary>
        /// <param name="bucketName">Bucket名称</param>
        /// <param name="org">组织名称</param>
        /// <param name="data">
        /// 需写入的数据
        /// 详细介绍链接【https://docs.influxdata.com/influxdb/cloud/reference/syntax/line-protocol/】
        /// 语法：<measurement>(类似关系数据库的表名称[必选])[,<tag_key>=<tag_value>[,<tag_key>=<tag_value>]](类似关系数据库的唯一标识[可选]) <field_key>=<field_value>[,<field_key>=<field_value>]（类似关系数据库的字段和内容[必选]） [<timestamp>]（时间戳，可选）
        /// 示例：MeterDevice,id=JLY2303261 totalHeight=150,curHeight=96 1742873091
        /// 注意：测量名称、标签键和字段键不能以下划线开头
        /// </param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDataOfLineProtocol(string bucketName,string org,string data)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }
            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteRecord(data, WritePrecision.Ms, bucketName, org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过Line协议;需在构造时传入BucketName与Org）
        /// </summary>
        /// <param name="data">需写入的行数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDataOfLineProtocol(string data)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(influxDBConPara.BucketName)||string.IsNullOrEmpty(influxDBConPara.Org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }
            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteRecord(data, WritePrecision.Ms, influxDBConPara.BucketName, influxDBConPara.Org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过数据点）
        /// </summary>
        /// <param name="bucketName">Bucket名称</param>
        /// <param name="org">组织名称</param>
        /// <param name="data">需写入的点数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDataOfPoint(string bucketName, string org, InfluxDB.Client.Writes.PointData data)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WritePoint(data, bucketName, org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过数据点）（需在构造时传入BucketName与Org）
        /// </summary>
        /// <param name="data">需写入的点数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDataOfPoint(InfluxDB.Client.Writes.PointData data)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(influxDBConPara.BucketName) || string.IsNullOrEmpty(influxDBConPara.Org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WritePoint(data, influxDBConPara.BucketName, influxDBConPara.Org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过POCO和对应的类）
        /// </summary>
        /// <typeparam name="T">需写入的数据类型</typeparam>
        /// <param name="bucketName">Bucket名称</param>
        /// <param name="org">组织名称</param>
        /// <param name="data">需写入的数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDataOfPocoAndClass<T>(string bucketName, string org,T data)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteMeasurement(data, WritePrecision.Ms, bucketName, org);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 写数据（通过POCO和对应的类;需在构造时传入BucketName与Org）
        /// </summary>
        /// <typeparam name="T">需写入的数据类型</typeparam>
        /// <param name="data">需写入的数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDataOfPocoAndClass<T>(T data)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(influxDBConPara.BucketName) || string.IsNullOrEmpty(influxDBConPara.Org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }
            
            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteMeasurement(data, WritePrecision.Ms, influxDBConPara.BucketName, influxDBConPara.Org);
                result = true;
            }
            return result;
        }

        #endregion


        #region   写入数据（多条）
        /// <summary>
        /// 写数据（通过Line协议）
        /// </summary>
        /// <param name="bucketName">Bucket名称</param>
        /// <param name="org">组织名称</param>
        /// <param name="dataList">
        /// 需写入的数据列表
        /// 详细介绍链接【https://docs.influxdata.com/influxdb/cloud/reference/syntax/line-protocol/】
        /// 语法：<measurement>(类似关系数据库的表名称[必选])[,<tag_key>=<tag_value>[,<tag_key>=<tag_value>]](类似关系数据库的唯一标识[可选]) <field_key>=<field_value>[,<field_key>=<field_value>]（类似关系数据库的字段和内容[必选]） [<timestamp>]（时间戳，可选）
        /// 示例：MeterDevice,id=JLY2303261 totalHeight=150,curHeight=96 1742873091
        /// 注意：测量名称、标签键和字段键不能以下划线开头
        /// </param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDatasOfLineProtocol(string bucketName, string org, List<string> dataList)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteRecords(dataList, WritePrecision.Ms, bucketName, org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过Line协议;需在构造时传入BucketName与Org）
        /// </summary>
        /// <param name="dataList">需写入的行数据列表</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDatasOfLineProtocol(List<string> dataList)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(influxDBConPara.BucketName) || string.IsNullOrEmpty(influxDBConPara.Org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteRecords(dataList, WritePrecision.Ms, influxDBConPara.BucketName, influxDBConPara.Org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过数据点）
        /// </summary>
        /// <param name="bucketName">Bucket名称</param>
        /// <param name="org">组织名称</param>
        /// <param name="dataList">需写入的点数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDatasOfPoint(string bucketName, string org, List<InfluxDB.Client.Writes.PointData> dataList)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WritePoints(dataList, bucketName, org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过数据点）（需在构造时传入BucketName与Org）
        /// </summary>
        /// <param name="dataList">需写入的点数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDatasOfPoint(List<InfluxDB.Client.Writes.PointData> dataList)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(influxDBConPara.BucketName) || string.IsNullOrEmpty(influxDBConPara.Org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WritePoints(dataList, influxDBConPara.BucketName, influxDBConPara.Org);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 写数据（通过POCO和对应的类）
        /// </summary>
        /// <typeparam name="T">需写入的数据类型</typeparam>
        /// <param name="bucketName">Bucket名称</param>
        /// <param name="org">组织名称</param>
        /// <param name="dataList">需写入的数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDatasOfPocoAndClass<T>(string bucketName, string org, List<T> dataList)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteMeasurements(dataList, WritePrecision.Ms, bucketName, org);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 写数据（通过POCO和对应的类;需在构造时传入BucketName与Org）
        /// </summary>
        /// <typeparam name="T">需写入的数据类型</typeparam>
        /// <param name="dataList">需写入的数据</param>
        /// <returns>true:表示写入数据成功</returns>
        public bool WriteDatasOfPocoAndClass<T>(List<T> dataList)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return result;
            }

            if (string.IsNullOrEmpty(influxDBConPara.BucketName) || string.IsNullOrEmpty(influxDBConPara.Org))
            {
                result = false;
                Console.WriteLine("当前的Bucket或组织名称为空，不能写入数据，请检查后重试！！！");
                return result;
            }

            using (var writeApi = influxDBClient.GetWriteApi())
            {
                writeApi.WriteMeasurements(dataList, WritePrecision.Ms, influxDBConPara.BucketName, influxDBConPara.Org);
                result = true;
            }
            return result;
        }

        #endregion 


        #region   读取数据

        /// <summary>
        /// 读取数据（通过自建实体）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="fluxSql">fluxSql语句
        /// 【FluxSql语句官方英文链接：https://docs.influxdata.com/flux/v0/ 】
        /// 【FluxSql语句官方中文链接：https://docs.influxdb.org.cn/flux/v0/ 】
        /// </param>
        /// <returns>返回实体列表</returns>
        public async Task<List<T>> GetDatas<T>(string fluxSql)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }
            if (string.IsNullOrEmpty(influxDBConPara.Org))
            {
                Console.WriteLine("当前的组织名称为空，不能写入数据，请检查后重试！！！");
                return null;
            }

            try
            {
                var res = await influxDBClient.GetQueryApi().QueryAsync<T>(fluxSql, influxDBConPara.Org);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// 读取数据（通过FluxTable）
        /// </summary>
        /// <param name="fluxSql">fluxSql语句
        /// 【FluxSql语句官方英文链接：https://docs.influxdata.com/flux/v0/ 】
        /// 【FluxSql语句官方中文链接：https://docs.influxdb.org.cn/flux/v0/ 】
        /// </param>
        /// <returns>返回FluxTable列表</returns>
        public async Task<List<FluxTable>> GetDatas(string fluxSql)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }
            if (string.IsNullOrEmpty(influxDBConPara.Org))
            {
                Console.WriteLine("当前的组织名称为空，不能写入数据，请检查后重试！！！");
                return null;
            }

            try
            {
                var res = await influxDBClient.GetQueryApi().QueryAsync(fluxSql, influxDBConPara.Org);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 读取数据（原生数据）
        /// </summary>
        /// <param name="fluxSql">fluxSql语句
        /// 【FluxSql语句官方英文链接：https://docs.influxdata.com/flux/v0/ 】
        /// 【FluxSql语句官方中文链接：https://docs.influxdb.org.cn/flux/v0/ 】
        /// </param>
        /// <returns>返回原生字符串</returns>
        public async Task<string> GetDataString(string fluxSql)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }
            if (string.IsNullOrEmpty(influxDBConPara.Org))
            {
                Console.WriteLine("当前的组织名称为空，不能写入数据，请检查后重试！！！");
                return null;
            }

            try
            {
                var res = await influxDBClient.GetQueryApi().QueryRawAsync(fluxSql, null, influxDBConPara.Org);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion


        #region   管理InfluxDB

        /// <summary>
        /// 获取指定组织
        /// </summary>
        /// <param name="orgName">组织名称</param>
        /// <returns>返回组织对象</returns>
        public async Task<Organization> GetOrg(string orgName)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }

            try
            {
                var res = await (influxDBClient.GetOrganizationsApi().FindOrganizationsAsync(org: orgName));
                if (res.Count <= 0)
                {
                    return null;
                }
                var org = res.First();
                return org;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// 获取组织包含的所有Bucket
        /// </summary>
        /// <param name="orgName"></param>
        /// <returns></returns>
        public async Task<List<Bucket>> GetAllBucketOfOrg(string orgName)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }

            try
            {
                var bucketList = await influxDBClient.GetBucketsApi().FindBucketsByOrgNameAsync(orgName);
                return bucketList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取Bucket
        /// </summary>
        /// <param name="bucketName">Bucket名称</param>
        /// <returns>返回Bucket对象</returns>
        public async Task<Bucket> GetBucket(string bucketName)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }

            try
            {
                var bucket = await influxDBClient.GetBucketsApi().FindBucketByNameAsync(bucketName);
                return bucket;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="orgName">组织名称</param>
        /// <returns>返回创建的组织对象</returns>
        public async Task<Organization> CreateOrg(string orgName)
        {
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return null;
            }

            if (string.IsNullOrEmpty(orgName))
            {
                throw new Exception($"组织名称不能为空");
                return null;
            }

            Organization organization = null;
            try
            {
                var res = await (influxDBClient.GetOrganizationsApi().FindOrganizationsAsync(org: orgName));
                organization = res.First();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(orgName))
                {
                    organization = await influxDBClient.GetOrganizationsApi().CreateOrganizationAsync(orgName);
                }
            }

            return organization;
        }

        /// <summary>
        /// 创建InfluxDB的Bucket
        /// </summary>
        /// <param name="bucketName">bucket名称</param>
        /// <param name="orgName">组织名称</param>
        /// <param name="retentionTime">数据保存时间（0表示永久保存;单位是秒）</param>
        /// <returns>返回创建好的Bucket对象</returns>
        public async Task<Bucket> CreateBucket(string bucketName,string orgName,long retentionTime=0)
        {
            Bucket bucket = null;
            bool result = CheckNetworkAndAuth();
            if (!result)
            {
                return bucket;
            }

            if (string.IsNullOrEmpty(bucketName) ||string.IsNullOrEmpty(orgName) || retentionTime<0)
            {
                throw new Exception($"bucket名称与组织名称不能为空，且保留时间也不能小于0");
                return bucket;
            }

            var retentionRules = new BucketRetentionRules(BucketRetentionRules.TypeEnum.Expire, retentionTime);
            try
            {
                var res = await (influxDBClient.GetOrganizationsApi().FindOrganizationsAsync(org: orgName));
               
                string orgId = res.First().Id;

                bucket = await influxDBClient.GetBucketsApi().CreateBucketAsync(bucketName, retentionRules, orgId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(orgName))
                {
                    var newOrg = await influxDBClient.GetOrganizationsApi().CreateOrganizationAsync(orgName);
                    string orgId = newOrg.Id;
                    bucket = await influxDBClient.GetBucketsApi().CreateBucketAsync(bucketName, retentionRules, orgId);
                }
            }
            return bucket;
        }

        /// <summary>
        /// 给Bucket设置读写权限
        /// </summary>
        /// <param name="bucketName">bucket名称</param>
        /// <param name="orgName">组织名称</param>
        /// <param name="enableReadAuth">启用读权限（true：表示启用）</param>
        /// <param name="enableReadAuth">启用写权限（true：表示启用）</param>
        /// <returns>返回授权对象</returns>
        public async Task<Authorization> SetPermissionOfBucket(string bucketName,string orgName,
            bool enableReadAuth,bool enableWriteAuth)
        {
            var bucketObj = await GetBucket(bucketName);
            var orgObj = await GetOrg(orgName);

            try
            {
                var resource = new PermissionResource(PermissionResource.TypeBuckets, bucketObj?.Id, null, orgObj?.Id);

                var read = new Permission(Permission.ActionEnum.Read, resource);
                var write = new Permission(Permission.ActionEnum.Write, resource);

                Authorization authorization = null;
                if (enableReadAuth)
                {
                     authorization = await influxDBClient.GetAuthorizationsApi()
                        .CreateAuthorizationAsync(orgObj.Id, new List<Permission> { read });
                }
                if (enableWriteAuth)
                {
                    authorization = await influxDBClient.GetAuthorizationsApi()
                   .CreateAuthorizationAsync(orgObj.Id, new List<Permission> { write });

                }
                if (enableReadAuth && enableWriteAuth)
                {
                    authorization = await influxDBClient.GetAuthorizationsApi()
                        .CreateAuthorizationAsync(orgObj.Id, new List<Permission> { read, write });
                }
                return authorization;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        #endregion 


        public void ToSting()
        {
            string str = $"InfluxDB参数 【 URL:{influxDBConPara.Url}】【Token:{influxDBConPara.Token}】【User:{influxDBConPara.User}】【Pwd:{influxDBConPara.Pwd}】" +
                $"【BucketName:{influxDBConPara.BucketName}】【Org:{influxDBConPara.Org}】";
            Console.WriteLine(str);
        }


    }//Class_end
}
