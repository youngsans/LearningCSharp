namespace ReviewTotalSystemTest
{
    public static class GameSettings
    {
        public const int PLAYER_BASIC_HEALTH = 80;
        public const int MONSTER_BASIC_HEALTH = 100;

        private static readonly string mGameVersion = "1.0.0";
        
        public static bool IsDebugMode { get; } = true;

        public static void PrintSettings()
        {
            Console.WriteLine($"--- 게임 설정 출력 ---\n-[게임 버전]: {mGameVersion}\n-[플레이어 기본 체력]: {PLAYER_BASIC_HEALTH}\n-[몬스터 기본 체력]: {MONSTER_BASIC_HEALTH}\n-[디버그 모드]: {IsDebugMode}\n");
        }
    }

    public static class CombatLogger
    {
        public static int TotalLogCount { get; private set; }

        public static void PrintAttackLog(string attacker, string defender, int damage)
        {            
            if (GameSettings.IsDebugMode)
            {
                TotalLogCount++;
                Console.WriteLine($"[{attacker}] 공격 → [{defender}] : [{damage}] 피해");
            }
        }

        public static void PrintDeathLog(string target)
        {            
            if (GameSettings.IsDebugMode)
            {
                TotalLogCount++;
                Console.WriteLine($"[{target}] 쓰러짐");
            }
        }

        public static void PrintTotalLog()
        {
            Console.WriteLine($"--- 전체 로그 출력: 총 {TotalLogCount}회 ---");
        }
    }

    public abstract class Character
    {
        private readonly string mName;
        public string Name { get { return mName; } }

        private int mCurrentHealth;
        public int CurrentHealth { get { return mCurrentHealth; } }

        public Character(string name, int health)
        {
            mName = name;
            mCurrentHealth = health;
        }

        public void TakeDamage(int amount, string attackerName)
        {
            mCurrentHealth = Math.Max(0, mCurrentHealth - amount);
            CombatLogger.PrintAttackLog(attackerName, mName, amount);
            if(mCurrentHealth == 0)
            {
                CombatLogger.PrintDeathLog(mName);
            }
        }
    }

    public sealed class Player : Character
    {
        public Player(string name) : base(name, GameSettings.PLAYER_BASIC_HEALTH)
        {
        }
    }

    public sealed class Monster : Character
    {
        public Monster(string name) : base(name, GameSettings.MONSTER_BASIC_HEALTH)
        {
        }
    }

    internal class TotalSystem
    {
        static void Main(string[] args)
        {
            GameSettings.PrintSettings();
            Character player = new Player("Player");
            Character monster = new Monster("Monster");
            List<Character> characterList = new List<Character>();
            characterList.Add(player);
            characterList.Add(monster);
            characterList[1].TakeDamage(30, player.Name);
            characterList[0].TakeDamage(40, monster.Name);
            characterList[1].TakeDamage(70, player.Name);

            CombatLogger.PrintTotalLog();
        }
    }
}