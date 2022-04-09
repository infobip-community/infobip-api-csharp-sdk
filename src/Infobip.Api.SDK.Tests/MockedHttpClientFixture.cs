using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Tests
{
    public class MockedHttpClientFixture : IDisposable
    {
        public HttpClient GetClient(string payloadFileName, HttpStatusCode responseHttpStatusCode = HttpStatusCode.OK)
            => MockHttpClient(responseHttpStatusCode, GetJsonDataFromFile(payloadFileName));

        public HttpClient GetClient(HttpResponseMessage mockedResponseMessage)
            => MockHttpClient(mockedResponseMessage);

        public TResponse GetMockedResponse<TResponse>(string payloadFileName) where TResponse : new()
            => JsonConvert.DeserializeObject<TResponse>(GetJsonDataFromFile(payloadFileName));

        private static string GetJsonDataFromFile(string fileName)
            => File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));

        private static HttpClient MockHttpClient(HttpStatusCode httpStatusCode, string mockedResponse)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(mockedResponse)
            };
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return BuildHttpClient(responseMessage);
        }

        private static HttpClient MockHttpClient(HttpResponseMessage mockedResponseMessage)
            => BuildHttpClient(mockedResponseMessage);

        private static HttpClient BuildHttpClient(HttpResponseMessage responseMessage)
        {
            var responseHttpMessageHandlerMock = new Mock<HttpMessageHandler>();
            responseHttpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(responseHttpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("http://localhost:56789")
            };

            return httpClient;
        }

        public void Dispose() { }
    }
}