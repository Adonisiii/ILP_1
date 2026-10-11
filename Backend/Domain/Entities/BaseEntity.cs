namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CreateUserId { get; set; }
        public User CreateUser { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public Guid? UpdateUserId { get; set; }
        public User? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}