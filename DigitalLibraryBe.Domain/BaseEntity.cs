namespace DigitalLibraryBe.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
    }
}
