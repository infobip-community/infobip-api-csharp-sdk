using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WebRtc.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WebRtc
{
    public class GenerateWebRtcTokenTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GenerateWebRtcTokenTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GenerateWebRtcToken_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcTokenResponse>(responsePayloadFileName);

            var request = new WebRtcTokenRequest("identity");

            // Act
            var response = await apiClient.WebRtc.GenerateWebRtcToken(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GenerateWebRtcToken_IdentityInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new WebRtcTokenRequest("Id");

            // Act
            Func<Task> act = () => apiClient.WebRtc.GenerateWebRtcToken(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GenerateWebRtcToken_DisplayNameInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new WebRtcTokenRequest("Identity", displayName: "a");

            // Act
            Func<Task> act = () => apiClient.WebRtc.GenerateWebRtcToken(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GenerateWebRtcToken_TimeToLiveInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new WebRtcTokenRequest("Identity", displayName: "DisplayName", timeToLive: 86401);

            // Act
            Func<Task> act = () => apiClient.WebRtc.GenerateWebRtcToken(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}