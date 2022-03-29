using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class GetEmailLogsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetEmailLogsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetEmailLogs_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetEmailLogsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetEmailLogsResponse>(responsePayloadFileName);

            var request = new GetEmailLogsRequest();

            // Act
            var response = await apiClient.Email.GetEmailLogs(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}