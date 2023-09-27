using TasksApp.Refit.DesktopClient.Requests;
using TasksApp.Refit.DesktopClient.Responses;
using Refit;

namespace TasksApp.Refit.DesktopClient.Interfaces
{
    public interface ITaskApi
    {
        [Post("/users/login")]
        Task<IApiResponse<TokenResponse>> Login([Body] LoginRequest loginRequest);

        [Post("/users/logout")]
        Task<IApiResponse> Logout();

        [Get("/tasks")]
        Task<IApiResponse<List<TaskResponse>>> GetTasks();

        [Post("/tasks")]
        Task<IApiResponse<TaskResponse>> AddTask([Body] TaskRequest task);

        [Delete("/tasks/{id}")]
        Task<IApiResponse<TaskResponse>> DeleteTask([AliasAs("id")] int id);

    }
}