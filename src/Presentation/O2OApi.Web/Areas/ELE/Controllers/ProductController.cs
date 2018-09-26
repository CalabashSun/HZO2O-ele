using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using O2OApi.Core;
using O2OApi.Core.Configuration;
using O2OApi.Data.DataBase;
using O2OApi.Data.Ele.Submit;
using O2OApi.Services.DataServices;
using O2OApi.Services.Ele;

namespace O2OApi.Web.Areas.ELE.Controllers
{
    [Area("Ele")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IO2OConfigService _o2OConfigService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IEleProductInfoService _productInfoService;



        public ProductController(
            IHttpClientFactory httpClientFactory
            , IO2OConfigService o2OConfigService
            , IProductCategoryService productCategoryService
            , IEleProductInfoService productInfoService)
        {
            _httpClientFactory = httpClientFactory;
            _o2OConfigService = o2OConfigService;
            _productCategoryService = productCategoryService;
            _productInfoService = productInfoService;
        }

        public IActionResult Index()
        {
            return Content("pllo");
        }
        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public IActionResult ProductCates(long shopId)
        {
            var config = _o2OConfigService.GetConfigs("ele");
            var infos = EleProducts.ProductCate(_httpClientFactory, shopId, config);

            if (infos!=null&&infos.result.Count > 0)
            {
                _productCategoryService.DeleteCate(shopId:shopId);
                foreach (var rCatese in infos.result)
                {
                    var cate = new EleProductCategory
                    {
                        ShopId = shopId,
                        CateId = rCatese.id,
                        Name = rCatese.name,
                        Description = rCatese.description,
                        IsValid = rCatese.isValid,
                        CategoryType = rCatese.categoryType
                    };
                    _productCategoryService.Add(cate);
                }
            }

            return Content(JsonConvert.SerializeObject(infos));
        }
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="cateId"></param>
        /// <returns></returns>
        public IActionResult ProductInfoByCateResult(long cateId)
        {
            var config = _o2OConfigService.GetConfigs("ele");
            var infos = EleProducts.ProductCate(_httpClientFactory, cateId, config);
            return Content(JsonConvert.SerializeObject(infos));
        }
        /// <summary>
        /// 分页获取所有商品
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public IActionResult ProductPages(long shopId)
        {
            var config = _o2OConfigService.GetConfigs(shopId:shopId);
            var accessToken= _o2OConfigService.RefreshAccessToken(httpClientFactory: _httpClientFactory, configs: config);
            var infos = EleProducts.ProductPage(_httpClientFactory, shopId, config,accessToken);

            //获取商品信息
            if (infos != null && infos.result.Count > 0)
            {
                _productInfoService.DeleteProduct(shopId);
                foreach (var rItemDetail in infos.result)
                {
                    var productInfo = new EleProductInfo
                    {
                        CateId = rItemDetail.categoryId,
                        IsValid = rItemDetail.isValid,
                        ProductId = rItemDetail.id,
                        ProductName = rItemDetail.name,
                        ProductPrice = rItemDetail.specs[0].price,
                        RecentPopularity = rItemDetail.recentPopularity,
                        ShopId = shopId
                    };
                    _productInfoService.Add(productInfo);
                }
            }

            return Content(JsonConvert.SerializeObject(infos));
        }
    }
}