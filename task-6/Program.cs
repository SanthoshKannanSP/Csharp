using task_6;

class Program
{
    public static void Main(string[] args)
    {
        var counter = new Counter();
        var evenListener = new EvenListener();
        var logger = new Logger("log.txt");

        counter.OnCounterChanged += evenListener.AnnounceEven;
        counter.OnCounterChanged += logger.LogValue;

        for (var iteration = 0; iteration < 10; iteration++)
        {
            counter.IncrementByRandom();
        }
    }
}