namespace ProjectManager.Domain.Entities
{
    public class ToolRent

    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Comment { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}