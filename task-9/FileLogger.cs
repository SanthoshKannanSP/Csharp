namespace task_9;

public class FileLogger
{
    private static string _logFileName = "log.txt";

    [Runnable("Logging to file log.txt")]
    public static void LogFileWrite(int number)
    {
        File.AppendAllText(_logFileName, $"The current random number value is {number}\n");
    }
}