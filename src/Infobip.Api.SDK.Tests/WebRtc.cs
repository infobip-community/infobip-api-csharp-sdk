using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.WebRtc.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests
{
    public class WebRtc : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public WebRtc(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GenerateWebRtcToken_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WebRtcTokenResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcTokenResponse>(responsePayloadFileName);

            var request = new WebRtcTokenRequest("identity");

            // Act
            var response = await apiClient.WebRtc.GenerateWebRtcToken(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetWebRtcApplications_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<List<WebRtcApplicationResponse>>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<List<WebRtcApplicationResponse>>(responsePayloadFileName);

            // Act
            var response = await apiClient.WebRtc.GetWebRtcApplications(cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SaveWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WebRtcApplicationResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");

            // Act
            var response = await apiClient.WebRtc.SaveWebRtcApplication(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WebRtcApplicationResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.WebRtc.GetWebRtcApplication("app_id", cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WebRtcApplicationResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");

            // Act
            var response = await apiClient.WebRtc.UpdateWebRtcApplication("app_id", request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
