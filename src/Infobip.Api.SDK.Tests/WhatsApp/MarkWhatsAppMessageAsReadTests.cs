using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class MarkWhatsAppMessageAsReadTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public MarkWhatsAppMessageAsReadTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task MarkWhatsAppMessageAsRead_Call_ExpectsSuccess()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act/Assert 
            await apiClient.WhatsApp.MarkWhatsAppMessageAsRead("sender", "mediaId");
        }

        [Fact]
        public async Task MarkWhatsAppMessageAsRead_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/MarkWhatsAppMessageAsReadBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.MarkWhatsAppMessageAsRead("sender", "mediaId");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task MarkWhatsAppMessageAsRead_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.MarkWhatsAppMessageAsRead(null, "mediaId");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task MarkWhatsAppMessageAsRead_MediaIdInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.MarkWhatsAppMessageAsRead("sender", null);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };
        }
    }
}