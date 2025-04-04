namespace task_9;

[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
    public string Description { get; }

    public RunnableAttribute(string description)
    {
        Description = description;
    }

    public RunnableAttribute()
    {
        Description = "This is a runnable method";
    }
}