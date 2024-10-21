

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/roman-to-integer/description/
    // This beat 100% people btw
    internal class RomanToInteger : ISolutionClass
    {
        public static Dictionary<char, int> RomanDictionary = new Dictionary<char, int>() {
            { 'M', 1000 }, { 'D', 500 },
            { 'C', 100 }, { 'L', 50 },
            { 'X', 10 }, { 'V', 5 },
            { 'I', 1 }
        };
        public static int RomanToInt(string s)
        {
            int result = 0;
            int previousNumber = 0;
            foreach(char c in s)
            {
                int currentNumber = RomanDictionary[c];

                if (currentNumber > previousNumber)
                {
                    previousNumber = currentNumber - previousNumber;
                }
                else
                {
                    result += previousNumber;
                    previousNumber = currentNumber;
                }
            }
            result += previousNumber;

            return result;
        }

        public static void TestSolution()
        {
            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("LVIII"));
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }
    }
}
