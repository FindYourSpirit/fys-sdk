using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYS_SDK.src
{
    public class Model
    {
        private readonly SdkClient _sdkClient;

        public Model(SdkConfiguration configuration)
        {
            _sdkClient = new SdkClient(configuration);
        }

        public async Task<string> GetApiResponse(string endpoint)
        {
            try
            {
                var response = await _sdkClient.GetApiResponseAsync(endpoint);
                return response;
            }
            catch (ApiException ex)
            {
                // Handle API exception
                Console.WriteLine("API Error: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                // Handle general exception
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }

}
