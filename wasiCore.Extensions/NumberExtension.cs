using System;
using System.Collections.Generic;
using System.Text;

namespace wasiCore.Extensions
{
    public static class NumberExtension
    {


        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer. If it fails, -1 (or another number if the parameter errorValue is set) will be returned.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="errorValue">Optional: Returns the value if the string cannot be converted.</param>
        /// <returns></returns>
        public static int ToInt(this string str, int errorValue = -1)
        {
            return int.TryParse(str, out var i) ? i : errorValue;
        }



        /// <summary>
        /// Converts the specified string representation of a number to an equivalent nullable integer. If it fails, (null) will be returned.
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
