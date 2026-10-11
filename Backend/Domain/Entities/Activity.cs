namespace Domain.Entities
{
    public class Activity : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ApplicationRequestId { get; set; }
        public ApplicationRequest ApplicationRequest { get; set; } = null!;
    }
}