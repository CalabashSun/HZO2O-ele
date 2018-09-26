using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Core.Configuration
{
    public static class EleAction
    {
        /// <summary>
        /// 查询店铺商品分类
        /// </summary>
        public static string shopCate = "eleme.product.category.getShopCategories";

        public static string shopProductCate = "eleme.product.item.getItemsByCategoryId";

        public static string shopProductPages = "eleme.product.item.queryItemByPage";
    }
}
