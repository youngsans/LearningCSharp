namespace ReviewForeach
{
    interface IPoisonable
    {
        void TakePoison(int amount);
    }

    interface IShieldable
    {
        void GetShield();
    }

    interface IManaRecoverable
    {
        void RecoverMana(int amount);
    }

    public interface IListable { }

    public static class CombatManager
    {
        //턴 종료시 매니저가 모든 개체를 순회하며 해당하는 처리를 진행
        private static int mLeftTurn = 10;

        public static void TurnOff(List<IListable> list)
        {
            if (mLeftTurn > 0)
            {                
                mLeftTurn = Math.Max(0, mLeftTurn - 1);
                Console.WriteLine($"--- 턴 종료 | 현재 남은 턴: {mLeftTurn} ---");
                foreach(IListable being in list)
                {
                    if(being is IPoisonable poisonableBeing)
                    {
                        poisonableBeing.TakePoison(3);
                    }

                    if(being is IShieldable shieldableBeing)
                    {
                        shieldableBeing.GetShield();
                    }
                    
                    if(being is IManaRecoverable manaRecoverableBeing)
                    {
                        manaRecoverableBeing.RecoverMana(1);
                    }

                    if(being is SummonedThing summonedBeing)
                    {
                        summonedBeing.CutLife();
                    }
                }
            }
            else
            {
                Console.WriteLine($"--- 남은 턴 없음 | [게임 종료] ---");
            }            
        }


    }

    public class Character : IPoisonable, IListable
    {
        private protected readonly string mName;
        private protected int mCurrentHealth;

        public string Name { get { return mName; } }
        public int CurrentHealth { get { return mCurrentHealth; } }

        public Character(string name , int health)
        {
            mName = name;
            mCurrentHealth = health;
        }

        public void TakePoison(int amount)
        {
            mCurrentHealth = Math.Max(0, mCurrentHealth - amount);
            Console.WriteLine($"[{mName}] 독 데미지 {amount} 입음 | 현재 체력: {mCurrentHealth}");
        }
    }

    public sealed class Warrior : Character, IShieldable, IListable
    {
        private int mShield;
        public int Shield { get { return mShield; } }

        public Warrior(string name, int health, int shield) : base(name, health)
        {
            mShield = shield;
        }

        public void GetShield()
        {
            mShield = 0;
            Console.WriteLine($"[{mName}] 방어도 초기화 | 현재 방어도: {mShield}");
        }
    }

    public sealed class Wizard : Character, IManaRecoverable, IListable
    {
        private int mMana;
        public int Mana { get { return mMana; } }

        public Wizard(string name, int health, int mana) : base(name, health)
        {
            mMana = mana;
        }

        public void RecoverMana(int amount)
        {
            mMana += amount;
            Console.WriteLine($"[{mName}] 마나 {amount} 회복 | 현재 마나: {mMana}");
        }
    }

    public sealed class SummonedThing : Character
    {
        private int mLeftLife;
        public int LeftLife { get { return mLeftLife; } }

        public SummonedThing(string name, int health, int leftLife) : base(name, health)
        {
            mLeftLife = leftLife;
        }

        public void CutLife()
        {
            mLeftLife = Math.Max(0, mLeftLife - 1);
            Console.WriteLine($"소환수 [{mName}]의 수명 깎임 | 남은 수명: {mLeftLife}턴");
            if(mLeftLife == 0)
            {
                Console.WriteLine($"소환수 [{mName}]의 남은 수명 없음.");
            }
        }
    }

    public class Trap : IListable
    {
        private readonly string mName;
        public string Name { get { return mName; } }

        public Trap(string name)
        {
            mName = name;
        }

    }



    internal class ReviewForeach
    {
        static void Main(string[] args)
        {
            IListable warrior = new Warrior("Warrior", 100, 5);
            IListable wizard = new Wizard("Wizard", 70, 40);
            IListable dragon = new SummonedThing("Dragon", 400, 3);
            IListable trap = new Trap("Trap");

            List<IListable> list = new List<IListable>();
            
            list.Add(warrior);
            list.Add(wizard);
            list.Add(dragon);
            list.Add(trap);

            CombatManager.TurnOff(list);
        }
    }
}
