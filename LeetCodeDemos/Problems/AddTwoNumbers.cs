﻿
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/add-two-numbers/description/

    internal class AddTwoNumbers : ISolutionClass
    {
        public ListNode Solution(ListNode l1, ListNode l2)
        {
            return ConcatNumbers(l1, l2);
        }

        private ListNode ConcatNumbers(ListNode? l1, ListNode? l2, int remainder = 0)
        {
            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + remainder;
            int nextRemainder = sum >= 10 ? 1 : 0;
            int currentValue = sum % 10;
            ListNode nextNode = null;
            if (nextRemainder == 1 || l2?.next != null || l1?.next != null)
            {
                nextNode = ConcatNumbers(l1?.next, l2?.next, nextRemainder);
            }

            return new ListNode(currentValue, nextNode);
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution(new ListNode([2, 4, 3]), new ListNode([5, 6, 4])));
            Console.WriteLine(Solution(new ListNode([0]), new ListNode([0])));
            Console.WriteLine(Solution(new ListNode([9, 9, 9, 9, 9, 9, 9]), new ListNode([9, 9, 9, 9])));
        }
    }
}
