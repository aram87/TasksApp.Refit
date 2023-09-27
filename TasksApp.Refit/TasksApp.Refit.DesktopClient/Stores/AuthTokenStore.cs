using TasksApp.Refit.DesktopClient.Interfaces;
using TasksApp.Refit.DesktopClient.Responses;

namespace TasksApp.Refit.DesktopClient.Stores
{
    public class AuthTokenStore : IAuthTokenStore
    {
        private TokenResponse? _token;

        public void ClearAuthToken()
        {
            _token = null;
        }

        public TokenResponse? GetAuthToken() => _token ?? new TokenResponse();

        public void SetAuthToken(TokenResponse? tokenResponse)
        {
            _token = tokenResponse;
        }
    }
}