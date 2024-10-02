
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/median-of-two-sorted-arrays/description/
    internal class MedianOfTwoSortedArrays : TestSolution
    {
        public static double FirstSolution(int[] nums1, int[] nums2)
        {
            int totalLength = nums1.Length + nums2.Length;
            int firstMedianIndex = (int)Math.Ceiling(((double)totalLength / 2)) - 1;
            int secondMedianIndex = totalLength / 2;

            Console.WriteLine($"First index: {firstMedianIndex}, Second index: {secondMedianIndex}");

            int firstMedianPart = 0;
            int secondMedianPart = 0;

            int num1Index = 0;
            int num2Index = 0;

            for (int i = 0; i < totalLength; i++)
            {
                int currentValue = 0;
                if (num1Index >= nums1.Length)
                {
                    currentValue = nums2[num2Index];
                    num2Index++;
                }
                else if (num2Index >= nums2.Length)
                {
                    currentValue = nums1[num1Index];
                    num1Index++;
                }
                else if (nums1[num1Index] <= nums2[num2Index])
                {
                    currentValue = nums1[num1Index];
                    num1Index++;
                }
                else if (nums2[num2Index] < nums1[num1Index])
                {
                    currentValue = nums2[num2Index];
                    num2Index++;
                }

                if (i == firstMedianIndex)
                {
                    firstMedianPart = currentValue;
                }
                if (i == secondMedianIndex)
                {
                    secondMedianPart = currentValue;
                    break;
                }
            }

            Console.WriteLine($"First part: {firstMedianPart}, Second part: {secondMedianPart}");


            return ((double)(firstMedianPart! + (double)secondMedianPart) / 2);
        }

        public static double SolutionWithBinarySearch(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return SolutionWithBinarySearch(nums2, nums1);
            }

            int totalLength = nums1.Length + nums2.Length;
            int lengthOfLowerHalf = totalLength / 2;

            // indexes
            int leftNums1 = 0;
            int rightNums1 = nums1.Length - 1;

            while (true)
            {
                // index of pivot, im looking for pivots to determine bound of lower array left to the median
                int pivotNums1 = (int)Math.Floor((leftNums1 + rightNums1) / 2.0);
                int pivotNums2 = lengthOfLowerHalf - pivotNums1 - 2; // -2 because working on lengths

                int left1 = int.MinValue, left2 = int.MinValue, right1 = int.MaxValue, right2 = int.MaxValue;

                if (pivotNums1 >= 0)
                {
                    left1 = nums1[pivotNums1];
                }
                if (pivotNums2 >= 0)
                {
                    left2 = nums2[pivotNums2];
                }
                if (pivotNums1 + 1 < nums1.Length)
                {
                    right1 = nums1[pivotNums1 + 1];
                }
                if (pivotNums2 + 1 < nums2.Length)
                {
                    right2 = nums2[pivotNums2 + 1];
                }

                if (left1 <= right2 && left2 <= right1)
                {
                    if (totalLength % 2 == 0)
                    {
                        return (double)(Math.Max(left1, left2) + Math.Min(right1, right2)) / 2;
                    }
                    else
                    {
                        return Math.Min(right1, right2);
                    }
                }
                else if (left1 > right2)
                {
                    rightNums1 = pivotNums1 - 1;
                }
                else
                {
                    leftNums1 = pivotNums1 + 1;
                }
            }

        } // end of FindMedianSortedArraysBinarySearch

        public void TestSolution()
        {
            Console.WriteLine(FirstSolution([1, 3], [2]));
            Console.WriteLine(SolutionWithBinarySearch([1, 3], [2]));
            Console.WriteLine(FirstSolution([1, 2], [3, 4]));
            Console.WriteLine(SolutionWithBinarySearch([1,2], [3,4]));
        }
    }
}
