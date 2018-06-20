using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace mvcTwo.Models
{
    public static class StringExtension
    {

        /// <summary>
        /// 获取从下标0开始指定长度的子串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length">子串长度</param>
        /// <returns></returns>
        public static string Sub(this string source, int length = 0)
        {

            length = length > source.Length ? source.Length : length;
            length = length < 0 ? 0 : length;
            return source.Substring(0, length);
        }

        public static string TrimBlank(this string source)
        {
            return Regex.Replace(source, @"\s", "");
            //return source.Replace(" ", "");
        }
    }
}