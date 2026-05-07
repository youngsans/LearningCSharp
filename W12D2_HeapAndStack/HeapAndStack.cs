namespace W12D2_HeapAndStack
{
    enum EKeyword
    {
        Attack,
        Skill,
        Defense,
        Curse,
        Heal,
        Upgraded
    }
    internal class HeapAndStack
    {
        struct SCardData
        {
            public string CardName;
            public int BasicDamage;
            public KeywordList KeywordList = new KeywordList();

            public SCardData(string cardName, int basicDamage, EKeyword keyword)
            {
                CardName = cardName;
                BasicDamage = basicDamage;
                KeywordList.Keywords.Add($"{keyword}");
            }
        }

        public class KeywordList
        {
            public List<string> Keywords = new List<string>();
        }

        static SCardData UpgradeCard(SCardData cardData)
        {
            Console.WriteLine($"--- 카드를 업그레이드 합니다 ---");

            SCardData cardDataNew = cardData;

            cardDataNew.CardName = cardData.CardName + "+";
            cardDataNew.BasicDamage = cardData.BasicDamage + 3;
            cardDataNew.KeywordList = new KeywordList();
            cardDataNew.KeywordList.Keywords.AddRange(cardData.KeywordList.Keywords);
            cardDataNew.KeywordList.Keywords.Add($"{EKeyword.Upgraded}");
            return cardDataNew;
        }

        static void PrintCardData(SCardData cardData)
        {
            Console.Write($"-카드 이름: [{cardData.CardName}] \n-기본 데미지: [{cardData.BasicDamage}] \n-키워드 목록: [");

            if (cardData.KeywordList.Keywords.Count == 0)
            {
                Console.WriteLine($"]");
            }

            else
            {
                for (int i = 0; i < cardData.KeywordList.Keywords.Count; i++)
                {
                    Console.Write($"{cardData.KeywordList.Keywords[i]}");

                    if (i < cardData.KeywordList.Keywords.Count - 1)
                    {
                        Console.Write($", ");
                    }
                    else
                    {
                        Console.WriteLine($"]");
                        return;
                    }
                }
            }
            
        }

        static void Main(string[] args)
        {
            SCardData cardDataA = new SCardData("강력한 타격", 5, EKeyword.Attack);
            PrintCardData(cardDataA);
            SCardData cardDataB = UpgradeCard(cardDataA);
            PrintCardData(cardDataB);

            //독립성 검증
            Console.WriteLine($"--- 독립성 검증 ---");
            cardDataA.KeywordList.Keywords.Add($"{EKeyword.Curse}");
            PrintCardData(cardDataA);
            PrintCardData(cardDataB);
        }

    }
}
