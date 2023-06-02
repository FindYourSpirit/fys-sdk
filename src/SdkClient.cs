using FYS_SDK.src.Commands;

namespace FYS_SDK.src
{
    public class SdkClient : IDisposable
    {
        private readonly SdkConfiguration _configuration;
        private readonly GetApiCommand _getCommand;
        private readonly PostApiCommand _postCommand;
        // Instantiate additional command classes for other HTTP methods as needed

        public SdkClient(SdkConfiguration configuration)
        {
            _configuration = configuration;
            _getCommand = new GetApiCommand(configuration);
            _postCommand = new PostApiCommand(configuration);
            // Instantiate additional command classes for other HTTP methods as needed
        }

        public async Task<string> GetApiResponseAsync(string endpoint)
        {
            return await _getCommand.ExecuteAsync(endpoint, null);
        }

        public async Task<string> PostApiResponseAsync(string endpoint, HttpContent content)
        {
            return await _postCommand.ExecuteAsync(endpoint, content);
        }

        // Add additional methods for other HTTP methods using the respective command classes

        public void Dispose()
        {
            _getCommand.Dispose();
            _postCommand.Dispose();
            // Dispose of additional command instances as needed
        }
    }
}
