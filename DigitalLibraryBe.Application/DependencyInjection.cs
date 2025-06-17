using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Application.Profiles;
using DigitalLibraryBe.Application.Services.AuthorService;
using DigitalLibraryBe.Application.Services.LiteraryBookService;
using DigitalLibraryBe.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibraryBe.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ILiteraryBookService, LiteraryBookService>();

            services.AddAutoMapper(typeof(AuthorProfile));

            services.AddScoped<IValidator<LiteraryBookRequest>, LiteraryBookRequestValidator>();

            return services;
        }
    }
}
