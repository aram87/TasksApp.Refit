namespace TasksApp.Refit.DesktopClient.Responses
{
    public class TokenResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
    }
}