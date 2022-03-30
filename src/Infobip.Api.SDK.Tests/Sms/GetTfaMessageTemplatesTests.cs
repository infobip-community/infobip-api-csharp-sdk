using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetTfaMessageTemplatesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetTfaMessageTemplatesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetTfaMessageTemplates_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplatesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<List<TfaMessageTemplateResponse>>(responsePayloadFileName);

            // Act
            var response = await apiClient.Sms.GetTfaMessageTemplates("app_id");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
