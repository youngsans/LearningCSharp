using System.ComponentModel.DataAnnotations;

namespace W10D3_WhenUseCompOrInheri;

class Program
{
    //다시 해보자.
    abstract class Card
    {
        public string mName{get; protected set;}
        public string mCardType{get; protected set;}
        public List<Effect> mEffects;

        public Card(string name, string cardType)
        {
            mName = name;
            mCardType = cardType;
        }
        public virtual void Play()
        {
            Console.Write($"[{mCardType}] {mName} 사용! ");
            foreach (Effect effect in mEffects)
            {
                effect.Apply();
            }
        }
    }

    sealed class AttackCard : Card
    {        
        public AttackCard(string name, List<Effect>effects) : base(name, "공격 카드")
        {
            mEffects = effects;
        }
        
    }
    sealed class SkillCard : Card
    {        
        public SkillCard(string name, List<Effect> effects) : base(name, "스킬 카드")
        {
            mEffects = effects;
        }
    }
    sealed class PowerCard : Card
    {
        public PowerCard(string name, List<Effect> effects) : base(name, "파워 카드")
        {
            mEffects = effects;
        }
        
    }


    abstract class Effect
    {
        public abstract void Apply();
    }

    sealed class AttackEffect : Effect
    {
        public int mDamage {  get; private set;}

        public AttackEffect(int damage)
        {
            mDamage = damage;
        }
        public override void Apply()
        {
            Console.WriteLine($"공격: [{mDamage}] 데미지.");
        }
    }
    sealed class PoisonEffect : Effect
    {
        public int mPoison { get; private set; }

        public PoisonEffect (int poison)
        {
            mPoison = poison;
        }
        public override void Apply()
        {
            Console.WriteLine($"독 부여: [{mPoison}] 턴.");
        }
    }
    sealed class DefendEffect : Effect
    {
        public int mArmor { get; private set; }
        public DefendEffect(int armor)
        {
            mArmor = armor;
        }

        public override void Apply()
        {
            Console.WriteLine($"방어: [{mArmor}] 아머.");
        }
    }



    static void Main(string[] args)
    {
        Card attackCard = new AttackCard("Attack", new List<Effect> { new AttackEffect(1)});
        attackCard.Play();
        Card skillCard = new SkillCard("Defend", new List<Effect> { new DefendEffect(1) });
        skillCard.Play();
        Card powerCard = new PowerCard("Poison", new List<Effect> { new PoisonEffect(1) });
        powerCard.Play();


    }
}
