using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
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

        [Fact]
        public async Task GetOutboundMmsMessageDeliveryReports_Call_With_InvalidRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = new GetMmsDeliveryReportRequest(limit: -1);

            // Act
            Func<Task> act = () => apiClient.Mms.GetOutboundMmsMessageDeliveryReports(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain(nameof(request.Limit));
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}