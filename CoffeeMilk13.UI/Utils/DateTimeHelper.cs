/***
*	Title："基础工具" 项目
*		主题：DateTime帮助类
*	Description：
*		功能：
*		    1、获取相差的天
*		    2、获取相差的小时
*		    3、获取相差的分钟
*		    4、获取相差的秒
*		    5、其他（格式转换、切割年月日 时分秒）
*	Date：2021
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Utils
{
    public class DateTimeHelper
    {
        #region   相差的天数
        /// <summary>
        /// 相差的天数和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffDaysAndDecimal(DateTime startTime, DateTime endTime)
        {
            TimeSpan daysSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return daysSpan.TotalDays;
        }

        /// <summary>
        /// 相差的天数和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffDaysAndDecimal(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan daysSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return daysSpan.TotalDays;
        }

        /// <summary>
        /// 相差的整数天数
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffDays(DateTime startTime, DateTime endTime)
        {
            TimeSpan daysSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return daysSpan.Days;
        }

        /// <summary>
        /// 相差的整数天数
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffDays(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);
            TimeSpan daysSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return daysSpan.Days;
        }

        #endregion


        #region   相差的小时
        /// <summary>
        /// 相差的小时和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffHoursAndDecimal(DateTime startTime, DateTime endTime)
        {
            TimeSpan hoursSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return hoursSpan.TotalHours;
        }

        /// <summary>
        /// 相差的小时和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffHoursAndDecimal(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan hoursSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return hoursSpan.TotalHours;
        }

        /// <summary>
        /// 相差的整数小时
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffHours(DateTime startTime, DateTime endTime)
        {
            TimeSpan hoursSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return hoursSpan.Hours;
        }

        /// <summary>
        /// 相差的整数小时
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffHours(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan hoursSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return hoursSpan.Hours;
        }

        #endregion


        #region   相差的分钟
        /// <summary>
        /// 相差的分钟和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffMinutesAndDecimal(DateTime startTime, DateTime endTime)
        {
            TimeSpan minuteSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return minuteSpan.TotalMinutes;
        }

        /// <summary>
        /// 相差的分钟和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffMinutesAndDecimal(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan minuteSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return minuteSpan.TotalMinutes;
        }

        /// <summary>
        /// 相差的整数分钟
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffMinutes(DateTime startTime, DateTime endTime)
        {
            TimeSpan minuteSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return minuteSpan.Minutes;
        }

        /// <summary>
        /// 相差的整数分钟
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffMinutes(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan minuteSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return minuteSpan.Minutes;
        }

        #endregion


        #region   相差的秒数
        /// <summary>
        /// 相差秒和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffSecondsAndDecimal(DateTime startTime, DateTime endTime)
        {
            TimeSpan secondSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return secondSpan.TotalSeconds;
        }

        /// <summary>
        /// 相差秒和小数部分
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static double DiffSecondsAndDecimal(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan secondSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return secondSpan.TotalSeconds;
        }

        /// <summary>
        /// 相差的整数秒
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffSeconds(DateTime startTime, DateTime endTime)
        {
            TimeSpan secondSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return secondSpan.Seconds;
        }

        /// <summary>
        /// 相差的整数秒
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int DiffSeconds(string startTime, string endTime)
        {
            DateTime startTimeTmp, endTimeTmp;
            DateTime.TryParse(startTime, out startTimeTmp);
            DateTime.TryParse(endTime, out endTimeTmp);

            TimeSpan secondSpan = new TimeSpan(endTimeTmp.Ticks - startTimeTmp.Ticks);
            return secondSpan.Seconds;
        }

        #endregion


        #region   其他

        /// <summary>
        /// 格式转换
        /// </summary>
        /// <param name="strDate">需要转换的日期（比如："2021-08-18" "2021-08-18 11:37:36"）</param>
        /// <param name="dateFormat">日期的格式（比如："yyyy-MM-dd"）</param>
        /// <returns></returns>
        public static string FormatConvert(string strDate, string dateFormat)
        {
            DateTime tmp;
            DateTime.TryParse(strDate, out tmp);
            return tmp.ToString(dateFormat);
        }

        /// <summary>
        /// 格式转换
        /// </summary>
        /// <param name="strDate">需要转换的日期（比如："2021-08-18" "2021-08-18 11:37:36"）</param>
        /// <param name="dateFormat">日期的格式（比如："yyyy-MM-dd"）</param>
        /// <returns></returns>
        public static DateTime FormatConvert2(string strDate, string dateFormat)
        {
            DateTime tmp = DateTime.ParseExact(strDate, dateFormat, System.Globalization.CultureInfo.InvariantCulture);

            return tmp;
        }

        /// <summary>
        /// 将时间切割为两部分(【年月日】 【时分秒】)
        /// </summary>
        /// <param name="strDate">需要切割的日期</param>
        /// <returns></returns>
        public static string[] GetHandleDate(string strDate)
        {
            if (string.IsNullOrEmpty(strDate))
            {
                return null;
            }

            string[] tmp = strDate.Split(' ');
            return tmp;
        }

        #endregion

    }//Class_end

}
