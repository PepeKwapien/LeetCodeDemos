
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/longest-palindromic-substring/description/?envType=problem-list-v2&envId=dynamic-programming
    internal class GenerateParentheses : ISolutionClass
    {
        public IList<string> Solution(int n)
        {
            List<string> solution = new List<string>();
            GenerateParenthesesRecursive(n, 0, 0, "", solution);
            return solution;
        }

        private void GenerateParenthesesRecursive(int n, int open, int close, string current, List<string> solution)
        {
            if (current.Length == n * 2)
            {
                solution.Add(current);
                return;
            }

            if (open < n)
            {
                GenerateParenthesesRecursive(n, open + 1, close, current + "(", solution);
            }

            if (close < open)
            {
                GenerateParenthesesRecursive(n, open, close + 1, current + ")", solution);
            }
        }

        public void TestSolution()
        {
            Console.WriteLine(JsonSerializer.Serialize(Solution(3)));
        }
    }
}
