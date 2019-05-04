using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Data.Ele.Submit
{
    /// <summary>
    /// 普通评价实体类
    /// </summary>
    public class SEleCommentsModel : SEleBaseModel
    {
        public SEleCommentsModelInfo @params { get; set; }
    }

    public class SEleCommentsModelInfo 
    {
        public string shopId { get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }

        public int offset { get; set; }

        public int pageSize { get; set;}
    }

    /// <summary>
    /// 星选评价实体类
    /// </summary>
    public class SEleRateCommentsModel : SEleJsonBaseModel
    {
        public SEleRateCommentsModelInfo @params { get; set; }
    }

    public class SEleRateCommentsModelInfo
    {
        public SEleRateCommentsModelJson rateQuery { get; set; }
    }

    public class SEleRateCommentsModelJson
    {
        public long shopId { get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }

        public int offset { get; set; }

        public int pageSize { get; set; }
    }
}
