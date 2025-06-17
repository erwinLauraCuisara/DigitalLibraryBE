using DigitalLibraryBe.Application.DataTransferObjects.Author;

namespace DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook
{
    public class LiteraryBookResponse : BaseResponse
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public IEnumerable<AuthorResponse> Authors { get; set; } = new List<AuthorResponse>();
    }
}
