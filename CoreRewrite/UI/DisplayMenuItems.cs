using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actors;
using Final.CoreRewrite.BattleSystem;

namespace Final.CoreRewrite.UI;

public class DisplayMenuItems
{
    private TurnManager _turnManager;
     

    public DisplayMenuItems(TurnManager turnManager)
    {
        _turnManager = turnManager;
    }
    //yes this isn't great. I'm repeating code where just the type changes, but not sure how to fix it other than by
    //doing typeof <t> == IActions or something along those lines.
    public IActions DisplayActionsMenu()
    {
        _turnManager._actionMenu.Display();
        
        Console.WriteLine();

        return _turnManager._actionMenu.GetInputActions();;
    }

    public IActor DisplayTargetMenu()
    {
        _turnManager._targetMenu.Display();
        Console.WriteLine();
         
        return _turnManager._targetMenu.GetInputActors();
    }

    public void DisplayAttackMenu(IActor target, IActor executingActor)
    {
        _turnManager._attackMenu.Display();
        IActions userChoice = _turnManager._attackMenu.GetInputActions();
        Console.WriteLine();
        _turnManager._attackMenu.GetAction(userChoice, executingActor, target);
    }
    
    public void DisplayDefendMenu(IActor target, IActor executingActor)
    {
        _turnManager._defendMenu.Display();
        IActions userChoice = _turnManager._defendMenu.GetInputActions();
        Console.WriteLine();
        _turnManager._defendMenu.GetAction(userChoice, executingActor, target);
    }
    
    
}