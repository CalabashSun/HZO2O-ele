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
using O2OApi.Services.Encryption;

namespace O2OApi.Services.Ele
{
    public class EleShops
    {
        public static REleShopsModel ShopInfos(IHttpClientFactory httpFactory, O2OConfigs config)
        {
            var shopUserModels = new SEleShopModel
            {
                id = CommonHelper.GenerateGuid(),
                action = EleAction.shopUsers,
                metas =
                {
                    app_key = config.AppKey
                },
                token = config.AccessToken,
                @params =new EleNullParam()
            };
            var encryString= "app_key=\"" + shopUserModels.metas.app_key + "\"" +
                             "timestamp=" + shopUserModels.metas.timestamp + config.AppSecret + "";
            shopUserModels.signature = EncryptionParams.Encrypt(shopUserModels.action, config.AccessToken, encryString);
            var client = httpFactory.CreateClient();
            var postJson = JsonConvert.SerializeObject(shopUserModels);
            HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(config.InterUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<REleShopsModel>(response);
        }
    }
}
