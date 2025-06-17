using DigitalLibraryBe.Application.Abstractions.Repositories;
using DigitalLibraryBe.Domain.Entities;
using DigitalLibraryBe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibraryBe.Infrastructure.Repositories
{
    public class AuthorRepository(DigitaLibraryDbContext context): IAuthorRepository
    {
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await context.Authors
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<Author> GetByIdAsync(Guid authorId)
        {
            return await context.Authors
                .FirstAsync(author => author.Id == authorId);
        }

        public async Task CreateAsync(Author author)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            author.UpdatedAt = DateTime.Now;
            context.Authors.Update(author);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllByIdsAsync(IEnumerable<Guid> ids)
        {
            return await context.Authors
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }
    }
}
