namespace task_8;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException()
        : base("Entity not found in repository") { }
}