using ProjectManager.Application.Common.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Services;

public class LongRunningService : BackgroundService
{
    private readonly IBackgroundWorkerQueue _queue;
    private readonly ILogger<LongRunningService> _logger;

    public LongRunningService(
        IBackgroundWorkerQueue queue,
        ILogger<LongRunningService> logger)
    {
        _queue = queue;
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var workItem = await _queue.DequeueAsync(stoppingToken);//pobranie delegata z kolejki
                _logger.LogInformation("DequeueAsync Start...");
                await workItem(stoppingToken);
                _logger.LogInformation("DequeueAsync Stop...");
            }
            catch (Exception exception)
            {

                _logger.LogError(exception, null);
            }
        }
    }
}
