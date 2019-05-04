using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using O2OApi.Data.Ele.Response;
using O2OApi.Services.DataServices;
using O2OApi.Services.Ele;

namespace O2OApi.Web.Areas.ELE.Controllers
{
    [Area("Ele")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IO2OConfigService _o2OConfigService;

        public CommentController(IHttpClientFactory httpClientFactory,
            IO2OConfigService o2OConfigService)
        {
            _httpClientFactory = httpClientFactory;
            _o2OConfigService = o2OConfigService;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 最近7天评价
        /// </summary>
        /// <returns></returns>
        public IActionResult LastSeven()
        {
            var shopConfig= _o2OConfigService.GetConfigs(shopId: 1);
            var result = new List<HandleComment>();
            var shopUsers = EleShops.ShopInfos(_httpClientFactory, shopConfig);
            if (shopUsers.result.authorizedShops.Count > 0)
            {
                foreach (var shopUser in shopUsers.result.authorizedShops)
                {
                    var mdComment=new HandleComment
                    {
                        shopId = shopUser.id,
                        shopName = shopUser.name
                    };
                    bool hasData = true;
                    int pageIndex = 0;
                    while (hasData)
                    {
                        var cuurentInfo = EleComments.LastSevenComments(_httpClientFactory, shopConfig,shopUser.id.ToString(), pageIndex, 20);
                        if (cuurentInfo.result.Count > 0)
                        {

                            mdComment.commentResult.AddRange(cuurentInfo.result);
                        }

                        if (cuurentInfo.result.Count < 20)
                        {
                            hasData = false;
                        }
                        else
                        {
                            pageIndex=pageIndex+20;
                        }
                    }
                    result.Add(mdComment);
                }
            }
            return Content(JsonConvert.SerializeObject(result));
        }
        /// <summary>
        /// 指定日期评价
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IActionResult AssignDate(string start, string end)
        {
            var startDate = Convert.ToDateTime(start);
            var endDate = Convert.ToDateTime(end);
            var shopConfig = _o2OConfigService.GetConfigs(shopId: 1);
            var result = new List<HandleComment>();
            var shopUsers = EleShops.ShopInfos(_httpClientFactory, shopConfig);
            if (shopUsers.result.authorizedShops.Count > 0)
            {
                foreach (var shopUser in shopUsers.result.authorizedShops)
                {
                    var mdComment = new HandleComment
                    {
                        shopId = shopUser.id,
                        shopName = shopUser.name
                    };
                    bool hasData = true;
                    int pageIndex = 0;
                    while (hasData)
                    {
                        var cuurentInfo = EleComments.AssignComments(_httpClientFactory, shopConfig, shopUser.id.ToString(),startDate,endDate,pageIndex, 20);
                        if (cuurentInfo.result.Count > 0)
                        {
                            mdComment.commentResult.AddRange(cuurentInfo.result);
                        }

                        if (cuurentInfo.result.Count < 20)
                        {
                            hasData = false;
                        }
                        else
                        {
                            pageIndex = pageIndex + 20;
                        }
                    }
                    result.Add(mdComment);
                }
            }
            return Content(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 指定日期星选评价
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IActionResult AssignDateRate(string start, string end)
        {
            var startDate = Convert.ToDateTime(start);
            var endDate = Convert.ToDateTime(end);
            var shopConfig = _o2OConfigService.GetConfigs(shopId: 1);
            var result = new List<RateHandleComment>();
            var shopUsers = EleShops.ShopInfos(_httpClientFactory, shopConfig);
            if (shopUsers.result.authorizedShops.Count > 0)
            {
                foreach (var shopUser in shopUsers.result.authorizedShops)
                {
                    var mdComment = new RateHandleComment
                    {
                        shopId = shopUser.id,
                        shopName = shopUser.name
                    };
                    bool hasData = true;
                    int pageIndex = 0;
                    while (hasData)
                    {
                        var cuurentInfo = EleComments.AssignRateComments(_httpClientFactory, shopConfig, shopUser.id, startDate, endDate, pageIndex, 20);
                        if (cuurentInfo.result!=null && cuurentInfo.result.rateInfo.Count>0)
                        {
                            mdComment.commentResult.AddRange(cuurentInfo.result.rateInfo);
                        }

                        if ((cuurentInfo.result!=null&&cuurentInfo.result.rateInfo.Count < 20)||cuurentInfo.result==null)
                        {
                            hasData = false;
                        }
                        else
                        {
                            pageIndex = pageIndex + 20;
                        }
                    }
                    result.Add(mdComment);
                }
            }
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}