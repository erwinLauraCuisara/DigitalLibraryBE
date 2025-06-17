using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using DigitalLibraryBe.Application.Services.LiteraryBookService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibraryBe.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiteraryBookController(
        ILiteraryBookService literaryBookService,
        IValidator<LiteraryBookRequest> validator
    ) : ControllerBase
    {
        [HttpPost("all")]
        public async Task<IActionResult> GetAllAsync([FromBody] LiteraryBookQuery query)
        {
            return Ok(await literaryBookService.GetAllAsync(query));
        }

        [HttpGet("{literaryBookId}")]
        public async Task<IActionResult> GetByIdAsync(Guid literaryBookId)
        {
            return Ok(await literaryBookService.GetByIdAsync(literaryBookId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LiteraryBookRequest literaryBookRequest)
        {
            var validatorResult = await validator.ValidateAsync(literaryBookRequest);
            if (!validatorResult.IsValid) return BadRequest(new { Error = validatorResult.Errors.Select(e => e.ErrorMessage) });

            return Ok(await literaryBookService.CreateAsync(literaryBookRequest));
        }

        [HttpPut("{literaryBookId}")]
        public async Task<IActionResult> UpdateAsync(Guid literaryBookId, [FromBody] LiteraryBookRequest literaryBookRequest)
        {
            var validatorResult = await validator.ValidateAsync(literaryBookRequest);
            if (!validatorResult.IsValid) return BadRequest(new { Error = validatorResult.Errors.Select(e => e.ErrorMessage) });

            return Ok(await literaryBookService.UpdateAsync(literaryBookId, literaryBookRequest));
        }
    }
}
