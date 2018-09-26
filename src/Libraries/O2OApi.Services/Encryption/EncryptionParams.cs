using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Services.Encryption
{
    public class EncryptionParams
    {
        /// <summary>
        /// 传递参数加密
        /// </summary>
        /// <param name="action"></param>
        /// <param name="token"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Encrypt(string action,string token,string param)
        {
            var sorts = action + token + param;
            return MD5Helper.GetMd5(sorts);
        }
    }
}
