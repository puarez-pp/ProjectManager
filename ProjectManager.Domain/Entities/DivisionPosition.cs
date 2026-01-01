using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class DivisionPosition
{
    public int Id { get; set; }
    public DivisionPositionType DivisionPositionType { get; set; }
    public string Comment { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? PerformedData { get; set; }
    public DateTime? CompletionDate { get; set; }
    public int DivisionId { get; set; }
    public Division Division { get; set; }
    public int SubContractorId { get; set; }
    public SubContractor SubContractor { get; set; }
    public ICollection<PositionPost> PositionPosts { get; set; } = new HashSet<PositionPost>();
}
