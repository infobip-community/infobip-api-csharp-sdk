using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetOutboundSmsMessageLogsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetOutboundSmsMessageLogsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetOutboundSmsMessageLogs_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetOutboundSmsMessageLogsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSmsLogsResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.GetOutboundSmsMessageLogs(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetOutboundSmsMessageLogs_LimitInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetOutboundSmsMessageLogsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestLimitInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.GetOutboundSmsMessageLogs(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetOutboundSmsMessageLogs_GeneralStatusInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetOutboundSmsMessageLogsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestGeneralStatusInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.GetOutboundSmsMessageLogs(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static GetSmsLogsRequest GetRequest()
        {
            var request = new GetSmsLogsRequest()
            {
                GeneralStatus = "ACCEPTED"
            };
            return request;
        }

        private static GetSmsLogsRequest GetRequestLimitInvalid()
        {
            var request = new GetSmsLogsRequest
            {
                Limit = 1010
            };
            return request;
        }

        private static GetSmsLogsRequest GetRequestGeneralStatusInvalid()
        {
            var request = new GetSmsLogsRequest
            {
                GeneralStatus = "invalid"
            };
            return request;
        }
    }
}
