using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class RescheduleEmailMessagesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public RescheduleEmailMessagesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task RescheduleEmailMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/RescheduleEmailMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RescheduleEmailMessagesResponse>(responsePayloadFileName);

            var request = new RescheduleEmailMessagesRequest(DateTime.Now);

            // Act
            var response = await apiClient.Email.RescheduleEmailMessages("bulkId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task RescheduleEmailMessages_InvalidRequest_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/RescheduleEmailMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new RescheduleEmailMessagesRequest();

            // Act
            Func<Task> act = () => apiClient.Email.RescheduleEmailMessages("bulkId", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}