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

        public long CateId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int IsValid { get; set; }

        public int RecentPopularity { get; set; }
    }
}
