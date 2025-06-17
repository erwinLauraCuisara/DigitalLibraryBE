using DigitalLibraryBe.Domain.Entities;
using System.Linq.Expressions;

namespace DigitalLibraryBe.Infrastructure.Common
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> source,
            bool condition,
            Expression<Func<T, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<LiteraryBook> ApplySorting(
            this IQueryable<LiteraryBook> query,
            string? sortBy,
            string sortDirection)
        {
            bool ascending = sortDirection == "ascend";

            return sortBy switch
            {
                "title" => ascending
                    ? query.OrderBy(b => b.Title)
                    : query.OrderByDescending(b => b.Title),

                "createdAt" => ascending
                    ? query.OrderBy(b => b.CreatedAt)
                    : query.OrderByDescending(b => b.CreatedAt),

                "publicationDate" => ascending
                    ? query.OrderBy(b => b.PublicationDate)
                    : query.OrderByDescending(b => b.PublicationDate),

                _ => query.OrderByDescending(b => b.CreatedAt)
            };
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int size)
        {
            var skip = (page - 1) * size;
            return query.Skip(skip).Take(size);
        }
    }
}
