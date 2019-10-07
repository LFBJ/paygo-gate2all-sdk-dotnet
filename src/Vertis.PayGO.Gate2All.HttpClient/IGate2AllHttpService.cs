using System.Threading;
using System.Threading.Tasks;
using Vertis.PayGO.Gate2All.HttpClient.CreditCard;

namespace Vertis.PayGO.Gate2All.HttpClient
{
    public interface IGate2AllHttpService
    {
        bool AvoidThrowingExceptions { get; set; }

        CreateAuthorizationResponse Authorize(CreateAuthorizationRequest request);

        Task<CreateAuthorizationResponse> AuthorizeAsync(CreateAuthorizationRequest request,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
