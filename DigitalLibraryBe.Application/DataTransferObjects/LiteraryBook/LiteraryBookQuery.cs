namespace DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook
{
    public class LiteraryBookQuery
    {
        public LiteraryBookFilter Filter { get; set; } = new();
        public PaginationFilter Pagination { get; set; } = new();
    }
}
