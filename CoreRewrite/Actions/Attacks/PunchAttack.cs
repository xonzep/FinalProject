using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions.Attacks;

public class PunchAttack : BaseAction
{
    private const int Damage = 5;

    public PunchAttack(string name) : base(name)
    {
        
    }
    public override void Execute(IActor executingActor, IActor target)
    {
        Console.WriteLine($"{executingActor.Name} punches {target.Name} and does {Damage} damage.");
        target.TakeDamage(Damage);
        Console.WriteLine($"{target.Name}'s health is now {target.CurrentHp}/{target.MaxHp}.");
        Console.WriteLine();
        
    }
    //I don't think I need an AI execute. It shouldn't matter who is executing, the call is the same.
}