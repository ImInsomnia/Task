using Entities.Concrete;
using FluentValidation;

namespace Business.Validations
{
    internal class SizeValidation : AbstractValidator<Size>
    {
        public SizeValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name cannot be empty");
        }
    }
}
