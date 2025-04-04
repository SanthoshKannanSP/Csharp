using task_8;

class Program
{
    private static InMemoryRepository<Todo> _todoRepo = new InMemoryRepository<Todo>();
    
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Todo Application!");
        PrintInstructions();
        String userInput = Console.ReadLine().ToLower();
        while (userInput != "e")
        {
            switch (userInput)
            {
                case "v":
                    ViewAllTodos();
                    break;
                case "a":
                    AddTodo();
                    break;
                case "r":
                    RemoveTodo();
                    break;
                default:
                    Console.WriteLine("Enter a valid input!");
                    break;
            }
            PrintInstructions();
            userInput = Console.ReadLine().ToLower();
        }
    }

    public static void PrintInstructions()
    {
        Console.WriteLine("\n");
        Console.WriteLine("[V]iew all todos");
        Console.WriteLine("[A]dd a new todo");
        Console.WriteLine("[R]emove a todo");
        Console.WriteLine("[E]xit the program");
    }

    private static void RemoveTodo()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Enter the todo number to be removed: ");
        if (int.TryParse(Console.ReadLine(), out var todoNumber))
        {
            try
            {
                _todoRepo.Delete(todoNumber);
            }
            catch (EntityNotFoundException)
            {
                Console.WriteLine("There is no such todo!");
            }
        }
        else
        {
            Console.WriteLine("Invalid todo number!");
        }
    }

    private static void AddTodo()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Enter todo name: ");
        var todoName = Console.ReadLine().Trim();
        if (todoName.Length == 0)
        {
            Console.WriteLine("Enter a todo!!");
            return;
        }

        var newToDo = new Todo(todoName);
        _todoRepo.Add(newToDo);
    }

    private static void ViewAllTodos()
    {
        Console.WriteLine("\n");
        List<Todo> allTodos;
        try
        {
            allTodos  = _todoRepo.GetAll();
        }
        catch (RepositoryEmptyException)
        {
            Console.WriteLine("There are no todos to show!");
            return;
        }

        foreach (var todo in allTodos)
        {
            Console.WriteLine($"[{todo.Id}] {todo.Name}");
        }
    }
}