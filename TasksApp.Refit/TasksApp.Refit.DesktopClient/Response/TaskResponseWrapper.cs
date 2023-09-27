using TasksApp.Refit.DesktopClient.Responses;

namespace TasksApp.Refit.DesktopClient.Response
{
    public class TaskResponseWrapper : BaseResponse
    {
        public List<TaskResponse> Tasks { get; set; }
    }
}