using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FYS_SDK.src
{
    public class SdkClient
    {
        private readonly HttpClient _httpClient;
        private readonly SdkConfiguration _configuration;

        public SdkClient(SdkConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetApiResponseAsync(string endpoint)
        {
            // Build the API request, add authentication headers or other necessary headers
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Add("Authorization", _configuration.ApiKey);

            // Send the API request
            var response = await _httpClient.SendAsync(request);

            // Process the API response
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            else
            {
                // Handle error response, throw exception or return null/empty response
                throw new ApiException("Error occurred while making API request.");
            }
        }
    }
}
