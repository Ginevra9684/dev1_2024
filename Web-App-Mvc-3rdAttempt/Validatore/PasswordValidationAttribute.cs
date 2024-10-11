using System.ComponentModel.DataAnnotations;

public class PasswordValidationAttribute : ValidationAttribute
{
    private readonly string _expectedPassword;

    public PasswordValidationAttribute(string expectedPassword)
    {
        _expectedPassword = expectedPassword;
        ErrorMessage = "Il codice non è corretto.";  // Error message for incorrect password
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Logging for debugging
        Console.WriteLine("Password validation triggered");

        var passwordValue = value?.ToString();
        if (string.IsNullOrEmpty(passwordValue) || passwordValue != _expectedPassword)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}