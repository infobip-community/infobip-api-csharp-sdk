using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class ResendTfaPinCodeOverVoiceTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public ResendTfaPinCodeOverVoiceTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task ResendTfaPinCodeOverVoice_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/ResendTfaPinCodeOverVoiceSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaPinCodeResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.ResendTfaPinCodeOverVoice("pinId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        private static ResendTfaPinCodeRequest GetRequest()
        {
            var request = new ResendTfaPinCodeRequest
            {
                Placeholders = new Dictionary<string, string>
                {
                    { "firstName","John" },
                    { "lastName","Doe" }
            }
            };
            return request;
        }
    }
}
