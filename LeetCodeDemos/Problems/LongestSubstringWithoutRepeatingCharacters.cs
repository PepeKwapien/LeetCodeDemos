namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
    internal class LongestSubstringWithoutRepeatingCharacters : ISolutionClass
    {
        public static int Solution(string s)
        {
            int answer = 0;

            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> nonRepeatingCharacters = new HashSet<char>(new char[] { s[i] });

                for (int j = i + 1; j < s.Length; j++)
                {
                    if (nonRepeatingCharacters.Contains(s[j]))
                    {
                        break;
                    }

                    nonRepeatingCharacters.Add(s[j]);
                }

                if (nonRepeatingCharacters.Count > answer)
                {
                    answer = nonRepeatingCharacters.Count;
                }
            }

            return answer;
        }

        public static void TestSolution()
        {
            Console.WriteLine(Solution("abcabcbb"));
            Console.WriteLine(Solution("bbbbb"));
            Console.WriteLine(Solution("pwwkew"));
        }
    }
}
