using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Submit
{
    #region 获取商品分类
    public class SProductCate : SEleBaseModel
    {
        public ShopCategories @params { get; set; }
    }

    public class ShopCategories
    {
        public long shopId { get; set; }
    }
    #endregion


    #region 根据商品分类获取分类下所有商品

    public class SItemsByCategoryId : SEleBaseModel
    {
        public ItemByCateId @params { get; set; }
    }

    public class ItemByCateId
    {
        public long categoryId { get; set; }
    }

    #endregion

    #region 获取商户下所有商品


    public class SProductInfoPage: SEleBaseModel
    {
        public ProductQueryPages @params { get; set; }
    }

    public class ProductQueryPages
    {
        public ProductQueryPage queryPage { get; set; }=new ProductQueryPage();
    }

    public class ProductQueryPage
    {
        public long shopId { get; set; }

        public long offset { get; set; }

        public long limit { get; set; }
    }

    #endregion
}
