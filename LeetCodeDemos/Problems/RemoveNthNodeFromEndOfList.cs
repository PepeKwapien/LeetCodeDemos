
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
    internal class RemoveNthNodeFromEndOfList : ISolutionClass
    {
        public static ListNode Solution(ListNode head, int n)
        {
            return RemoveNthFromEnd(head, n, out int currentIndexFromEnd);
        }

        private static ListNode RemoveNthFromEnd(ListNode head, int n, out int currentIndexFromEnd)
        {
            int childIndexFromEnd;
            ListNode next = null;

            if (head.next == null)
            {
                currentIndexFromEnd = 1;
            }
            else
            {
                next = RemoveNthFromEnd(head.next, n, out childIndexFromEnd);
                currentIndexFromEnd = childIndexFromEnd + 1;
            }

            head.next = next;

            if(currentIndexFromEnd == n)
            {
                return head.next;
            }

            return head;
        }

        public static void TestSolution()
        {
            Console.WriteLine(Solution(new ListNode([1, 2, 3, 4, 5]), 2));
            Console.WriteLine(Solution(new ListNode([1]), 1));
            Console.WriteLine(Solution(new ListNode([1, 2]), 1));
        }
    }
}
