using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class RescheduleSmsMessagesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public RescheduleSmsMessagesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task RescheduleSmsMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/RescheduleSmsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<ScheduledSmsMessagesResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.RescheduleSmsMessages(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task RescheduleSmsMessages_BulkIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/RescheduleSmsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestBulkIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.RescheduleSmsMessages(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static RescheduleSmsMessagesRequest GetRequest()
        {
            var request = new RescheduleSmsMessagesRequest("BulkId", DateTimeOffset.Now);
            return request;
        }

        private static RescheduleSmsMessagesRequest GetRequestBulkIdInvalid()
        {
            var request = new RescheduleSmsMessagesRequest("", DateTimeOffset.Now);
            return request;
        }
    }
}
