using TasksApp.Refit.DesktopClient.Responses;

namespace TasksApp.Refit.DesktopClient.Services
{
    public interface IUserService
    {
        Task<TokenResponse> Login(string email, string password);
        Task Logout();
    }
}