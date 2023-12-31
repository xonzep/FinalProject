using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actors;
using Final.CoreRewrite.AI;
using Final.CoreRewrite.Enums;
using Final.CoreRewrite.UI;


//Handles the actual turn based system.

//I hate all the switch statements to check battle number here. But that's poor planning on my part and I'm sure there are
//better ways.
//This works for now.

namespace Final.CoreRewrite.BattleSystem;

public class TurnManager
{
    public int BattleNumber = 1;
    public readonly Menu _actionMenu;
    public Menu _targetMenu = null!;
    public Menu _attackMenu = null!;
    public Menu _defendMenu = null!;
    //private Menu _itemMenu;
    private List<IActor> _enemyParty;
    private readonly DisplayMenuItems _displayMenuItems;
    private List<IActor>? _turnOrder;
    private List<IActor>? _turnList;
    private PartyManager PartyManager { get; }

    public TurnManager(PartyManager partyManager)
    {
        List<IActions> actionRegistry = ActionRegistry.GetList();
        _actionMenu = new Menu(actionRegistry);
        PartyManager = partyManager;
        _displayMenuItems = new DisplayMenuItems(this);
    }

    public void RunTurn()
    {
        if (PartyManager.EnemyParty.PartyMembers.Count == 0 && BattleNumber == 1)
        {
            BattleNumber = 2;
            Thread.Sleep(300);
            Console.WriteLine("Another challenger appears!");
            
            
        }
        
        if (PartyManager.EnemyParty2.PartyMembers.Count == 0 && BattleNumber == 2)
        {
            BattleNumber = 3;
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("You face the UnCoded One!");
            Thread.Sleep(500);
        }
        _turnList = CombineLists();
       

        if (_turnList != null)
        {
            foreach (IActor member in _turnList)
            {
                switch (member.team)
                {
                    case Teams.AI:
                    {
                        AIActor actorAI = new(PartyManager, member);
                        switch (BattleNumber)
                        {
                            case 1:
                                member.Death(PartyManager.EnemyParty);
                                break;
                            case 2:
                                member.Death(PartyManager.EnemyParty2);
                                break;
                            case 3:
                                member.Death(PartyManager.EnemyPartyBoss);
                                break;
                        }

                        if (member.IsAlive)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine();
                            Console.WriteLine($"It is {member.Name.ToUpper()}'s turn.");
                            Console.WriteLine();
                            actorAI.AIChoice();
                        }

                        break;
                    }
                    case Teams.Player:
                    {
                        switch (BattleNumber)
                        {
                            case 1:
                                _enemyParty = PartyManager.EnemyParty.PartyMembers;
                                _targetMenu = new Menu(_enemyParty);
                                break;
                            case 2:
                                _enemyParty = PartyManager.EnemyParty2.PartyMembers;
                                _targetMenu = new Menu(_enemyParty);
                                break;
                            case 3:
                                _enemyParty = PartyManager.EnemyPartyBoss.PartyMembers;
                                _targetMenu = new Menu(_enemyParty);

                                break;
                            
                        }

                        member.Death(PartyManager.HeroParty);
                        Thread.Sleep(500);
                        Console.WriteLine();
                        Console.WriteLine($"It is {member.Name.ToUpper()}'s turn.");
                        IActions choice = _displayMenuItems.DisplayActionsMenu();
                        Console.WriteLine(member.isBlock);
                    
                        switch (choice.Name)
                        {
                            case "Attack":
                            {
                                IActor target = _displayMenuItems.DisplayTargetMenu();
                                //This is getting called each time.
                                _attackMenu = new Menu(member.ReturnAttackList());
                                _displayMenuItems.DisplayAttackMenu(target, member);
                                break;
                            }
                            case "Defend":
                                _defendMenu = new Menu(member.ReturnDefendList());
                                _displayMenuItems.DisplayDefendMenu(member, member);
                                break;
                        }

                        break;
                    }
                }
            }
        }
    }
        

    private List<IActor> CombineLists()
    {
        _turnOrder = new List<IActor>();
        _turnOrder.AddRange(PartyManager.HeroParty.PartyMembers);
        //We need a way to continue the battle.
        switch (BattleNumber)
        {
            case 1:
                _turnOrder.AddRange(PartyManager.EnemyParty.PartyMembers);
                break;
            case 2:
                _turnOrder.AddRange(PartyManager.EnemyParty2.PartyMembers);
                break;
            case 3:
                _turnOrder.AddRange(PartyManager.EnemyPartyBoss.PartyMembers);
                break;
        }

        return _turnOrder.OrderByDescending(actor => actor.Initiative).ToList();
    }
}