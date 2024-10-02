
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/regular-expression-matching/description/
    internal class RegularExpressionMatching : TestSolution
    {
        private static Dictionary<string, bool> _regularExpressionMAtchingStartAndDotResults = [];

        public static bool RegularExpressionMatchingStartAndDot(string s, string p)
        {
            _regularExpressionMAtchingStartAndDotResults = [];
            return RegularExpressionRecursion(s, p, 0, 0);
        }

        private static bool RegularExpressionRecursion(string s, string p, int indexS, int indexP)
        {
            if (indexP >= p.Length)
            {
                return false;
            }

            var createResultsKey = (int indexS, int indexP) => $"s{indexS}p{indexP}";
            var currentKey = createResultsKey(indexS, indexP);

            if (_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey))
            {
                return _regularExpressionMAtchingStartAndDotResults[currentKey];
            }


            int nextIndexS = indexS;
            int nextIndexP = indexP;


            // we are dealing with * group in pattern
            if (indexP + 1 < p.Length && p[indexP + 1] == '*')
            {
                // word ended, the only way this * group is valid is by it being a 0 occurrence
                if (indexS == s.Length)
                {
                    nextIndexP += 2;
                }
                else
                {
                    // symbol not matching, treat * group as an empty group
                    if (s[indexS] != p[indexP] && p[indexP] != '.')
                    {
                        nextIndexP += 2;
                    }
                    else
                    {
                        // check if moving to next symbol and not moving away from gorup is valid
                        bool result = RegularExpressionRecursion(s, p, indexS + 1, indexP);
                        currentKey = createResultsKey(indexS + 1, indexP);
                        if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);

                        // in case of fail, check if moving from group is valid
                        if (!result)
                        {
                            result = RegularExpressionRecursion(s, p, indexS + 1, indexP + 2);
                            currentKey = createResultsKey(indexS + 1, indexP + 2);
                            if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);
                        }

                        // although the symbol matched, maybe the group should be treated as empty
                        if (!result)
                        {
                            result = RegularExpressionRecursion(s, p, indexS, indexP + 2);
                            currentKey = createResultsKey(indexS, indexP + 2);
                            if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);
                        }

                        return result;
                    }
                }
            }
            // we are not dealing with * group in pattern
            else
            {
                // s ended and pattern expects a character
                if (indexS == s.Length)
                {
                    return false;
                }
                // match character or wildcard
                if (s[indexS] == p[indexP] || p[indexP] == '.')
                {
                    nextIndexP++;
                    nextIndexS++;
                }
                else
                {
                    return false;
                }

            }

            // not done with analyzing pattern
            if (nextIndexP < p.Length)
            {
                bool result = RegularExpressionRecursion(s, p, nextIndexS, nextIndexP);
                currentKey = createResultsKey(nextIndexS, nextIndexP);
                if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);
                return result;
            }
            // done with pattern but not done with word
            else if (nextIndexS < s.Length)
            {
                return false;
            }
            // done with pattern and word
            else
            {
                return true;
            }

        }
        public void TestSolution()
        {
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "abc"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a.c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a."));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a.."));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("aaa", "baa"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("a", "aa"));
            Console.WriteLine("-------------------------------\nBIG BOY EXAMPLES\n-------------------------------");
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a.*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*b"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("aab", "a*b"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("a", "ab*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("a", "ab*c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("ba", "a*.*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("b", "a*b*c*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*b.*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("ba", ".*a*a"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("bbab", "b*a*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("aaaaaaaaaaaaaaaaaaab", "a*a*a*a*a*a*a*a*a*a*"));
        }
    }
}
