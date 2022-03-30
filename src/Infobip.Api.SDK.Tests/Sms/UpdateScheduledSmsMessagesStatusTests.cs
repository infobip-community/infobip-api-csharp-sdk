using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class UpdateScheduledSmsMessagesStatusTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public UpdateScheduledSmsMessagesStatusTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task UpdateScheduledSmsMessagesStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateScheduledSmsMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<ScheduledSmsMessagesStatusResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.UpdateScheduledSmsMessagesStatus(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateScheduledSmsMessagesStatus_BulkIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateScheduledSmsMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestBulkIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateScheduledSmsMessagesStatus(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static UpdateScheduledSmsMessagesStatusRequest GetRequest()
        {
            var request = new UpdateScheduledSmsMessagesStatusRequest("BulkId", SmsBulkStatus.Failed);
            return request;
        }

        private static UpdateScheduledSmsMessagesStatusRequest GetRequestBulkIdInvalid()
        {
            var request = new UpdateScheduledSmsMessagesStatusRequest("", SmsBulkStatus.Failed);
            return request;
        }
    }
}
