using Final.CoreRewrite.Actions;
using Final.CoreRewrite.Actions.Attacks;
using Final.CoreRewrite.Actions.Defense;
using Final.CoreRewrite.Enums;

namespace Final.CoreRewrite.Actors;

public class TruePro : IActor
{
    public bool isBlock { get; set; }
    public bool Creature { get; set; }
    public bool Npc { get; set; }
    public bool IsAlive { get; set; }
    public string Name { get; set; }

    public int MaxHp { get; }
    public int CurrentHp { get; set; }
    public int Initiative { get; set; }
    public Teams team { get; set; }

    private readonly List<IActions> _attacksList = new();
    private readonly List<IActions> _defendList = new();
    public List<IActions> ItemInventory = new();


    public TruePro(bool creature, bool npc, string name, int maxhp, int initiative)
    {
        IsAlive = true;
        Creature = creature;
        Npc = npc;
        Name = name;
        MaxHp = maxhp;
        CurrentHp = maxhp;
        Initiative = initiative;
    }

    public TruePro(string name) : this(false, false, name, 25, 6)
    {
        ActorAttacksList();
        ActorDefendList();
    }

    public void OnTurn()
    {
        
    }

    public void ActorAttacksList()
    {
        _attacksList.Add(new PunchAttack("Punch Attack"));
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

    public void UseItem(IActor executingActor)
    {
        
    }
}