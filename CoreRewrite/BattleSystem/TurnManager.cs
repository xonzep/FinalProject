using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actors;
using Final.CoreRewrite.AI;
using Final.CoreRewrite.Enums;
using Final.CoreRewrite.UI;


//Handles the actual turn based system.

namespace Final.CoreRewrite.BattleSystem;

public class TurnManager
{
    
    
    private List<IActor>? _turnOrder;
    private List<IActor>? _turnList;
    private PartyManager PartyManager { get; }

    public readonly Menu _actionMenu;
    public Menu _targetMenu = null!;
    public Menu _attackMenu = null!;
    //private Menu _itemMenu;
    public Menu _defendMenu = null!;
    private List<IActor> _enemyParty;
    private readonly DisplayMenuItems _displayMenuItems;

    public TurnManager(PartyManager partyManager)
    {
        List<IActions> actionRegistry = ActionRegistry.GetList();
        _actionMenu = new Menu(actionRegistry);
        PartyManager = partyManager;
        _displayMenuItems = new DisplayMenuItems(this);
    }

    public void RunTurn()
    {
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
                        member.Death(PartyManager.EnemyParty);
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
                        _enemyParty = PartyManager.EnemyParty.PartyMembers;
                        _targetMenu = new Menu(_enemyParty);

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
        _turnOrder.AddRange(PartyManager.EnemyParty.PartyMembers);

        return _turnOrder.OrderByDescending(actor => actor.Initiative).ToList();
    }
}