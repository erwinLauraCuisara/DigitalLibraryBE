namespace DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook
{
    public class LiteraryBookFilter
    {
        public string? Title { get; set; } = null;
        public DateTime? PublicationDate { get; set; } = null;
        public IEnumerable<Guid> AuthorIds { get; set; } = new List<Guid>();
    }   
}
