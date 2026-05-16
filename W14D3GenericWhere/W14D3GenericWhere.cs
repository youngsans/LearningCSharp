namespace W14D3GenericWhere
{
    public static class CombatHelper
    {
        public static void DealDamageToAll<T> (List<T> targets, int amount ) where T : IDamageable
        {
            for ( int i = 0; i < targets.Count; i++)
            {
                if (targets[i].IsAlive)
                {
                    targets[i].TakeDamage(amount);
                }

                else
                {
                    Console.WriteLine($"[{targets[i].Name}] 현재 사망 상태");
                }
                
            }
        }

        public static void PrintStatus<T> (List<T> targets) where T : IDamageable
        {
            for (int i = 0; i < targets.Count; i++)
            {
                Console.WriteLine($"[{targets[i].Name}] | 체력: {targets[i].CurrentHealth} | 생존 여부: {targets[i].IsAlive}");
            }
        }
    }
    public interface IDamageable
    {
        string Name { get; }
        int CurrentHealth { get; }
        bool IsAlive { get; }

        void TakeDamage(int damageAmount);
    }

    public class Player : IDamageable
    {
        private readonly string mName;

        private int mShield;
        private int mCurrentHealth;
        private bool mIsAlive;

        public string Name { get { return mName; } }
        public int CurrentHealth { get { return mCurrentHealth; } }
        public bool IsAlive { get { return mIsAlive; } }

        public Player(string name, int currentHealth, int shield)
        {
            mName = name;
            mCurrentHealth = currentHealth;
            mShield = shield;

            mIsAlive = true;
        }

        public void TakeDamage(int damageAmount)
        {
            if (damageAmount - mShield <= 0)
            {
                Console.WriteLine($"[{mName}] {damageAmount} 데미지 받음 | 방어도: {mShield}에 막힘 | 남은 방어도: {mShield -= damageAmount} | 남은 체력: {mCurrentHealth}");                
            }
            else
            {
                Console.Write($"[{mName}] {damageAmount} 데미지 받음 | 현재 방어도: {mShield} | 남은 체력: {mCurrentHealth = Math.Max(0, mCurrentHealth - (damageAmount -= mShield))} | 남은 방어도: {mShield = 0}");

                if (mCurrentHealth == 0)
                {
                    mIsAlive = false;
                    Console.WriteLine($" - [{mName}] 사망");
                }
                else
                {
                    Console.WriteLine();
                }
            }

        }
    }

    public class Monster : IDamageable
    {
        private readonly string mName;

        private int mCurrentHealth;
        private bool mIsAlive;

        public string Name { get { return mName; } }
        public int CurrentHealth { get { return mCurrentHealth; } }
        public bool IsAlive { get { return mIsAlive; } }

        public Monster(string name, int currentHealth)
        {
            mName = name;
            mCurrentHealth = currentHealth;

            mIsAlive = true;
        }

        public void TakeDamage(int damageAmount)
        {
            mCurrentHealth = Math.Max(0, mCurrentHealth - damageAmount);

            Console.Write($"[{mName}] {damageAmount} 데미지 받음 | 남은 체력: {mCurrentHealth}");

            if (mCurrentHealth == 0)
            {
                mIsAlive = false;
                Console.WriteLine($" - [{mName}] 사망");
            }
            else
            {
                Console.WriteLine();
            }
        }

    }
    internal class W14D3GenericWhere
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 50, 10);
            Monster goblin = new Monster("Goblin", 30);
            Monster slime = new Monster("Slime", 20);
            Monster dragon = new Monster("Dragon", 100);

            List<Monster> monsters = new List<Monster>();
            monsters.Add(goblin);
            monsters.Add(slime);
            monsters.Add(dragon);

            List<Player> players = new List<Player>();
            players.Add(player);

            CombatHelper.PrintStatus(monsters);
            CombatHelper.DealDamageToAll(monsters, 25);
            CombatHelper.PrintStatus(monsters);

            CombatHelper.DealDamageToAll(players, 8);
            CombatHelper.DealDamageToAll(players, 15);

        }
    }
}
