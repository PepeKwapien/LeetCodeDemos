namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/valid-parentheses/description/
    internal class ValidParentheses : ISolutionClass
    {
        public bool Solution(string s)
        {
            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(' || c == '[' || c == '{')
                {
                    parentheses.Push(c);
                }
                if (c == ')' || c == ']' || c == '}')
                {
                    if (parentheses.Count == 0)
                    {
                        return false;
                    }
                    var poppedParentheses = parentheses.Pop();
                    if ((c == ')' && poppedParentheses != '(') ||
                        (c == ']' && poppedParentheses != '[') ||
                        (c == '}' && poppedParentheses != '{'))
                    {
                        return false;
                    }
                }
            }

            if (parentheses.Count != 0)
            {
                return false;
            }

            return true;
        }
        public void TestSolution()
        {
            Console.WriteLine(Solution("()"));
            Console.WriteLine(Solution("()[]{}"));
            Console.WriteLine(Solution("(]"));
            Console.WriteLine(Solution("([])"));
            Console.WriteLine(Solution(")"));
        }
    }
}
