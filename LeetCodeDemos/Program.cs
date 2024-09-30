using System.Text;

namespace LeetCodeDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ContainerWithMostWater([1, 8, 6, 2, 5, 4, 8, 3, 7]));
            Console.WriteLine(ContainerWithMostWater([1, 1]));
            Console.WriteLine(ContainerWithMostWater([1, 1, 1, 2, 1]));
            Console.WriteLine(ContainerWithMostWater([2, 9, 8, 1, 2]));
        }

        public static int[] TwoSum(int[] nums, int target)
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
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }
 
        public static ListNode AddTwoNumbersAsLists(ListNode l1, ListNode l2)
        {
            return ConcatNumbers(l1, l2);
        }

        private static ListNode ConcatNumbers(ListNode? l1, ListNode? l2, int remainder = 0)
        {
            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + remainder;
            int nextRemainder = sum >= 10 ? 1 : 0;
            int xd = sum % 10;
            ListNode nextNode = null;
            if (nextRemainder == 1 || l2?.next != null || l1?.next != null)
            {
                nextNode = ConcatNumbers(l1?.next, l2?.next, nextRemainder);
            }

            return new ListNode(xd, nextNode);
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int answer = 0;

            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> nonRepeatingCharacters = new HashSet<char>(new char[] { s[i] });

                for (int j = i + 1; j < s.Length; j++)
                {
                    if (nonRepeatingCharacters.Contains(s[j]))
                    {
                        break;
                    }

                    nonRepeatingCharacters.Add(s[j]);
                }

                if (nonRepeatingCharacters.Count > answer)
                {
                    answer = nonRepeatingCharacters.Count;
                }
            }

            return answer;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
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

        public static double FindMedianSortedArraysBinarySearch(int[] nums1, int[] nums2)
        {
            if(nums1.Length > nums2.Length)
            {
                return FindMedianSortedArraysBinarySearch(nums2, nums1);
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

                if(pivotNums1 >= 0)
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
                        return (double)(Math.Max(left1, left2) + Math.Min(right1, right2))/2;
                    }
                    else
                    {
                        return Math.Min(right1, right2);
                    }
                }
                else if(left1 > right2)
                {
                    rightNums1 = pivotNums1 - 1;
                }
                else
                {
                    leftNums1 = pivotNums1 + 1;
                }
            }
            
        } // end of FindMedianSortedArraysBinarySearch

        public static string LongestPalindrome(string s)
        {
            /**
             * 
             * Console.WriteLine(LongestPalindrome("babad"));
            Console.WriteLine(LongestPalindrome("cbbd"));
            Console.WriteLine(LongestPalindrome("a"));
            Console.WriteLine(LongestPalindrome("aacabdkacaa"));
            Console.WriteLine(LongestPalindrome("babaddtattarrattatddetartrateedredividerb"));
            Console.WriteLine(LongestPalindrome("kobylamamalybok"));
             * 
             */

            string output = "";

            for (int i = 0; i < s.Length; i++)
            {
                string centerPali = ExpandPalindrome(s, i, false);
                string betweenPali = ExpandPalindrome(s, i, true);
                string longerPali = centerPali.Length < betweenPali.Length ? betweenPali : centerPali;
                if(longerPali.Length > output.Length)
                {
                    output = longerPali;
                }
            }

            return output;
        }

        private static string ExpandPalindrome(string s, int index, bool isIndexBetweenCharacters) {
            int left = index;
            int right = isIndexBetweenCharacters ? index + 1 : index;
            StringBuilder stringBuilder = new StringBuilder();

            if (!isIndexBetweenCharacters)
            {
                stringBuilder.Append(s[left]);
                left--;
                right++;
            }

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                stringBuilder.Append(s[right]);
                stringBuilder.Insert(0, s[left]);
                left--;
                right++;
            }

            return stringBuilder.ToString();
        }

        public static string ZigzagConversion(string s, int numRows)
        {
            /**
             * Console.WriteLine(ZigzagConversion("PAYPALISHIRING", 2));
            Console.WriteLine(ZigzagConversion("PAYPALISHIRING", 3));
            Console.WriteLine(ZigzagConversion("PAYPALISHIRING", 4));
            Console.WriteLine(ZigzagConversion("PAYPALISHIRING", 5));
            Console.WriteLine(ZigzagConversion("A", 1));
            Console.WriteLine(ZigzagConversion("ABC", 1));
             */

            StringBuilder stringBuilder = new StringBuilder();

            for(int i = 0; i < numRows; i++)
            {
                int distanceBetweenColumns = Math.Max(numRows * 2 - 2, 1);
                int distanceOnDiagonal = Math.Max(distanceBetweenColumns - i * 2, 0);
                int currentIndex = i;

                while(currentIndex < s.Length)
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

        public static int ReverseInteger(int x)
        {
            /**
             *  Console.WriteLine(ReverseInteger(123));
            Console.WriteLine(ReverseInteger(-123));
            Console.WriteLine(ReverseInteger(120));
            Console.WriteLine(ReverseInteger(1534236469));
             */
            long result = 0;
            long moduloDivider = 10;

            do
            {
                long currentPartOfNumber = x % moduloDivider;
                long currentSum = currentPartOfNumber / (moduloDivider/10);
                result *= 10;
                result += currentSum;
                moduloDivider *= 10;
            }
            while (x % (moduloDivider / 10) != x);

            if (result > int.MaxValue || result < int.MinValue)
            {
                result = 0;
            }

            return (int)result;
        }

        public static int StringToIntegerAtoi(string s)
        {
            /**
             * Console.WriteLine(StringToIntegerAtoi("42"));
            Console.WriteLine(StringToIntegerAtoi("   -042"));
            Console.WriteLine(StringToIntegerAtoi("1337c0d3"));
            Console.WriteLine(StringToIntegerAtoi("0-1"));
            Console.WriteLine(StringToIntegerAtoi("words and 987"));
             */
            s = s.Trim();
            int sign = 1;
            double result = 0;
            int index = 0;

            if (s.Length > 0 && !Char.IsNumber(s[0]))
            {
                if (s[0] == '+')
                {
                    sign = 1;
                } else if (s[0] == '-')
                {
                    sign = -1;
                } else
                {
                    return 0;
                }

                index++;
            }

            for(int i = index; i < s.Length; i++)
            {
                if (!Char.IsDigit(s[i]))
                {
                    break;
                }

                result *= 10;
                result += Int32.Parse(s[i].ToString())*sign;
            }


            if(result > int.MaxValue)
            {
                result = int.MaxValue;
            }
            else if(result < int.MinValue)
            {
                result = int.MinValue;
            }

            return (int)result;
        }

        public static bool IsIntegerPalindrome(int x)
        {
            /**
             * Console.WriteLine(IsIntegerPalindrome(121));
            Console.WriteLine(IsIntegerPalindrome(-121));
            Console.WriteLine(IsIntegerPalindrome(10));
            Console.WriteLine(IsIntegerPalindrome(1234567899));
             */
            if (x < 0)
            {
                return false;
            }

            long revertedNumber = 0;
            long moduloDivider = 10;

            do
            {
                long currentDigit = x % moduloDivider;
                long currentSum = currentDigit / (moduloDivider / 10);
                revertedNumber *= 10;
                revertedNumber += currentSum;
                moduloDivider *= 10;
            }
            while (x % (moduloDivider / 10) != x);

            return x - revertedNumber == 0;
        }

        public static bool RegularExpressionMatchingStartAndDot(string s, string p)
        {
            /**
             * Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "abc"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a.c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a."));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a.."));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("aaa", "baa"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("a", "aa"));
            Console.WriteLine("-------------------------------\nBIG BOY EXAMPLES\n-------------------------------");
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", "a.*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*b"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("aab", "a*b"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("a", "ab*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("a", "ab*c"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("ba", "a*.*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("b", "a*b*c*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("abc", ".*b.*"));
                        Console.WriteLine("-------------------------------\nFailing\n-------------------------------");
                        Console.WriteLine(RegularExpressionMatchingStartAndDot("ba", ".*a*a"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("bbab", "b*a*"));
            Console.WriteLine(RegularExpressionMatchingStartAndDot("aaaaaaaaaaaaaaaaaaab", "a*a*a*a*a*a*a*a*a*a*"));
             */
            _regularExpressionMAtchingStartAndDotResults = [];
            return RegularExpressionRecursion(s, p, 0, 0);
        }

        private static Dictionary<string, bool> _regularExpressionMAtchingStartAndDotResults = [];

        private static bool RegularExpressionRecursion(string s, string p, int indexS, int indexP)
        {
            if(indexP >= p.Length)
            {
                return false;
            }

            var createResultsKey = (int indexS, int indexP) => $"s{indexS}p{indexP}";
            var currentKey = createResultsKey(indexS, indexP);

            if (_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey))
            {
                return _regularExpressionMAtchingStartAndDotResults[currentKey];
            }


            int nextIndexS = indexS;
            int nextIndexP = indexP;


            // we are dealing with * group in pattern
            if(indexP +1 < p.Length && p[indexP +1] == '*')
            {
                // word ended, the only way this * group is valid is by it being a 0 occurrence
                if(indexS == s.Length)
                {
                    nextIndexP += 2;
                }
                else
                {
                    // symbol not matching, treat * group as an empty group
                    if (s[indexS] != p[indexP] && p[indexP] != '.')
                    {
                        nextIndexP += 2;
                    }
                    else
                    {
                        // check if moving to next symbol and not moving away from gorup is valid
                        bool result = RegularExpressionRecursion(s, p, indexS + 1, indexP);
                        currentKey = createResultsKey(indexS + 1, indexP);
                        if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);

                        // in case of fail, check if moving from group is valid
                        if (!result)
                        {
                            result = RegularExpressionRecursion(s ,p, indexS + 1, indexP + 2);
                            currentKey = createResultsKey(indexS + 1, indexP + 2);
                            if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);
                        }

                        // although the symbol matched, maybe the group should be treated as empty
                        if (!result)
                        {
                            result = RegularExpressionRecursion(s, p, indexS, indexP + 2);
                            currentKey = createResultsKey(indexS, indexP + 2);
                            if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);
                        }

                        return result;
                    }
                }
            }
            // we are not dealing with * group in pattern
            else
            {
                // s ended and pattern expects a character
                if (indexS == s.Length)
                {
                    return false;
                }
                // match character or wildcard
                if (s[indexS] == p[indexP] || p[indexP] == '.')
                {
                    nextIndexP++;
                    nextIndexS++;
                }
                else
                {
                    return false;
                }

            }

            // not done with analyzing pattern
            if (nextIndexP < p.Length)
            {
                bool result = RegularExpressionRecursion(s, p, nextIndexS, nextIndexP);
                currentKey = createResultsKey(nextIndexS, nextIndexP);
                if (!_regularExpressionMAtchingStartAndDotResults.ContainsKey(currentKey)) _regularExpressionMAtchingStartAndDotResults.Add(currentKey, result);
                return result;
            }
            // done with pattern but not done with word
            else if(nextIndexS < s.Length)
            {
                return false;
            }
            // done with pattern and word
            else
            {
                return true;
            }

        }

        public static int ContainerWithMostWater(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int result = 0;

            while(left < right)
            {
                int currentField = (right - left) * Math.Min(height[left], height[right]);
                if(currentField > result)
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
    } // end of class Program
}
