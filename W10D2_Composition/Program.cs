namespace W10D2_Composition;
abstract class Effect
{
    public abstract void Apply();
}

class AttackEffect : Effect
{
    private int mDamage;
    public AttackEffect(int damage)
    {
        mDamage = damage;
    }

    public override void Apply()
    {
        Console.WriteLine($"데미지 {mDamage}를 입힌다.");        
    }    
}

class BlockEffect : Effect
{
    private int mBlock;
    public BlockEffect(int block)
    {
        mBlock = block;
    }
    public override void Apply()
    {
        Console.WriteLine($"{mBlock} 블록을 얻는다.");
    }
}

class PoisonEffect : Effect
{
    private int mPoison;
    public PoisonEffect(int poison)
    {
        mPoison = poison;
    }
    public override void Apply()
    {
        Console.WriteLine($"독 {mPoison}을 부여한다.");
    }
}

class Card
{
    public string Name {get; private set;}
    public int Cost {get; private set;}
    private List<Effect> mEffects;

    public Card(string name, int cost, List<Effect> effects)
    {
        Name = name;
        Cost = cost;
        mEffects = effects;
    }

    public void Play()
    {
        foreach (Effect effect in mEffects)
        {
            effect.Apply();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Card justAttack = new Card("Just Attack", 1, new List<Effect>{new AttackEffect(1)});

        Card onlyDefend = new Card("Only Defend", 1, new List<Effect>{new BlockEffect(2)});

        Card trinity = new Card("Trinity", 3, new List<Effect>{new AttackEffect(1), new BlockEffect(2), new PoisonEffect(3)});

        List<Card> cards = new List<Card>{justAttack, onlyDefend, trinity};
        foreach(Card card in cards)
        {
            card.Play();
            Console.WriteLine($"");
        }


    }
}
