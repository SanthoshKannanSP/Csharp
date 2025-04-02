using System.Numerics;

BigInteger CalculateFactorial(int n)
{
    if (n == 0 || n == 1)
    {
        return 1;
    }
    return n * CalculateFactorial(n - 1);
}

Console.Write("Enter a number: ");
if (int.TryParse(Console.ReadLine(), out int number))
{
    if (number < 0)
    {
        Console.WriteLine("Factorial cannot be calculated for a negative number!");
    }
    else
    {
        BigInteger factorial = CalculateFactorial(number);
        Console.WriteLine($"The factorial of {number} is {factorial}");
    }
}
else
{
    Console.WriteLine("Enter a valid number!");
}
