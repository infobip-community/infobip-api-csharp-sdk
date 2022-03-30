using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetTfaMessageTemplateTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetTfaMessageTemplateTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetTfaMessageTemplate_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaMessageTemplateResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Sms.GetTfaMessageTemplate("appId", "messageId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
