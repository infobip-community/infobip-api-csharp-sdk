using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class GetWhatsAppTemplatesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetWhatsAppTemplatesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetWhatsAppTemplates_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/GetWhatsAppTemplatesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppTemplateManagementTemplatesResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.WhatsApp.GetWhatsAppTemplates("sender");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetWhatsAppTemplates_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetWhatsAppTemplates(null);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetWhatsAppTemplates_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetWhatsAppTemplates("sender");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task GetWhatsAppTemplates_Call_With_ForbiddenResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Forbidden.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Forbidden));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetWhatsAppTemplates("sender");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipForbiddenException>(act);
        }

        [Fact]
        public async Task GetWhatsAppTemplates_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetWhatsAppTemplates("sender");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
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