
// https://leetcode.com/problems/divide-two-integers/description/
namespace LeetCodeDemos.Problems
{
    internal class DivideTwoIntegers : ISolutionClass
    {
        public int Solution(int dividend, int divisor)
        {
            var normalisedDividend = dividend <= Int32.MinValue ? Int32.MaxValue : Math.Abs(dividend);
            var normalisedDivisor = divisor <= Int32.MinValue ? Int32.MaxValue : Math.Abs(divisor);

            if ( normalisedDividend == normalisedDivisor)
            {
                return 1;
            }

            if (normalisedDivisor == 1)
            {
                return ReturnResult(dividend, divisor, normalisedDividend);
            }

            var result = 0;
            while (normalisedDividend >= normalisedDivisor)
            {
                var bitsShifted = 0;
                while(normalisedDividend > (normalisedDivisor << (bitsShifted + 1)))
                {
                    bitsShifted++;
                }
                result += (1 << bitsShifted);
                normalisedDividend -= normalisedDivisor << bitsShifted;
            }

            return ReturnResult(dividend, divisor, result);
        }

        private int ReturnResult(int dividend, int divisor, int result)
        {
            if ((divisor < 0 && dividend > 0) || (divisor > 0 && dividend < 0))
            {
                if (result >= Int32.MaxValue)
                {
                    return Int32.MinValue;
                }

                return 0 - result;
            }

            return result;
        }
        public void TestSolution()
        {
            Console.WriteLine(Solution(24, 6));             // 4
            Console.WriteLine(Solution(36, 8));             // 4
            Console.WriteLine(Solution(10, 3));             // 3
            Console.WriteLine(Solution(7, -3));             // -2
            Console.WriteLine(Solution(1, 1));              // 1
            Console.WriteLine(Solution(-2147483648, -1));   // 2147483647
            Console.WriteLine(Solution(-2147483648, 1));    // -2147483648
            Console.WriteLine(Solution(2147483647, 2));     // 1
        }
    }
}
