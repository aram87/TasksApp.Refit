using TasksApp.Refit.DesktopClient.Requests;
using TasksApp.Refit.DesktopClient.Response;
using TasksApp.Refit.DesktopClient.Responses;
using Refit;

namespace TasksApp.Refit.DesktopClient.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponseWrapper> GetTasks();
        Task<TaskResponseWrapper> AddTask([Body] TaskRequest task);
        Task<BaseResponse> DeleteTask([Body] TaskRequest task);
    }
}