using System.Xml.Linq;

namespace W11D4_InterfaceAsVariable
{
    interface IDamageable
    {
        void TakeDamage(int amount);
    }

    interface IBuffable
    {
        void GetBuff(string buffName, int buffStack);
    }

    class Player : IDamageable, IBuffable
    {
        public string Name { get; private set; }
        public int AtkPower { get; private set; }
        public int CurrentHP { get; private set; }
        public int MaxHP { get; private set; }

        public Player(string name, int atkPower, int maxhp)
        {
            Name = name;
            AtkPower = atkPower;
            MaxHP = maxhp;
            CurrentHP = maxhp;
        }        

        public void TakeDamage(int amount)
        {
            CurrentHP -= amount;
            Console.WriteLine($"[{Name}] 데미지 {amount} 받음. 현재 체력: {CurrentHP} / {MaxHP}");
        }

        public void ApplyBuff(IBuffable target, string buffName, int buffStack)
        {
            target.GetBuff(buffName, buffStack);
        }

        public void GetBuff(string buffName, int buffStack)
        {
            Console.WriteLine($"버프 [{buffName}]을 {buffStack} 턴 동안 적용");
        }
    }

    class Monster : IDamageable, IBuffable
    {
        public string Name { get; private set; }
        public int AtkPower { get; private set; }
        public int CurrentHP { get; private set; }
        public int MaxHP { get; private set; }

        public Monster(string name, int atkPower, int maxhp)
        {
            Name = name;
            AtkPower = atkPower;
            MaxHP = maxhp;
            CurrentHP = maxhp;
        }
        public void DealDamage(IDamageable target, int amount)
        {
            Console.WriteLine($"[{Name}]이 [{target.ToString}]을 {amount}로 공격.");
            target.TakeDamage(amount);
        }

        public void TakeDamage(int amount)
        {
            CurrentHP -= amount;
            Console.WriteLine($"[{Name}] 데미지 {amount} 받음. 현재 체력: {CurrentHP} / {MaxHP}");
        }

        public void ApplyBuff(IBuffable target, string buffName, int buffStack)
        {
            target.GetBuff(buffName, buffStack);
        }

        public void GetBuff(string buffName, int buffStack)
        {
            Console.WriteLine($"버프 [{buffName}]을 {buffStack} 턴 동안 적용");
        }
    }

    class Barricade : IDamageable
    {
        public string Name { get; private set; }
        public int CurrentHP { get; private set; }
        public int MaxHP { get; private set; }

        public Barricade(string name, int maxhp)
        {
            Name = name;
            MaxHP = maxhp;
            CurrentHP = maxhp;
        }        

        public void TakeDamage(int amount)
        {
            CurrentHP -= amount;
            Console.WriteLine($"[{Name}] 데미지 {amount} 받음. 현재 체력: {CurrentHP} / {MaxHP}");
        }
    }

    internal class W11D4_InterfaceAsVariable
    {
        static void DealDamage(IDamageable target, string targetName, string dealerName, int amount)
        {
            Console.WriteLine($"[{dealerName}]이 [{targetName}]을 {amount}로 공격.");
            target.TakeDamage(amount);
        }

        static void Main(string[] args)
        { 
            Player player = new Player("플레이어", 10, 100);
            Monster monster = new Monster("몬스터", 8, 40);
            Barricade barricade = new Barricade("바리케이드", 50);

            player.DealDamage(monster, monster.Name, player.Name, player.AtkPower);
            monster.DealDamage(barricade, monster.AtkPower);
            monster.DealDamage(player, monster.AtkPower);

        }
    }
}
