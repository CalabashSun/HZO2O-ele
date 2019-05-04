using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Response
{
    public class REleShopsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShopInfos result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error { get; set; }
    }

    public class ShopInfos
    {
        /// <summary>
        /// 
        /// </summary>
        public long userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AuthorizedShopsItem> authorizedShops { get; set; }
    }

    public class AuthorizedShopsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 烤鸭大王
        /// </summary>
        public string name { get; set; }
    }


}
