using FluentValidation.Results;
using System.Text;

namespace Business.Extensions
{
    public static class FluentValidationExtensions
    {
        public static string FluentErrorsToString(this List<ValidationFailure> errors)
        {
            StringBuilder sb = new();
            foreach (var error in errors)
            {
                sb.Append(error.ErrorMessage);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
