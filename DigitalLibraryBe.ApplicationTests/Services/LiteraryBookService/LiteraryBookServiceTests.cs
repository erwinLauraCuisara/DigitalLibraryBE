using Xunit;
using Moq;
using AutoMapper;
using DigitalLibraryBe.Application.Abstractions.Repositories;
using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Domain.Entities;

namespace DigitalLibraryBe.Application.Services.LiteraryBookService.Tests
{
    public class LiteraryBookServiceTests
    {
        private readonly Mock<IMapper> mapperMock = new();
        private readonly Mock<ILiteraryBookRepository> bookRepoMock = new();
        private readonly Mock<IAuthorRepository> authorRepoMock = new();

        private readonly LiteraryBookService service;

        public LiteraryBookServiceTests()
        {
            service = new LiteraryBookService(
                mapperMock.Object,
                bookRepoMock.Object,
                authorRepoMock.Object
            );
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsBookResponse()
        {
            var bookId = Guid.NewGuid();
            var book = new LiteraryBook { Id = bookId, Title = "Test Book" };
            var response = new LiteraryBookResponse { Id = bookId, Title = "Test Book" };

            bookRepoMock.Setup(r => r.GetByIdAsync(bookId)).ReturnsAsync(book);
            mapperMock.Setup(m => m.Map<LiteraryBookResponse>(book)).Returns(response);

            var result = await service.GetByIdAsync(bookId);

            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
            Assert.Equal("Test Book", result.Title);
        }

        [Fact]
        public async Task CreateAsync_ValidRequest_ShouldCreateBookAndReturnResponse()
        {
            var bookId = Guid.NewGuid();
            var authorIds = new List<Guid> { Guid.NewGuid() };

            var request = new LiteraryBookRequest { Title = "New Book", AuthorIds = authorIds };

            var mappedBook = new LiteraryBook
            {
                Id = bookId,
                Title = "New Book",
            };

            var authors = new List<Author> { new() { Id = authorIds[0], Name = "Author 1" }};

            var response = new LiteraryBookResponse { Id = bookId, Title = "New Book" };

            mapperMock.Setup(m => m.Map<LiteraryBook>(request)).Returns(mappedBook);
            authorRepoMock.Setup(a => a.GetAllByIdsAsync(authorIds)).ReturnsAsync(authors);
            bookRepoMock.Setup(r => r.CreateAsync(It.IsAny<LiteraryBook>())).Returns(Task.CompletedTask);
            bookRepoMock.Setup(r => r.GetByIdAsync(bookId)).ReturnsAsync(mappedBook);
            mapperMock.Setup(m => m.Map<LiteraryBookResponse>(mappedBook)).Returns(response);

            var result = await service.CreateAsync(request);

            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
            Assert.Equal("New Book", result.Title);
        }
    }
}