
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/two-sum/
    internal class TwoSum : ISolutionClass
    {
        public int[] Solution(int[] nums, int target)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionary.ContainsKey(nums[i]))
                {
                    return new int[] { dictionary[nums[i]], i };
                }
                int difference = target - nums[i];
                dictionary[difference] = i;
            }

            return [-1, -1];
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution([2, 7, 11, 15], 9));
            Console.WriteLine(Solution([3, 2, 4], 6));
            Console.WriteLine(Solution([3, 3], 6));
        }
    }
}
