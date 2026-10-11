namespace Domain.Entities
{
    public class Annex : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ApplicationRequestId { get; set; }
        public ApplicationRequest ApplicationRequest { get; set; } = null!;
    }
}