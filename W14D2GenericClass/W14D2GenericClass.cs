using System.Diagnostics;

namespace W14D2GenericClass
{
    public class Pool<T>
    {
        private readonly Queue<T> mPool = new Queue<T>();
        
        public int Count { get {  return mPool.Count; }  }

        public void Register(T item)
        {
            mPool.Enqueue(item);
        }

        public T Pull()
        {
            Debug.Assert(mPool.Count > 0);
            return mPool.Dequeue();
        }

        public void Restore(T item)
        {
            mPool.Enqueue(item);
        }

    }

    public class Card
    {
        
        private readonly string mName;
        private readonly int mCost;

        public string Name { get { return mName; } }
        public int Cost { get { return mCost; } }

        public Card(string name, int cost)
        {
            mName = name;
            mCost = cost;
        }
    }

    public class Monster
    {
        
        private readonly string mName;
        private readonly int mHealth;

        public string Name { get { return mName; } }
        public int Health { get { return mHealth; } }

        public Monster(string name, int health)
        {
            mName = name;
            mHealth = health;
        }
    }



    internal class W14D2GenericClass
    {
        static void Main(string[] args)
        {
            Pool<Card> cardPool = new Pool<Card>();
            Card strike = new Card("Strike", 1);
            Card defend = new Card("Defend", 1);
            Card bash = new Card("Bash", 2);
            cardPool.Register(strike);
            cardPool.Register(defend);
            cardPool.Register(bash);

            Pool<Monster> monsterPool = new Pool<Monster>();
            Monster goblin = new Monster("Goblin", 30);
            Monster slime = new Monster("Slime", 20);
            monsterPool.Register(goblin);
            monsterPool.Register(slime);

            Console.WriteLine($"현재 남은 카드 갯수: {cardPool.Count}");
            List<Card> hand = new List<Card>();
            hand.Add(cardPool.Pull());
            Console.WriteLine($"뽑은 카드: [{hand[0].Name}]");
            Console.WriteLine($"현재 남은 카드 갯수: {cardPool.Count}");
            cardPool.Restore(hand[0]);
            Console.WriteLine($"현재 남은 카드 갯수: {cardPool.Count}");

            List<Monster> monsters = new List<Monster>();
            monsters.Add(monsterPool.Pull());
            Console.WriteLine($"등장한 몬스터: [{monsters[0].Name}] | 체력: [{monsters[0].Health}]");



        }
    }
}
