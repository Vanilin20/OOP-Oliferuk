using System;
using System.Collections.Generic;
using System.Linq;

namespace lab7v16;

public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public void Add(T item)
    {
        if (_items.Any(x => x.Id == item.Id))
        {
            throw new ArgumentException($"Item with Id {item.Id} already exists.");
        }
        _items.Add(item);
    }

    public void Update(T item)
    {
        var existingItem = GetById(item.Id);
        if (existingItem == null)
        {
            throw new KeyNotFoundException($"Item with Id {item.Id} not found for update.");
        }

        var index = _items.IndexOf(existingItem);
        _items[index] = item;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item == null)
        {
            throw new KeyNotFoundException($"Item with Id {id} not found for deletion.");
        }
        _items.Remove(item);
    }
}