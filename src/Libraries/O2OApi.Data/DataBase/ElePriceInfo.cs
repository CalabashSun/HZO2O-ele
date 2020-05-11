using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.DataBase
{
    [Table("ElePriceInfo")]
    public class ElePriceInfo:BaseEntity
    {

        public string ShopId { get; set; }

        public string ShopName { get; set; }

        public string OrderId { get; set; }

        public int? DaySeq { get; set; }

        public decimal? Total { get; set; }

        public decimal? ActualTotal { get; set; }

        public decimal? OriginalPrice { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? ServiceFee { get; set; }

        public decimal? ActualReceive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? IsCanceled { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? CreateTime { get; set; }



    }

}
