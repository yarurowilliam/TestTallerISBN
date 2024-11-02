using System.Linq;
using System.Text.RegularExpressions;

namespace TDDTest;

using System.Diagnostics;

public class PasswordValidator
{
    public PasswordValidationResult ValidatePassword(string password)
    {
        var result = new PasswordValidationResult();

        if (password.Length < 8)
        {
            Debug.WriteLine("Failed length check");
            result.Errors.Add("Password must be at least 8 characters");
        }

        if (password.Count(char.IsDigit) < 2)
        {
            Debug.WriteLine("Failed digit count check");
            result.Errors.Add("The password must contain at least 2 numbers");
        }

        if (!password.Any(char.IsUpper))
        {
            Debug.WriteLine("Failed capital letter check");
            result.Errors.Add("Password must contain at least one capital letter");
        }

        if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
        {
            Debug.WriteLine("Failed special character check");
            result.Errors.Add("Password must contain at least one special character");
        }

        result.IsValid = result.Errors.Count == 0;
        return result;
    }
}
