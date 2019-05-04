using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using O2OApi.Core;
using O2OApi.Core.Configuration;
using O2OApi.Core.Helper;
using O2OApi.Data.DataBase;
using O2OApi.Data.Ele.Response;
using O2OApi.Data.Ele.Submit;
using O2OApi.Services.DataServices;
using O2OApi.Services.Encryption;

namespace O2OApi.Services.Ele
{
    public class EleComments
    {
        /// <summary>
        /// 获取最近七天评价数据
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="config"></param>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static REleCommentsModel LastSevenComments(IHttpClientFactory httpFactory, O2OConfigs config,string shopId,int offset,int pageSize)
        {
            var startDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now;
            return ShopComments(httpFactory, config, shopId, startDate, endDate,offset,pageSize);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="config"></param>
        /// <param name="shopId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="offset"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static REleCommentsModel AssignComments(IHttpClientFactory httpFactory, O2OConfigs config, string shopId,
            DateTime start, DateTime end, int offset, int pageSize)
        {
            return ShopComments(httpFactory, config, shopId, start, end, offset, pageSize);
        }


        public static REleCommentsModel ShopComments(IHttpClientFactory httpFactory, O2OConfigs config,string shopId,DateTime start,DateTime end,int offset,int pageSize)
        {
            //构建请求参数
            var requestModel = new SEleCommentsModel
            {
                id=CommonHelper.GenerateGuid(),
                action = EleAction.shopComments,
                metas =
                {
                    app_key = config.AppKey
                },
                token = config.AccessToken,
                @params = new SEleCommentsModelInfo
                {
                    shopId = shopId,
                    startTime = start.ToString("yyyy-MM-ddT00:00:00"),
                    endTime = end.ToString("yyyy-MM-ddT00:00:00"),
                    offset = offset,
                    pageSize = pageSize
                }
            };
            //构建加密参数
            var encryString = "app_key=\"" + requestModel.metas.app_key + "\"endTime=\"" + requestModel.@params.endTime +
                              "\"offset="+requestModel.@params.offset+
                              "pageSize="+requestModel.@params.pageSize+
                              "shopId=\""+requestModel.@params.shopId+ "\"startTime=\""+requestModel.@params.startTime+
                              "\"timestamp=" + requestModel.metas.timestamp + config.AppSecret + "";
            requestModel.signature= EncryptionParams.Encrypt(requestModel.action, config.AccessToken, encryString);
            var client = httpFactory.CreateClient();
            var postJson = JsonConvert.SerializeObject(requestModel);
            HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(config.InterUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<REleCommentsModel>(response);
        }



        /// <summary>
        /// 获取最近七天星选评价数据
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="config"></param>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static REleRateCommentsModel LastSevenRateComments(IHttpClientFactory httpFactory, O2OConfigs config, long shopId, int offset, int pageSize)
        {
            var startDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now;
            return RateShopComments(httpFactory, config, shopId, startDate, endDate, offset, pageSize);
        }
        /// <summary>
        /// 指定星选评价
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="config"></param>
        /// <param name="shopId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="offset"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static REleRateCommentsModel AssignRateComments(IHttpClientFactory httpFactory, O2OConfigs config, long shopId,
            DateTime start, DateTime end, int offset, int pageSize)
        {
            return RateShopComments(httpFactory, config, shopId, start, end, offset, pageSize);
        }

        public static REleRateCommentsModel RateShopComments(IHttpClientFactory httpFactory, O2OConfigs config, long shopId, DateTime start, DateTime end, int offset, int pageSize)
        {
            //构建请求参数
            var rateQuery=new SEleRateCommentsModelJson
            {
                shopId = shopId,
                startTime = start.ToString("yyyy-MM-ddT00:00:00"),
                endTime = end.ToString("yyyy-MM-ddT00:00:00"),
                offset = offset,
                pageSize = pageSize
            };
            var requestModel = new SEleRateCommentsModel
            {
                id = CommonHelper.GenerateGuid(),
                action = EleAction.shopRateComments,
                metas =
                {
                    app_key = config.AppKey
                },
                token = config.AccessToken,
                @params = new SEleRateCommentsModelInfo
                {
                    rateQuery = rateQuery
                }
            };
            //构建加密参数
            var encryString = "app_key=\"" + requestModel.metas.app_key +
                              "\"rateQuery={\"shopId\":" + requestModel.@params.rateQuery.shopId +
                              ",\"startTime\":\"" + requestModel.@params.rateQuery.startTime +
                              "\",\"endTime\":\"" + requestModel.@params.rateQuery.endTime +
                              "\",\"offset\":" + requestModel.@params.rateQuery.offset +
                              ",\"pageSize\":" + requestModel.@params.rateQuery.pageSize +
                              "}" +
                              "timestamp=" + requestModel.metas.timestamp + config.AppSecret + "";
            requestModel.signature = EncryptionParams.Encrypt(requestModel.action, config.AccessToken, encryString);
            var client = httpFactory.CreateClient();
            var postJson = JsonConvert.SerializeObject(requestModel);
            HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(config.InterUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<REleRateCommentsModel>(response);
        }
    }
}
