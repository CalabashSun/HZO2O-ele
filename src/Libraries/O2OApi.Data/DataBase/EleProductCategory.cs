using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace O2OApi.Data.DataBase
{
    [Table("EleProductCategory")]
    public class EleProductCategory:BaseEntity
    {
        public long ShopId { get; set; }

        public long CateId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int IsValid { get; set; }

        public string CategoryType { get; set; }
    }
}
