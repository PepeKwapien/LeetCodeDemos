
// https://leetcode.com/problems/divide-two-integers/description/
namespace LeetCodeDemos.Problems
{
    internal class DivideTwoIntegers : ISolutionClass
    {
        public int Solution(int dividend, int divisor)
        {
            if (dividend == Int32.MaxValue && divisor == Int32.MinValue)
            {
                // Edge case because normalised value will miss one bit
                return 0;
            }

            var normalisedDividend = dividend == Int32.MinValue ? Int32.MaxValue : Math.Abs(dividend);
            var normalisedDivisor = divisor == Int32.MinValue ? Int32.MaxValue : Math.Abs(divisor);
            var shiftedNormalisedDivisor = normalisedDivisor;

            if (normalisedDividend == normalisedDivisor)
            {
                return ReturnResult(dividend, divisor, 1);
            }

            if (normalisedDivisor == 1)
            {
                return ReturnResult(dividend, divisor, normalisedDividend);
            }

            var bitsShifted = 1;
            while ((shiftedNormalisedDivisor << 1 <= normalisedDividend) && (shiftedNormalisedDivisor << 1 > shiftedNormalisedDivisor))
            {
                shiftedNormalisedDivisor <<= 1;
                bitsShifted++;
            }

            var result = 0;
            while (normalisedDividend >= normalisedDivisor)
            {
                result <<= 1;
                bitsShifted--;
                var rest = normalisedDividend - shiftedNormalisedDivisor;
                if (rest >= 0)
                {
                    result++;
                    normalisedDividend = rest;
                }
                shiftedNormalisedDivisor >>= 1;
            }

            result <<= bitsShifted;

            return ReturnResult(dividend, divisor, result);
        }

        private int ReturnResult(int dividend, int divisor, int result)
        {
            if (dividend == Int32.MinValue && IsItPowerOfTwo(divisor))
            {
                result++;
            }

            if ((divisor < 0 && dividend > 0) || (divisor > 0 && dividend < 0))
            {
                if (result == Int32.MaxValue && dividend == Int32.MinValue)
                {
                    return Int32.MinValue;
                }

                return 0 - result;
            }

            return result;
        }

        public bool IsItPowerOfTwo(int divisor)
        {
            var kek = 2;
            while (divisor >= kek && kek > 0)
            {
                if(divisor == kek)
                {
                    return true;
                }
                kek <<= 1;
            }

            return false;
        }

        public void TestSolution()
        {
            //Console.WriteLine(Solution(24, 6));             // 4
            //Console.WriteLine(Solution(36, 8));             // 4
            //Console.WriteLine(Solution(10, 3));             // 3
            //Console.WriteLine(Solution(7, -3));             // -2
            //Console.WriteLine(Solution(1, 1));              // 1
            //Console.WriteLine(Solution(-2147483648, -1));   // 2147483647
            //Console.WriteLine(Solution(-2147483648, 1));    // -2147483648
            //Console.WriteLine(Solution(2147483647, 2));     // 1073741823
            //Console.WriteLine(Solution(-1, 1));             // -1
            //Console.WriteLine(Solution(-2147483648, 2));    // -1073741824
            //Console.WriteLine(Solution(-2147483647, 3));    // 715827882
            //Console.WriteLine(Solution(Int32.MaxValue, Int32.MinValue));    // 0
            Console.WriteLine(Solution(-2147483648, 1262480350));    // -1
            Console.WriteLine(Solution(2147483647, -1));    // -2147483647

            //Console.WriteLine((Int32.MinValue / 2) + (Int32.MaxValue / 2));
            //Console.WriteLine((Int32.MinValue / 4) + (Int32.MaxValue / 4));
            //Console.WriteLine((Int32.MinValue / 6) + (Int32.MaxValue / 6));
            //Console.WriteLine((Int32.MinValue / 8) + (Int32.MaxValue / 8));
            //Console.WriteLine((Int32.MinValue / 10) + (Int32.MaxValue / 10));
            //Console.WriteLine((Int32.MinValue / 12) + (Int32.MaxValue / 12));
            //Console.WriteLine((Int32.MinValue / 14) + (Int32.MaxValue / 14));
            //Console.WriteLine((Int32.MinValue / 16) + (Int32.MaxValue / 16));

            //Console.WriteLine(IsItPowerOfTwo(1));
            //Console.WriteLine(IsItPowerOfTwo(2));
            //Console.WriteLine(IsItPowerOfTwo(3));
            //Console.WriteLine(IsItPowerOfTwo(4));
            //Console.WriteLine(IsItPowerOfTwo(5));
            //Console.WriteLine(IsItPowerOfTwo(6));
            //Console.WriteLine(IsItPowerOfTwo(8));
            //Console.WriteLine(IsItPowerOfTwo(12));
            //Console.WriteLine(IsItPowerOfTwo(16));

            //int xd = 1610612736;
            //Console.WriteLine(Convert.ToString(xd, toBase: 2));

            //int xd1 = 715827882;
            //Console.WriteLine(Convert.ToString(xd1, toBase: 2));

            //int xd2 = 536870912;
            //Console.WriteLine(Convert.ToString(xd2, toBase: 2));

            //Console.WriteLine((Int32.MaxValue - 2) << 1);
            //Console.WriteLine(Convert.ToString((Int32.MaxValue - 2) << 1, toBase: 2));
        }
    }
}
