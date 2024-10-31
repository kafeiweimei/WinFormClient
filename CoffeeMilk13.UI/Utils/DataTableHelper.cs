/***
*	Title："Winfrom" 项目
*		主题：DataTable帮助类
*	Description：
*		功能：
*		    1、将DataTable转为实体
*		    2、将实体转为DataTable
*		    3、将两个不同列的DataTable合并成一个新的DataTable
*		    4、DataTable表的操作
*		        1-复制DataTable
*		        2-给DataTable表添加字段
*		        3-获取到DataTable表的所有字段
*		        4-给Datatable添加一列内容
*		        5-给Datatable添加两列内容
*		        6-将List内容添加到DataTable（添加数据行）
*		        7-给DataTable添加多个空白行
*		        8-给DataTable添加单个空白行
*		        9-给DataTable指定行添加单个空白行
*		        10-向DataTable的指定行添加一条数据
*		        11-删除Datable的指定行开始及其之后的数据
*		        12-获取DataTable的所有字段名(通过实体模型)
*		        13-获取DataTable中指定行列的数据
*		        14-获取到指定列多行的数据
*		        15-获取到指定一列的所有数据
*		        16-获取到指定两列的所有数据
*		    5、删除DataTable的空白行
*		        1-删除DataTable中的空白行
*		        2-过滤空白行
*	Date：2021
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.UI.Utils
{
    public class DataTableHelper
    {
        #region   DataTable转为实体类
        /// <summary>
        /// DataTable指定行数据转化为实体类
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dataTable">dataTable</param>
        /// <param name="rowIndex">需要解析行的索引</param>
        /// <returns>返回当前指定行的实体类数据</returns>
        public static T DataTableToEntity<T>(DataTable dataTable, int rowIndex) where T : new()
        {
            try
            {
                if (dataTable == null || dataTable.Rows.Count <= 0 || rowIndex < 0)
                {
                    return default(T);
                }

                //实例化实体类
                T t = new T();
                // 获取指定行数据
                DataRow dr = dataTable.Rows[rowIndex];
                // 获取所有列
                DataColumnCollection columns = dataTable.Columns;

                // 获得实体类的所有公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    string name = pi.Name;
                    // 检查DataTable是否包含此列    
                    if (columns.Contains(name))
                    {
                        if (!pi.CanWrite) continue;

                        object value = dr[name];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                return t;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// DataTable所有数据转换成实体类列表
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns>返回实体类列表</returns>
        public static List<T> DataTableToList<T>(DataTable dt) where T : new()
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    return new List<T>();
                }

                // 实例化实体类和列表

                List<T> list = new List<T>();

                // 获取所有列
                DataColumnCollection columns = dt.Columns;


                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    // 获得实体类的所有公共属性
                    PropertyInfo[] propertys = t.GetType().GetProperties();

                    //循环比对且赋值
                    foreach (PropertyInfo p in propertys)
                    {
                        string name = p.Name;
                        // 检查DataTable是否包含此列    
                        if (columns.Contains(name))
                        {
                            if (!p.CanWrite) continue;

                            object value = dr[name];

                            if (value != DBNull.Value)
                            {
                                ////是否需要转化
                                //if (value is int || value is float || value is decimal || value is double)
                                //{
                                //    p.SetValue(t, value.ToString(), null);
                                //}
                                //else
                                //{
                                //    p.SetValue(t, value, null);
                                //}

                                p.SetValue(t, value, null);
                            }
                        }
                    }
                    list.Add(t);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region   实体类转为DataTable

        /// <summary>
        /// 实体类列表转换成DataTable
        /// </summary>
        /// <param name="entityList">实体类列表</param>
        /// <param name="excludeFields">排除字段</param>
        /// <returns>返回实体类列表对应的DataTable</returns>
        public static DataTable ListToDataTable<T>(List<T> entityList, List<string> excludeFields = null)
        {
            var countExclude = 0;
            if (excludeFields != null)
                countExclude = excludeFields.Count();

            //检查实体集合不能为空
            if (entityList == null || entityList.Count <= 0)
            {
                throw new Exception("需转换的集合为空");
            }

            //取出第一个实体的所有属性
            Type entityType = entityList[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();



            //实例化DataTable
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                Type colType = entityProperties[i].PropertyType;
                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    colType = colType.GetGenericArguments()[0];
                }
                //排除列
                string fieldName = entityProperties[i].Name;
                if (excludeFields == null || !excludeFields.Contains(fieldName))
                {
                    dt.Columns.Add(fieldName, colType);
                }
            }

            //将所有entity添加到DataTable中
            foreach (object entity in entityList)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[dt.Columns.Count];
                int icount = 0;
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    //排除列
                    string fieldName = entityProperties[i].Name;
                    if (excludeFields == null || !excludeFields.Contains(fieldName))
                    {
                        entityValues[i - icount] = entityProperties[i].GetValue(entity, null);
                    }
                    else
                    {
                        icount++;
                    }
                }
                dt.Rows.Add(entityValues);
            }

            return dt;
        }

        /// <summary>
        /// 实体类转换成DataTable(且实体类名称转为大写)
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="isUpperFieldName">DataTable的字段名称是否转为大写（true：表示转为大写）</param>
        /// <returns></returns>
        public static DataTable EntityToDataTable<T>(T model,bool isUpperFieldName=false)
        {
            if (model == null)
            {
                return null;
            }
            DataTable dt = null;
            if (isUpperFieldName)
            {
               dt = CreateData2(model);
            }
            else
            {
               dt = CreateData(model);
            }
            
            DataRow dataRow = dt.NewRow();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
            }
            dt.Rows.Add(dataRow);
            return dt;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private static DataTable CreateData<T>(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }
            return dataTable;
        }

        /// <summary>
        /// 根据实体类得到表结构(且实体类名称转为大写)
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private static DataTable CreateData2<T>(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name.ToUpper(), propertyInfo.PropertyType));
            }
            return dataTable;
        }

        /// <summary>
        /// 获取到实体类的字段列表
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static List<string> GetEntityFieldList<T>()
        {
            List<string> fieldNameList = new List<string>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                string filedName = propertyInfo.Name;
                if (!fieldNameList.Contains(filedName))
                {
                    fieldNameList.Add(filedName);
                }
            }
            return fieldNameList;
        }

        /// <summary>
        /// 获取到实体类的字段和描述字典
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static Dictionary<string,string> GetEntityFieldAndDesc<T>()
        {
            Dictionary<string, string> fieldAndDescDic =new Dictionary<string,string>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                string filedName = propertyInfo.Name;
                //var descName =  propertyInfo.CustomAttributes.ElementAt(0).ConstructorArguments.ElementAt(0).Value.ToString();
                string descName = propertyInfo.CustomAttributes.Count()>0?propertyInfo.CustomAttributes.ElementAt(0).ConstructorArguments.ElementAt(0).Value.ToString():string.Empty;
                if (!fieldAndDescDic.ContainsKey(filedName))
                {
                    fieldAndDescDic.Add(filedName, descName);
                }
            }
            return fieldAndDescDic;
        }

        /// <summary>
        /// 获取到实体类的字段列表(且所有的字段都转为大写)
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static List<string> GetEntityFieldList2<T>(T model)
        {
            List<string> fieldNameList = new List<string>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                string filedName = propertyInfo.Name.ToUpper();
                if (!fieldNameList.Contains(filedName))
                {
                    fieldNameList.Add(filedName);
                }
            }
            return fieldNameList;
        }

        #endregion

        #region   将两个列不同(结构不同)的DataTable合并成一个新的DataTable 
        /// <summary> 
        /// 将两个列不同(结构不同)的DataTable合并成一个新的DataTable 
        /// </summary> 
        /// <param name="DataTable1">表1</param> 
        /// <param name="DataTable2">表2</param> 
        /// <param name="DTName">合并后新的表名</param> 
        /// <returns>合并后的新表</returns> 
        public static DataTable MergeDataTable(DataTable DataTable1, DataTable DataTable2, string DTName)
        {
            DataTable newDataTable = new DataTable();
            if (DataTable1.Rows.Count > DataTable2.Rows.Count)
            {
                newDataTable = FillData(DataTable1, DataTable2);
            }
            else
            {
                newDataTable = FillData(DataTable2, DataTable1);
            }

            newDataTable.TableName = DTName; //设置DT的名字 
            return newDataTable;
        }

        private static DataTable FillData(DataTable dt1, DataTable dt2)
        {
            //克隆DataTable1的结构
            DataTable newDataTable = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                //再向新表中加入DataTable2的列结构
                newDataTable.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[newDataTable.Columns.Count];
            //添加DataTable1的数据
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    newDataTable.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                }
            }
            return newDataTable;
        }

        #endregion

        #region   DataTable表的操作

        /// <summary>
        /// 复制DataTable
        /// </summary>
        /// <param name="haveInfoDataTable">有数据的DataTable</param>
        /// <param name="newDataTable">新的DataTable(该新表复制有数据表的内容)</param>
        public static void CopyDataTableDatas(DataTable haveInfoDataTable, ref DataTable newDataTable)
        {
            if (haveInfoDataTable != null)
            {
                newDataTable = haveInfoDataTable.Clone();

                foreach (DataRow dr in haveInfoDataTable.Rows)
                {
                    //DataRow dw = newDataTable.NewRow();
                    //dw.ItemArray = dr.ItemArray;
                    //newDataTable.Rows.Add(dw);
                    //newDataTable = haveInfoDataTable.Clone();
                    newDataTable.ImportRow(dr);
                }
            }
        }

        /// <summary>
        /// 复制DataTable【修改DataTable列的数据类型为String】
        /// </summary>
        /// <param name="haveInfoDataTable">有数据的DataTable</param>
        /// <param name="newDataTable">新的DataTable(该新表复制有数据表的内容)</param>
        public static void CopyDataTableDatas2(DataTable haveInfoDataTable, ref DataTable newDataTable)
        {
            if (haveInfoDataTable != null)
            {
                newDataTable = haveInfoDataTable.Clone();

                if (newDataTable.Columns.Count > 0)
                {
                    foreach (DataColumn item in newDataTable.Columns)
                    {
                        newDataTable.Columns[item.ColumnName].DataType = typeof(string);
                    }
                }

                foreach (DataRow dr in haveInfoDataTable.Rows)
                {
                    DataRow dw = newDataTable.NewRow();
                    dw.ItemArray = dr.ItemArray;
                    newDataTable.Rows.Add(dw);
                }
            }
        }

        /// <summary>
        /// 给DataTable表添加字段
        /// </summary>
        /// <param name="fieldNameList">DataTable表的字段</param>
        /// <param name="dataTable">需添加字段的DataTable</param>
        /// <returns></returns>
        public static void AddFieldNameToDataTable(List<string> fieldNameList,ref DataTable dataTable)
        {
            if (fieldNameList != null && fieldNameList.Count > 0)
            {
                foreach (var item in fieldNameList)
                {
                    if (!dataTable.Columns.Contains(item))
                    {
                        dataTable.Columns.Add(item);
                    }
                   
                }
            }
        }

        /// <summary>
        /// 给DataTable表添加字段
        /// </summary>
        /// <param name="fieldNameList">DataTable表的字段</param>
        /// <param name="dataTable">需添加字段的DataTable</param>
        /// <returns></returns>
        public static void AddFieldNameToDataTable(Dictionary<string,string> fieldAndDescNameList, ref DataTable dataTable)
        {
            if (fieldAndDescNameList != null && fieldAndDescNameList.Count > 0)
            {
                foreach (var item in fieldAndDescNameList.Keys)
                {
                    if (!dataTable.Columns.Contains(item))
                    {
                        dataTable.Columns.Add(item);
                    }

                }
            }
        }

        /// <summary>
        /// 获取到DataTable表的所有字段
        /// </summary>
        /// <param name="fieldNameList">DataTable表的字段</param>
        /// <returns></returns>
        public static List<string> GetAllFieldNameOfDataTable(DataTable dataTable)
        {
            List<string> tmpList = new List<string>();
            if (dataTable!=null && dataTable.Columns.Count>0)
            {
                foreach (DataColumn item in dataTable.Columns)
                {
                    if (!tmpList.Contains(item.ColumnName))
                    {
                        tmpList.Add(item.ColumnName);
                    }
                }
            }
            return tmpList;
        }

        /// <summary>
        /// 给Datatable添加一列内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDatas">列表数据</param>
        /// <param name="fieldNameList">DataTable表的字段</param>
        /// <param name="dt">DataTable表</param>
        public static void AddOneColumnDatasToDataTable<T>(List<T> listDatas, 
            string fieldName, ref DataTable dt)
        {
            if (listDatas != null && listDatas.Count > 0 && !string.IsNullOrEmpty(fieldName) && dt != null)
            {
                DataColumn dc = null;

                if (!dt.Columns.Contains(fieldName))
                {
                    dc = dt.Columns.Add(fieldName, typeof(string));
                }
                int count = listDatas.Count;
                for (int i = 0; i < count; i++)
                {
                    dt.Rows[i][fieldName] = listDatas[i];
                }
            }
        }

        /// <summary>
        /// 给Datatable添加一列内容
        /// </summary>
        /// <param name="haveDataTable">有数据的表</param>
        /// <param name="haveDataTableColumnFieldName">有数据表的列名称</param>
        /// <param name="dt">需添加列内容的表</param>
        /// <param name="needAddColumnName">需添加列的名称</param>
        public static void AddOneColumnDatasToDataTable(DataTable haveDataTable,
            string haveDataTableColumnFieldName, ref DataTable dt, string needAddColumnName)
        {
            if (haveDataTable != null && haveDataTable.Rows.Count > 0 &&
                !string.IsNullOrEmpty(haveDataTableColumnFieldName) && !string.IsNullOrEmpty(needAddColumnName)
                && dt != null)
            {
                //if (!dt.Columns.Contains(needAddColumnName))
                //{
                //    DataColumn dc1 = dt.Columns.Add(needAddColumnName, typeof(string));
                //}

                int count = haveDataTable.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[i][needAddColumnName] = haveDataTable.Rows[i][haveDataTableColumnFieldName];

                }
            }
        }


        /// <summary>
        /// 给Datatable添加两列内容
        /// </summary>
        /// <param name="haveDataTable">有数据的表</param>
        /// <param name="oneColumnFieldName">需要添加的第一列字段名称</param>
        /// <param name="twoColumnFieldName">需要添加的第二列字段名称</param>
        /// <param name="dt">需添加列内容的表</param>
        public static void AddTwoColumnDatasToDataTable(DataTable haveDataTable,
            string oneColumnFieldName, string twoColumnFieldName, ref DataTable dt)
        {
            if (haveDataTable != null && haveDataTable.Rows.Count > 0 &&
                !string.IsNullOrEmpty(oneColumnFieldName) && !string.IsNullOrEmpty(twoColumnFieldName)
                && dt != null)
            {
                DataColumn dc1 = dt.Columns.Add(oneColumnFieldName, typeof(string));
                DataColumn dc2 = dt.Columns.Add(twoColumnFieldName, typeof(string));
                int count = haveDataTable.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    //dt.Rows.Add();
                    dt.Rows[i][oneColumnFieldName] = haveDataTable.Rows[i][oneColumnFieldName];
                    dt.Rows[i][twoColumnFieldName] = haveDataTable.Rows[i][twoColumnFieldName];
                }
            }
        }


        /// <summary>
        /// 将List内容添加到DataTable（添加数据行）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDatas">列表数据</param>
        /// <param name="fieldNameList">DataTable表的字段</param>
        /// <param name="dt">DataTable表</param>
        public static void AddListDatasToDataTable<T>(List<T> listDatas, 
            List<string> fieldNameList, ref DataTable dt)
        {
            if (listDatas != null && listDatas.Count > 0 && fieldNameList != null && fieldNameList.Count > 0 && dt != null)
            {
                int count = fieldNameList.Count;

                DataRow dr = dt.NewRow();
                for (int i = 0; i < count; i++)
                {
                    dr[fieldNameList[i]] = listDatas[i];
                }
                dt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 给DataTable添加多个空白行
        /// </summary>
        /// <param name="needAddEmptyRowNumber">需要添加的空白行数量</param>
        /// <param name="dt">DataTable表</param>
        public static void AddMutiEmptyRowToDataTable(int needAddEmptyRowNumber, ref DataTable dt)
        {
            if (needAddEmptyRowNumber > 0 && dt != null)
            {
                int rowCount = dt.Rows.Count;
                int totalCount = rowCount + needAddEmptyRowNumber;
                for (int i = rowCount; i < totalCount; i++)
                {
                    DataRow dr = dt.NewRow();

                    dt.Rows.InsertAt(dr, i);
                }

            }
        }

        /// <summary>
        /// 给DataTable添加单个空白行
        /// </summary>
        /// <param name="dt">DataTable表</param>
        public static void AddSingleEmptyRowToDataTable(ref DataTable dt)
        {
            if (dt != null)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 给DataTable指定行添加单个空白行
        /// </summary>
        /// <param name="needInsertRowIndex">需插表中的行索引</param>
        /// <param name="dt">DataTable表</param>
        public static void AddSingleEmptyRowToDataTable(int needInsertRowIndex, ref DataTable dt)
        {
            if (needInsertRowIndex >= 0 && dt != null)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.InsertAt(dr, needInsertRowIndex);
            }
        }

        /// <summary>
        /// 向DataTable的指定行添加一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDatas">列表数据</param>
        /// <param name="fieldNameList">DataTable表的字段</param>
        /// <param name="dt">DataTable表</param>
        /// <param name="needInsertRowIndex">需插表中的行索引</param>
        public static void AddSingleRowToAppointRowOfDataTable<T>(List<T> listDatas,
            List<string> fieldNameList, ref DataTable dt, int needInsertRowIndex)
        {
            if (listDatas != null && listDatas.Count > 0 && fieldNameList != null && fieldNameList.Count > 0 && dt != null)
            {
                int count = fieldNameList.Count;

                DataRow dr = dt.NewRow();
                for (int i = 0; i < count; i++)
                {
                    dr[fieldNameList[i]] = listDatas[i];
                }
                dt.Rows.InsertAt(dr, needInsertRowIndex);

            }

        }

        /// <summary>
        /// 删除Datable的指定行开始及其之后的数据
        /// </summary>
        /// <param name="startDeleteRowIndex">开始删除行的索引</param>
        /// <param name="dt">数据表</param>
        public static void DeleteAppointRowFromDataTable(int startDeleteRowIndex, ref DataTable dt)
        {
            if (startDeleteRowIndex <= 0 || dt == null || dt.Rows.Count <= 0) return;

            int rowCount = dt.Rows.Count;
            for (int i = rowCount - 1; i >= startDeleteRowIndex; i--)
            {
                try
                {
                    dt.Rows.RemoveAt(i);
                }
                catch (Exception)
                {
                    continue;
                }

            }
        }

        /// <summary>
        /// 获取DataTable的所有字段名(通过实体模型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">实体</param>
        /// <param name="isOpenUpper">实体字段名称是否开启大写（true：表示开启）</param>
        /// <returns></returns>
        public static List<string> GetDataTableAllFieldNameOfModel<T>(T model, bool isOpenUpper = true)
        {
            List<string> tmpList = new List<string>();
            if (model != null)
            {
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    string filedName = propertyInfo.Name;
                    if (isOpenUpper)
                    {
                        if (!tmpList.Contains(filedName.ToUpper()))
                        {
                            tmpList.Add(filedName.ToUpper());
                        }
                    }
                    else
                    {
                        if (!tmpList.Contains(filedName))
                        {
                            tmpList.Add(filedName);
                        } 
                    }
                }
            }
            return tmpList;
        }


        /// <summary>
        /// 获取DataTable中指定行列的数据
        /// </summary>
        /// <param name="dt">DataTable表</param>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnIndex">列索引</param>
        /// <returns></returns>
        public static string GetRowColumnValue(DataTable dt, int rowIndex, int columnIndex)
        {
            if (dt == null || dt.Rows.Count < 1 || dt.Columns.Count < 1)
            {
                return null;
            }
            return dt.Rows[rowIndex][columnIndex].ToString();

        }

        /// <summary>
        /// 获取DataTable中指定行列的数据
        /// </summary>
        /// <param name="dt">DataTable表</param>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnFieldName">列字段名称</param>
        /// <returns></returns>
        public static string GetRowColumnValue(DataTable dt, int rowIndex, string columnFieldName)
        {
            if (dt == null || dt.Rows.Count < 1 || dt.Columns.Count < 1)
            {
                return null;
            }
            return dt.Rows[rowIndex][columnFieldName].ToString();

        }

        /// <summary>
        /// 获取到指定行多列的数据
        /// </summary>
        /// <param name="dt">DataTable表</param>
        /// <param name="rowIndex">行索引</param>
        /// <param name="startColumnIndex">开始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <returns></returns>
        public static List<string> GetRowAndMutiColumnValues(DataTable dt, int rowIndex,
            int startColumnIndex, int endColumnIndex)
        {
            List<string> tmpList = new List<string>();
            if (dt == null || dt.Rows.Count < 1 || dt.Columns.Count < 1)
            {
                return null;
            }
            for (int i = startColumnIndex; i <= endColumnIndex; i++)
            {
                string tmpValue = dt.Rows[rowIndex][i].ToString();
                tmpList.Add(tmpValue);
            }
            return tmpList;
        }

        /// <summary>
        /// 获取到指定列多行的数据
        /// </summary>
        /// <param name="dt">DataTable表</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="startRowIndex">开始行索引</param>
        /// <param name="endRowIndex">结束行索引</param>
        /// <returns></returns>
        public static List<string> GetColumnAndMutiRowValues(DataTable dt, int columnIndex,
            int startRowIndex, int endRowIndex)
        {
            List<string> tmpList = new List<string>();
            if (dt == null || dt.Rows.Count < 1 || dt.Columns.Count < 1)
            {
                return null;
            }
            for (int i = startRowIndex; i <= endRowIndex; i++)
            {
                string tmpValue = dt.Rows[i][columnIndex].ToString();
                tmpList.Add(tmpValue);
            }
            return tmpList;
        }

        /// <summary>
        /// 获取到指定列多行的数据
        /// </summary>
        /// <param name="dt">DataTable表</param>
        /// <param name="columnFieldName">列字段名称</param>
        /// <param name="startRowIndex">开始行索引</param>
        /// <param name="endRowIndex">结束行索引</param>
        /// <returns></returns>
        public static List<string> GetColumnAndMutiRowValues(DataTable dt, string columnFieldName,
            int startRowIndex, int endRowIndex)
        {
            List<string> tmpList = new List<string>();
            if (dt == null || dt.Rows.Count < 1 || dt.Columns.Count < 1)
            {
                return null;
            }
            for (int i = startRowIndex; i <= endRowIndex; i++)
            {
                string tmpValue = dt.Rows[i][columnFieldName].ToString();
                tmpList.Add(tmpValue);
            }
            return tmpList;
        }

        /// <summary>
        /// 获取到指定一列的所有数据
        /// </summary>
        /// <param name="dataTable">DataTable表</param>
        /// <param name="columnIndex">列索引</param>
        /// <returns>返回指定索引的列的所有数据</returns>
        public static List<string> GetIndexColumnValueItems(DataTable dataTable, int columnIndex = 0)
        {
            List<string> items = new List<string>();
            if (dataTable == null || (dataTable != null && dataTable.Rows.Count == 0))
                items.Add("");
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    items.Add(dataRow[columnIndex].ToString());
                }
            }
            return items;
        }

        /// <summary>
        /// 获取到指定一列名称的所有数据
        /// </summary>
        /// <param name="dataTable">DataTable表</param>
        /// <param name="columnFieldName">列字段名称</param>
        /// <returns>返回指定索引的列的所有数据</returns>
        public static List<string> GetIndexColumnValueItems(DataTable dataTable, string columnFieldName)
        {
            List<string> items = new List<string>();
            if (dataTable == null || (dataTable != null && dataTable.Rows.Count == 0))
                items.Add("");
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    items.Add(dataRow[columnFieldName].ToString());
                }
            }
            return items;
        }


        /// <summary>
        /// 获取到指定两列的所有数据
        /// </summary>
        /// <param name="dataTable">DataTable表</param>
        /// <param name="columnIndex1">列索引1</param>
        /// <param name="columnIndex2">列索引2</param>
        /// <returns>返回指定索引的列的所有数据</returns>
        public static Dictionary<string, string> GetTwoIndexColumnValueItems(DataTable dataTable, 
            int columnIndex1 = 0, int columnIndex2 = 1)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            if (dataTable == null || (dataTable != null && dataTable.Rows.Count == 0))
                items.Add("", "");
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (!items.ContainsKey(dataRow[columnIndex1].ToString()))
                    {
                        items.Add(dataRow[columnIndex1].ToString(), dataRow[columnIndex2].ToString());
                    }
                    
                }
            }
            return items;
        }

        /// <summary>
        /// 获取到指定两列的所有数据
        /// </summary>
        /// <param name="dataTable">DataTable表</param>
        /// <param name="columnFieldName1">列字段名称1</param>
        /// <param name="columnFieldName2">列字段名称2</param>
        /// <returns>返回指定索引的列的所有数据</returns>
        public static Dictionary<string, string> GetTwoIndexColumnValueItems(DataTable dataTable, 
            string columnFieldName1, string columnFieldName2)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            if (dataTable == null || (dataTable != null && dataTable.Rows.Count == 0))
                items.Add("", "");
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (!items.ContainsKey(dataRow[columnFieldName1].ToString()))
                    {
                        items.Add(dataRow[columnFieldName1].ToString(), dataRow[columnFieldName2].ToString());
                    }
                        
                }
            }
            return items;
        }


        #endregion

        #region   删除DataTable的空白行

        /// <summary>
        /// 删除DataTable中的空白行
        /// </summary>
        /// <param name="dt">需处理的DataTable</param>
        /// <returns></returns>
        public static DataTable DeleteEmptyRow(DataTable dt)
        {
            if (dt == null || dt.Rows.Count < 1) return null;

            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool rowdataisnull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string curColumnValue = dt.Rows[i][j].ToString().Trim();
                    if (!string.IsNullOrEmpty(curColumnValue))
                    {
                        rowdataisnull = false;
                    }
                }
                if (rowdataisnull)
                {
                    removelist.Add(dt.Rows[i]);
                }

            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
            return dt;
        }

        /// <summary>
        /// 过滤空白行
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable FilterBlankRow(DataTable dt)
        {
            if (dt == null || dt.Columns.Count < 1) return null;

            DataView dv = dt.DefaultView;
            string filterRule = "";
            foreach (DataColumn col in dt.Columns)
            {
                filterRule += $"{col.ColumnName} <> '' or ";
            }
            filterRule = filterRule.Substring(0, filterRule.LastIndexOf("or"));
            dv.RowFilter = $"({filterRule})";
            return dv.ToTable();
        }


        #endregion 


    }//Class_end

}
