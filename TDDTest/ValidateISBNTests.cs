using Xunit;

namespace TDDTest;

public class ValidateISBNTests
{
    private readonly ValidateISBN _validateISBN;

    public ValidateISBNTests()
    {
        _validateISBN = new ValidateISBN();
    }

    [Fact]
    public void CheckValidTenDigitISBN()
    {
        bool result = _validateISBN.CheckISBN("0140449116");
        Assert.True(result);
    }

    [Fact]
    public void CheckInvalidTenDigitISBN()
    {
        bool result = _validateISBN.CheckISBN("0140449117");
        Assert.False(result);
    }

    [Fact]
    public void CheckValidThirteenDigitISBN()
    {
        bool result = _validateISBN.CheckISBN("9780306406157");
        Assert.True(result);
    }

    [Fact]
    public void CheckInvalidThirteenDigitISBN()
    {
        bool result = _validateISBN.CheckISBN("9780306406158");
        Assert.False(result);
    }

    [Fact]
    public void CheckISBNWithXCharacter()
    {
        bool result = _validateISBN.CheckISBN("080442957X");
        Assert.True(result);
    }

    [Fact]
    public void CheckISBNInvalidLengthThrowsException()
    {
        Assert.Throws<FormatException>(() => _validateISBN.CheckISBN("123"));
    }

    [Fact]
    public void CheckISBNNonNumericThrowsException()
    {
        Assert.Throws<FormatException>(() => _validateISBN.CheckISBN("helloworld"));
    }
}