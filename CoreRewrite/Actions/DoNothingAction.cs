using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions;

public class DoNothingAction : IActions
{
    public DoNothingAction(string name)
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