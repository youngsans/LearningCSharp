namespace W12D1_Struct
{
    enum EDamageType
    {
        Physics = 0,
        Fire,
        Lightning
    }
    internal class Structs
    {        
        public struct SDamageInfo
        {
            public int dmgAmount;
            public bool bIsPierce;            
            public EDamageType dmgType;

            public SDamageInfo(int damageAmount, bool boolIsPierce, EDamageType damageType)
            {
                this.dmgAmount = damageAmount;
                this.bIsPierce = boolIsPierce;
                this.dmgType = damageType;
            }
        }

        public class Monster
        {
            string mName;
            int mHealth;
            int mArmor;

            public Monster(string name, int health, int armor)
            {
                this.mName = name;
                this.mHealth = health;
                this.mArmor = armor;
            }

            public void TakeDamage(SDamageInfo damageInfo)
            {
                Console.WriteLine($"--- 몬스터가 공격 받음 ---");
                Console.Write($"[데미지 타입: {damageInfo.dmgType}] ");
                if (!damageInfo.bIsPierce)
                {
                    Console.WriteLine($"관통 불가. [몬스터의 방어도: {this.mArmor}] | [데미지: {damageInfo.dmgAmount}]");

                    int finalDamage = this.mArmor - damageInfo.dmgAmount;

                    if(finalDamage < 0)
                    {
                        this.mArmor = 0;
                        this.mHealth += finalDamage;

                        if (this.mHealth < 0)
                        { 
                            this.mHealth = 0;
                        }                   
                    }

                    else 
                    {
                        this.mArmor = finalDamage;
                    }

                    Console.WriteLine($"몬스터의 현재 체력: {this.mHealth}(남은 방어도: {this.mArmor})");
                }

                else
                {
                    Console.WriteLine($"관통 가능. [몬스터의 방어도: {this.mArmor}(무시)] | [데미지:{damageInfo.dmgAmount}]");

                    this.mHealth -= damageInfo.dmgAmount;
                    if (this.mHealth < 0) 
                    {
                        this.mHealth = 0;
                    }

                    Console.WriteLine($"몬스터의 현재 체력: {this.mHealth}(남은 방어도: {this.mArmor})");
                }
            }
        }

        static void Main(string[] args)
        {
            Monster testMonster = new Monster("몬스터", 100, 10);

            SDamageInfo damage1 = new SDamageInfo(20, true, EDamageType.Fire);
            SDamageInfo damage2 = new SDamageInfo(10, false, EDamageType.Physics);

            testMonster.TakeDamage(damage1);
            testMonster.TakeDamage(damage2);
        }
    }
}
