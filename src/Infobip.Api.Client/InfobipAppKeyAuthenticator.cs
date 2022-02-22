using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Infobip.Api.Client
{
    public sealed class InfobipAppKeyAuthenticator : IAuthenticator
    {
        private const string AuthorizationHeaderName = "Authorization";

        private readonly string _apiKey;

        public InfobipAppKeyAuthenticator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (request.Parameters.Any(p => p.Name.Equals(AuthorizationHeaderName, StringComparison.OrdinalIgnoreCase))) return;

            var authorizationHeaderValue = $"App {_apiKey}";
            request.AddParameter(AuthorizationHeaderName, authorizationHeaderValue, ParameterType.HttpHeader);
        }
    }
}