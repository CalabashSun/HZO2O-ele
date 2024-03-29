﻿using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace O2OApi.Data.DataBase
{
    [Table("EleOrderInfo")]
    public class EleOrderInfo:BaseEntity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 用户收获地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 用户下单时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public DateTime? ActiveAt { get; set; }
        /// <summary>
        /// 派送费
        /// </summary>
        public decimal DeliverFee { get; set; }
        /// <summary>
        /// 派送时间
        /// </summary>
        public DateTime? DeliverTime { get; set; }

        public string Description { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string Invoice { get; set; }

        public string Phone { get; set; }

        public string ShopId { get; set; }
        /// <summary>
        /// 日第几单
        /// </summary>
        public string DaySeq { get; set; }

        public string Status { get; set; }

        public decimal Income { get; set; }

        public decimal ServiceFee { get; set; }

        public decimal HongBao { get; set; }

        public decimal PackageFee { get; set; }

        public DateTime? CancelOrderDescription { get; set; }

        public DateTime? CancelOrderCreatedAt { get; set; }

        public int DinnersNumber { get; set; } = 1;
        /// <summary>
        /// 除配送费的商品原价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 商家实收
        /// </summary>
        public decimal WmPoiReceive { get; set; }
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

    }
}
