using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.MMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Mms
{
    public class GetInboundMmsMessagesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetInboundMmsMessagesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetInboundMmsMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/GetInboundMmsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetInboundMmsMessagesResponse>(responsePayloadFileName);

            var request = new GetInboundMmsMessagesRequest();

            // Act
            var response = await apiClient.Mms.GetInboundMmsMessages(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}

