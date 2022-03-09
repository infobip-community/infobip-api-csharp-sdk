using System;
using System.Net.Http.Headers;
using System.Threading;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.Validation.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infobip.Api.SDK.Extensions
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
                throw new ArgumentNullException("ApiKey",
                    "Specify API Key in configuration section 'Infobip:ApiKey'.");
            }

            if (string.IsNullOrWhiteSpace(apiBaseUrl))
            {
                throw new ArgumentNullException("ApiBaseUrl",
                    "Specify API Base Url in configuration section 'Infobip:ApiBaseUrl'.");
            }

            if (!timeoutParsed)
            {
                throw new ArgumentNullException("Timeout",
                    "Specify Timeout valid value in configuration section 'Infobip:Timeout'.");
            }

            return
                services
                    .AddSingleton<IRequestValidator, RequestValidator>()
                    .AddSingleton<IDataAnnotationsValidator, DataAnnotationsValidator>()
                    .AddHttpClient<IInfobipApiClient, InfobipApiClient>(client =>
                    {
                        client.BaseAddress = new Uri(apiBaseUrl);
                        client.Timeout = timeout == 0 ? Timeout.InfiniteTimeSpan : TimeSpan.FromSeconds(timeout);
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("App", apiKey);
                    })
                    .Services;
        }
    }
}