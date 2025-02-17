
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/string-to-integer-atoi/description/
    internal class StringToIntegerAtoi : ISolutionClass
    {
        public int Solution(string s)
        {
            s = s.Trim();
            int sign = 1;
            double result = 0;
            int index = 0;

            if (s.Length > 0 && !Char.IsNumber(s[0]))
            {
                if (s[0] == '+')
                {
                    sign = 1;
                }
                else if (s[0] == '-')
                {
                    sign = -1;
                }
                else
                {
                    return 0;
                }

                index++;
            }

            for (int i = index; i < s.Length; i++)
            {
                if (!Char.IsDigit(s[i]))
                {
                    break;
                }

                result *= 10;
                result += Int32.Parse(s[i].ToString()) * sign;
            }


            if (result > int.MaxValue)
            {
                result = int.MaxValue;
            }
            else if (result < int.MinValue)
            {
                result = int.MinValue;
            }

            return (int)result;
        }
        public void TestSolution()
        {
            Console.WriteLine(Solution("42"));
            Console.WriteLine(Solution("   -042"));
            Console.WriteLine(Solution("1337c0d3"));
            Console.WriteLine(Solution("0-1"));
            Console.WriteLine(Solution("words and 987"));
        }
    }
}
