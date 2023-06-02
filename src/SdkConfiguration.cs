using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYS_SDK.src
{
    public class SdkConfiguration
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }

        public SdkConfiguration(string apiKey, string baseUrl)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }
    }
}
