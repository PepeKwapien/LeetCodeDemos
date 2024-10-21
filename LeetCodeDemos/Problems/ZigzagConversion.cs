

using System.Text;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/zigzag-conversion/description/
    internal class ZigzagConversion : ISolutionClass
    {
        public static string Solution(string s, int numRows)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < numRows; i++)
            {
                int distanceBetweenColumns = Math.Max(numRows * 2 - 2, 1);
                int distanceOnDiagonal = Math.Max(distanceBetweenColumns - i * 2, 0);
                int currentIndex = i;

                while (currentIndex < s.Length)
                {
                    stringBuilder.Append(s[currentIndex]);

                    if (i != numRows - 1 && i != 0 && (currentIndex + distanceOnDiagonal) < s.Length)
                    {
                        stringBuilder.Append(s[currentIndex + distanceOnDiagonal]);
                    }

                    currentIndex += distanceBetweenColumns;
                }

            }

            return stringBuilder.ToString();
        }

        public static void TestSolution()
        {
            Console.WriteLine(Solution("PAYPALISHIRING", 2));
            Console.WriteLine(Solution("PAYPALISHIRING", 3));
            Console.WriteLine(Solution("PAYPALISHIRING", 4));
            Console.WriteLine(Solution("PAYPALISHIRING", 5));
            Console.WriteLine(Solution("A", 1));
            Console.WriteLine(Solution("ABC", 1));
        }
    }
}
