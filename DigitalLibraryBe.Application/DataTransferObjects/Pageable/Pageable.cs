namespace DigitalLibraryBe.Application.DataTransferObjects.Pageable
{
    public class Pageable<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
