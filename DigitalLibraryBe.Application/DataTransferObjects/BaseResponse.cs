namespace DigitalLibraryBe.Application.DataTransferObjects
{
    public class BaseResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
