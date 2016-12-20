using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    public static class BaseSeoExtensions
    {


        public static string ToUri(this string inputStr)
        {
            string str = inputStr.RemoveAccent().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-\/]", ""); // invalid chars           
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            str = Regex.Replace(str, "-+", "-");
            str = str.Trim('-');

            return str;
        }

        public static string ToSlug(this string inputStr)
        {
            string str = inputStr.RemoveAccent().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars           
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space   
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // cut and trim it   
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            str = Regex.Replace(str, "-+", "-");
            str = str.Trim('-');

            return str;
        }

        public static string RemoveAccent(this string inputStr)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(inputStr);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
