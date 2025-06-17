namespace DigitalLibraryBe.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<LiteraryBook> LiteraryBooks { get; set; } = new List<LiteraryBook>();
    }
}
