class Program
{
    public static List<string> Tasks = new List<string>();
    public static void PrintInstructions()
    {
        Console.WriteLine("\n");
        Console.WriteLine("[V]iew all tasks");
        Console.WriteLine("[A]dd a new task");
        Console.WriteLine("[R]emove a task");
        Console.WriteLine("[E]xit the program");
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Todo Application!");
        PrintInstructions();
        String userInput = Console.ReadLine().ToLower();
        do
        {
            switch (userInput)
            {
                case "v":
                    ViewAllTasks();
                    break;
                case "a":
                    AddTask();
                    break;
                case "r":
                    RemoveTask();
                    break;
                default:
                    Console.WriteLine("Enter a valid input!");
                    break;
            }
            PrintInstructions();
            userInput = Console.ReadLine().ToLower();
        } while (userInput != "e");
    }

    private static void RemoveTask()
    {
        Console.WriteLine("\n");
        if (Tasks.Count == 0)
        {
            Console.WriteLine("Nothing to remove!");
            return;
        }
        
        Console.WriteLine("Enter the task number to be removed: ");
        if (int.TryParse(Console.ReadLine(), out var taskNumber))
        {
            if (taskNumber >0 && taskNumber <= Tasks.Count)
            {
                Tasks.RemoveAt(taskNumber-1);
                Console.WriteLine("Removed Task!");
            }
            else
            {
                Console.WriteLine("Invalid task number!");
            }
        }
        else
        {
            Console.WriteLine("Invalid task number!");
        }
    }

    private static void AddTask()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Enter task name: ");
        var task = Console.ReadLine().Trim();
        if (task.Length == 0)
        {
            Console.WriteLine("Enter a task!!");
            return;
        }
        Tasks.Add(task);
    }

    private static void ViewAllTasks()
    {
        Console.WriteLine("\n");
        if (Tasks.Count == 0)
        {
            Console.WriteLine("No tasks to do!");
            return;
        }

        for (var index = 0; index < Tasks.Count; index++)
        {
            Console.WriteLine($"[{index+1}] {Tasks[index]}");
        }
    }
}