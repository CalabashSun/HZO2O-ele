using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele
{
    public static class EleApiUrl
    {
        /// <summary>
        /// 回调Url
        /// </summary>
        public static string redirectUri = "https://o2o.dongdongmm.com";
        /// <summary>
        /// 获取授权codeUrl
        /// </summary>
        public static string urlForGettingOAuthUrl = "https://open-api-sandbox.shop.ele.me/authorize?response_type=code&client_id={0}&redirect_uri={1}&scope=all&state={2}";
        /// <summary>
        /// 获取accesstokenUrl
        /// </summary>
        public static string urlForGettingAccessToken = "https://open-api-sandbox.shop.ele.me/token";
    }
}
