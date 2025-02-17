
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/container-with-most-water/description/
    internal class ContainerWithMostWater : ISolutionClass
    {
        public int Solution(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int result = 0;

            while (left < right)
            {
                int currentField = (right - left) * Math.Min(height[left], height[right]);
                if (currentField > result)
                {
                    result = currentField;
                }

                if (height[left] <= height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return result;
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution([1, 8, 6, 2, 5, 4, 8, 3, 7]));
            Console.WriteLine(Solution([1, 1]));
            Console.WriteLine(Solution([1, 1, 1, 2, 1]));
            Console.WriteLine(Solution([2, 9, 8, 1, 2]));
        }
    }
}
