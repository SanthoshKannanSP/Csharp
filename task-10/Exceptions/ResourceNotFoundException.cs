namespace task_10.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string resourceName, int resourceId) :
        base($"Resource {resourceName} with Id {resourceId} not found.") { }
}