namespace ReviewInterfaceAsIs
{
    interface IDamageable
    {
        void TakeDamage(int amount);
    }

    interface IHealable
    {
        void TakeHeal(int amount);
    }


    public abstract class Character : IDamageable, IHealable
    {
        private readonly string mName;
        private int mCurrentHealth;

        public string Name { get { return mName; } }
        public int CurrentHealth { get { return mCurrentHealth; } }

        public Character(string name, int health)
        {
            mName = name;
            mCurrentHealth = health;
        }

        public void TakeDamage(int amount)
        {
            mCurrentHealth = Math.Max(0, mCurrentHealth - amount);
            Console.WriteLine($"{mName}이(가) {amount} 데미지 받음. (남은 체력: {mCurrentHealth})");
        }

        public void TakeHeal(int amount)
        {
            mCurrentHealth = Math.Max(0, mCurrentHealth + amount);
            Console.WriteLine($"{mName}이(가) {amount} 만큼 치유 받음. (현재 체력: {mCurrentHealth})");
        }
    }

    public abstract class Structure : IDamageable
    {
        private readonly string mName;
        private int mDurability;

        public string Name { get { return mName; } }
        public int Durability { get { return mDurability; } }

        public Structure(string name, int durability)
        {
            mName = name;
            mDurability = durability;
        }

        public void TakeDamage(int amount)
        {
            mDurability = Math.Max(0, mDurability - amount);
            Console.WriteLine($"{mName}이(가) {amount} 데미지 받음. (남은 내구도: {mDurability})");
        }
    }

    public sealed class Player : Character
    {
        public Player(string name, int health) : base(name, health)
        {
        }
    }

    public sealed class Monster : Character
    {
        public Monster(string name, int health) : base(name, health)
        {
        }
    }

    public sealed class Barricade : Structure
    {
        public Barricade(string name, int durability) : base(name, durability)
        {
        }
    }

    internal class ReviewInterfaceAsIs
    {
        static void Main(string[] args)
        {
            Character player = new Player("Player", 100);
            Character monster = new Monster("Monster", 50);
            Structure barricade = new Barricade("Barricade", 20);

            List<IDamageable> targetList = new List<IDamageable>();
            targetList.Add(player);
            targetList.Add(monster);
            targetList.Add(barricade);

            foreach(IDamageable damageable in targetList)
            {
                damageable.TakeDamage(10);
            }
                        
            foreach (IDamageable damageable in targetList)
            {
                if(damageable is IHealable healable)
                {
                    healable.TakeHeal(5);
                }
            }
        }
    }
}
