using Final.CoreRewrite.Actors;
using Final.CoreRewrite.Enums;
using Final.CoreRewrite.UI;

namespace Final.CoreRewrite.BattleSystem;
public class PartyManager
{
    public Party HeroParty = null!;
    public Party EnemyParty = null!;
    public Party EnemyParty2 = null!;

    public PartyManager()
    {
        HeroPartySetup();
        EnemyPartySetup();
        EnemyPartyTwoSetup();
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
        EnemyParty = new Party();
        EnemyParty.AddActor(eSkeleton1);

        foreach (IActor mem in EnemyParty.PartyMembers) mem.team = Teams.AI;
    }
//I hate having another method here, but with how I built things it's the easiest way. If I do this again, I need to
//setup the party system a bit better so I can just call a method and add it to the current battle party, rather than
//having another list everytime I want a new party as the old is no longer needed and I can just add them to the enemy
//party.
    private void EnemyPartyTwoSetup()
    {
        Skeleton eSkeleton1 = new("Skeleton 1");
        Skeleton eSkeleton2 = new("Skeleton 2");
        EnemyParty2 = new Party();
        EnemyParty2.AddActor(eSkeleton1);
        EnemyParty2.AddActor(eSkeleton2);
        
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