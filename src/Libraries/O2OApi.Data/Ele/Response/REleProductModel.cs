using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace O2OApi.Data.Ele.Response
{

    #region 获取商品分类
    public class RProductCate : REleBaseModel
    {
        public List<RCates> result { get; set; }
    }

    public class RCates
    {
        /// <summary>
        /// 商品分类Id
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 商品分类描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public int isValid { get; set; }
        /// <summary>
        /// 一级分类父分类ID为0，二级分类父分类ID为一级分类ID
        /// </summary>
        public long parentId { get; set; }
        /// <summary>
        /// 分类类型
        /// </summary>
        public string categoryType { get; set; }
        /// <summary>
        /// 下级分类信息
        /// </summary>
        public List<RCates> children { get; set; }

    }

    #endregion

    #region 根据商品分类获取分类下所有商品

    public class RItemDetails
    {
        public Dictionary<string, RItemDetail> result { get; set; }
    }

    public class RItemDetail
    {
        /// <summary>
        /// 香脆可口，外焦里嫩
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 白切鸡
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isValid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int recentPopularity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long categoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int shopId { get; set; }
        /// <summary>
        /// 烤鸡大王
        /// </summary>
        public string shopName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RItemLabels labels { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RItemSpecsItem> specs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RItemSellingTime sellingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RItemAttributes> attributes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int backCategoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int minPurchaseQuantity { get; set; }
        /// <summary>
        /// 份
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int setMeal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RItemMaterials> materials { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> imageUrls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RItemVideo video { get; set; }
    }

    /// <summary>
    /// 商品标签
    /// </summary>
    public class RItemLabels
    {
        /// <summary>
        /// 
        /// </summary>
        public int isFeatured { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isGum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isNew { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isSpicy { get; set; }
    }


    /// <summary>
    /// 商品规格的列表
    /// </summary>
    public class RItemSpecsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long specId { get; set; }
        /// <summary>
        /// 大份
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int stock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int maxStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int stockStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal packingFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int onShelf { get; set; }
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
        public int weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int activityLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RItemSupplyLink supplyLink { get; set; }
    }
    public class RItemSupplyLink
    {
        /// <summary>
        /// 代表冷链
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RItemMinorSpecItem> minorSpec { get; set; }
    }
    public class RItemMinorSpecItem
    {
        /// <summary>
        /// 度
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> value { get; set; }
    }
    /// <summary>
    /// 商品售卖时间
    /// </summary>
    public class RItemSellingTime
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> weeks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string beginDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RItemTimesItem> times { get; set; }
    }

    public class RItemTimesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string beginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endTime { get; set; }
    }

    /// <summary>
    /// 商品属性
    /// </summary>
    public class RItemAttributes
    {
        public string name { get; set; }

        public List<string> details { get; set; }
    }

    /// <summary>
    /// 原材料
    /// </summary>
    public class RItemMaterials
    {
        public long id { get; set; }

        public string name { get; set; }
    }

    /// <summary>
    /// 商品视频信息
    /// </summary>
    public class RItemVideo
    {
        /// <summary>
        /// 视频时长
        /// </summary>
        public long duration { get; set; }
        /// <summary>
        /// 视频id
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 视频大小
        /// </summary>
        public long sizeInByte { get; set; }
        /// <summary>
        /// 视频缩略图
        /// </summary>
        public string thumbnail { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string url { get; set; }
    }


    #endregion

    #region 获取商户所有商品

    public class RProductPages
    {
        public List<RItemDetail> result { get; set; }
    }

    #endregion
}
