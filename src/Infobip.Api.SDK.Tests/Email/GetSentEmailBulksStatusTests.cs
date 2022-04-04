using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class GetSentEmailBulksStatusTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetSentEmailBulksStatusTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetSentEmailBulksStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetSentEmailBulksStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSentEmailBulksStatusResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Email.GetSentEmailBulksStatus("bulkId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}