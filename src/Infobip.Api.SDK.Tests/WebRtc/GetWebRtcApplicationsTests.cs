using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WebRtc.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WebRtc
{
    public class GetWebRtcApplicationsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetWebRtcApplicationsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetWebRtcApplications_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/GetWebRtcApplicationsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<List<WebRtcApplicationResponse>>(responsePayloadFileName);

            // Act
            var response = await apiClient.WebRtc.GetWebRtcApplications();

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetWebRtcApplications_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            // Act
            Func<Task> act = () => apiClient.WebRtc.GetWebRtcApplications();

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }
    }
}