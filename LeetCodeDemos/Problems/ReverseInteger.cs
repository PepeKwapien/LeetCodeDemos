
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/reverse-integer/description/
    internal class ReverseInteger : ISolutionClass
    {
        public static int Solution(int x)
        {
            long result = 0;
            long moduloDivider = 10;

            do
            {
                long currentPartOfNumber = x % moduloDivider;
                long currentSum = currentPartOfNumber / (moduloDivider / 10);
                result *= 10;
                result += currentSum;
                moduloDivider *= 10;
            }
            while (x % (moduloDivider / 10) != x);

            if (result > int.MaxValue || result < int.MinValue)
            {
                result = 0;
            }

            return (int)result;
        }
        public static void TestSolution()
        {
            Console.WriteLine(Solution(123));
            Console.WriteLine(Solution(-123));
            Console.WriteLine(Solution(120));
            Console.WriteLine(Solution(1534236469));
        }
    }
}
