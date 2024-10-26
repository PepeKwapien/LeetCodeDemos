﻿using System.Text.Json;
using System.Text.Json.Nodes;

namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/3sum/description/
    internal class ThreeSum : ISolutionClass
    {
        public static IList<IList<int>> Solution1(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> solutions = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i])
                {
                    continue;
                }
                int goal = -nums[i];
                var adressBook = new Dictionary<int, int>();
                var usedNumbers = new HashSet<int>();

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (usedNumbers.Contains(nums[j]))
                    {
                        continue;
                    }
                    if (adressBook.ContainsKey(nums[j]))
                    {
                        solutions.Add(new List<int>() { nums[i], nums[j], nums[adressBook[nums[j]]] });
                        usedNumbers.Add(nums[j]);
                        usedNumbers.Add(nums[adressBook[nums[j]]]);
                    }
                    else
                    {
                        int lookingFor = goal - nums[j];
                        adressBook[lookingFor] = j;
                    }
                }
            }

            return solutions;
        }

        public static IList<IList<int>> Solution(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> solutions = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i])
                {
                    continue;
                }

                int j = i + 1, k = nums.Length - 1;
                var usedNumbers = new HashSet<int>();

                while (j < k)
                {
                    if (usedNumbers.Contains(nums[j]))
                    {
                        j++;
                    }
                    else if (usedNumbers.Contains(nums[k]))
                    {
                        k--;
                    }
                    else if (nums[j] + nums[i] + nums[k] == 0)
                    {
                        solutions.Add([nums[j], nums[i], nums[k]]);
                        usedNumbers.Add(nums[j]);
                        usedNumbers.Add(nums[k]);
                        j++;
                    }
                    else if (nums[j] + nums[i] + nums[k] > 0)
                    {
                        k--;
                    }
                    else if (nums[j] + nums[i] + nums[k] < 0)
                    {
                        j++;
                    }
                }
            }

            return solutions;
        }

        public static void TestSolution()
        {
            Console.WriteLine(JsonSerializer.Serialize(Solution([-1, 0, 1, 2, -1, -4])));
            Console.WriteLine(JsonSerializer.Serialize(Solution([0, 0, 0, 0])));
            Console.WriteLine(JsonSerializer.Serialize(Solution([0, 0, 0, 0, 0])));
            Console.WriteLine(JsonSerializer.Serialize(Solution([-2, 0, 1, 1, 2])));
            Console.WriteLine(JsonSerializer.Serialize(Solution([3, 0, -2, -1, 1, 2])));
        }
    }
}