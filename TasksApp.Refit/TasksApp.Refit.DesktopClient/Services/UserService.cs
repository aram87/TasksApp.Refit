using TasksApp.Refit.DesktopClient.Interfaces;
using TasksApp.Refit.DesktopClient.Responses;

namespace TasksApp.Refit.DesktopClient.Services
{
    public class UserService : IUserService
    {
        public UserService(ITaskApi taskApi, IAuthTokenStore authTokenStore)
        {
            TaskApi = taskApi;
            AuthTokenStore = authTokenStore;
        }

        public ITaskApi TaskApi { get; }
        public IAuthTokenStore AuthTokenStore { get; }

        public async Task<TokenResponse> Login(string email, string password)
        {
            var response = await TaskApi.Login(new Requests.LoginRequest { Email = email, Password = password });

            if (!response.IsSuccessStatusCode)
            {
                return new TokenResponse { Success = false, Error = response.Error?.Content ?? "Invalid response", ErrorCode = "L01" };
            }
            
            var token = response.Content;
            
            if (token is null)
            {
                return new TokenResponse { Success = false, Error = "Token is null", ErrorCode = "L02" };
            }

            AuthTokenStore.SetAuthToken(token);

            return token;
        }

        public async Task Logout()
        {   
            await TaskApi.Logout();

            AuthTokenStore.ClearAuthToken();

        }
    }
}
