
namespace StringCalculatorKata;

internal class StringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == "")
            return 0;

        if (numbers.Length > 2 && numbers.Substring(0,2) == "//")
        {
            numbers = numbers.Replace(numbers[2], ',');
            numbers = numbers.Substring(4);
        }

        numbers = numbers.Replace('\n', ',');
        return sumNumbers(numbers);
    }

    private int sumNumbers(string numbers)
    {
        var numArray = numbers.Split(',');
        var sum = 0;
        foreach (var num in numArray)
        {
            sum += int.Parse(num);
        }
        return sum;
    }
}
