using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class SendFullyFeaturedEmailTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendFullyFeaturedEmailTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendFullyFeaturedEmail_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/SendFullyFeaturedEmailSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<SendFullyFeaturedEmailResponse>(responsePayloadFileName);

            var request = new SendFullyFeaturedEmailRequest("to", "from", "Subject");

            // Act
            var response = await apiClient.Email.SendFullyFeaturedEmail(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendFullyFeaturedEmail_InvalidRequest_Call_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/SendFullyFeaturedEmailSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new SendFullyFeaturedEmailRequest();

            // Act
            Func<Task> act = () => apiClient.Email.SendFullyFeaturedEmail(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendFullyFeaturedEmail_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/SendFullyFeaturedEmailBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = new SendFullyFeaturedEmailRequest("from", "to", "Subject");

            // Act
            Func<Task> act = () => apiClient.Email.SendFullyFeaturedEmail(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }
    }
}