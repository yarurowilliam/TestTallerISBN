namespace TDDTest;

public class ValidateISBN
{
    public static readonly int ISBN_SHORT = 10;
    public static readonly int ISBN_LONG = 13;
    public static readonly int ISBN_SHORT_VALIDATOR = 11;
    public static readonly int ISBN_LONG_VALIDATOR = 10;

    public bool CheckISBN(string isbn)
    {
        if (isbn.Length == ISBN_SHORT || isbn.Length == ISBN_LONG)
        {
            if (isbn.Length == ISBN_LONG)
            {
                return CheckISBNThirteenDigits(isbn);
            }
            else
            {
                return CheckISBNTenDigits(isbn);
            }
        }
        else
        {
            throw new FormatException("El número ISBN debe tener una longitud de 10 o 13.");
        }
    }

    private bool CheckISBNTenDigits(string isbn)
    {
        int total = 0;
        for (int i = 0; i < ISBN_SHORT; i++)
        {
            if (!char.IsDigit(isbn[i]))
            {
                if (i == 9 && isbn[i] == 'X')
                {
                    total += 10;
                }
                else
                {
                    throw new FormatException("El ISBN solo puede contener dígitos.");
                }
            }
            else
            {
                total += (isbn[i] - '0') * (ISBN_SHORT - i);
            }
        }
        return total % ISBN_SHORT_VALIDATOR == 0;
    }

    private bool CheckISBNThirteenDigits(string isbn)
    {
        int total = 0;
        for (int i = 0; i < ISBN_LONG; i++)
        {
            if (char.IsDigit(isbn[i]))
            {
                total += (isbn[i] - '0') * (i % 2 == 0 ? 1 : 3);
            }
            else
            {
                throw new FormatException("El ISBN solo puede contener dígitos.");
            }
        }
        return total % ISBN_LONG_VALIDATOR == 0;
    }
}