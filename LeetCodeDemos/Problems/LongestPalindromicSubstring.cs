
using System.Text;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/longest-palindromic-substring/description/
    internal class LongestPalindromicSubstring : ISolutionClass
    {
        public static string Solution(string s)
        {
            string output = "";

            for (int i = 0; i < s.Length; i++)
            {
                string centerPali = ExpandPalindrome(s, i, false);
                string betweenPali = ExpandPalindrome(s, i, true);
                string longerPali = centerPali.Length < betweenPali.Length ? betweenPali : centerPali;
                if (longerPali.Length > output.Length)
                {
                    output = longerPali;
                }
            }

            return output;
        }

        private static string ExpandPalindrome(string s, int index, bool isIndexBetweenCharacters)
        {
            int left = index;
            int right = isIndexBetweenCharacters ? index + 1 : index;
            StringBuilder stringBuilder = new StringBuilder();

            if (!isIndexBetweenCharacters)
            {
                stringBuilder.Append(s[left]);
                left--;
                right++;
            }

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                stringBuilder.Append(s[right]);
                stringBuilder.Insert(0, s[left]);
                left--;
                right++;
            }

            return stringBuilder.ToString();
        }

        public static void TestSolution()
        {
            Console.WriteLine(Solution("babad"));
            Console.WriteLine(Solution("cbbd"));
            Console.WriteLine(Solution("a"));
            Console.WriteLine(Solution("aacabdkacaa"));
            Console.WriteLine(Solution("babaddtattarrattatddetartrateedredividerb"));
            Console.WriteLine(Solution("kobylamamalybok"));
             
        }
    }
}
