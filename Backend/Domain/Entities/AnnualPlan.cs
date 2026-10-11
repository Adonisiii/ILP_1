namespace Domain.Entities
{
    public class AnnualPlan : BaseEntity
    {
        public int Year { get; set; }
        public Guid ApplicationRequestId { get; set; }
        public ApplicationRequest ApplicationRequest { get; set; } = null!;
        public ICollection<AnnualPlanItems> AnnualPlanItems { get; set; } = new List<AnnualPlanItems>();
    }
}