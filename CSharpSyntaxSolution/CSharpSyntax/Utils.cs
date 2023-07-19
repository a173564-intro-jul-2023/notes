namespace CSharpSyntax;



public class Utils
{
    public static string FormatName(string firstName, string lastName)
    {
        return $"{lastName.Trim()}, {firstName.Trim()}";
    }
}

