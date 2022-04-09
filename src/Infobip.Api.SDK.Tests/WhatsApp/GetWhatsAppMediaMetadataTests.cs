using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class GetWhatsAppMediaMetadataTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetWhatsAppMediaMetadataTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetWhatsAppMediaMetadata_Call_ExpectsSuccess()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var mockedResponse = await responseMessage.Content.ReadAsStringAsync();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            var response = await apiClient.WhatsApp.GetWhatsAppMediaMetadata("sender", "mediaId");

            // Assert 
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetWhatsAppMediaMetadata_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetWhatsAppMediaMetadata(null, "mediaId");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetWhatsAppMediaMetadata_MediaIdInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetWhatsAppMediaMetadata("sender", null);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("OK")
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