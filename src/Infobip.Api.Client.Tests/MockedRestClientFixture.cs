using System;
using System.IO;
using System.Net;
using System.Threading;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Infobip.Api.Client.Tests
{
    public class MockedRestClientFixture : IDisposable
    {
        public IRestClient GetClient<TResponse>(string payloadFileName) where TResponse : new()
        {
            var client = MockRestClient<TResponse>(HttpStatusCode.OK, GetMockedResponse<TResponse>(payloadFileName));
            client.UseNewtonsoftJson();

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

        private static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, T mockedResponse)
            where T : new()
        {
            var response = new Mock<IRestResponse<T>>();
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            response.Setup(_ => _.Data).Returns(mockedResponse);

            var mockIRestClient = new Mock<IRestClient>();

            mockIRestClient
                .Setup(x => x.ExecuteAsync<T>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response.Object);

            return mockIRestClient.Object;

        }

        public void Dispose() { }
    }
}