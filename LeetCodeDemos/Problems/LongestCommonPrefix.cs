
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/longest-common-prefix/description/
    internal class LongestCommonPrefix : ISolutionClass
    {
        public static string Solution(string[] strs)
        {
            string longestPrefix = strs[0];

            for(int i = 1; i < strs.Length && !String.IsNullOrEmpty(longestPrefix); i++)
            {
                int j = 0;
                for(; j < longestPrefix.Length && j < strs[i].Length; j++)
                {
                    if (longestPrefix[j] != strs[i][j])
                    {
                        break;
                    }
                }

                longestPrefix = longestPrefix.Substring(0, j);
            }

            return longestPrefix;
        }

        public static void TestSolution()
        {
            Console.WriteLine(Solution(["flower", "flow", "flight"]));
            Console.WriteLine(Solution(["dog", "racecar", "car"]));
        }
    }
}
