using Final.CoreRewrite.Actors;

namespace Final.CoreRewrite.BattleSystem;

public record Party
{
    public List<IActor> PartyMembers { get; } = new();

    public void RemoveActor(IActor actor)
    {
        PartyMembers.Remove(actor);
    }

    public void AddActor(IActor actor)
    {
        PartyMembers.Add(actor);
    }
}