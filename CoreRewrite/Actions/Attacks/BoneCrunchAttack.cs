using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions.Attacks;


public class BoneCrunchAttack : BaseAction
{
    //do random damage between 0 and 1;
    private static readonly Random _random = new();
    private int Damage = _random.Next(2);
    public BoneCrunchAttack(string name) : base(name)
    {
    }

    public override void Execute(IActor executingActor, IActor target)
    {
        Console.WriteLine($"{executingActor.Name} uses Bone Crunch on {target.Name} and does {Damage} damage.");
        target.TakeDamage(Damage);
        Console.WriteLine($"{target.Name}'s health is now {target.CurrentHp}/{target.MaxHp}.");
        Console.WriteLine();
    }
}