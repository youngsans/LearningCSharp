using System.Diagnostics;

namespace W14D2GenericClass
{
    public class Pool<T>
    {
        private readonly Queue<T> mPool = new Queue<T>();
        public Queue<T> PoolQueue { get { return mPool; } }

        public void Regist(T item)
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

        public void PrintLeftItems()
        {
            if(mPool.Count > 0)
            {
                Console.WriteLine($"현재 남은 갯수: {mPool.Count}");
            }

            else
            {
                Console.WriteLine("남은 갯수가 없습니다.");
            }
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
            cardPool.Regist(strike);
            cardPool.Regist(defend);
            cardPool.Regist(bash);

            Pool<Monster> monsterPool = new Pool<Monster>();
            Monster goblin = new Monster("Goblin", 30);
            Monster slime = new Monster("Slime", 20);
            monsterPool.Regist(goblin);
            monsterPool.Regist(slime);

            cardPool.PrintLeftItems();
            List<Card> hand = new List<Card>();
            hand.Add(cardPool.Pull());
            Console.WriteLine($"뽑은 카드: [{hand[0].Name}]");
            cardPool.PrintLeftItems();
            cardPool.Restore(hand[0]);
            cardPool.PrintLeftItems();

            List<Monster> monsters = new List<Monster>();
            monsters.Add(monsterPool.Pull());
            Console.WriteLine($"등장한 몬스터: [{monsters[0].Name}]");



        }
    }
}
