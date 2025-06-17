using DigitalLibraryBe.Application.Abstractions.Repositories;
using DigitalLibraryBe.Infrastructure.Context;
using DigitalLibraryBe.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibraryBe.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ILiteraryBookRepository, LiteraryBookRepository>();

            services.AddDbContext<DigitaLibraryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DigitalLibraryDbContext")));

            return services;
        }
    }
}
