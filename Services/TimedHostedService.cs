using PivotController.Controllers;

namespace PivotController.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimedHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Calculate the initial delay until 8 PM
            ScheduleNextRun();
            return Task.CompletedTask;
        }

        private void ScheduleNextRun()
        {
            // Get the current time
            var now = DateTime.Now;
            // Calculate the next 8 PM
            var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0);
            // If it's already past 10 PM today, schedule for tomorrow
            if (now > nextRunTime)
            {
                nextRunTime = nextRunTime.AddDays(1);
            }

            // Calculate the time difference between now and the next run time
            var timeUntilNextRun = nextRunTime - now;
            // Schedule the timer to call the method at the calculated time
            _timer = new Timer(ExecuteTask, null, timeUntilNextRun, Timeout.InfiniteTimeSpan);
        }

        private async void ExecuteTask(object state)
        {
            // Call the post method
            await CallPostMethodAsync();
            // Schedule the next run for the next day at 10 PM
            ScheduleNextRun();
        }

        private async Task CallPostMethodAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetRequiredService<PivotController.Controllers.PivotController>();
                await controller.Post();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
