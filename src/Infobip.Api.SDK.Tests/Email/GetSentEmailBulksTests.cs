using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class GetSentEmailBulksTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetSentEmailBulksTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetSentEmailBulks_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetSentEmailBulksSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSentEmailBulksResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Email.GetSentEmailBulks("bulkId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetSentEmailBulks_BulkIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetSentEmailBulksSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.Email.GetSentEmailBulks("");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}