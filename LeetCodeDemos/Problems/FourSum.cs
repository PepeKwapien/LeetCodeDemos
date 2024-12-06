using System.Text.Json;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/4sum/description/
    internal class FourSum : ISolutionClass
    {
        public static IList<IList<int>> Solution(int[] nums, int target)
        {
            if (nums.Length < 4)
            {
                return [];
            }

            Array.Sort(nums);
            var solution = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                    {
                        continue;
                    }

                    int l = j + 1, r = nums.Length - 1;

                    long targetSum = (long)target - nums[i] - nums[j];

                    while (l < r)
                    {
                        int sum = nums[l] + nums[r];

                        if (sum == targetSum)
                        {
                            solution.Add([nums[i], nums[j], nums[l], nums[r]]);

                            do
                            {
                                l++;
                            }
                            while (l < r && nums[l - 1] == nums[l]);
                            do
                            {
                                r--;
                            }
                            while (l < r && nums[r + 1] == nums[r]);
                        }

                        if (sum > targetSum)
                        {
                            do
                            {
                                r--;
                            }
                            while (l < r && nums[r + 1] == nums[r]);
                        }
                        else if (sum < targetSum)
                        {
                            do
                            {
                                l++;
                            }
                            while (l < r && nums[l - 1] == nums[l]);
                        }
                    }
                }
            }

            return solution;
        }
        public static void TestSolution()
        {
            //Console.WriteLine(JsonSerializer.Serialize(Solution([1, 0, -1, 0, -2, 2], 0)));
            //Console.WriteLine(JsonSerializer.Serialize(Solution([2, 2, 2, 2, 2], 8)));
            //Console.WriteLine(JsonSerializer.Serialize(Solution([0, 0, 0, 0], 0)));
            //Console.WriteLine(JsonSerializer.Serialize(Solution([1, -2, -5, -4, -3, 3, 3, 5], -11)));
            Console.WriteLine(JsonSerializer.Serialize(Solution([1000000000, 1000000000, 1000000000, 1000000000], -294967296)));
        }
    }
}
