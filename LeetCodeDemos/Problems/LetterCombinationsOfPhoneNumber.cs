
using System.Text.Json;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    internal class LetterCombinationsOfPhoneNumber : ISolutionClass
    {
        public static readonly Dictionary<char, IList<string>> digitMap = new Dictionary<char, IList<string>> {
            { '2', ["a", "b", "c"] },
            { '3', ["d", "e", "f"] },
            { '4', ["g", "h", "i"] },
            { '5', ["j", "k", "l"] },
            { '6', ["m", "n", "o"] },
            { '7', ["p", "q","r", "s"] },
            { '8', ["t", "u", "v"] },
            { '9', ["w", "x", "y", "z"] }
        };

        public static IList<string> Solution1(string digits)
        {
            return AppendLetters(digits);
        }

        public static IList<string> AppendLetters(string remainingDigits)
        {
            if (remainingDigits.Length == 0)
            {
                return [];
            }

            var possibleLetters = digitMap[remainingDigits[0]];
            var possibleLettersFromRemainder = AppendLetters(remainingDigits.Substring(1));
            if (possibleLettersFromRemainder.Count == 0)
            {
                possibleLettersFromRemainder = [""];
            }

            return possibleLetters.SelectMany(letter => possibleLettersFromRemainder.Select(letters => letter + letters)).ToList();
        }

        public static void TestSolution()
        {
            Console.WriteLine(JsonSerializer.Serialize(Solution1("23")));
            Console.WriteLine(JsonSerializer.Serialize(Solution1("")));
            Console.WriteLine(JsonSerializer.Serialize(Solution1("2")));
        }
    }
}
