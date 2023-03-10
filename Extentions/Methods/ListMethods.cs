using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace SDN.Extensions
{
    public static class ListExtensions
    {
        public static List<T> DataReaderMapToList<T>(this List<T> DataReaderMapToList, IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}