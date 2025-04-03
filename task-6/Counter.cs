namespace task_6;

public class Counter
{
    private int _counter = 0;
    private Random _randomGenerator = new Random();
    public event CounterChanged OnCounterChanged;

    public void IncrementByRandom()
    {
        _counter += _randomGenerator.Next(1, 10);
        OnCounterChanged?.Invoke(_counter);
    }
    
    public delegate void CounterChanged(int counter);
}