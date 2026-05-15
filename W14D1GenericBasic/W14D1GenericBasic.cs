namespace W14D1GenericBasic
{
    internal class W14D1GenericBasic
    {
        public static void PrintAll<T>(T[] targetArray)
        {
            for (int i = 0; i < targetArray.Length; i++)
            {
                Console.WriteLine($"{targetArray[i]}");
            }
        }

        public static T GetFirstOrDefault<T>(T[] targetArray, T targetValue)
        {
            for (int i = 0; i < targetArray.Length; i++)
            {
                if (object.Equals(targetArray[i], targetValue))
                {
                    Console.WriteLine($"해당 배열의 [{i+1}]번째에 {targetValue}가 있습니다.");
                    return targetArray[i];
                }
            }

            Console.WriteLine($"해당 배열에 {targetValue}가 없습니다.");

            return default(T);
        }

        static void Main(string[] args)
        {
            int[] numArray = new int[] { 10, 25, 30, 5 };
            string[] stringArray = new string[] { "Strike", "Defend", "Bash" };

            PrintAll(numArray);
            PrintAll(stringArray);

            GetFirstOrDefault<int>(numArray, 25);
            GetFirstOrDefault<int>(numArray, 99);

            GetFirstOrDefault<string>(stringArray, "Bash");
            GetFirstOrDefault<string>(stringArray, "Neutralize");
        }
    }
}
