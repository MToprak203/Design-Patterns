using System.Collections;

// Define the iterator interface
interface IIterator
{
    bool HasNext();
    object Next();
}

// Define the collection interface
interface IIterableCollection
{
    IIterator CreateIterator();
}

// Concrete collection
class ConcreteCollection : IIterableCollection
{
    private ArrayList _items = new ArrayList();

    public void AddItem(object item)
    {
        _items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public object this[int index]
    {
        get { return _items[index]; }
    }
}

// Concrete iterator
class ConcreteIterator : IIterator
{
    private ConcreteCollection _collection;
    private int _index = 0;

    public ConcreteIterator(ConcreteCollection collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _index < _collection.Count;
    }

    public object Next()
    {
        object item = _collection[_index];
        _index++;
        return item;
    }
}