/***
*	Title："WinFormClient" 项目
*		主题：通用的InfluxDB数据库操作类
*	Description：
*		功能：实现数据库的基础增、删、查、改操作
*	Date：2025/3/23 15:56:19
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.TimeSeriesDB.DBHelper
{
    public class InfluxdbHelper
    {
        #region   基础参数
        private InfluxDbClient influxDbClient;
        private InfluxDBModel influxDBModel;

        #endregion 

        /// <summary>
        /// 实例化InfluxDB数据库
        /// </summary>
        /// <param name="influxDBModel"></param>
        public InfluxdbHelper(InfluxDBModel influxDBModel)
        {
            this.influxDBModel = influxDBModel;
            influxDbClient = new InfluxDbClient(this.influxDBModel.Url,
                this.influxDBModel.User,this.influxDBModel.Pwd,InfluxDbVersion.Latest);
        }


        //读取数据
        public async Task<List<T>> GetList<T>(string sqlStr) where T : new()
        {
            try
            {
                var response = await influxDbClient.Client.QueryAsync(sqlStr,this.influxDBModel.BucketName);

                var series = response.ToList();

                if (series.Count==0)
                {
                    return new List<T>();
                }

                var listColumns = series[0].Columns;
                var listValue = series[0].Values;

                return null;
            }
            catch (Exception)
            {

                return new List<T>();
            }
        }



        public class InfluxDBModel
        {
            public string Url { get; set; }

            public string User { get; set; }

            public string Pwd { get; set; }

            public string BucketName { get; set; }
        }

    }//Class_end
}
