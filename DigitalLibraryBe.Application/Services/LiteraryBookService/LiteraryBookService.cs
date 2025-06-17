using AutoMapper;
using DigitalLibraryBe.Application.Abstractions.Repositories;
using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Application.DataTransferObjects.Pageable;
using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Services.LiteraryBookService
{
    public class LiteraryBookService(
        IMapper mapper,
        ILiteraryBookRepository literaryBookRepository,
        IAuthorRepository authorRepository
    ) : ILiteraryBookService
    {
        public async Task<Pageable<LiteraryBookResponse>> GetAllAsync(LiteraryBookQuery query)
        {
            var literaryBookPaged = await literaryBookRepository.GetAllAsync(query);
            
            return new Pageable<LiteraryBookResponse>
            {
                Items = mapper.Map<List<LiteraryBookResponse>>(literaryBookPaged.Items),
                TotalCount = literaryBookPaged.TotalCount,
                Page = literaryBookPaged.Page,
                Size = literaryBookPaged.Size
            };
        }

        public async Task<LiteraryBookResponse> GetByIdAsync(Guid literaryBookId)
        {
            var literaryBook = await literaryBookRepository.GetByIdAsync(literaryBookId);

            return mapper.Map<LiteraryBookResponse>(literaryBook);
        }

        public async Task<LiteraryBookResponse> CreateAsync(LiteraryBookRequest literaryBookRequest)
        {
            var author = mapper.Map<LiteraryBook>(literaryBookRequest);
            author.Authors = await GetAuthorsByIdsOrThrow(literaryBookRequest.AuthorIds);

            await literaryBookRepository.CreateAsync(author);

            return await GetByIdAsync(author.Id);
        }

        public async Task<LiteraryBookResponse> UpdateAsync(Guid literaryBookId, LiteraryBookRequest literaryBookRequest)
        {
            var literaryBook = await literaryBookRepository.GetByIdAsync(literaryBookId);
            mapper.Map(literaryBookRequest, literaryBook);
            literaryBook.Authors = await GetAuthorsByIdsOrThrow(literaryBookRequest.AuthorIds);

            await literaryBookRepository.UpdateAsync(literaryBook);

            return await GetByIdAsync(literaryBook.Id);
        }

        private async Task<IEnumerable<Author>> GetAuthorsByIdsOrThrow(IEnumerable<Guid> authorIdList)
        {
            if (!authorIdList.Any()) throw new Exception("At least one author is required");

            var authors = await authorRepository.GetAllByIdsAsync(authorIdList);

            if (authors.Count() != authorIdList.Count()) throw new Exception("One or more authors not found");

            return authors;
        }
    }
}
