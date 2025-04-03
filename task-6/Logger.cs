namespace task_6;

public class Logger
{
    private string _fileName;

    public Logger(string fileName)
    {
        _fileName = fileName;
    }

    public void LogValue(int value)
    {
        File.AppendAllText(_fileName, $"The current value is {value}\n");
    }
}