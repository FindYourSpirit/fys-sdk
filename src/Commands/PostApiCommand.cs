using FYS_SDK.src.Interfaces;

namespace FYS_SDK.src.Commands
{
    public class PostApiCommand : IApiCommand
    {
        private readonly HttpClient _httpClient;
        private readonly SdkConfiguration _configuration;

        public PostApiCommand(SdkConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<string> ExecuteAsync(string endpoint, HttpContent content)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                AddCommonHeaders(request);
                request.Content = content;

                using (var response = await _httpClient.SendAsync(request))
                {
                    return await HandleResponseAsync(response);
                }
            }
        }

        private void AddCommonHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", _configuration.ApiKey);
            request.Headers.Add("JwtToken", _configuration.JwtToken);
        }

        private async Task<string> HandleResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApiException($"Error occurred while making API request. Status Code: {response.StatusCode}. Response: {errorContent}");
            }
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
