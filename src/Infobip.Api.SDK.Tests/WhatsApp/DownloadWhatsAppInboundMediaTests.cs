using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class DownloadWhatsAppInboundMediaTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public DownloadWhatsAppInboundMediaTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task DownloadWhatsAppInboundMedia_Call_ExpectsSuccess()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var mockedResponse = await responseMessage.Content.ReadAsStreamAsync();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            var response = await apiClient.WhatsApp.DownloadWhatsAppInboundMedia("sender", "mediaId");

            // Assert 
            mockedResponse.Should().BeSameAs(response);
        }

        [Fact]
        public async Task DownloadWhatsAppInboundMedia_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.DownloadWhatsAppInboundMedia(null, "mediaId");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task DownloadWhatsAppInboundMedia_MediaIdInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.DownloadWhatsAppInboundMedia("sender", null);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            var responseContent = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/WhatsApp/media.png"));
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ByteArrayContent(responseContent)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("*/*")
                    }
                }
            };
        }
    }
}