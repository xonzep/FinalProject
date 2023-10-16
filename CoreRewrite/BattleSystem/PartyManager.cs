using Final.CoreRewrite.Actors;
using Final.CoreRewrite.Enums;
using Final.CoreRewrite.UI;

namespace Final.CoreRewrite.BattleSystem;
public class PartyManager
{
    public Party HeroParty = null!;
    public Party EnemyParty = null!;

    public PartyManager()
    {
        HeroPartySetup();
        EnemyPartySetup();
    }

    private void HeroPartySetup()
    {
        //Hero creation.
        string userName = InputManager.UserInputText("Please enter your name.");
        TruePro playerHero = new(userName);

        HeroParty = new Party();
        HeroParty.AddActor(playerHero);

        foreach (IActor mem in HeroParty.PartyMembers) mem.team = Teams.Player;
    }

    private void EnemyPartySetup()
    {
        //Enemy
        Skeleton eSkeleton1 = new("Skeleton 1");
        Skeleton eSkeleton2 = new("Skeleton 2");

        EnemyParty = new Party();
        EnemyParty.AddActor(eSkeleton1);
        EnemyParty.AddActor(eSkeleton2);

        foreach (IActor mem in EnemyParty.PartyMembers) mem.team = Teams.AI;
    }

    public static (int CurrentHP, int MaxHP) ReturnPartyHealth(Party party)
    {
        int partyCurrentHealth = 0;
        int partyMax = 0;
        foreach (IActor mactor in party.PartyMembers )
        {
            partyCurrentHealth += mactor.CurrentHp;
            partyMax += mactor.MaxHp;
        }

        return (partyCurrentHealth, partyMax);
    }
}