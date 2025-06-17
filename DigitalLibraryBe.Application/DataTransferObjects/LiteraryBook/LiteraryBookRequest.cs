namespace DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook
{
    public class LiteraryBookRequest
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public IEnumerable<Guid> AuthorIds { get; set; } = new List<Guid>();
    }
}
