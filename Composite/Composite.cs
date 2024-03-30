// Component
interface IComponent
{
    string Name { get; }
    void DisplayHierarchy(int depth);
}

// Leaf and Composite
class Department : IComponent
{
    public string Name { get; }
    private readonly List<IComponent> _components = new List<IComponent>();

    public Department(string name)
    {
        Name = name;
    }

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(IComponent component)
    {
        _components.Remove(component);
    }

    public void DisplayHierarchy(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);

        // Display sub-components hierarchy
        foreach (var component in _components)
        {
            component.DisplayHierarchy(depth + 2);
        }
    }
}

// Leaf
class IndividualContributor : IComponent
{
    public string Name { get; }

    public IndividualContributor(string name)
    {
        Name = name;
    }

    public void DisplayHierarchy(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);
    }
}