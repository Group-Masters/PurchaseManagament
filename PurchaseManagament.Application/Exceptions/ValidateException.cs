using FluentValidation.Results;

namespace PurchaseManagament.Application.Exceptions
{
    public class ValidateException:Exception
    {

        public List<string> ErrorMessage { get; set; }
        public ValidateException(ValidationResult validationResult) : base()
        {
            ErrorMessage = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
