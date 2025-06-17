using AutoMapper;
using DigitalLibraryBe.Application.DataTransferObjects.Author;
using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() {
            CreateMap<Author, AuthorResponse>();
            CreateMap<AuthorRequest, Author>();
        }
    }
}
