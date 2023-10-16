using Final.CoreRewrite.BattleSystem;

namespace Final.CoreRewrite;

public static class Game
{
    private static bool Play = true;
    private static readonly PartyManager PartyManager = new();
    private static readonly TurnManager TurnManager = new(PartyManager);

    public static void GameLoop()
    {
        if (PartyManager.EnemyParty == null || PartyManager.HeroParty == null)
        {
            Play = false;
        }
        while (Play) TurnManager.RunTurn();
    }
    
}