using Entities.Concrete;
using FluentValidation;

namespace Business.Validations
{
    internal class CityValidation : AbstractValidator<City>
    {
        public CityValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name cannot be empty");
        }
    }
}
