using TasksApp.Refit.DesktopClient.Interfaces;
using TasksApp.Refit.DesktopClient.Requests;
using TasksApp.Refit.DesktopClient.Responses;
using TasksApp.Refit.DesktopClient.Services;

namespace TasksApp.Refit.DesktopClient.Forms
{
    public partial class TasksForm : Form
    {
        public TasksForm(ITaskService taskService, IUserService userService)
        {
            InitializeComponent();
            TaskService = taskService;
            UserService = userService;
        }

        public ITaskService TaskService { get; }
        public IUserService UserService { get; }
        public LoginForm? LoginForm { get; set; }

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            TaskRequest taskRequest = new()
            {
                Name = txtTask.Text.Trim(),
                IsCompleted = false,
                Ts = DateTime.Now
            };

            var addResponseWrapper = await TaskService.AddTask(taskRequest);

            if (!addResponseWrapper.Success)
            {
                if (addResponseWrapper.ErrorCode == "AT01")
                {
                    MessageBox.Show("Your login session has expired, must login again");
                    await Logout();
                    return;
                }
                MessageBox.Show($"Cannot add Task due to {addResponseWrapper.Error}");
                return;
            }

            await RefreshTasks();
        }

        private async void Tasks_Load(object sender, EventArgs e)
        {
            await RefreshTasks();
        }

        private async Task<bool> RefreshTasks()
        {
            var tasksResponseWrapper = await TaskService.GetTasks();

            if (!tasksResponseWrapper.Success)
            {
                MessageBox.Show($"Cannot load Tasks due to {tasksResponseWrapper.Error}");
                return false;
                //return;
            }
            lstTasks.Items.Clear();
            // return;
            tasksResponseWrapper.Tasks.ForEach(task =>
            {
                if (lstTasks.Items.IndexOf(task) == -1)
                {
                    lstTasks.Items.Add(task);
                }
                else
                {
                    lstTasks.Items.Remove(task);
                }

            });

            return true;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem is not TaskResponse item) // Tip: This is a declaration pattern matching syntax
            {
                var message = "unable to select item";
                MessageBox.Show(message);
                return;
            }

            var response = await TaskService.DeleteTask(new TaskRequest { Id = item.Id });

            if (!response.Success)
            {
                MessageBox.Show($"Cannot delete Task due to {response.Error}");
                return;
            }

            var tasksResponseWrapper = await TaskService.GetTasks();

            if (!tasksResponseWrapper.Success)
            {
                MessageBox.Show($"Cannot load Tasks due to {tasksResponseWrapper.Error}");
                return;
            }

            lstTasks.Items.Remove(item);

        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await Logout();
        }

        private async Task<bool> Logout()
        {
            await UserService.Logout();

            Hide();

            LoginForm ??= new LoginForm(UserService, TaskService);
            LoginForm.TasksForm = this;
            LoginForm.Show();

            return true;
        }
    }
}
