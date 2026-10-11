using Domain.Enums;

namespace Domain.Entities
{
    public class ApplicationRequest : BaseEntity
    {
        public string ApplicationNumber { get; set; } = string.Empty;
        public string TaxPayerName { get; set; } = string.Empty;
        public string NUI { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Manager { get; set; } = string.Empty;
        public ApplicationStatus Status { get; set; } 
        public CurrentStep CurrentStep { get; set; } 
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<ApplicationDocument> ApplicationDocuments { get; set; } = new List<ApplicationDocument>();
        public ICollection<Annex> Annexes { get; set; } = new List<Annex>();
        public AnnualPlan? AnnualPlan { get; set; }
    }
}