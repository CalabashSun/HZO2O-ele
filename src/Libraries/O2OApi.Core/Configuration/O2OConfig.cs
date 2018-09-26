using System;
using System.Collections.Generic;
using System.Text;

namespace O2OApi.Core.Configuration
{
    public class O2OConfig
    {
        public Ele Ele { get; set; }
    }

    public class Ele
    {
        public string appkey { get; set; }

        public string appsecret { get; set; }

        public string url { get; set; }
    }
}
