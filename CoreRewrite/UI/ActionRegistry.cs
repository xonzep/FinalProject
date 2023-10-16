using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Items;

namespace Final.CoreRewrite.UI;

public abstract class ActionRegistry
{
    private static readonly List<IActions> ActionsList = new();

    //We create each of our actions here when GetList is called and add them to the list. We then pass
    //ActionList to our menu which automatically grabs the actions, lists them and executes the code when chosen.
    public static List<IActions> GetList()
    {
        ActionsList.Add(new DoNothingAction("Do Nothing."));
        //BaseAction is set for Attack as it does not have an execute. It's just for menu.
        ActionsList.Add(new BaseAction("Attack"));
        ActionsList.Add(new BaseAction("Defend"));
        ActionsList.Add(new ItemAction("Item"));
        
        
        return ActionsList;
    }
    

}