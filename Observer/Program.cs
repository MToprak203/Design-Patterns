ConcreteSubject subject = new ConcreteSubject();

// Create observers
ConcreteObserver observer1 = new ConcreteObserver("Observer 1", subject);
ConcreteObserver observer2 = new ConcreteObserver("Observer 2", subject);

// Change subject's state
subject.State = 5;

// Detach an observer
subject.Detach(observer2);

// Change subject's state again
subject.State = 10;

Console.ReadLine();