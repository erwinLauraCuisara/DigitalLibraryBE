using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Abstractions.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(Guid authorId);
        Task CreateAsync(Author author);
        Task UpdateAsync(Author author);
        Task<IEnumerable<Author>> GetAllByIdsAsync(IEnumerable<Guid> ids);
    }
}
