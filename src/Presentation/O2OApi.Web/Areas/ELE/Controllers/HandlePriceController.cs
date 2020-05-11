using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using O2OApi.Data.DataBase;
using O2OApi.Data.Ele.Receive;
using O2OApi.Services.DataServices;

namespace O2OApi.Web.Areas.ELE.Controllers
{
    [Area("Ele")]
    public class HandlePriceController : Controller
    {
        private readonly IEleOrderLogService _orderLogService;
        private readonly IEleOrderPriceService _eleOrderPriceService;


        public HandlePriceController(IEleOrderLogService orderLogService,
            IEleOrderPriceService eleOrderPriceService)
        {
            _orderLogService = orderLogService;
            _eleOrderPriceService = eleOrderPriceService;
        }

        public IActionResult Index()
        {
            var logList = _orderLogService.GetOrderLogs();
            if (logList != null && logList.Count > 0)
            {
                var cancelOrders = _orderLogService.GetCancelOrder();
                foreach (var eleOrderLog in logList)
                {
                    //解析json
                    var orderBase = JsonConvert.DeserializeObject<RecieveMsgBase>(eleOrderLog.OrderContext);
                    var orderDetail = JsonConvert.DeserializeObject<OrderProcess>(eleOrderLog.OrderDetail);
                    var orderPrice = new ElePriceInfo
                    {
                        ShopId = orderBase.shopId,
                        ShopName = orderDetail.shopName,
                        OrderId = orderDetail.orderId.ToString(),
                        DaySeq = orderDetail.daySn,
                        Total = orderDetail.totalPrice,
                        ActualTotal = orderDetail.originalPrice - orderDetail.deliverFee,
                        OriginalPrice = orderDetail.originalPrice,
                        IsCanceled = cancelOrders.Where(p=>p.OrderId== orderDetail.orderId).Count()>0,
                        CreatedAt = Convert.ToDateTime(orderDetail.createdAt)
                    };
                    orderPrice.ActualReceive = decimal.Round((decimal)orderDetail.income, 2);
                    orderPrice.ServiceFee = decimal.Round((decimal)orderDetail.serviceFee, 2)*-1;
                    orderPrice.DiscountAmount = decimal.Round(Convert.ToDecimal(orderDetail.shopPart), 2)*-1; 
                    orderPrice.CreateTime = DateTime.Now;
                    _eleOrderPriceService.Add(orderPrice);
                }
            }
            _orderLogService.SetHandeled();
            return Content("success");
        }
    }
}