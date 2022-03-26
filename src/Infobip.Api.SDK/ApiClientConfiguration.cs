namespace Infobip.Api.SDK
{
    /// <summary>
    /// API Client configuration
    /// </summary>
    public class ApiClientConfiguration
    {
        /// <summary>
        /// Gets API BaseUrl
        /// </summary>
        public string BaseUrl { get; }

        /// <summary>
        /// Gets ApiKey
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientConfiguration" /> class.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="apiKey"></param>
        public ApiClientConfiguration(string baseUrl, string apiKey)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
        }
    }
}
