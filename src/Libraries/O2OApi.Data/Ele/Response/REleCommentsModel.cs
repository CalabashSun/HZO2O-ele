using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Response
{
    public class REleCommentsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ResultItem> result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error { get; set; }
    }

    public class ResultItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rating { get; set; }
        /// <summary>
        /// 非常好吃
        /// </summary>
        public string rateContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ratedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<ItemRatesItem> itemRates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public OrderRateReply orderRateReply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public RateTag rateTag { get; set; }
    }

    public class ItemRatesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string itemRateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemId { get; set; }
        /// <summary>
        /// 土豆
        /// </summary>
        public string itemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rating { get; set; }
        /// <summary>
        /// 非常好吃
        /// </summary>
        public string rateContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ratedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<string>> pictures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RateReply rateReply { get; set; }
    }

    public class RateReply
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rateId { get; set; }
        /// <summary>
        /// 十分感谢
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string replierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rateType { get; set; }
    }

    public class OrderRateReply
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rateId { get; set; }
        /// <summary>
        /// 十分感谢
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string replierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rateType { get; set; }
    }

    public class RateTag
    {
        /// <summary>
        /// 
        /// </summary>
        public string rateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string orderId { get; set; }
        /// <summary>
        /// 态度很好,准时送达,送货上门
        /// </summary>
        public string tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<string>> tagList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopId { get; set; }
    }

    public class HandleComment
    {
        public long shopId { get; set; }

        public string shopName { get; set; }

        public List<ResultItem> commentResult { get; set; }=new List<ResultItem>();
    }

    /// <summary>
    /// 星选评价
    /// </summary>
    public class REleRateCommentsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RateResult result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error { get; set; }
    }

    public class RateResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<RateInfoItem> rateInfo { get; set; }
    }

    public class RateInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        //public string shopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OrderRateInfoItem> orderRateInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string orderItemRateInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string imageUrls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string dataType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public bool baiduIsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string baiduDeleteTime { get; set; }
    }

    public class OrderRateInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string rateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? serviceRating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? qualityRating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string packageRating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ratingContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ratingAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string replied { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string replyAt { get; set; }
        /// <summary>
        /// 亲爱的顾客，感谢您选择品尝本店的美食，谢谢您认可我们的口味和服务，我们会继续努力，为您提供更好的服务。祝您生活愉快！
        /// </summary>
        public string replyContent { get; set; }
    }


    public class RateHandleComment
    {
        public long shopId { get; set; }

        public string shopName { get; set; }

        public List<RateInfoItem> commentResult { get; set; } = new List<RateInfoItem>();
    }


}
