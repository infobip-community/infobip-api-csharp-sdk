using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class GetIdentityTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetIdentityTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetIdentity_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/GetIdentitySuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetIdentityResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.WhatsApp.GetIdentity("sender", "userNumber");

            // Assert 
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetIdentity_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetIdentity("sender", "userNumber");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task GetIdentity_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responseMessage = GetBadRequestResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetIdentity("sender", "userNumber");

            // Assert
            await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task GetIdentity_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetIdentity("sender", "userNumber");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task GetIdentity_SenderInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/GetIdentitySuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetIdentity(null, "userNumber");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetIdentity_UserNumberInvalid_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/GetIdentitySuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.GetIdentity("sender", null);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
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