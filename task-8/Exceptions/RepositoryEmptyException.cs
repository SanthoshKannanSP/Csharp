namespace task_8;

public class RepositoryEmptyException : Exception
{
    public RepositoryEmptyException()
        : base("The repository is empty.") { }
}