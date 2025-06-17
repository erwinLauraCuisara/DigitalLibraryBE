using DigitalLibraryBe.Application.Abstractions.Repositories;
using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Application.DataTransferObjects.Pageable;
using DigitalLibraryBe.Domain.Entities;
using DigitalLibraryBe.Infrastructure.Common;
using DigitalLibraryBe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibraryBe.Infrastructure.Repositories
{
    public class LiteraryBookRepository(DigitaLibraryDbContext context) : ILiteraryBookRepository
    {
        public async Task<Pageable<LiteraryBook>> GetAllAsync(LiteraryBookQuery query)
        {
            var filter = query.Filter;
            var pagination = query.Pagination;

            var baseQuery = context.LiteraryBooks
                .Include(lb => lb.Authors)
                .AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(filter.Title), lb => lb.Title.ToUpper().Contains(filter.Title!.ToUpper()))
                .WhereIf(filter.PublicationDate.HasValue, lb => lb.PublicationDate.Date == filter.PublicationDate!.Value.Date)
                .WhereIf(filter.AuthorIds.Any(), lb => lb.Authors.Any(author => filter.AuthorIds.Contains(author.Id)));

            var totalCount = await baseQuery.CountAsync();

            var literaryBooks = await baseQuery
                .ApplySorting(pagination.SortBy, pagination.SortDirection)
                .Paginate(pagination.Page, pagination.Size)
                .ToListAsync();

            return new Pageable<LiteraryBook>
            {
                Items = literaryBooks,
                Page = pagination.Page,
                Size = pagination.Size,
                TotalCount = totalCount,
            };
        }

        public async Task<LiteraryBook> GetByIdAsync(Guid literaryBookId)
        {
            return await context.LiteraryBooks
                .Include(lb => lb.Authors)
                .FirstAsync(lb => lb.Id == literaryBookId);
        }

        public async Task CreateAsync(LiteraryBook literaryBook)
        {
            await context.LiteraryBooks.AddAsync(literaryBook);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LiteraryBook literaryBook)
        {
            literaryBook.UpdatedAt = DateTime.Now;
            context.LiteraryBooks.Update(literaryBook);
            await context.SaveChangesAsync();
        }
    }
}
