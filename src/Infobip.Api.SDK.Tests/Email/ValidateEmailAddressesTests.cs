using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Xunit;

namespace Infobip.Api.SDK.Tests.Email
{
    public class ValidateEmailAddressesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public ValidateEmailAddressesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task ValidateEmailAddresses_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/ValidateEmailAddressesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<ValidateEmailAddressesResponse>(responsePayloadFileName);

            var request = new ValidateEmailAddressesRequest("to");

            // Act
            var response = await apiClient.Email.ValidateEmailAddresses(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task ValidateEmailAddresses_InvalidRequest_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/ValidateEmailAddressesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = new ValidateEmailAddressesRequest();

            // Act
            Func<Task> act = () => apiClient.Email.ValidateEmailAddresses(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task ValidateEmailAddresses_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/ValidateEmailAddressesBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = new ValidateEmailAddressesRequest("a@b.c");

            // Act
            Func<Task> act = () => apiClient.Email.ValidateEmailAddresses(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }
    }
}