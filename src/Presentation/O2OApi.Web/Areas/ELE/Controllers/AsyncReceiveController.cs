using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using O2OApi.Core.Helper;
using O2OApi.Data.DataBase;
using O2OApi.Data.Ele.Receive;
using O2OApi.Services.DataServices;

namespace O2OApi.Web.Areas.ELE.Controllers
{
    [Area("Ele")]
    public class AsyncReceiveController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IEleOrderInfoService _orderInfoService;
        private readonly IEleOrderProductService _orderProductService;


        public AsyncReceiveController(IHttpClientFactory httpClientFactory
        , IEleOrderInfoService orderInfoService
        , IEleOrderProductService orderProductService
            )
        {
            _httpClientFactory = httpClientFactory;
            _orderInfoService = orderInfoService;
            _orderProductService = orderProductService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("{\"message\":\"ok\"}");
        }
        [HttpPost]
        public IActionResult Index([FromBody]RecieveMsgBase model)
        {
            if (model == null)
            {
                return Content("{\"message\":\"ok\"}");
            }

            var jsonResult = JsonConvert.SerializeObject(model);
            LogsHelper.WriteLog(jsonResult);
            //用户下订单
            if (model.type == 10)
            {
                OrderProcessing(model);
            }

            return Content("{\"message\":\"ok\"}");
        }

        public IActionResult Hello()
        {
            return Content("hello");
        }

        private void OrderProcessing(RecieveMsgBase model)
        {

            var orderData = JsonConvert.DeserializeObject<OrderProcess>(model.message,new JsonSerializerSettings{StringEscapeHandling=StringEscapeHandling.EscapeNonAscii});
            //应该先判断是否存在orderId的
            if (_orderInfoService.GetEleOrderInfoService(orderData.orderId) == null)
            {
                //处理订单数据
                var orderInfo = new EleOrderInfo();
                orderInfo.OrderId = orderData.orderId;
                orderInfo.Address = orderData.address;
                orderInfo.CreatedAt = Convert.ToDateTime(orderData.createdAt);
                orderInfo.ActiveAt = Convert.ToDateTime(orderData.activeAt);
                orderInfo.DeliverFee = orderData.deliverFee;
                orderInfo.DeliverTime = null;
                orderInfo.Description = orderData.description;
                orderInfo.Invoice = orderData.invoice;
                orderInfo.Phone = orderData.phoneList[0];
                orderInfo.ShopId = model.shopId;
                orderInfo.ShopName = orderData.shopName;
                orderInfo.Status = model.type.ToString();

                _orderInfoService.Add(orderInfo);
                foreach (var orderProductInfo in orderData.groups)
                {
                    foreach (var orderProductItem in orderProductInfo.items)
                    {
                        var orderProduct = new EleOrderProduct();
                        orderProduct.OrderId = orderData.orderId;
                        orderProduct.OrderProductId = orderProductItem.id;
                        orderProduct.ProductId = orderProductItem.vfoodId;
                        orderProduct.Price = orderProductItem.price;
                        orderProduct.Quantity = orderProductItem.quantity;
                        orderProduct.Total = orderProductItem.total;
                        //商品属性是否存在值
                        if (orderProductItem.attributes != null && orderProductItem.attributes.Count > 0)
                        {
                            var attributes = "";
                            foreach (var attributesItem in orderProductItem.attributes)
                            {
                                attributes += attributesItem.name + ":" + attributesItem.value + ",";
                            }
                            orderProduct.Attributes = attributes;
                        }

                        if (orderProductItem.newSpecs != null && orderProductItem.newSpecs.Count > 0)
                        {
                            var specs = "";
                            foreach (var newSpecsItem in orderProductItem.newSpecs)
                            {
                                specs += newSpecsItem.name + ":" + newSpecsItem.value + ",";
                            }

                            orderProduct.NewSpecs = specs;
                        }

                        orderProduct.UserPrice = orderProductItem.userPrice;
                        orderProduct.ShopPrice = orderProductItem.shopPrice;
                        _orderProductService.Add(orderProduct);
                    }

                }
            }
        }

        public IActionResult TestConvertData()
        {
            var client = _httpClientFactory.CreateClient();
            //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
            //var result =client.GetAsync("https://www.dongdongmm.com:444/ordertext.html").Result.Content.ReadAsStringAsync().Result;
            var result = Encoding.GetEncoding("GBK").GetString(client.GetAsync("https://www.dongdongmm.com:444/ordertext.html")
                .Result.Content.ReadAsByteArrayAsync().Result);
            var baseData = JsonConvert.DeserializeObject<RecieveMsgBase>(result, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });
            OrderProcessing(model:baseData);
            return Content("success");

        }
    }
}