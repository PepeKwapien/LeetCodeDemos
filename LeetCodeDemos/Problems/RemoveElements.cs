// https://leetcode.com/problems/remove-element/description/
namespace LeetCodeDemos.Problems
{
    internal class RemoveElements : ISolutionClass
    {
        public int Solution(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var k = 0;
            var i = nums.Length - 1;
            
            
            while(k <= i)
            {
                if (nums[k] != val)
                {
                    k++;
                }

                if (nums[i] == val)
                {
                    i--;
                }

                if (k < i && k < nums.Length && nums[k] == val && i >= 0 && nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                    i--;
                }
            }

            return k;
        }
        public void TestSolution()
        {
            Console.WriteLine(Solution([3, 2, 2, 3], 3)); // 2
            Console.WriteLine(Solution([0, 1, 2, 2, 3, 0, 4, 2], 2)); // 5
            Console.WriteLine(Solution([], 0)); // 0
            Console.WriteLine(Solution([1], 1)); // 0
            Console.WriteLine(Solution([2], 3)); // 1
            Console.WriteLine(Solution([3, 3], 3)); // 0
            Console.WriteLine(Solution([4, 5], 5)); // 1
        }
    }
}
