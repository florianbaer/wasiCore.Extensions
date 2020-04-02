using System;
using System.Collections.Generic;

namespace wasiCore.Extensions
{
    public static class StringExtensions
    {


        /// <summary>
        /// Like string.Trim() but trims unwanted characters between char (0) and char (32). Spaces, tabs, line breaks, and the like.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimExtended(this string str)
        {
            var s = str;

            if (s == null)
                return null;

            var unwantedCharList = new List<char>();
            for (var i = 0; i <= 32; i++)
                unwantedCharList.Add((char)i);

            return s.Trim(unwantedCharList.ToArray());
        }



        /// <summary>
        /// Exactly the same as string.Substring(Int32)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string SubstringExtended(this string str, int startIndex)
        {
            return str.Substring(startIndex);
        }


        /// <summary>
        /// Like string.Substring(Int32, Int32) but without errors if the string is shorter than the length to be displayed.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringExtended(this string str, int startIndex, int length)
        {
            return str.Substring(startIndex, Math.Min(str.Length - startIndex, length));
        }


        /// <summary>
        /// Identical to LEFT () in T-SQL
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string str, int length)
        {
            return str.SubstringExtended(0, length);
        }


        /// <summary>
        /// Identical to LEFT () in T-SQL
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string str, int length)
        {
            return str.SubstringExtended(str.Length - length >= 0 ? str.Length - length : str.Length, str.Length);
        }


    }
}
