using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WebRtc.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WebRtc
{
    public class UpdateWebRtcApplicationTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public UpdateWebRtcApplicationTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task UpdateWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");

            // Act
            var response = await apiClient.WebRtc.UpdateWebRtcApplication("app_id", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = new WebRtcApplicationRequest("app");

            // Act
            Func<Task> act = () => apiClient.WebRtc.UpdateWebRtcApplication("app_id", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_IdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new WebRtcApplicationRequest("app");

            // Act
            Func<Task> act = () => apiClient.WebRtc.UpdateWebRtcApplication("", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_NameInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new WebRtcApplicationRequest("");

            // Act
            Func<Task> act = () => apiClient.WebRtc.UpdateWebRtcApplication("app", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_IosConfigInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var iosConfig = new IosApplicationPushNotificationConfig();
            var request = new WebRtcApplicationRequest("name", "description", iosConfig);

            // Act
            Func<Task> act = () => apiClient.WebRtc.UpdateWebRtcApplication("app", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_AndroidConfigInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var androidConfig = new AndroidApplicationPushNotificationConfig();
            var request = new WebRtcApplicationRequest("name", "description", android: androidConfig);

            // Act
            Func<Task> act = () => apiClient.WebRtc.UpdateWebRtcApplication("app", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}