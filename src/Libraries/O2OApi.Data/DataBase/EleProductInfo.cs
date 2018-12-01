using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace O2OApi.Data.DataBase
{
    [Table("EleProductInfo")]
    public class EleProductInfo:BaseEntity
    {
        public long ShopId { get; set; }

        public string ShopName { get; set; }

        public long CateId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int IsValid { get; set; }

        public int RecentPopularity { get; set; }

        public DateTime CreateTime { get; set; }

        public string Zp_ProductId { get; set; }

        public string Zp_ProductName { get; set; }

        public DateTime? UpdateTime { get; set; }
    }


    public class TempEleProductInfo : EleProductInfo
    {
        public int DealState { get; set; } = 0;
    }
}
