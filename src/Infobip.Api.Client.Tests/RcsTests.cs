using System;
using System.Collections.Generic;
using FluentAssertions;
using Infobip.Api.Client.RCS.Models;
using Xunit;

namespace Infobip.Api.Client.Tests
{
    public class RcsTests : IClassFixture<MockedRestClientFixture>
    {
        private readonly MockedRestClientFixture _fixture;

        public RcsTests(MockedRestClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void SendRcsMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<RcsMessageResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeContent(MessageTypeContent.TypeEnum.TEXT);
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content: content);
            var response = apiClient.Rcs.SendRcsMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendBulkRcsMessages_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/Rcs/SendBulkRcsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<RcsMessageResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeContent(MessageTypeContent.TypeEnum.TEXT);
            var messages = new List<SendRcsMessageRequest>
            {
                new("447860099299", "447860099300", content: content)
            };
            var request = new SendRscBulkMessagesRequest(messages);
            var response = apiClient.Rcs.SendBulkRcsMessages(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
