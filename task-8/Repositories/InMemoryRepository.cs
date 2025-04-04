namespace task_8;

public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
{
    private List<T> _items = new List<T>();
    private int _counter = 1;
    
    public List<T> GetAll()
    {
        if (_items.Count == 0)
        {
            throw new RepositoryEmptyException();
        }
        return _items;
    }

    public T GetById(int id)
    {
        var item = _items.FirstOrDefault(entity => entity.Id == id);
        if (item == null)
        {
            throw new EntityNotFoundException();
        }
        return item;
    }

    public void Add(T item)
    {
        item.Id = _counter++;
        _items.Add(item);
    }

    public void Update(T item)
    {
        var index = _items.IndexOf(item);
        if (index == -1)
        {
            throw new EntityNotFoundException();
        }
        _items[index] = item;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item == null)
        {
            throw new EntityNotFoundException();
        }
        _items.Remove(item);
    }
}