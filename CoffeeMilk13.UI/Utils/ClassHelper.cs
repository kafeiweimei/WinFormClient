/***
*	Title："WinFormClient" 项目
*		主题：实体类的帮助
*	Description：
*		功能：
*		    1、获取到类中的所有属性和对应值
*		    2、解析类中的所有属性和对应值字符串
*	Date：2025/2/11 17:48:29
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Utils
{
    public class ClassHelper
    {
        /// <summary>
        /// 获取到类中的所有属性和对应值
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="t">类实体</param>
        /// <returns>返回类中的所有属性和对应值</returns>
        public static string GetAllProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tStr += string.Format("{0}:{1},", name, value);
                }
                else
                {
                    GetAllProperties(value);
                }
            }
            return tStr;
        }

        /// <summary>
        /// 解析类中的所有属性和对应值字符串
        /// </summary>
        /// <param name="strClassAllProperties">类中的所有属性和对应值字符串</param>
        /// <returns>返回类中所有属性和对应值得键值对列表</returns>
        public static Dictionary<string, string> AnalyAllPropertiesString(string strClassAllProperties)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(strClassAllProperties)) return dic;

            string[] splitDatas = strClassAllProperties.Split(',');

            int len = splitDatas.Length - 1;
            for (int i = 0; i < len; i++)
            {
                string[] strSingle = splitDatas[i].Split(':');

                dic.Add(strSingle[0], strSingle[1]);
            }

            return dic;
        }

        /// <summary>
        /// 解析类中的所有属性和对应值字符串到DataTable中
        /// </summary>
        /// <param name="strClassAllProperties">实体类的所有属性和值信息字符串</param>
        /// <param name="dt">虚拟数据表</param>
        public static void AnalyAllPropertiesToDataTable(string strClassAllProperties, ref DataTable dt)
        {
            if (string.IsNullOrEmpty(strClassAllProperties)) return;

            DataRow row = dt.Rows.Add();

            string[] splitDatas = strClassAllProperties.Split(',');

            int len = splitDatas.Length - 1;
            for (int i = 0; i < len; i++)
            {
                string[] strSingle = splitDatas[i].Split(':');

                row[strSingle[0]] = strSingle[1];
            }

        }


    }//Class_end
}
