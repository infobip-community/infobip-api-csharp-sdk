using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class VerifyPhoneNumberTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public VerifyPhoneNumberTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task VerifyPhoneNumber_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/VerifyPhoneNumberSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<VerifyPhoneNumberResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.VerifyPhoneNumber("pinId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task VerifyPhoneNumber_PinInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/CreateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestPinInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.VerifyPhoneNumber("pinId", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static VerifyPhoneNumberRequest GetRequest()
        {
            var request = new VerifyPhoneNumberRequest("pin");
            return request;
        }

        private static VerifyPhoneNumberRequest GetRequestPinInvalid()
        {
            var request = new VerifyPhoneNumberRequest("");
            return request;
        }
    }
}
