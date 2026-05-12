namespace ReviewVirtualAbstract
{
    public abstract class Card
    {
        private readonly string mName;
        public string Name { get { return mName; } }
        private readonly int mCost;
        public int Cost { get { return mCost; } }

        public Card(string name, int cost)
        {
            mName = name;
            mCost = cost;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"[{mName}] (코스트: {mCost})");
        }
        public abstract void Play();
        public virtual void Discard()
        {
            Console.WriteLine($"[{mName}] 폐기됨");
        }
    }

    public sealed class AttackCard : Card
    {
        public AttackCard(string name, int cost) : base(name, cost)
        {
        }

        public override void Play()
        {
            Console.WriteLine($"[{Name}] 공격!");
        }
    }

    public sealed class DefenseCard : Card
    {
        public DefenseCard(string name, int cost) : base(name, cost)
        {
        }

        public override void Play()
        {
            Console.WriteLine($"[{Name}] 방어!");
        }
    }

    public sealed class EtherealCard : Card
    {
        public EtherealCard(string name, int cost) : base(name, cost)
        {
        }

        public override void Play()
        {
            Console.WriteLine($"[{Name}] 휘발!");
        }

        public override void Discard()
        {
            Console.WriteLine($"[{Name}] 다음 턴 영구 소멸");
        }
    }



    internal class ReviewVirtualAbstract
    {
        static void Main(string[] args)
        {
            Card strike = new AttackCard("Strike", 2);
            Card block = new DefenseCard("Block", 1);
            Card ghost = new EtherealCard("Ghost", 3);

            List<Card> hand = new List<Card>();

            hand.Add(strike);
            hand.Add(block);
            hand.Add(ghost);

            foreach (Card card in hand)
            {
                card.PrintInfo();
                card.Play();
                card.Discard();
            }
        }
    }
}
