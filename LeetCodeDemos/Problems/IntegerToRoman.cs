
using System.Text;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/integer-to-roman/description/
    internal class IntegerToRoman : ISolutionClass
    {
        private static void GreedyIntegerToRoman(ref int num, int treshhold, ref StringBuilder result, string romanEquivalent)
        {
            while (num >= treshhold)
            {
                result.Append(romanEquivalent);
                num -= treshhold;
            }
        }

        public static string Solution(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var greedyWithLocalStringBuilder =
                (int treshhold, string romanEquivalent) => GreedyIntegerToRoman(ref num, treshhold, ref stringBuilder, romanEquivalent);

            greedyWithLocalStringBuilder(1000, "M");
            greedyWithLocalStringBuilder(900, "CM");
            greedyWithLocalStringBuilder(500, "D");
            greedyWithLocalStringBuilder(400, "CD");
            greedyWithLocalStringBuilder(100, "C");
            greedyWithLocalStringBuilder(90, "XC");
            greedyWithLocalStringBuilder(50, "L");
            greedyWithLocalStringBuilder(40, "XL");
            greedyWithLocalStringBuilder(10, "X");
            greedyWithLocalStringBuilder(9, "IX");
            greedyWithLocalStringBuilder(5, "V");
            greedyWithLocalStringBuilder(4, "IV");
            greedyWithLocalStringBuilder(1, "I");

            return stringBuilder.ToString();
        }
        public static void TestSolution()
        {
            Console.WriteLine(Solution(3749));
            Console.WriteLine(Solution(58));
            Console.WriteLine(Solution(1994));
        }
    }
}
