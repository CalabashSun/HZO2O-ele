using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Core.Enums
{
    public enum EleReceiveType
    {
        /// <summary>
        /// 订单生效
        /// </summary>
        OrderTakingEffect=10,
        /// <summary>
        /// 商户接单
        /// </summary>
        OrderedMerchant = 12,
        /// <summary>
        /// 订单被取消
        /// </summary>
        OrderCancel=14,
        /// <summary>
        /// 订单被置为无效
        /// </summary>
        OrderInvalid=15,
        /// <summary>
        /// 订单强制无效
        /// </summary>
        OrderInvalidForce=17,
        /// <summary>
        /// 订单完结
        /// </summary>
        OrderEnd=18,
        /// <summary>
        /// 用户申请取消
        /// </summary>
        OrderCancelUser=20,
        /// <summary>
        /// 用户取消取消申请
        /// </summary>
        OrderUserCancelApply=21,
        /// <summary>
        /// 商家拒绝取消
        /// </summary>
        OrderRefuseCancel=22,
        /// <summary>
        /// 商家同意取消
        /// </summary>
        OrderAgreeCancel=23
    }
}
