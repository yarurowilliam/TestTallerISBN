namespace TDDTest;

using Xunit;

public class PasswordValidatorTests
{
    private readonly PasswordValidator _validator;

    public PasswordValidatorTests()
    {
        _validator = new PasswordValidator();
    }

    [Fact]
    public void Password_TooShort_ReturnsError()
    {
        var result = _validator.ValidatePassword("Pass1!");

        Assert.False(result.IsValid);
        Assert.Contains("Password must be at least 8 characters", result.Errors);
    }

    [Fact]
    public void Password_MissingNumbers_ReturnsError()
    {
        var result = _validator.ValidatePassword("Password!");

        Assert.False(result.IsValid);
        Assert.Contains("The password must contain at least 2 numbers", result.Errors);
    }

    [Fact]
    public void Password_MissingCapitalLetter_ReturnsError()
    {
        var result = _validator.ValidatePassword("password1!");

        Assert.False(result.IsValid);
        Assert.Contains("Password must contain at least one capital letter", result.Errors);
    }

    [Fact]
    public void Password_MissingSpecialCharacter_ReturnsError()
    {
        var result = _validator.ValidatePassword("Password1");

        Assert.False(result.IsValid);
        Assert.Contains("Password must contain at least one special character", result.Errors);
    }

    [Fact]
    public void Password_WithMultipleErrors_ReturnsAllErrors()
    {
        var result = _validator.ValidatePassword("pass");

        Assert.False(result.IsValid);
        Assert.Contains("Password must be at least 8 characters", result.Errors);
        Assert.Contains("The password must contain at least 2 numbers", result.Errors);
        Assert.Contains("Password must contain at least one capital letter", result.Errors);
        Assert.Contains("Password must contain at least one special character", result.Errors);
    }

    [Fact]
    public void Password_ValidPassword_ReturnsSuccess()
    {
        var result = _validator.ValidatePassword("Password12!");

        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
}
