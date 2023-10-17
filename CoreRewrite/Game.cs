using Final.CoreRewrite.BattleSystem;

namespace Final.CoreRewrite;

public static class Game
{
    private static bool Play = true;
    private static readonly PartyManager PartyManager = new();
    private static readonly TurnManager TurnManager = new(PartyManager);

    public static void GameLoop()
    {

        while (Play)
        {
            TurnManager.RunTurn();
            if (TurnManager.BattleNumber == 2)
            {
                //I feel like this is terrible.
                if (PartyManager.EnemyParty.PartyMembers.Count == 0 && PartyManager.EnemyParty2.PartyMembers.Count == 0 || PartyManager.HeroParty.PartyMembers.Count == 0)
                {
                    Play = false;
                }
            }
        }
    }
    
}