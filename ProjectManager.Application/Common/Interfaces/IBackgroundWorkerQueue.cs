namespace ProjectManager.Application.Common.Interfaces;

public interface IBackgroundWorkerQueue
{
    Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    void QueueBackgroundWorkerItem(Func<CancellationToken, Task> workItem, string workItemDescription);
};
