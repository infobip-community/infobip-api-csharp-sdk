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
        {
            var client = MockHttpClient(responseHttpStatusCode, GetJsonDataFromFile(payloadFileName));

            return client;
        }

        public TResponse GetMockedResponse<TResponse>(string payloadFileName) where TResponse : new()
        {
            return JsonConvert.DeserializeObject<TResponse>(GetJsonDataFromFile(payloadFileName));
        }

        private static string GetJsonDataFromFile(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            return File.ReadAllText(filePath);

        }

        private static HttpClient MockHttpClient(HttpStatusCode httpStatusCode, string mockedResponse)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(mockedResponse)
            };
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

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