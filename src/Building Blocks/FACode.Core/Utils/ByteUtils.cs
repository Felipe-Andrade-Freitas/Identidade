using System;

namespace FACode.Core.Utils
{
    public static class ByteUtils
    {
        public static string FromImageToString(this byte[] bt)
        {
            return Convert.ToBase64String(bt);
        }
    }
}