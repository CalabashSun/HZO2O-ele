using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Response
{
    public class REleBaseModel
    {
        /// <summary>
        /// guid
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public ErrorMsg error { get; set; }=new ErrorMsg();
    }

    public class ErrorMsg
    {
        public string code { get; set; }

        public string message { get; set; }
    }
}
