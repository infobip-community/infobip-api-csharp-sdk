using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class ConfirmIdentityTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public ConfirmIdentityTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task ConfirmIdentity_Call_ExpectsSuccess()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act/Assert 
            await apiClient.WhatsApp.ConfirmIdentity("sender", "userNumber", request);
        }

        [Fact]
        public async Task ConfirmIdentity_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.ConfirmIdentity("sender", "userNumber", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task ConfirmIdentity_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responseMessage = GetBadRequestResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.ConfirmIdentity("sender", "userNumber", request);

            // Assert
            await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task  ConfirmIdentity_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.ConfirmIdentity("sender", "userNumber", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task GetIdentity_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.ConfirmIdentity(null, "userNumber", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetIdentity_UserNumberInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.ConfirmIdentity("sender", null, request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task ConfirmIdentity_HashInvalid_Call_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = GetRequestHashInvalid();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.ConfirmIdentity("sender", "userNumber", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private ConfirmIdentityRequest GetRequest()
        {
            var request = new ConfirmIdentityRequest("hash");
            return request;
        }

        private ConfirmIdentityRequest GetRequestHashInvalid()
        {
            var request = new ConfirmIdentityRequest("");
            return request;
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };
        }

        private static HttpResponseMessage GetBadRequestResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
}