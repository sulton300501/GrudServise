public class GenericService<T>
{
    private List<T> dataStore = new List<T>();

    public void Add(T item)
    {
        dataStore.Add(item);
    }

    public T Get(int id)
    {
        
        return dataStore.FirstOrDefault(item => item.GetType().GetProperty("Id")?.GetValue(item)?.Equals(id) ?? false);
    }

    public List<T> GetAll()
    {
        return dataStore;
    }

    public void Update(int id, T newItem)
    {
        
        var existingItem = dataStore.FirstOrDefault(item => item.GetType().GetProperty("Id")?.GetValue(item)?.Equals(id) ?? false);

        if (existingItem != null)
        {
            dataStore.Remove(existingItem);
            dataStore.Add(newItem);
        }
    }

    public void Delete(int id)
    {
        // Assume your class has a property named "Id"
        var itemToDelete = dataStore.FirstOrDefault(item => item.GetType().GetProperty("Id")?.GetValue(item)?.Equals(id) ?? false);

        if (itemToDelete != null)
        {
            dataStore.Remove(itemToDelete);
        }
    }
}

public class QanaqadurClass
{
    public int Id { get; set; }
    // other properties...
}

class Program
{
    static void Main()
    {
        GenericService<QanaqadurClass> qanaqadurService = new GenericService<QanaqadurClass>();

        qanaqadurService.Add(new QanaqadurClass() { Id = 1 /* set other properties */ });

        QanaqadurClass retrievedItem = qanaqadurService.Get(1);

        List<QanaqadurClass> allItems = qanaqadurService.GetAll();

        qanaqadurService.Update(1, new QanaqadurClass() { Id = 1 /* set other properties */ });

        qanaqadurService.Delete(1);
    }
}
