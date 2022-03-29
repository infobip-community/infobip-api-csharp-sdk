using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class GetSentEmailBulksTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetSentEmailBulksTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetSentEmailBulks_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetSentEmailBulksSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSentEmailBulksResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Email.GetSentEmailBulks("bulkId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}