// Strategy interface
public interface IAttackStrategy
{
    void Attack();
}

// Concrete strategies
public class SwordAttackStrategy : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Performing sword attack");
    }
}

public class BowAttackStrategy : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Performing bow attack");
    }
}

public class MagicAttackStrategy : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Performing magic attack");
    }
}

// Context class
public class Character
{
    private IAttackStrategy _attackStrategy;

    // Set attack strategy at runtime
    public void SetAttackStrategy(IAttackStrategy attackStrategy)
    {
        _attackStrategy = attackStrategy;
    }

    // Character performs attack using the current strategy
    public void PerformAttack()
    {
        _attackStrategy?.Attack();
    }
}