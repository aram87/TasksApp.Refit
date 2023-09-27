using TasksApp.Refit.DesktopClient.Interfaces;
using TasksApp.Refit.DesktopClient.Services;
using TasksApp.Refit.DesktopClient.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using TasksApp.Refit.DesktopClient.Forms;
using TasksApp.Refit.DesktopClient.Handlers;

namespace TasksApp.Refit.DesktopClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            Application.Run(host.Services.GetRequiredService<LoginForm>());
        }
        static IHostBuilder CreateHostBuilder()
        {

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddTransient<ITaskService, TaskService>();
                    services.AddTransient<IUserService, UserService>();
                    services.AddSingleton<IAuthTokenStore, AuthTokenStore>();
                    services.AddTransient<AuthHeaderHandler>();
                    services.AddSingleton<LoginForm>();
                    services.AddSingleton<TasksForm>();
                    services.AddRefitClient<ITaskApi>()
                            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7217/api"))
                            .AddHttpMessageHandler<AuthHeaderHandler>();
                });
        }
    }
}