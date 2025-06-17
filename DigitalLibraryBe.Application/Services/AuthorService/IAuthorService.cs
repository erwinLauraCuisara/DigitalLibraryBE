using DigitalLibraryBe.Application.DataTransferObjects.Author;

namespace DigitalLibraryBe.Application.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponse>> GetAllAsync();
        Task<AuthorResponse> GetAuthorByIdAsync(Guid authorId);
        Task<AuthorResponse> CreateAsync(AuthorRequest authorRequest);
        Task<AuthorResponse> UpdateAsync(Guid authorId, AuthorRequest authorRequest);
    }
}
