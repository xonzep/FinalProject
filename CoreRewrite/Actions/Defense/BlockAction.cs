using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions.Defense;

public class BlockAction : BaseAction
{
    public BlockAction(string name) : base(name)
    {
    }

    public override void Execute(IActor executingActor, IActor target)
    {
        Console.WriteLine($"{executingActor.Name} chooses to block incoming damage for one attack.");
        executingActor.isBlock = true;
    }
}