namespace Domain.Entities
{
    public class ApplicationDocument : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public Guid ApplicationRequestId { get; set; }
        public ApplicationRequest ApplicationRequest { get; set; } = null!;
    }
}