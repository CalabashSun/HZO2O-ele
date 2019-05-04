using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using O2OApi.Data.DataBase;
using O2OApi.Services.Ele;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services.DataServices
{
    public interface IO2OConfigService:IRepository<O2OConfigs>
    {
        O2OConfigs GetConfigs(string name="",long shopId=0);

        O2OConfigs GetConfigsByZpShopId(string zpShopId);
        /// <summary>
        /// 获取accesstoken
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <returns></returns>
        string RefreshAccessToken(IHttpClientFactory httpClientFactory);

        string ForceRefreshAccessToken(IHttpClientFactory httpClientFactory);
    }

    public class O2OConfigService: Repository<O2OConfigs>, IO2OConfigService
    {
        public O2OConfigs GetConfigs(string name="", long shopId = 0)
        {
            var where = "1=1";
            if (!string.IsNullOrEmpty(name))
            {
                where += $" and name='{name}'";
            }

            if (shopId!=0)
            {
                where += $" and ShopId='{shopId}'";
            }

            var selectString = $"select * from EleConfig where " +where;
            return _Conn.QueryFirstOrDefault<O2OConfigs>(selectString);
        }

        public O2OConfigs GetConfigsByZpShopId(string zpShopId)
        {
            var sqlString = $"select * from EleConfig where Zp_ShopId='{zpShopId}'";
            return _Conn.QueryFirstOrDefault<O2OConfigs>(sqlString);
        }

        public string RefreshAccessToken(IHttpClientFactory httpClientFactory)
        {
            var configs = GetConfigs(shopId: 1);
            if (configs.ExpiresTime != null && configs.ExpiresTime.Value < DateTime.Now)
            {
                var tokenInfo = EleOAuth.GetRefreshToken(httpClientFactory, configs.RefershToken);
                if (string.IsNullOrEmpty(tokenInfo.access_token))
                {
                    //刷新token也过期了需要重新授权了
                    return "error";
                }

                configs.AccessToken = tokenInfo.access_token;
                configs.RefershToken = tokenInfo.refresh_token;
                configs.ExpiresTime = DateTime.Now.AddSeconds(Convert.ToDouble(tokenInfo.expires_in) - 80000);
                _Conn.Update<O2OConfigs>(configs);
                return tokenInfo.access_token;
            }
            else
            {
                return configs.AccessToken;
            }
        }

        public string ForceRefreshAccessToken(IHttpClientFactory httpClientFactory)
        {
            var configs = GetConfigs(shopId: 1);
            var tokenInfo = EleOAuth.GetRefreshToken(httpClientFactory, configs.RefershToken);
            if (string.IsNullOrEmpty(tokenInfo.access_token))
            {
                //刷新token也过期了需要重新授权了
                return "token error";
            }

            configs.AccessToken = tokenInfo.access_token;
            configs.RefershToken = tokenInfo.refresh_token;
            configs.ExpiresTime = DateTime.Now.AddSeconds(Convert.ToDouble(tokenInfo.expires_in) - 1000);
            _Conn.Update<O2OConfigs>(configs);
            return tokenInfo.access_token;
        }
    }
}
