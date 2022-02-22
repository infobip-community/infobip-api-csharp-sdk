using System.Collections.Generic;
using FluentAssertions;
using Infobip.Api.Client.WebRtc.Models;
using Xunit;

namespace Infobip.Api.Client.Tests
{
    public class WebRtc : IClassFixture<MockedRestClientFixture>
    {
        private readonly MockedRestClientFixture _fixture;

        public WebRtc(MockedRestClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GenerateWebRtcToken_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WebRtc/GenerateWebRtcTokenSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WebRtcTokenResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WebRtcTokenResponse>(responsePayloadFileName);

            var request = new WebRtcTokenRequest("identity");
            var response = apiClient.WebRtc.GenerateWebRtcToken(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void GetWebRtcApplications_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationsSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient< List<WebRtcApplicationResponse>>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse< List<WebRtcApplicationResponse>>(responsePayloadFileName);

            var response = apiClient.WebRtc.GetWebRtcApplications().Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SaveWebRtcApplication_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WebRtcApplicationResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var request = new WebRtcApplicationRequest("app");
            var response = apiClient.WebRtc.SaveWebRtcApplication(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void GetWebRtcApplication_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WebRtcApplicationResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);

            var response = apiClient.WebRtc.GetWebRtcApplication("app_id").Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void UpdateWebRtcApplication_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WebRtcApplicationResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WebRtcApplicationResponse>(responsePayloadFileName);
            
            var request = new WebRtcApplicationRequest("app");
            var response = apiClient.WebRtc.UpdateWebRtcApplication("app_id", request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
