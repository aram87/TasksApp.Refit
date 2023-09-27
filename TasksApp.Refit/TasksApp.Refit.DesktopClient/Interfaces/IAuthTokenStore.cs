using TasksApp.Refit.DesktopClient.Responses;

namespace TasksApp.Refit.DesktopClient.Interfaces
{
    public interface IAuthTokenStore
    {
        TokenResponse? GetAuthToken();
        void SetAuthToken(TokenResponse? tokenResponse);
        void ClearAuthToken();
    }
}