using Entities.Concrete;
using FluentValidation;

namespace Business.Validations
{
    internal class CharacteristicsValidation : AbstractValidator<Characteristics>
    {
        public CharacteristicsValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name cannot be empty");
        }
    }
}
