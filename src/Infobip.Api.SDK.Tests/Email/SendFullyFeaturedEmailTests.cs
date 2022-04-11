using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [Fact]
        public async Task SendFullyFeaturedEmail_Call_With_InvalidRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var callbackData = new string('x', 4001);
            var request = new SendFullyFeaturedEmailRequest("", "", "", 
                callbackData: callbackData, 
                notifyContentType: "invalid value");
            

            // Act
            Func<Task> act = () => apiClient.Email.SendFullyFeaturedEmail(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain(nameof(request.From));
            errors.Should().Contain(nameof(request.To));
            errors.Should().Contain(nameof(request.Subject));
            errors.Should().Contain(nameof(request.CallbackData));
            errors.Should().Contain(nameof(request.NotifyContentType));
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