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
using O2OApi.Data.Ele.Response;
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
        /// <param name="zpShopId"></param>
        /// <returns></returns>
        public IActionResult ProductPages(string zpShopId)
        {
            if (string.IsNullOrEmpty(zpShopId))
                return Content("门店id不允许为空！");
            var config = _o2OConfigService.GetConfigsByZpShopId(zpShopId);
            if (config == null)
                return Content("门店信息不存在！");
            var accessToken= _o2OConfigService.RefreshAccessToken(_httpClientFactory);
            if (accessToken == "error")
            {
                return RedirectToAction("GetEleCode","Home",new{ shopId = config.ShopId});
            }

            RProductPages infos;
            try
            {
                infos = EleProducts.ProductPage(_httpClientFactory, config.ShopId, config, accessToken);
            }
            catch
            {
                return Content("菜品更新失败，请联系IT部处理");
            }


            //获取商品信息
            if (infos != null && infos.result.Count > 0)
            {
                //重写录入菜品方法
                var productList = _productInfoService.ListProductInfo(config.ShopId);
                if (productList != null && productList.Any())
                {
                    foreach (var rItemDetail in infos.result)
                    {
                        var exist = productList.FirstOrDefault(p =>
                            p.ProductName == rItemDetail.name && p.ShopId == config.ShopId);
                        //存在该商品
                        if (exist != null)
                        {
                            if (exist.ProductPrice == rItemDetail.specs[0].price)
                            {
                                exist.DealState = 1;
                                continue;
                            }//数据变更
                            else
                            {
                                //构建新数据
                                var productInfo = new EleProductInfo
                                {
                                    CateId = rItemDetail.categoryId,
                                    IsValid = rItemDetail.isValid,
                                    ProductId = rItemDetail.id,
                                    ProductName = rItemDetail.name,
                                    ProductPrice = rItemDetail.specs[0].price,
                                    RecentPopularity = rItemDetail.recentPopularity,
                                    ShopId = config.ShopId,
                                    ShopName = rItemDetail.shopName,
                                    CreateTime = DateTime.Now
                                };
                                _productInfoService.Add(productInfo);
                            }
                        }
                        else
                        {
                            //构建新数据
                            var productInfo = new EleProductInfo
                            {
                                CateId = rItemDetail.categoryId,
                                IsValid = rItemDetail.isValid,
                                ProductId = rItemDetail.id,
                                ProductName = rItemDetail.name,
                                ProductPrice = rItemDetail.specs[0].price,
                                RecentPopularity = rItemDetail.recentPopularity,
                                ShopId = config.ShopId,
                                ShopName = rItemDetail.shopName,
                                CreateTime = DateTime.Now
                            };
                            _productInfoService.Add(productInfo);
                        }


                    }
                    //获取删除的数据
                    var deleteFoods = productList.Where(p => p.DealState == 0 && p.ProductId!=0);
                    foreach (var tempMeiTProductInfo in deleteFoods)
                    {
                        var deleteFood = (EleProductInfo)tempMeiTProductInfo;
                        _productInfoService.Remove(deleteFood);
                    }
                }
                else
                {
                    //直接批量添加

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
                            ShopId = config.ShopId,
                            ShopName = rItemDetail.shopName,
                            CreateTime = DateTime.Now
                        };
                        _productInfoService.Add(productInfo);
                    }
                }

            }

            return Content("数据更新成功");
        }
    }
}
