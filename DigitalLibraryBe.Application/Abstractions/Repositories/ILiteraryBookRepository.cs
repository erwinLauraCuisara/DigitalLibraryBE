using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Application.DataTransferObjects.Pageable;
using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Abstractions.Repositories
{
    public interface ILiteraryBookRepository
    {
        Task<Pageable<LiteraryBook>> GetAllAsync(LiteraryBookQuery query);
        Task<LiteraryBook> GetByIdAsync(Guid literaryBookId);
        Task CreateAsync(LiteraryBook literaryBook);
        Task UpdateAsync(LiteraryBook literaryBook);
    }
}
