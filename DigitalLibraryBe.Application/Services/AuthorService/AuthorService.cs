using AutoMapper;
using DigitalLibraryBe.Application.Abstractions.Repositories;
using DigitalLibraryBe.Application.DataTransferObjects.Author;
using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Services.AuthorService
{
    public class AuthorService (
        IMapper mapper,
        IAuthorRepository authorRepository    
    ) : IAuthorService
    {
        public async Task<IEnumerable<AuthorResponse>> GetAllAsync()
        {
            var authors = await authorRepository.GetAllAsync();

            return mapper.Map<IEnumerable<AuthorResponse>>(authors);
        }

        public async Task<AuthorResponse> GetAuthorByIdAsync(Guid authorId)
        {
            var author = await authorRepository.GetByIdAsync(authorId);

            return mapper.Map<AuthorResponse>(author);
        }

        public async Task<AuthorResponse> CreateAsync(AuthorRequest authorRequest)
        {
            var author = mapper.Map<Author>(authorRequest);
            await authorRepository.CreateAsync(author);

            return await GetAuthorByIdAsync(author.Id);
        }

        public async Task<AuthorResponse> UpdateAsync(Guid authorId, AuthorRequest authorRequest)
        {
            var author = await authorRepository.GetByIdAsync(authorId);
            mapper.Map(authorRequest, author);
            await authorRepository.UpdateAsync(author);

            return await GetAuthorByIdAsync(author.Id);
        }
    }
}
