ConcreteCollection collection = new ConcreteCollection();
collection.AddItem("Item 1");
collection.AddItem("Item 2");
collection.AddItem("Item 3");

IIterator iterator = collection.CreateIterator();

while (iterator.HasNext())
{
    string item = (string)iterator.Next();
    Console.WriteLine(item);
}