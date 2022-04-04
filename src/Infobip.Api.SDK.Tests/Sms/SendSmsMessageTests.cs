using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class SendSmsMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendSmsMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendSmsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<SendSmsMessageResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.SendSmsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendSmsMessage_MessagesInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessagesInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessage_MessageFromInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageFromInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessage_MessageTextInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageTextInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessage_MessageDestinationsInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageDestinationsInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessage_MessageDestinationToInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageDestinationToInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessage_MessageRegionalIndiaDltPrincipalEntityIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageRegionalIndiaDltPrincipalEntityIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessage_MessageLanguageCodeInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageLanguageCodeInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static SendSmsMessageRequest GetRequest()
        {
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    From = "CompanyName",
                    Text = "Hi from CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    }
                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessagesInvalid()
        {
            var request = new SendSmsMessageRequest("2034072219640523072");
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessageFromInvalid()
        {
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    Text = "Hi from CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    }
                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessageTextInvalid()
        {
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    From = "CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    }
                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessageDestinationsInvalid()
        {
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    From = "CompanyName",
                    Text = "Hi from CompanyName"
                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessageDestinationToInvalid()
        {
            var destinationToInvalid = new string('a', 51);
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    From = "CompanyName",
                    Text = "Hi from CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", destinationToInvalid)
                    }
                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessageRegionalIndiaDltPrincipalEntityIdInvalid()
        {
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    From = "CompanyName",
                    Text = "Hi from CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    },
                    Regional = new SmsRegionalOptions(new SmsIndiaDltOptions("", ""))

                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }

        private static SendSmsMessageRequest GetRequestMessageLanguageCodeInvalid()
        {
            var messages = new List<SmsMessage>
            {
                new SmsMessage
                {
                    From = "CompanyName",
                    Text = "Hi from CompanyName",
                    Destinations = new List<SmsDestination>
                    {
                        new SmsDestination("41793026727", "447860099299")
                    },
                    Language = new SmsLanguage(""),
                    Regional = new SmsRegionalOptions(new SmsIndiaDltOptions("", ""))

                }
            };

            var request = new SendSmsMessageRequest("2034072219640523072", messages);
            return request;
        }
    }
}
