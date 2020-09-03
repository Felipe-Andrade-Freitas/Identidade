using System;
using System.Linq;

namespace FACode.Core.Utils
{
    public static class StringUtils
    {
        public static string ApenasNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public static byte[] FromBase64String(this string str)
        {
            return Convert.FromBase64String(str);
        }

        public static byte[] FromImageToString(this string str)
        {
            return Convert.FromBase64String(str.Split(',')[1]);
        }
    }
}