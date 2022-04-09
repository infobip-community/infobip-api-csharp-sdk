using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WebRtc.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WebRtc
{
    public class SaveWebRtcApplicationTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SaveWebRtcApplicationTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SaveWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");

            // Act
            var response = await apiClient.WebRtc.SaveWebRtcApplication(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SaveWebRtcApplication_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = new WebRtcApplicationRequest("app");

            // Act
            Func<Task> act = () => apiClient.WebRtc.SaveWebRtcApplication(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }


        [Fact]
        public async Task SaveWebRtcApplication_NameInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new WebRtcApplicationRequest("");

            // Act
            Func<Task> act = () => apiClient.WebRtc.SaveWebRtcApplication(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SaveWebRtcApplication_IosConfigInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var iosConfig = new IosApplicationPushNotificationConfig();
            var request = new WebRtcApplicationRequest("name", "description", iosConfig);

            // Act
            Func<Task> act = () => apiClient.WebRtc.SaveWebRtcApplication(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SaveWebRtcApplication_AndroidConfigInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var androidConfig = new AndroidApplicationPushNotificationConfig();
            var request = new WebRtcApplicationRequest("name", "description", android: androidConfig);

            // Act
            Func<Task> act = () => apiClient.WebRtc.SaveWebRtcApplication(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}