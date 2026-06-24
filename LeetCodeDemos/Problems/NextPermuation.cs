namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/next-permutation/description/
    internal class NextPermuation : ISolutionClass
    {
        public void Solution(int[] nums)
        {
            int indexuSwitchu = -1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int biggaIndex = -1; // nums <= 100
                for(int j = i+1; j < nums.Length; j++)
                {
                    if (nums[j] > nums[i] && (biggaIndex == -1 || nums[j] <= nums[biggaIndex]))
                    {
                        biggaIndex = j;
                    }
                }

                if (biggaIndex != -1)
                {
                    (nums[biggaIndex], nums[i]) = (nums[i], nums[biggaIndex]);
                    Array.Sort(nums, i + 1, nums.Length - i - 1);
                    indexuSwitchu = i;
                    break;
                }
            }

            if(indexuSwitchu == -1)
            {
                Array.Sort(nums);
            }
        }

        public void TestSolution()
        {
            InnerTestSolution([1, 2, 3]); // 1,3,2
            InnerTestSolution([3, 2, 1]); // 1,2,3
            InnerTestSolution([1, 1, 5]); // 1,5,1
            InnerTestSolution([1, 3, 2]); // 2,1,3
            InnerTestSolution([5, 4, 7, 5, 3, 2]); // 5, 5, 2, 3, 4, 7
            InnerTestSolution([1, 2, 0, 3, 0, 1, 2, 4]); // 1,2,0,3,0,1,4,2
        }

        private void InnerTestSolution(int[] nums)
        {
            Solution(nums);
            Console.WriteLine(String.Join(", ", nums));
        }
    }
}
