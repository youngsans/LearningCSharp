namespace W11D1_Interface
{//하다가 꼬여서 4일차로 넘어감.
    interface IDamageable
    {
        void DealDamage(IAttackable target, int amount);        
    }

    interface IBuffable
    {
        void GetBuff(string name, int stack);
    }

    interface IAttackable
    {
        void TakeDamage(int amount);
    }

    interface I

    public class Player : IAttackable, IBuffable, IDamageable
    {
        public int HP { get; private set; }
        public int Damage { get; private set; }
        public Player(int hp, int damage)
        {
            HP = hp;
            Damage = damage;
        }

        public void DealDamage(IAttackable target, int amount)
        {
            target.TakeDamage(amount);
        }

        public void TakeDamage(int amounts)
        {
            HP -= amounts;
            Console.WriteLine($"플레이어 공격 받음. [데미지]: {amounts} | [남은 체력]: {HP}");
        }

        public void GetBuff(string buffName, int buffStack)
        {
            Console.WriteLine($"플레이어가 버프 획득. [버프]: {buffName} | [턴]: {buffStack}");
        }
    }

    public class Monster : IDamageable, IBuffable
    {
        public int HP {  get; private set; }
        public int Damage { get; private set; }
        public Monster(int hp, int damage)
        {
            HP = hp;
            Damage = damage;
        }
        public void TakeDamage(int amount)
        {
            HP -= amount;
            Console.WriteLine($"몬스터 공격 받음. [데미지]: {amount} | [남은 체력]: {HP}");
        }

        public void GetBuff(string buffName, int buffStack)
        {
            Console.WriteLine($"몬스터가 버프 획득. [버프]: {buffName} | [턴]: {buffStack}");
        }
    }

    public class Barricade : IDamageable
    {
        public int HP { get; private set; }
        public Barricade(int hp)
        {
            HP = hp;
        }
        public void TakeDamage(int amount)
        {
            HP -= amount;
            Console.WriteLine($"바리케이드 공격 받음. [데미지]: {amount} | [남은 체력]: {HP}");
        }
    }

    internal class W11D1_Interface
    {
        static void Main(string[] args)
        {
            Player player = new Player(100, 10);
            Monster monster = new Monster(50, 20);
            Barricade barricade = new Barricade(100);

            player.TakeDamage(monster.Damage);
            player.GetBuff("버프 0001", 4);
            monster.TakeDamage(player.Damage);
            monster.GetBuff("버프 0451", 5);
            barricade.TakeDamage(monster.Damage);

        }
    }
}
