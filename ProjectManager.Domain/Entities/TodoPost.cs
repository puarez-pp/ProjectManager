namespace ProjectManager.Domain.Entities
{
    public class TodoPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TodoId { get; set; }
        public Todo Todo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
