using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace Infobip.Api.Client.Tests
{
    public class MockedHttpClientFixture : IDisposable
    {
        public HttpClient GetClient<TResponse>(string payloadFileName) where TResponse : new()
        {
            var client = MockHttpClient<TResponse>(HttpStatusCode.OK, GetJsonDataFromFile(payloadFileName));

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

        private static HttpClient MockHttpClient<T>(HttpStatusCode httpStatusCode, string mockedResponse)
            where T : new()
        {

            var responseHttpMessageHandlerMock = new Mock<HttpMessageHandler>();
            responseHttpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                { 
                    StatusCode = httpStatusCode,
                    Content = new StringContent(mockedResponse)
                });

            var httpClient = new HttpClient(responseHttpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("http://localhost:56789")
            };

            return httpClient;

        }

        public void Dispose() { }
    }
}