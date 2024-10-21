
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/palindrome-number/description/
    internal class PalindromeNumber : ISolutionClass
    {
        public static bool Solution(int x)
        {
            if (x < 0)
            {
                return false;
            }

            long revertedNumber = 0;
            long moduloDivider = 10;

            do
            {
                long currentDigit = x % moduloDivider;
                long currentSum = currentDigit / (moduloDivider / 10);
                revertedNumber *= 10;
                revertedNumber += currentSum;
                moduloDivider *= 10;
            }
            while (x % (moduloDivider / 10) != x);

            return x - revertedNumber == 0;
        }
        public static void TestSolution()
        {
            Console.WriteLine(Solution(121));
            Console.WriteLine(Solution(-121));
            Console.WriteLine(Solution(10));
            Console.WriteLine(Solution(1234567899));
        }
    }
}
