using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using O2OApi.Core;
using O2OApi.Core.Configuration;
using O2OApi.Core.Infrastructure;
using O2OApi.Data.Ele;

namespace O2OApi.Services.Ele
{
    public class EleOAuth
    {
        /// <summary>
        /// 换取code
        /// </summary>
        /// <returns></returns>
        public static string GetOAuthUrl(string shopId)
        {
            var appkey = EngineContext.Current.Resolve<O2OConfig>().Ele.appkey;

            var url = string.Format(EleApiUrl.urlForGettingOAuthUrl, appkey, HttpUtility.HtmlEncode(EleApiUrl.redirectUri),shopId);
            return url;
        }
        /// <summary>
        /// 获取accesstoken
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static AccessToken GetAccessToken(IHttpClientFactory httpFactory, string code)
        {
            var config = EngineContext.Current.Resolve<O2OConfig>();

            var appkey = config.Ele.appkey;
            var secret = config.Ele.appsecret;

            var auth = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(appkey + ":" + secret));
            var client = httpFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", auth);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var keyValues = new Dictionary<string, string>();
            keyValues["grant_type"] = "authorization_code";
            keyValues["code"] = code;
            keyValues["redirect_uri"] = HttpUtility.HtmlEncode(EleApiUrl.redirectUri);
            keyValues["client_id"] = appkey;
            FormUrlEncodedContent content = new FormUrlEncodedContent(keyValues);
            var result = client.PostAsync(EleApiUrl.urlForGettingAccessToken, content).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<AccessToken>(result);
        }
        /// <summary>
        /// 刷新accesstoken
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="refershToken"></param>
        /// <returns></returns>
        public static AccessToken GetRefreshToken(IHttpClientFactory httpFactory, string refershToken) 
        {
            var config = EngineContext.Current.Resolve<O2OConfig>();

            var appkey = config.Ele.appkey;
            var secret = config.Ele.appsecret;

            var auth = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(appkey + ":" + secret));
            var client = httpFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", auth);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var keyValues = new Dictionary<string, string>();
            keyValues["grant_type"] = "refresh_token";
            keyValues["refresh_token"] = refershToken;
            FormUrlEncodedContent content = new FormUrlEncodedContent(keyValues);
            var result = client.PostAsync(EleApiUrl.urlForGettingAccessToken, content).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<AccessToken>(result);
        }
    }
}
