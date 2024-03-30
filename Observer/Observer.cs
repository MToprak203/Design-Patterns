// Subject interface that defines methods for adding, removing, and notifying observers
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject class that implements ISubject
public class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private int _state;

    public int State
    {
        get { return _state; }
        set
        {
            _state = value;
            Notify(); // Notify observers when the state changes
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

// Observer interface that defines the method called by the subject when its state changes
public interface IObserver
{
    void Update();
}

// Concrete Observer class that implements IObserver
public class ConcreteObserver : IObserver
{
    private string _observerName;
    private ConcreteSubject _subject;

    public ConcreteObserver(string observerName, ConcreteSubject subject)
    {
        _observerName = observerName;
        _subject = subject;
        _subject.Attach(this); // Register the observer with the subject
    }

    public void Update()
    {
        Console.WriteLine($"Observer {_observerName} is notified with new state: {_subject.State}");
    }
}