using Entities.Concrete;
using FluentValidation;

namespace Business.Validations
{
    internal class CountryValidation : AbstractValidator<Country>
    {
        public CountryValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name cannot be empty");
        }
    }
}
