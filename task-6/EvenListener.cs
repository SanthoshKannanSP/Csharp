namespace task_6;

public class EvenListener
{
    public void AnnounceEven(int number)
    {
        if (number % 2 == 0)
        {
            Console.WriteLine($"Wow! The number {number} is Even");
        }
    }
}