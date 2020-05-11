using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using O2OApi.Services.DataServices;
using O2OApi.Services.Ele;

namespace O2OApi.Web.Areas.ELE.Controllers
{
    [Area("Ele")]
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IO2OConfigService _o2OConfigService;


        public ShopController(IHttpClientFactory httpClientFactory
            , IO2OConfigService o2OConfigService)
        {
            _httpClientFactory = httpClientFactory;
            _o2OConfigService = o2OConfigService;
        }

        public IActionResult Index()
        {
            var shopConfig = _o2OConfigService.GetConfigs(shopId: 1);
            var shopUsers = EleShops.ShopInfos(_httpClientFactory, shopConfig);

            return Content(JsonConvert.SerializeObject(shopUsers));
        }

        public IActionResult RefreshToken()
        {
            var result = _o2OConfigService.RefreshAccessToken(_httpClientFactory);
            return Content(result == "error" ? "error" : "success");
        }

        public IActionResult LeXiangToken(string appkey,string appSecret) 
        {
            var reuslt = _o2OConfigService.GetLeXiangAccessToken(_httpClientFactory, appkey, appSecret);
            return Content(reuslt);
        }
    }
}