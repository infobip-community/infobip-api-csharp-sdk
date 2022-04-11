using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetTfaVerificationStatusTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetTfaVerificationStatusTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetTfaVerificationStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaVerificationStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaVerificationStatusResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.GetTfaVerificationStatus("pinId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetTfaVerificationStatus_MsisdnInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaVerificationStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMsisdnInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.GetTfaVerificationStatus("appId", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }


        [Fact]
        public async Task GetTfaVerificationStatus_AppIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaVerificationStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.Sms.GetTfaVerificationStatus("", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static TfaVerificationStatusRequest GetRequest()
        {
            var request = new TfaVerificationStatusRequest("447860099299");
            return request;
        }

        private static TfaVerificationStatusRequest GetRequestMsisdnInvalid()
        {
            var request = new TfaVerificationStatusRequest("");
            return request;
        }
    }
}
