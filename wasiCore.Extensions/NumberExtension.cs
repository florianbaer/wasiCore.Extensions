using System;
using System.Collections.Generic;
using System.Text;

namespace wasiCore.Extensions
{
    public static class NumberExtension
    {


        /// <summary>
        /// Tries to convert a string to a number. If it fails, the return value is -1, or the value specified in the optional parameter "errorValue".
        /// </summary>
        /// <param name="str"></param>
        /// <param name="errorValue">Optional: Returned if it fails.</param>
        /// <returns></returns>
        public static int ToInt(this string str, int errorValue = -1)
        {
            return int.TryParse(str, out var i) ? i : errorValue;
        }



        /// <summary>
        /// Convert a string to a nullable number. If it fails, the return value is null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToIntNullable(this string str)
        {
            if (int.TryParse(str, out var i))
                return i;
            return null;
        }


    }
}
