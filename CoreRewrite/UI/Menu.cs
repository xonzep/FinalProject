using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actors;
using Final.CoreRewrite.Enums;

namespace Final.CoreRewrite.UI;

public class Menu
{
    private readonly List<IActions>? _actionsToDisplay;
    private readonly List<IActor>? _targetActors;
    private int _displayIndex;
    
    public Menu(List<IActor>? targetActors)
    {
        _targetActors = targetActors;
    }

    public Menu(List<IActions>? actionsList)
    {
        _actionsToDisplay = actionsList;
    }
    
    /*
     * I dislike needing two display methods that basically do the same thing, but I don't know how else to do it.
     * Using a generic has us passing the list again anyway, so this way we can construct what we need and then call the
     * correct display method just by "Constructor.DisplayActors" or "DisplayActions".
     * I guess I could check the list for null? But that would just be copying the code twice in the method.
     * Would make it easier to use, I guess. Don't care about type, just call Display() and be done with it.
     * One of the lists will be null for that construction anyway.
    */
    public void Display()
    {
        _displayIndex = 1; //reset display index if called again.

        if (_targetActors != null)
        {
            foreach (IActor actor in _targetActors)
            {
                Console.WriteLine($"{_displayIndex}. {actor.Name}");
                _displayIndex++;
            }
        }
        else if (_actionsToDisplay != null)
        {
            foreach (IActions action in _actionsToDisplay)
            {
                Console.WriteLine($"{_displayIndex}. {action.Name}");
                _displayIndex++;
            }
        }
        else
        {
            //throw new NotSupportedException();
            Console.WriteLine("Only Actors and Actions are supported. Please check that you are passing the correct list type.");
        }
    }

    public IActions GetInputActions()
    {
        Console.WriteLine();
        int choice = InputManager.UserInputInt("Please make your choice.", _actionsToDisplay!.Count);
        return _actionsToDisplay[choice - 1]; //we take 1 away for zero indexing.
    }
    
    public IActor GetInputActors()
    {
        Console.WriteLine();
        int choice = InputManager.UserInputInt("Please make your choice.", _targetActors!.Count);
        return _targetActors[choice - 1]; //we take 1 away for zero indexing.
    }

    public void GetAction(IActions userChoice, IActor executingActor, IActor target)
    {
        //Same thing, our input already checks the range.
        if (executingActor.team == Teams.Player)
        {
            userChoice.Execute(executingActor, target);
        }
    }
}