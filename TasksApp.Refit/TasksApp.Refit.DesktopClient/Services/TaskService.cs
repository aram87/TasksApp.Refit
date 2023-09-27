using TasksApp.Refit.DesktopClient.Interfaces;
using TasksApp.Refit.DesktopClient.Requests;
using TasksApp.Refit.DesktopClient.Response;
using TasksApp.Refit.DesktopClient.Responses;
using Refit;

namespace TasksApp.Refit.DesktopClient.Services
{
    public class TaskService : ITaskService
    {
        public TaskService(ITaskApi taskApi)
        {
            TaskApi = taskApi;
        }

        public ITaskApi TaskApi { get; }
        
        public async Task<TaskResponseWrapper> AddTask([Body] TaskRequest task)
        {
            var addTaskResponse = await TaskApi.AddTask(task);

            if (!addTaskResponse.IsSuccessStatusCode)
            {
                if (addTaskResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // Ideally this should call the refresh token endpoint to get a new access token
                    // and refresh token and then retry the same action with the new token, and this should apply to all other endpoints
                    // but for this tutorial, we are just expiring the session and redirecting to logout

                    return new TaskResponseWrapper { Success = false, Error = "Session Expired", ErrorCode = "AT01" };

                }
                return new TaskResponseWrapper { Success = false, Error = addTaskResponse.Error?.Content ?? "Invalid add task response", ErrorCode = "AT02" };
            }

            if (addTaskResponse.Content is null)
            {
                return new TaskResponseWrapper { Success = false, Error = "Invalid add task response", ErrorCode = "AT02" };
            }

            return new TaskResponseWrapper { Success = true, Tasks = new List<TaskResponse> { addTaskResponse.Content }};

        }

        public async Task<BaseResponse> DeleteTask(TaskRequest task)
        {
            var deleteTaskResponse = await TaskApi.DeleteTask(task.Id);
          
            if (!deleteTaskResponse.IsSuccessStatusCode)
            {
                return new BaseResponse { Success = false, Error = deleteTaskResponse.Error?.Content ?? "Invalid delete task response", ErrorCode = "DT01" };
            }

            return new BaseResponse { Success = true };
        }

        public async Task<TaskResponseWrapper> GetTasks()
        {
            var getTasksResponse = await TaskApi.GetTasks();

            if (!getTasksResponse.IsSuccessStatusCode)
            {
                return new TaskResponseWrapper { Success = false, Error = getTasksResponse.Error?.Content ?? "Invalid response", ErrorCode = "GT01" };
            }

            return new TaskResponseWrapper { Success = true, Tasks = getTasksResponse.Content ?? new List<TaskResponse>()};

        }

    }
}
