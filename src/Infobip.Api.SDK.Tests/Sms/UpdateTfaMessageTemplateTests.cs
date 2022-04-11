using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class UpdateTfaMessageTemplateTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public UpdateTfaMessageTemplateTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaMessageTemplateResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.UpdateTfaMessageTemplate("app_id", "message_Id", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_MessageTextInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageTextInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateTfaMessageTemplate("app_id","message_Id", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_RegionalOptionsIndiaDltPrincipalInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestRegionalOptionsIndiaDltPrincipalInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateTfaMessageTemplate("app_id", "message_Id", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_RegionalOptionsIndiaDltPrincipalToLongInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestRegionalOptionsIndiaDltPrincipalToLongInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateTfaMessageTemplate("app_id", "message_Id", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_RegionalOptionsIndiaDltContentTemplateIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestRegionalOptionsIndiaDltContentTemplateIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateTfaMessageTemplate("app_id", "message_Id", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_AppIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateTfaMessageTemplate("", "messageId", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task UpdateTfaMessageTemplate_MessageIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/UpdateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.Sms.UpdateTfaMessageTemplate("app_id", "", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static TfaMessageTemplateRequest GetRequest()
        {
            var request = new TfaMessageTemplateRequest("Your pin is {{pin}}", TfaPinType.Numeric);
            return request;
        }

        private static TfaMessageTemplateRequest GetRequestMessageTextInvalid()
        {
            var request = new TfaMessageTemplateRequest("pin placeholder is missing...", TfaPinType.Numeric);
            return request;
        }

        private static TfaMessageTemplateRequest GetRequestRegionalOptionsIndiaDltPrincipalInvalid()
        {
            var request = new TfaMessageTemplateRequest("Your pin is {{pin}}", TfaPinType.Numeric)
            {
                Regional = new SmsRegionalOptions
                {
                    IndiaDlt = new SmsIndiaDltOptions("")
                }
            };
            return request;
        }

        private static TfaMessageTemplateRequest GetRequestRegionalOptionsIndiaDltPrincipalToLongInvalid()
        {
            var invalidPrincipal = new string('a', 31);
            var request = new TfaMessageTemplateRequest("Your pin is {{pin}}", TfaPinType.Numeric)
            {
                Regional = new SmsRegionalOptions
                {
                    IndiaDlt = new SmsIndiaDltOptions(invalidPrincipal)
                }
            };
            return request;
        }

        private static TfaMessageTemplateRequest GetRequestRegionalOptionsIndiaDltContentTemplateIdInvalid()
        {
            var invalidContentTemplateId = new string('a', 31);
            var request = new TfaMessageTemplateRequest("Your pin is {{pin}}", TfaPinType.Numeric)
            {
                Regional = new SmsRegionalOptions
                {
                    IndiaDlt = new SmsIndiaDltOptions("principal", invalidContentTemplateId)
                }
            };
            return request;
        }
    }
}
