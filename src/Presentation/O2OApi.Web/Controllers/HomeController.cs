using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using O2OApi.Core;
using O2OApi.Data.DataBase;
using O2OApi.Services.DataServices;
using O2OApi.Services.Ele;
using O2OApi.Web.Models;

namespace O2OApi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IO2OConfigService _o2OConfigService;

        public HomeController(IHttpClientFactory httpClientFactory,
            IO2OConfigService o2OConfigService)
        {
            _httpClientFactory = httpClientFactory;
            _o2OConfigService = o2OConfigService;
        }

        public IActionResult Index(string code, long state)
        {
            var content = "汉资餐饮:饿了么（商家开放平台）";
            if (!string.IsNullOrEmpty(code))
            {
                 content= GetAccessToken(code,state);

            }
            return Content(content);
        }

        public IActionResult GetEleCode(long shopId)
        {
            var eleConfig = _o2OConfigService.GetConfigs(shopId: shopId);
            if (eleConfig != null)
            {
                var url = EleOAuth.GetOAuthUrl(eleConfig);
                return Redirect(url);
            }
            else
            {
                return Content("请联系管理员录入数据");
            }
        }
         

        private string GetAccessToken(string code,long state)
        {
            var result = EleOAuth.GetAccessToken(_httpClientFactory,code);
            if (!string.IsNullOrEmpty(result.access_token))
            {
                var eleConfig = _o2OConfigService.GetConfigs(shopId:state);
                if (eleConfig != null)
                {
                    eleConfig.AccessToken = result.access_token;
                    eleConfig.RefershToken = result.refresh_token;
                    eleConfig.ExpiresTime = DateTime.Now.AddSeconds(Convert.ToDouble(result.expires_in) - 1000);
                    _o2OConfigService.Update(eleConfig);
                }
            }
            return "汉资餐饮:商家已授权";
        }

        public IActionResult RefeshToken(string key)
        {
            if (key != "refreshhanztoken")
                return Content("error!");
            try
            {
                _o2OConfigService.ForceRefreshAccessToken(_httpClientFactory);
                return Content("token更新成功");
            }
            catch
            {
                return Content("token更新失败请及时处理");
            }

        }

        public IActionResult UseCommonHelper()
        {
            var pathInfo = CommonHelper.DefaultFileProvider.MapPath("~/cala");
            return Content(pathInfo);
        }

    }
}
