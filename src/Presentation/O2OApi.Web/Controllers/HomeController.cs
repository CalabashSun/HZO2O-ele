using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult GetEleCode(string shopId)
        {
            var url = EleOAuth.GetOAuthUrl(shopId);
            return Redirect(url);
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
    }
}
