namespace Application.DTOs.Response
{
    public class ActivityResponseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ApplicationRequestId { get; set; }
    }
}