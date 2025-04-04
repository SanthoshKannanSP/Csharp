namespace task_8;

public class Todo : IEntity
{
    public Todo(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public int Id { get; set; }
}