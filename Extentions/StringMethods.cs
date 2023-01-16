using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDN.Extensions
{
    public static class StringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }



        #region Took From https://san-tech-solutions.blogspot.com/2017/02/c-string-helper-class.html
        
        /// <summary>
        /// Check particular string present in provided string or not
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck,StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
        /// <summary>
        /// Check value is present or not
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        ///  Get Integer value from string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetIntValue(this string value, int defaultValue = 0)
        {
            int val;
            return string.IsNullOrWhiteSpace(value)
                       ? defaultValue
                       : int.TryParse(value, out val) ? val : defaultValue;
        }

    }
    #endregion


}
