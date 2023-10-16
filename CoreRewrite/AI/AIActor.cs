using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actors;
using Final.CoreRewrite.BattleSystem;

namespace Final.CoreRewrite.AI;


public class AIActor
{
    private readonly List<IActor> _actorList;
    private readonly List<IActions> _attackActionsList;
    private readonly List<IActions> _defendActionsList;
    //private List<IActions> _itemActionList;
    private readonly PartyManager _partyManager;
    private readonly IActor _executingActor;
    public bool hasAttacked = false;
    public AIActor( PartyManager partyManager, IActor executingActor)
    {
        _actorList = partyManager.HeroParty.PartyMembers;
        _attackActionsList = executingActor.ReturnAttackList();
        _defendActionsList = executingActor.ReturnDefendList();
        _partyManager = partyManager;
        _executingActor = executingActor;
    }
    /*
     * The AI needs to make a choice for it's current actor turn. I want it to attack if it's more than half health
     * and there have a chance of choosing attack every turn. It can perhaps take into account the enemy team's health.
     * I also want it to check it's inventory and if it has a health item, use that instead of attacking. But maybe if
     * it's close to dying only, like one turn away.
     *
     * I don't need to use the menu. I can just call the actions directly from the action list and the target list. 
     */
    public void AIChoice()
    {
        //We get the health of the party and the current actor so we can use it to compare in our choices. Also useful
        //for when we do a battle display.
        (int, int) partyHealth = PartyManager.ReturnPartyHealth(_partyManager.EnemyParty);
        IActions attackAction = _attackActionsList[0];
        IActions defendAction = _defendActionsList[0];
        
        Random _random = new();
        
        
        //Check if our health is maxed and attack if so.
        if (_executingActor.CurrentHp <= _executingActor.MaxHp && !hasAttacked)
        {
            attackAction.Execute(_executingActor, ReturnLowestHpActor(_actorList));
            hasAttacked = true;
        }
        
        if (_executingActor.CurrentHp <= _executingActor.MaxHp / 2 && !hasAttacked)
        {
            if (_random.Next(2) == 1)
            {
                defendAction.Execute(_executingActor, _executingActor);
                hasAttacked = true;
            }
            else
            {
                attackAction.Execute(_executingActor, ReturnLowestHpActor(_actorList));
                hasAttacked = true;
            }
        }
        
    }

    //We need a way to choose a target. This is simple for now, but I need to add some randomness to it cause otherwise it's just attrition.
    //Doing it by health and a random number might be enough, but I'd like something like 'focus who did most damage last turn' or something.
    private static IActor ReturnLowestHpActor(List<IActor> actorList)
    {
        IActor previousActor = actorList[0];
        foreach (IActor actor in actorList)
        {
            if (actor.CurrentHp < previousActor.CurrentHp)
            {
                previousActor = actor;
            }
            
        }

        return previousActor;
    }
}