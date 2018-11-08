using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace O2OApi.Data.DataBase
{
    [Table("EleOrderLog")]
    public class EleOrderLog:BaseEntity
    {
        public string RequestId { get; set; }

        public string OrderContext { get; set; }

        public string OrderDetail { get; set; }

        public DateTime CreateTime { get; set; }

        public int OrderType { get; set; }
    }
}
