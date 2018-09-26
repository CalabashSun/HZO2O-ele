using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace O2OApi.Data.DataBase
{
    [Table("EleOrderProduct")]
    public class EleOrderProduct:BaseEntity
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public long OrderProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public string Attributes { get; set; }

        public string NewSpecs { get; set; }

        public decimal UserPrice { get; set; }

        public decimal ShopPrice { get; set; }
    }
}
