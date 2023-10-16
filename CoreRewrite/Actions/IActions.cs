using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.Actions;

public interface IActions
{
    string Name { get; }
    
    
    void Execute(IActor executingActor, IActor target);
    
    public string GetName()
    {
        return Name;
    }
    
}