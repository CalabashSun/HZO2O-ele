using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Submit
{
    public class SEleBaseModel
    {
        /// <summary>
        /// 标示协议版本，固定为 1.0.0
        /// </summary>
        public string nop { get; set; } = "1.0.0";
        /// <summary>
        /// guid
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 公共参数
        /// </summary>
        public Metas metas { get; set; }=new Metas();
        /// <summary>
        /// 接口名称
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// access_token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string signature { get; set; }

    }

    public class Metas
    {
        /// <summary>
        /// 应用的app key
        /// </summary>
        public string app_key { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }= ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
    }
}
