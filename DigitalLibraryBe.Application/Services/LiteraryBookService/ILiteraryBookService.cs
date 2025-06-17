using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Application.DataTransferObjects.Pageable;

namespace DigitalLibraryBe.Application.Services.LiteraryBookService
{
    public interface ILiteraryBookService
    {
        Task<Pageable<LiteraryBookResponse>> GetAllAsync(LiteraryBookQuery query);
        Task<LiteraryBookResponse> GetByIdAsync(Guid literaryBookId);
        Task<LiteraryBookResponse> CreateAsync(LiteraryBookRequest literaryBookRequest);
        Task<LiteraryBookResponse> UpdateAsync(Guid literaryBookId, LiteraryBookRequest literaryBookRequest);
    }
}
