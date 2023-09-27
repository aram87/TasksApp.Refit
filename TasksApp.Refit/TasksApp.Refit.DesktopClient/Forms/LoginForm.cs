using TasksApp.Refit.DesktopClient.Interfaces;
using TasksApp.Refit.DesktopClient.Responses;
using TasksApp.Refit.DesktopClient.Services;
using System.Text.Json;

namespace TasksApp.Refit.DesktopClient.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm(IUserService userService, ITaskService taskService)
        {
            InitializeComponent();
            UserService = userService;
            TaskService = taskService;
        }

        public IUserService UserService { get; }
        public ITaskService TaskService { get; }

        public TasksForm? TasksForm { get; set; }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();

            var password = txtPassword.Text.Trim();

            var tokenResponse = await UserService.Login(email, password);

            if (string.IsNullOrEmpty(tokenResponse.AccessToken))
            {
                var baseResponse = JsonSerializer.Deserialize<BaseResponse>(tokenResponse.Error);
                lblMessage.Text = $"Unable to login due to {baseResponse?.Error ?? "technical error"}";

                return;
            }
            
            TasksForm ??= new TasksForm(TaskService, UserService);
            TasksForm.LoginForm = this;
            TasksForm.Show();
            Hide();
        }
    }
}