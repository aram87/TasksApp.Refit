namespace TasksApp.Refit.DesktopClient.Responses
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Ts { get; set; }

        public override string? ToString()
        {
            return Name;
        }
    }
}