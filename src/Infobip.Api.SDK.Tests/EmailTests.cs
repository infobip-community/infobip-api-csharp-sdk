using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.Validation.DataAnnotations;
using Xunit;

namespace Infobip.Api.SDK.Tests
{
    public class EmailTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public EmailTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetEmailDeliveryReports_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetEmailDeliveryReportsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<GetEmailDeliveryReportsResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<GetEmailDeliveryReportsResponse>(responsePayloadFileName);

            var request = new GetEmailDeliveryReportsRequest();

            // Act
            var response = await apiClient.Email.GetEmailDeliveryReports(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetEmailLogs_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetEmailLogsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<GetEmailLogsResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<GetEmailLogsResponse>(responsePayloadFileName);

            var request = new GetEmailLogsRequest();

            // Act
            var response = await apiClient.Email.GetEmailLogs(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendFullyFeaturedEmail_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/SendFullyFeaturedEmailSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<SendFullyFeaturedEmailResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<SendFullyFeaturedEmailResponse>(responsePayloadFileName);

            var request = new SendFullyFeaturedEmailRequest("to", "from", "Subject");

            // Act
            var response = await apiClient.Email.SendFullyFeaturedEmail(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetSentEmailBulks_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetSentEmailBulksSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<GetSentEmailBulksResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSentEmailBulksResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Email.GetSentEmailBulks("bulkId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task RescheduleEmailMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/RescheduleEmailMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<RescheduleEmailMessagesResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<RescheduleEmailMessagesResponse>(responsePayloadFileName);

            var request = new RescheduleEmailMessagesRequest(DateTime.Now);

            // Act
            var response = await apiClient.Email.RescheduleEmailMessages("bulkId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetSentEmailBulksStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/GetSentEmailBulksStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<GetSentEmailBulksStatusResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<GetSentEmailBulksStatusResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Email.GetSentEmailBulksStatus("bulkId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateScheduledEmailMessagesStatus_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/UpdateScheduledEmailMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<UpdateScheduledEmailMessagesStatusResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<UpdateScheduledEmailMessagesStatusResponse>(responsePayloadFileName);

            var request = new UpdateScheduledEmailMessagesStatusRequest(BulkStatusInfoEnum.Finished);

            // Act
            var response = await apiClient.Email.UpdateScheduledEmailMessagesStatus("bulkId", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task ValidateEmailAddresses_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/ValidateEmailAddressesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<ValidateEmailAddressesResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));
            var mockedResponse = _clientFixture.GetMockedResponse<ValidateEmailAddressesResponse>(responsePayloadFileName);

            var request = new ValidateEmailAddressesRequest("to");

            // Act
            var response = await apiClient.Email.ValidateEmailAddresses(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendFullyFeaturedEmail_InvalidRequest_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/SendFullyFeaturedEmailSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<SendFullyFeaturedEmailResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));

            var request = new SendFullyFeaturedEmailRequest();

            // Act
            Func<Task> act = () => apiClient.Email.SendFullyFeaturedEmail(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task RescheduleEmailMessages_InvalidRequest_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/RescheduleEmailMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<RescheduleEmailMessagesResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));

            var request = new RescheduleEmailMessagesRequest();

            // Act
            Func<Task> act = () => apiClient.Email.RescheduleEmailMessages("bulkId", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateScheduledEmailMessagesStatus_InvalidRequest_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/UpdateScheduledEmailMessagesStatusSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<UpdateScheduledEmailMessagesStatusResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));

            var request = new UpdateScheduledEmailMessagesStatusRequest();

            // Act
            Func<Task> act = () => apiClient.Email.UpdateScheduledEmailMessagesStatus("bulkId", request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task ValidateEmailAddresses_InvalidRequest_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Email/ValidateEmailAddressesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<UpdateScheduledEmailMessagesStatusResponse>(responsePayloadFileName), new RequestValidator(new DataAnnotationsValidator()));

            var request = new ValidateEmailAddressesRequest();

            // Act
            Func<Task> act = () => apiClient.Email.ValidateEmailAddresses(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}
