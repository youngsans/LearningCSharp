namespace ReviewStatics
{
    public static class GameSettings
    {
        public const int BASIC_HEALTH = 100; 

    }

    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Character
    {
        public static int CharacterCount { get; private set; } = 0;
        private readonly string mName;
        public string Name { get { return mName; } }
        public int CurrentHealth { get; private set; }

        public Character(string name)
        {
            mName = name;
            CurrentHealth = GameSettings.BASIC_HEALTH;
            CharacterCount++;
            Logger.Log($"[{Name}] 생성됨");
        }


        public void TakeDamage(int amount)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - amount);
            Logger.Log($"{Name}, [{amount}] 데미지 받음. 현재 체력 {CurrentHealth}");
        }

    }


    internal class ReviewStatics
    {
        static void Main(string[] args)
        {
            Character characterA = new Character("캐릭터 A");
            Character characterB = new Character("캐릭터 B");

            characterA.TakeDamage(30);
            characterB.TakeDamage(50);

            Logger.Log($"지금까지 생성된 캐릭터 수: {Character.CharacterCount}");
        }
    }
}
