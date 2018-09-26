using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace O2OApi.Data.DataBase
{
    [Table("Config")]
    public class O2OConfigs:BaseEntity
    {
        /// <summary>
        /// 门店id
        /// </summary>
        public long ShopId { get; set; }

        /// <summary>
        /// o2o名称
        /// </summary>
        public string Name { get; set; }
        public string AppKey { get; set; }

        public string AppSecret { get; set; }

        public string AccessToken { get; set; }

        public string InterUrl { get; set; }

        public string RefershToken { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpiresTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
