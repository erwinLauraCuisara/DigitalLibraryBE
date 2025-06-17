namespace DigitalLibraryBe.Domain.Entities
{
    public class LiteraryBook : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    }
}
