using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using RestSharp.Serializers.NewtonsoftJson;

namespace Infobip.Api.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfobipClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            var apiBaseUrl = configuration["Infobip:ApiBaseUrl"];
            var apiKey = configuration["Infobip:ApiKey"];
            var timeoutParsed = int.TryParse(configuration["Infobip:Timeout"], out var timeout);


            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiBaseUrl),
                    "Specify API Key in configuration section 'Infobip:ApiKey'.");
            }

            if (string.IsNullOrWhiteSpace(apiBaseUrl))
            {
                throw new ArgumentNullException(nameof(apiBaseUrl),
                    "Specify API Base Url in configuration section 'Infobip:ApiBaseUrl'.");
            }

            if (!timeoutParsed)
            {
                throw new ArgumentNullException(nameof(apiBaseUrl),
                    "Specify Timeout valid value in configuration section 'Infobip:Timeout'.");
            }

            return
                services
                    .AddSingleton<IRestClient, RestClient>(provider =>
                    {
                        var client = new RestClient(new Uri(apiBaseUrl))
                        {
                            Authenticator = new InfobipAppKeyAuthenticator(apiKey),
                            Timeout = timeout
                        };

                        client.UseNewtonsoftJson();

                        return client;
                    })
                    .AddScoped<IInfobipApiClient, InfobipApiClient>();
        }
    }
}