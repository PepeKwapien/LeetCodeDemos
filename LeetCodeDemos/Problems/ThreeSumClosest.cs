
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/3sum-closest/description/
    internal class ThreeSumClosest : ISolutionClass
    {
        public int Solution1(int[] nums, int target)
        {
            Array.Sort(nums);

            int solution = 0;
            bool firstIteration = true;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = nums.Length - 1;

                // Break when solution found but on before first iteration
                if (!firstIteration && solution == target)
                {
                    break;
                }

                if (i > 0 && nums[i - 1] == nums[i] && !firstIteration)
                {
                    continue;
                }

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int distance = Math.Abs(sum - target);

                    // Apply solution on first iteration
                    if (distance < Math.Abs(target - solution) || firstIteration)
                    {
                        solution = sum;
                        firstIteration = false;
                    }
                    if (distance == 0)
                    {
                        break;
                    }
                    if (sum < target)
                    {
                        do
                        {
                            j++;
                        }
                        while (j < k && nums[j - 1] == nums[j]);
                    }
                    if (sum > target)
                    {
                        do
                        {
                            k--;
                        }
                        while (j < k && nums[k + 1] == nums[k]);
                    }
                }
            }

            return solution;
        }
        public int Solution(int[] nums, int target)
        {
            Array.Sort(nums);

            int distance = int.MaxValue;
            int solution = 0;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = nums.Length - 1;

                if (i > 0 && nums[i - 1] == nums[i])
                {
                    continue;
                }

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];

                    if (sum > target)
                    {
                        if (distance > sum - target)
                        {
                            solution = sum;
                            distance = sum - target;
                        }
                        do
                        {
                            k--;
                        }
                        while (j < k && nums[k] == nums[k + 1]);
                    }
                    else if (sum < target)
                    {
                        if (distance > target - sum)
                        {
                            solution = sum;
                            distance = target - sum;
                        }
                        do
                        {
                            j++;
                        }
                        while (j < k && nums[j - 1] == nums[j]);

                    }
                    else
                    {
                        return target;
                    }
                }
            }

            return solution;
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution([-1, 2, 1, -4], 1));
            Console.WriteLine(Solution([0, 0, 0], 1));
            Console.WriteLine(Solution([1, 1, 1, 1], 0));
            Console.WriteLine(Solution([-100, -98, -2, -1], -101));
            Console.WriteLine(Solution([2, 3, 8, 9, 10], 16));
        }
    }
}
