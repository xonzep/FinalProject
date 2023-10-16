using Final.CoreRewrite.Actions;
using Final.CoreRewrite.BattleSystem;
using Final.CoreRewrite.Enums;

namespace Final.CoreRewrite.Actors;

public interface IActor
{
    bool Creature { get; set; }
    bool Npc { get; set; }
    bool IsAlive { get; set; }
    string Name { get; set; }
    Teams team { get; set; }
    bool isBlock { get; set; }
    


    int MaxHp { get; }

    int CurrentHp { get; set; }

    //Initiative is compared to other creatures and assigned turn order based on which is higher. If the same, random? Or enemy?
    int Initiative { get; set; }

    void OnTurn();

    void TakeDamage(int damageAmount)
    {
        if (!isBlock)
        {
            CurrentHp -= damageAmount;
        }
        else
        {
            Console.WriteLine($"{Name} blocked all damage.");
            isBlock = false;
        }

        if (CurrentHp < 0) CurrentHp = 0;
        
    }
    

    void Death(Party party)
    {
        if (CurrentHp == 0)
        {
            Console.WriteLine($"{Name} has died.");
            IsAlive = false;
            party.RemoveActor(this);
        }
    }

    void ActorAttacksList();
    List<IActions> ReturnAttackList();
    void ActorDefendList();
    List<IActions> ReturnDefendList();
}