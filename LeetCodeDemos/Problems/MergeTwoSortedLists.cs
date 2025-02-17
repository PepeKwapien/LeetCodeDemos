namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/merge-two-sorted-lists/description/
    internal class MergeTwoSortedLists : ISolutionClass
    {
        public ListNode Solution(ListNode list1, ListNode list2)
        {
            return MergeTwoLists(list1, list2);
        }

        private ListNode MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }

            (ListNode currentHead, ListNode otherHead) = list1.val < list2.val ? (list1, list2) : (list2, list1);

            currentHead.next = MergeTwoLists(currentHead.next, otherHead);

            return currentHead;
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution(new ListNode([1, 2, 4]), new ListNode([1, 3, 4])));
            Console.WriteLine(Solution(null, null));
            Console.WriteLine(Solution(null, new ListNode([0])));
        }
    }
}
