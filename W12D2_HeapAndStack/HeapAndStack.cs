namespace W12D2_HeapAndStack
{
    internal class HeapAndStack
    {
        struct SCardStat
        {
            public int Damage;
            public int Cost;
        }

        class CardEffect
        {
            public int Damage;
            public int Cost;
        }

        void ModifyStat(SCardStat stat)
        {
            stat.Damage = 999;
        }

        void ModifyEffect(CardEffect effect)
        {
            effect.Damage = 999;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

    }
}
