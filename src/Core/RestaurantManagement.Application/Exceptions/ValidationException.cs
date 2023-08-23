namespace RestaurantManagement.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public override string Message => GetErrors();

        public ValidationException(ValidationResult validationResult)
        {

            ValidationErrors = new List<String>();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        private string GetErrors()
        {
            StringBuilder message = new StringBuilder();
            message.Append("Following erros appeared when trying to execute your request: ");
            foreach (var error in ValidationErrors)
            {
                message.AppendLine(error);
            }
            return message.ToString();
        }
    }
}
