namespace ReviewAccessScopes
{
    public class Character
    {
        public string Name { get; private set; }
        public int CurrentHealth { get; private set; }
        private readonly int mBasicArmor;//상속 받는 클래스의 메서드에서는 mBasicArmor를 쓰지 않을 예정.

        public Character(string name, int currentHealth, int basicArmor)
        {
            Name = name;
            CurrentHealth = currentHealth;
            mBasicArmor = basicArmor;
        }

        public void TakeDamage(int damage)
        {
            int finalDamage = calculateFinalDamage(damage);

            //체력이 음수로 내려가지 않게 깎는 계산 코드 단계에서 보장
            CurrentHealth = Math.Max(0, CurrentHealth - finalDamage);

            printCurrentHealth();
        }

        private int calculateFinalDamage(int damage)
        {
            int finalDamage = damage - mBasicArmor;
            if (finalDamage < 0)
            {
                finalDamage = 0;
            }
            return finalDamage;
        }

        private void printCurrentHealth()
        {
            Console.WriteLine($"{Name}의 현재 체력: [{CurrentHealth}]");
        }
    }

    sealed class Player : Character
    {
        public Player(string name, int currentHealth, int basicArmor) : base(name, currentHealth, basicArmor)
        {
        }
    }

    sealed class Monster : Character
    {
        public Monster(string name, int currentHealth, int basicArmor) : base(name, currentHealth, basicArmor)
        {
        }
    }

    internal class ReviewAccessScopes
    {
        static void Main(string[] args)
        {
            Player playerTest = new Player("플레이어", 100, 20);
            Monster monsterTest = new Monster("몬스터", 50, 10);

            playerTest.TakeDamage(10);
            monsterTest.TakeDamage(20);

        }
    }
}
