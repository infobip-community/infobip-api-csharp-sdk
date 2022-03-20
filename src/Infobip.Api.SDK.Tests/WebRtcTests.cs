using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.Validation.DataAnnotations;
using Infobip.Api.SDK.WebRtc.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests
{
    public class WebRtcTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public WebRtcTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GenerateWebRtcToken_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
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
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));

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
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));

            var request = new WebRtcTokenRequest("Identity", displayName: "a");

            // Act
            Func<Task> act = () => apiClient.WebRtc.GenerateWebRtcToken(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetWebRtcApplications_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<List<WebRtcApplicationResponse>>(responsePayloadFileName);

            // Act
            var response = await apiClient.WebRtc.GetWebRtcApplications();

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SaveWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");

            // Act
            var response = await apiClient.WebRtc.SaveWebRtcApplication(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.WebRtc.GetWebRtcApplication("app_id");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");

            // Act
            var response = await apiClient.WebRtc.UpdateWebRtcApplication("app_id", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
