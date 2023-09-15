namespace agrolugue_api.Domain.Exceptions.PasswordValidation
{
    public class PasswordValidationException : Exception
    {
        public PasswordValidationException() { }

        public PasswordValidationException(string message)
            : base(message)
        {

        }

        public PasswordValidationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
