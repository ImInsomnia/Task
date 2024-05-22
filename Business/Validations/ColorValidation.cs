using Entities.Concrete;
using FluentValidation;

namespace Business.Validations
{
    internal class ColorValidation : AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name cannot be empty");
        }
    }
}
