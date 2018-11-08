using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Receive
{
    public class RecieveMsgBase
    {
        public long appId { get; set; }

        public string requestId { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public int type { get; set; }

        public string message { get; set; }

        public string shopId { get; set; }

        public string timestamp { get; set; }
        /// <summary>
        /// 授权商户的账号id，商户身份标识
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string signature { get; set; }
    }

    #region 订单详细信息
    public class OrderProcess
    {
        public long orderId { get; set; }

        public string address { get; set; }

        public string createdAt { get; set; }

        public string activeAt { get; set; }

        public decimal deliverFee { get; set; }

        public string deliverTime { get; set; }

        public string description { get; set; }

        public List<OrderProductInfo> groups { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string invoice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string book { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string onlinePaid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string railwayAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> phoneList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long shopId { get; set; }
        /// <summary>
        /// 饿了吗平台对接测试店铺
        /// </summary>
        public string shopName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int daySn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refundStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userIdStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal totalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal originalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string consignee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deliveryGeo { get; set; }
        /// <summary>
        /// 东平国家森林公园-知青广场1002
        /// </summary>
        public string deliveryPoiAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string invoiced { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double income { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double serviceRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double serviceFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal hongbao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal packageFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal activityTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopPart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string elemePart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string downgraded { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal vipDeliveryFeeDiscount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string secretPhoneExpireTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> orderActivities { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string invoiceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string taxpayerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal coldBoxFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cancelOrderDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cancelOrderCreatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> orderCommissions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baiduWaimai { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserExtraInfo userExtraInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> consigneePhones { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string superVip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string confirmCookingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OrderActivityPartsItem> orderActivityParts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int orderBusinessType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pickUpTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pickUpNumber { get; set; }
    }

    public class OrderProductInfo
    {
        public string name { get; set; }

        public string type { get; set; }

        public List<OrderProductItem> items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> relatedItems { get; set; }
    }

    public class UserExtraInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string giverPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string greeting { get; set; }
    }

    public class OrderProductItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 奶茶
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long categoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> additions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<NewSpecsItem> newSpecs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AttributesItem> attributes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extendCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string barCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal userPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal shopPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long vfoodId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> ingredients { get; set; }
    }

    public class NewSpecsItem
    {
        /// <summary>
        /// 杯型
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 大杯
        /// </summary>
        public string value { get; set; }
    }

    public class AttributesItem
    {
        /// <summary>
        /// 加冰
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 少冰
        /// </summary>
        public string value { get; set; }
    }

    public class IngredientsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string skuCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
    }

    public class OrderActivityPartsItem
    {
        /// <summary>
        /// 优惠总计
        /// </summary>
        public string partName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal partValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal weight { get; set; }
    }
    #endregion

}
