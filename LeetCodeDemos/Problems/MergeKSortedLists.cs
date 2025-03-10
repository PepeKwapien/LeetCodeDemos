
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/merge-k-sorted-lists/description/
    internal class MergeKSortedLists : ISolutionClass
    {
        public ListNode Solution(ListNode[] lists)
        {
            return Merge(null, lists);
        }

        private ListNode Merge(ListNode head, ListNode[] lists)
        {
            int minIndex = FindMin(lists);
            ListNode result = null;

            if (minIndex != -1)
            {
                result = lists[minIndex];
                if (head != null)
                {
                    head.next = result;
                }

                lists[minIndex] = lists[minIndex].next;
                Merge(result, lists);
            }

            return result;
        }

        private int FindMin(ListNode[] lists)
        {
            int index = -1;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    if (index == -1)
                    {
                        index = i;
                    }
                    else if (lists[i].val < lists[index].val)
                    {
                        index = i;
                    }
                }
            }

            return index;
        }
        public void TestSolution()
        {
            Console.WriteLine(Solution([new ListNode([1, 4, 5]), new ListNode([1, 3, 4]), new ListNode([2, 6])]));
            Console.WriteLine(Solution([]));
            Console.WriteLine(Solution([new ListNode([])]));
        }
    }
}
