using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetScheduledSmsMessagesStatusTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetScheduledSmsMessagesStatusTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetScheduledSmsMessagesStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetScheduledSmsMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<ScheduledSmsMessagesStatusResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.GetScheduledSmsMessagesStatus(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetScheduledSmsMessagesStatus_BulkIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetScheduledSmsMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestBulkIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.GetScheduledSmsMessagesStatus(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static GetScheduledSmsMessagesStatusRequest GetRequest()
        {
            var request = new GetScheduledSmsMessagesStatusRequest("BulkId");
            return request;
        }

        private static GetScheduledSmsMessagesStatusRequest GetRequestBulkIdInvalid()
        {
            var request = new GetScheduledSmsMessagesStatusRequest("");
            return request;
        }
    }
}
