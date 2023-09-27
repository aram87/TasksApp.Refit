using TasksApp.Refit.DesktopClient.Interfaces;
using System.Net.Http.Headers;

namespace TasksApp.Refit.DesktopClient.Handlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IAuthTokenStore authTokenStore;

        public AuthHeaderHandler(IAuthTokenStore authTokenStore)
        {
            this.authTokenStore = authTokenStore;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = authTokenStore.GetAuthToken();

            if (token is null)
            {
               return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }

            //TODO: Add code here to refresh the token if it has expired or near expiry (silent refresh)

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
