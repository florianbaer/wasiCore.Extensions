using System;

namespace wasiCore.Extensions
{
    public static class StringExtensions
    {
        public static string Test(this string str, bool toUpper = false)
        {
            return toUpper ? str.ToUpper() : str;
        }
    }
}
