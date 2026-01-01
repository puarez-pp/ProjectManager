namespace ProjectManager.Domain.Entities
{
    public class ToolRental
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Comment { get; set; }
        public DateTime RentalData { get; set; }
        public DateTime? ReturnData { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}