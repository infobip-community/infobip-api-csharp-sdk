using System;
using System.Net;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.WebRtc
{
    public class DeleteWebRtcApplicationTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public DeleteWebRtcApplicationTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task DeleteWebRtcApplication_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/UpdateWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            await apiClient.WebRtc.DeleteWebRtcApplication("app_id");
        }

        [Fact]
        public async Task DeleteWebRtcApplication_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            // Act
            Func<Task> act = () => apiClient.WebRtc.DeleteWebRtcApplication("app_id");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task DeleteWebRtcApplication_IdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WebRtc/SaveWebRtcApplicationSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.WebRtc.DeleteWebRtcApplication("");

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}

