using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.CriticalPath;
using ProjectManager.Application.Schedules.Dto;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.Services;

public class CriticalPathService : ICriticalPathService
{
    public List<ScheduleTask> CalculateCriticalPath(IEnumerable<ScheduleTask> tasks)
    {
        var graph = BuildGraph(tasks.ToList());
        var sorted = TopologicalSort(graph);

        ForwardPass(sorted);
        BackwardPass(sorted);

        return ExtractCriticalPath(sorted);
    }

    public CriticalPathResult CalculateDetailedCriticalPath(IEnumerable<ScheduleTask> tasks)
    {
        var graph = BuildGraph(tasks.ToList());
        var sorted = TopologicalSort(graph);

        ForwardPass(sorted);
        BackwardPass(sorted);

        return new CriticalPathResult
        {
            Tasks = sorted
                .OrderBy(n => n.ES)
                .Select(n => new CriticalPathTaskDto
                {
                    TaskId = n.Task.Id,
                    Name = n.Task.Name,
                    ES = n.ES,
                    EF = n.EF,
                    LS = n.LS,
                    LF = n.LF,
                    Slack = n.Slack
                })
                .ToList()
        };
    }

    public CriticalPathResultDto CalculateDetailedCriticalPathDto(IEnumerable<ScheduleTask> tasks)
    {
        var graph = BuildGraph(tasks.ToList());
        var sorted = TopologicalSort(graph);

        ForwardPass(sorted);
        BackwardPass(sorted);

        var result = new CriticalPathResultDto
        {
            Tasks = sorted.Select(n => new CriticalPathTaskDto
            {
                TaskId = n.Task.Id,
                Name = n.Task.Name,
                PlannedStart = n.Task.PlannedStart,
                PlannedEnd = n.Task.PlannedEnd,

                ES = n.ES,
                EF = n.EF,
                LS = n.LS,
                LF = n.LF,
                Slack = n.Slack,

                PredecessorIds = n.Predecessors.Select(p => p.Task.Id).ToList(),
                SuccessorIds = n.Successors.Select(s => s.Task.Id).ToList()
            }).ToList()
        };

        result.TotalDuration = sorted.Max(n => n.EF);
        result.FirstTaskId = sorted.OrderBy(n => n.ES).FirstOrDefault()?.Task.Id;
        result.LastTaskId = sorted.OrderByDescending(n => n.EF).FirstOrDefault()?.Task.Id;

        return result;
    }

    private class CpmNode
    {
        public ScheduleTask Task { get; set; }
        public List<CpmNode> Predecessors { get; set; } = new();
        public List<CpmNode> Successors { get; set; } = new();

        public TimeSpan Duration { get; set; }

        public TimeSpan ES { get; set; }
        public TimeSpan EF { get; set; }
        public TimeSpan LS { get; set; }
        public TimeSpan LF { get; set; }

        public TimeSpan Slack => LS - ES;
    }

    private List<CpmNode> BuildGraph(List<ScheduleTask> tasks)
    {
        var map = tasks.ToDictionary(
            t => t.Id,
            t => new CpmNode
            {
                Task = t,
                Duration = (t.PlannedEnd - t.PlannedStart) ?? TimeSpan.Zero
            });

        foreach (var t in tasks)
        {
            var node = map[t.Id];

            foreach (var dep in t.Dependencies)
            {
                var predecessor = map[dep.PredecessorTaskId];
                var successor = map[dep.SuccessorTaskId];

                predecessor.Successors.Add(successor);
                successor.Predecessors.Add(predecessor);
            }
        }

        return map.Values.ToList();
    }

    private List<CpmNode> TopologicalSort(List<CpmNode> nodes)
    {
        var result = new List<CpmNode>();
        var incoming = nodes.ToDictionary(n => n, n => n.Predecessors.Count);

        var queue = new Queue<CpmNode>(nodes.Where(n => incoming[n] == 0));

        while (queue.Any())
        {
            var n = queue.Dequeue();
            result.Add(n);

            foreach (var succ in n.Successors)
            {
                incoming[succ]--;
                if (incoming[succ] == 0)
                    queue.Enqueue(succ);
            }
        }

        if (result.Count != nodes.Count)
            throw new InvalidOperationException("Wykryto cykl w zależnościach zadań.");

        return result;
    }
    private void ForwardPass(List<CpmNode> sorted)
    {
        foreach (var n in sorted)
        {
            n.ES = n.Predecessors.Any()
                ? n.Predecessors.Max(p => p.EF)
                : TimeSpan.Zero;

            n.EF = n.ES + n.Duration;
        }
    }

    private void BackwardPass(List<CpmNode> sorted)
    {
        var maxEF = sorted.Max(n => n.EF);

        foreach (var n in sorted.AsEnumerable().Reverse())
        {
            n.LF = n.Successors.Any()
                ? n.Successors.Min(s => s.LS)
                : maxEF;

            n.LS = n.LF - n.Duration;
        }
    }

    private List<ScheduleTask> ExtractCriticalPath(List<CpmNode> nodes)
    {
        return nodes
            .Where(n => n.Slack == TimeSpan.Zero)
            .OrderBy(n => n.ES)
            .Select(n => n.Task)
            .ToList();
    }
}

