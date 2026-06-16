
// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
namespace LeetCodeDemos.Problems
{
    internal class RemoveDuplicates : ISolutionClass
    {
        //1 <= nums.length <= 3 * 104
        //-100 <= nums[i] <= 100
        //nums is sorted in non-decreasing order.
        public int Solution(int[] nums)
        {
            int k = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[k - 1] != nums[i])
                {
                    nums[k] = nums[i];
                    k++;
                }
            }

            return k;
        }
        public void TestSolution()
        {
            Console.WriteLine(Solution([1, 1, 2])); // 2
            Console.WriteLine(Solution([0, 0, 1, 1, 1, 2, 2, 3, 3, 4])); // 5
        }
    }
}
