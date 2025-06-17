using DigitalLibraryBe.Application.DataTransferObjects.LiteraryBook;
using FluentValidation;

namespace DigitalLibraryBe.Application.Validators
{
    public class LiteraryBookRequestValidator : AbstractValidator<LiteraryBookRequest>
    {
        public LiteraryBookRequestValidator() {
            RuleFor(lb => lb.Title)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Title should not be empty")
                .MaximumLength(255);
            
            RuleFor(lb => lb.PublicationDate)
                .Must(d => d != default);

            RuleFor(lb => lb.AuthorIds)
                .Must(a => a.Count() > 0).WithMessage("At least an author is required")
                .Must(a => a.Distinct().Count() == a.Count()).WithMessage("No duplicate authors");
        }
    }
}
