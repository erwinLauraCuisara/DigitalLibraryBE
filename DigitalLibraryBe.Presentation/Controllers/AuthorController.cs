using DigitalLibraryBe.Application.DataTransferObjects.Author;
using DigitalLibraryBe.Application.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibraryBe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await authorService.GetAllAsync());
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetByIdAsync(Guid authorId)
        {
            return Ok(await authorService.GetAuthorByIdAsync(authorId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AuthorRequest authorRequest)
        {
            return Ok(await authorService.CreateAsync(authorRequest));
        }

        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAsync(Guid authorId, [FromBody] AuthorRequest authorRequest)
        {
            return Ok(await authorService.UpdateAsync(authorId, authorRequest));
        }
    }
}
