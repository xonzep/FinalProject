using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions;
//This is our base class for attacks. Not sure if it's really needed when we have an interface, but this makes more sense in my head.
public class BaseAction : IActions
{
    public BaseAction(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public virtual void Execute(IActor executingActor, IActor target)
    {
        throw new NotImplementedException();
    }

    //I think this will work. It's useful for actions that don't have a target, or rather the target is the actor.
    public void Execute(IActor executingActor)
    {
        Execute(executingActor, executingActor);
    }
    
}