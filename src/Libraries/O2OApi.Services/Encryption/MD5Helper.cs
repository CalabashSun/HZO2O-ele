using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace O2OApi.Services.Encryption
{
    public class MD5Helper
    {
        public static string GetMd5(string myString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(myString);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string lasttime = "";
            foreach (var b in bytHash)
            {
                string last = string.Format("{0:X}", b);
                if (last.Length == 1)
                    last = "0" + last;
                lasttime += last;
            }
            return lasttime.ToUpper();
        }
    }
}
