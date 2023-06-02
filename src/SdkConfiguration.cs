namespace FYS_SDK.src
{
    public class SdkConfiguration
    {
        public string ApiKey { get; set; }
        public string JwtToken { get; set; }
        public string ClientID { get; set; }
        public EnvironmentType Environment { get; set; }  // New property to specify the environment
        public string Version { get; set; }  // New property to specify the version

        public SdkConfiguration(string apiKey, EnvironmentType environment, string jwtToken, string clientID, string version)
        {
            ApiKey = apiKey;
            Environment = environment;
            JwtToken = jwtToken;
            ClientID = clientID;
            Version = version;
        }

        public string GetBaseUrl()
        {
            switch (Environment)
            {
                case EnvironmentType.Live:
                    return $"https://api.live.fysapp.co/{Version}";
                case EnvironmentType.Test:
                    return $"https://api.test.fysapp.co/{Version}";
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
