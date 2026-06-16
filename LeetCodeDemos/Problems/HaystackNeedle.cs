// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/
namespace LeetCodeDemos.Problems
{
    internal class HaystackNeedle : ISolutionClass
    {
        public int Solution(string haystack, string needle)
        {
            return haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution("sadbutsad", "sad"));
            Console.WriteLine(Solution("leetcode", "leeto"));
        }
    }
}
