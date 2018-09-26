
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using O2OApi.Core;
using O2OApi.Core.Configuration;
using O2OApi.Core.Infrastructure;
using O2OApi.Data.DataBase;
using O2OApi.Data.Ele.Response;
using O2OApi.Data.Ele.Submit;
using O2OApi.Services.Encryption;

namespace O2OApi.Services.Ele
{
    public class EleProducts
    {
        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="shopId"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static RProductCate ProductCate(IHttpClientFactory httpFactory, long shopId,O2OConfigs config)
        {
            var shopCateModel = new SProductCate
            {
                id = CommonHelper.GenerateGuid(),
                action = EleAction.shopCate,
                metas =
                {
                    app_key = config.AppKey
                },
                token = config.AccessToken,
                @params =new ShopCategories
                {
                    shopId = shopId
                }
            };
            //构建加密参数
            var encryString = "app_key=\"" + shopCateModel.metas.app_key + "\"shopId=" + shopCateModel.@params.shopId +
                              "timestamp=" + shopCateModel.metas.timestamp + config.AppSecret + "";
            shopCateModel.signature = EncryptionParams.Encrypt(shopCateModel.action, config.AccessToken, encryString);


            var client = httpFactory.CreateClient();
            var postJson = JsonConvert.SerializeObject(shopCateModel);
            HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(config.InterUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<RProductCate>(response);
        }

        /// <summary>
        /// 获取商品详细信息
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="cateId"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static RItemDetails ProductDetails(IHttpClientFactory httpFactory, long cateId, O2OConfigs config)
        {
            var productModel = new SItemsByCategoryId
            {
                id = CommonHelper.GenerateGuid(),
                action = EleAction.shopProductCate,
                metas =
                {
                    app_key = config.AppKey
                },
                token = config.AccessToken,
                @params = new ItemByCateId
                {
                    categoryId = cateId
                }
            };
            //构建加密参数
            var encryString = "app_key=\"" + productModel.metas.app_key + "\"categoryId=" + productModel.@params.categoryId +
                              "timestamp=" + productModel.metas.timestamp + config.AppSecret + "";
            productModel.signature = EncryptionParams.Encrypt(productModel.action, config.AccessToken, encryString);


            var client = httpFactory.CreateClient();
            var postJson = JsonConvert.SerializeObject(productModel);
            HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(config.InterUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<RItemDetails>(response);
        }


        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <param name="httpFactory"></param>
        /// <param name="shopId"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static RProductPages ProductPage(IHttpClientFactory httpFactory, long shopId, O2OConfigs config,string accessToken)
        {
            #region 构建参数
            var productModel = new SProductInfoPage()
            {
                id = CommonHelper.GenerateGuid(),
                action = EleAction.shopProductPages,
                metas =
                {
                    app_key = config.AppKey
                },
                token = accessToken,
            };
            var queryPageInfo = new ProductQueryPages
            {
                queryPage = new ProductQueryPage
                {
                    limit = 299,
                    offset = 0,
                    shopId = shopId
                }
            };
            productModel.@params = queryPageInfo;
            #endregion

            var paramEncry = "queryPage={\"shopId\":" + productModel.@params.queryPage.shopId + ",\"offset\":" +
                             productModel.@params.queryPage.offset + ",\"limit\":" + productModel.@params.queryPage.limit + "}";
            //构建加密参数
            var encryString = "app_key=\"" + productModel.metas.app_key + "\"" +
                              paramEncry
                              + "timestamp=" + productModel.metas.timestamp + config.AppSecret + "";
            productModel.signature = EncryptionParams.Encrypt(productModel.action, accessToken, encryString);
            var client = httpFactory.CreateClient();
            var postJson = JsonConvert.SerializeObject(productModel);
            HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(config.InterUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<RProductPages>(response);
        }

    }
}
