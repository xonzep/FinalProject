using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actions.Attacks;
using Final.CoreRewrite.Actions.Defense;
using Final.CoreRewrite.Enums;

namespace Final.CoreRewrite.Actors;

public class UnCoded : IActor
{
    public bool Creature { get; set; }
    public bool Npc { get; set; }
    public bool IsAlive { get; set; }
    public string Name { get; set; }
    public Teams team { get; set; }
    public bool isBlock { get; set; }
    public int MaxHp { get; }
    public int CurrentHp { get; set; }
    public int Initiative { get; set; }
    
    private readonly List<IActions> _attacksList = new();
    private readonly List<IActions> _defendList = new();
    
    public UnCoded(bool creature, bool npc, string name, int maxhp, int initiative)
    {
        IsAlive = true;
        Creature = creature;
        Npc = npc;
        Name = name;
        MaxHp = maxhp;
        CurrentHp = maxhp;
        Initiative = initiative;
    }

    //We have default values 
    //and can take in just a name here instead of everything since its a generic enemy.
    public UnCoded(string name) : this(false, true, name, 15, 4)
    {
        //we call this so that the list is updated during construction and then we just return the list during the for
        //loop. This fixes our duplication list item issue.
        ActorAttacksList();
        ActorDefendList();
    }
    public void OnTurn()
    {
    }

    public void ActorAttacksList()
    {
        _attacksList.Add(new UnravelingAttack("Unraveling"));
       
    }

    public List<IActions> ReturnAttackList()
    {
        return _attacksList;
    }

    public void ActorDefendList()
    {
        _defendList.Add(new BlockAction("Block"));
    }

    public List<IActions> ReturnDefendList()
    {
        return _defendList;
    }
}