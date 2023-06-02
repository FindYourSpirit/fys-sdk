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
        public string JwtToken { get; set; }
        public string ClientID { get; set; }
        public EnvironmentType Environment { get; set; }  // New property to specify the environment

        public SdkConfiguration(string apiKey, EnvironmentType environment, string jwtToken, string clientID)
        {
            ApiKey = apiKey;
            Environment = environment;
            JwtToken = jwtToken;
            ClientID = clientID;
        }

        public string GetBaseUrl()
        {
            switch (Environment)
            {
                case EnvironmentType.Live:
                    return "https://api.live.fysapp.co";
                case EnvironmentType.Test:
                    return "https://api.test.fysapp.co";
                default:
                    throw new ArgumentException("Invalid environment specified.");
            }
        }
    }

    public enum EnvironmentType
    {
        Live,
        Test
    }


}
