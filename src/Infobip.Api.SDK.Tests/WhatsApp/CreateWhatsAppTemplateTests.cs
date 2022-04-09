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
    public class CreateWhatsAppTemplateTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public CreateWhatsAppTemplateTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task CreateWhatsAppTemplate_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/CreateWhatsAppTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppTemplateManagementTemplateResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.WhatsApp.CreateWhatsAppTemplate("sender", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task CreateWhatsAppTemplate_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.CreateWhatsAppTemplate(null, request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task CreateWhatsAppTemplate_Call_With_BadRequestResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/BadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.CreateWhatsAppTemplate("sender", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task CreateWhatsAppTemplate_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.CreateWhatsAppTemplate("sender", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task CreateWhatsAppTemplate_Call_With_ForbiddenResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Forbidden.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Forbidden));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.CreateWhatsAppTemplate("sender", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipForbiddenException>(act);
        }

        [Fact]
        public async Task CreateWhatsAppTemplate_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.CreateWhatsAppTemplate("sender", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        private WhatsAppTemplateManagementTemplateRequest GetRequest()
        {
            var request = new WhatsAppTemplateManagementTemplateRequest("name", WhatsAppTemplateManagementTemplateRequest.LanguageEnum.En,
                WhatsAppTemplateManagementTemplateRequest.CategoryEnum.ACCOUNTUPDATE,
                new WhatsAppTemplateTemplateStructureApiData(new WhatsAppTemplateHeaderApiData(WhatsAppTemplateHeaderApiData.FormatEnum.Text),"My Message", "Footer text"));
            return request;
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