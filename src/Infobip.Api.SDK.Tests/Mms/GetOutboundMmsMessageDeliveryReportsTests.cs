using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.MMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Mms
{
    public class GetOutboundMmsMessageDeliveryReportsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetOutboundMmsMessageDeliveryReportsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetOutboundMmsMessageDeliveryReports_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Mms/GetOutboundMmsMessageDeliveryReportsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetMmsDeliveryReportResponse>(responsePayloadFileName);

            var request = new GetMmsDeliveryReportRequest();

            // Act
            var response = await apiClient.Mms.GetOutboundMmsMessageDeliveryReports(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}