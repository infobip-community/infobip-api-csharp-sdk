using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.RCS.Models;

namespace Infobip.Api.SDK.RCS
{
    public interface IRcs
    {
        Task<RcsMessageResponse> SendRcsMessage(SendRcsMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<RcsMessageResponse> SendBulkRcsMessages(SendRscBulkMessagesRequest requestPayload, CancellationToken cancellationToken);
    }
}