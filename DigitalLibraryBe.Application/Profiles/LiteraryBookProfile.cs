using AutoMapper;
using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Profiles
{
    public class LiteraryBookProfile : Profile
    {
        public LiteraryBookProfile() {
            CreateMap<LiteraryBook, LiteraryBookResponse>();
            CreateMap<LiteraryBookRequest, LiteraryBook>();
        }
    }
}
