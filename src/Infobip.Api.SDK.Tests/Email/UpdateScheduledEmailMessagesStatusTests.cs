using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class UpdateScheduledEmailMessagesStatusTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public UpdateScheduledEmailMessagesStatusTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task UpdateScheduledEmailMessagesStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/UpdateScheduledEmailMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<UpdateScheduledEmailMessagesStatusResponse>(responsePayloadFileName);

            var request = new UpdateScheduledEmailMessagesStatusRequest(BulkStatusInfoEnum.Finished);

            // Act
            var response = await apiClient.Email.UpdateScheduledEmailMessagesStatus("bulkId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateScheduledEmailMessagesStatus_InvalidRequest_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/UpdateScheduledEmailMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new UpdateScheduledEmailMessagesStatusRequest();

            // Act
            Func<Task> act = () => apiClient.Email.UpdateScheduledEmailMessagesStatus("bulkId", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}

