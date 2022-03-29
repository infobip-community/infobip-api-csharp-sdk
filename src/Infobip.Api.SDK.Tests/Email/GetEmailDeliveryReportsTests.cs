using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class GetEmailDeliveryReportsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetEmailDeliveryReportsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetEmailDeliveryReports_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetEmailDeliveryReportsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<GetEmailDeliveryReportsResponse>(responsePayloadFileName);

            var request = new GetEmailDeliveryReportsRequest();

            // Act
            var response = await apiClient.Email.GetEmailDeliveryReports(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
        
        [Fact]
        public async Task GetEmailDeliveryReports_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetEmailDeliveryReportsBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = new GetEmailDeliveryReportsRequest();

            // Act
            Func<Task> act = () => apiClient.Email.GetEmailDeliveryReports(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }
    }
}