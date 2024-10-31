/***
*	Title："基础工具" 项目
*		主题：容器帮助类
*	Description：
*		功能：
*		    1、添加信息到字典中
*		    2、根据键获取值
*		    3、根据值获取键
*		    4、添加内容到列表中
*		    5、移除列表中的指定内容
*	Date：2021
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Utils
{
    public class ContainerHelper
    {
        /// <summary>
        /// 添加唯一信息到字典中（若存在键则不添加值）
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="dic">容器</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void AddOnlyInfoToDic<T>(Dictionary<string, T> dic, string key, T value)
        {
            if (dic == null)
            {
                dic = new Dictionary<string, T>();
            }

            if (!dic.ContainsKey(key))
            {
                dic.Add(key, value);
            }
        }

        /// <summary>
        /// 添加信息到字典中(若存在则替换)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic">容器</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void AddInfoToDic<T>(Dictionary<string, T> dic, string key, T value)
        {
            if (dic == null)
            {
                dic = new Dictionary<string, T>();
            }

            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic">容器</param>
        /// <param name="key">键</param>
        /// <returns>返回键对应的值</returns>
        public static T GetValueOfKey<T>(Dictionary<string, T> dic, string key)
        {
            T tmpValue = default(T);
            if (dic != null && dic.Count > 0)
            {
                if (dic.ContainsKey(key))
                {
                    tmpValue = dic[key];
                }
            }
            return tmpValue;
        }


        /// <summary>
        /// 根据值获取键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic">容器</param>
        /// <param name="value">值</param>
        /// <returns>返回值对应的键</returns>
        public static string GetKeyOfValue<T>(Dictionary<string, T> dic, T value)
        {
            string tmpKey = null;
            foreach (KeyValuePair<string, T> kv in dic)
            {
                if (kv.Value.Equals(value))
                {
                    tmpKey = kv.Key;
                }
            }
            return tmpKey;
        }

        /// <summary>
        /// 添加内容到列表中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="needAddInfo"></param>
        /// <param name="list"></param>
        public static void AddInfoToList<T>(T needAddInfo, ref List<T> list)
        {
            if (!list.Contains(needAddInfo))
            {
                list.Add(needAddInfo);
            }
        }

        /// <summary>
        /// 移除列表中的指定内容
        /// </summary>
        /// <param name="needRemoveinfo"></param>
        /// <param name="list"></param>
        public static void RemoveListInfo<T>(T needRemoveinfo, ref List<T> list)
        {
            if (list.Contains(needRemoveinfo))
            {
                list.Remove(needRemoveinfo);
            }
        }

        /// <summary>
        /// 添加信息到嵌套列表中
        /// </summary>
        /// <typeparam name="T">需添加的数据类型</typeparam>
        /// <param name="doubleList">嵌套列表</param>
        /// <param name="needInfo1">需添加的信息1</param>
        /// <param name="needInfo2">需添加的信息2</param>
        public static void AddInfoToDoubleList<T>(List<List<T>> doubleList, T needInfo1, T needInfo2)
        {
            List<T> tmpList = new List<T> {needInfo1,needInfo2 };
            doubleList.Add(tmpList);
        }

        /// <summary>
        /// 移除嵌套列表中指定索引的内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doubleList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool RemoveDoubleListInfo<T>(List<List<T>> doubleList, int index)
        {
            if (doubleList == null || doubleList.Count < 1) return false;

            try
            {
                doubleList.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        /// <summary>
        /// 获取嵌套列表指定索引的内容
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="doubleList">嵌套列表</param>
        /// <param name="index">需要查询的索引</param>
        /// <returns>返回指定索引对应的列表信息</returns>
        public static T[] GetDoubleListInfo<T>(List<List<T>> doubleList, int index)
        {
            if (doubleList == null || doubleList.Count < 1) return null;

            T[] tmpArray = new T[2];

            tmpArray[0] = doubleList[index][0];
            tmpArray[1] = doubleList[index][1];

            return tmpArray;
        }


    }//Class_end

}
