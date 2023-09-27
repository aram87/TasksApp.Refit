using System.Text.Json.Serialization;

namespace TasksApp.Refit.DesktopClient.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}