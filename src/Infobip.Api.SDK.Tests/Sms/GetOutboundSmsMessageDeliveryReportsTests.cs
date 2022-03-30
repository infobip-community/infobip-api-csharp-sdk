using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetOutboundSmsMessageDeliveryReportsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetOutboundSmsMessageDeliveryReportsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetOutboundSmsMessageDeliveryReports_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetOutboundSmsMessageDeliveryReportsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSmsDeliveryReportResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.GetOutboundSmsMessageDeliveryReports(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetOutboundSmsMessageDeliveryReports_LimitInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetOutboundSmsMessageDeliveryReportsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestLimitInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.GetOutboundSmsMessageDeliveryReports(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
        
        private static GetSmsDeliveryReportRequest GetRequest()
        {
            var request = new GetSmsDeliveryReportRequest();
            return request;
        }

        private static GetSmsDeliveryReportRequest GetRequestLimitInvalid()
        {
            var request = new GetSmsDeliveryReportRequest()
            {
                Limit = 1010
            };
            return request;
        }
    }
}