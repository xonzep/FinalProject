using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions.Attacks;

public class UnravelingAttack : BaseAction
{
    private static readonly Random _random = new();
    private int Damage = _random.Next(3);
    public UnravelingAttack(string name) : base(name)
    {
        
    }
    
    public override void Execute(IActor executingActor, IActor target)
    {
        Console.WriteLine($"{executingActor.Name} uses Unraveling on {target.Name} and does {Damage} damage!");
        Console.WriteLine();
        target.TakeDamage(Damage);
        Console.WriteLine($"{target.Name}'s health is now {target.CurrentHp}/{target.MaxHp}.");
        Console.WriteLine();
        
    }
}