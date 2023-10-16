using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Items;

public class ItemAction : IActions
{
    public ItemAction(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public void Execute(IActor executingActor, IActor target)
    {
        throw new NotImplementedException();
    }

    public void AIExecute(IActor actor, int userChoice)
    {
        throw new NotImplementedException();
    }
}