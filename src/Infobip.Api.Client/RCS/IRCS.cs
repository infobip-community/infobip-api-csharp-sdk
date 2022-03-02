using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.Client.RCS.Models;

namespace Infobip.Api.Client.RCS
{
    public interface IRcs
    {
        Task<RcsMessageResponse> SendRcsMessage(SendRcsMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<RcsMessageResponse> SendBulkRcsMessages(SendRscBulkMessagesRequest requestPayload, CancellationToken cancellationToken);
    }
}