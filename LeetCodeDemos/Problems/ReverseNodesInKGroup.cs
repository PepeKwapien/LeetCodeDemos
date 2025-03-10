
namespace LeetCodeDemos.Problems
{
    // https://leetcode.com/problems/swap-nodes-in-pairs/submissions/1569558336/
    // https://leetcode.com/problems/reverse-nodes-in-k-group/description/
    internal class ReverseNodesInKGroup : ISolutionClass
    {
        public ListNode Solution(ListNode head, int k)
        {
            return ReverseNodesRecurrence(head, [], k)!;
        }

        public ListNode? ReverseNodesRecurrence(ListNode? head, IList<ListNode> list, int k) {
            if(head == null)
            {
                return list.Count == 0 ? null : list[0];
            }

            list.Add(head);
            if(list.Count == k)
            {
                var temp = list.Last().next;

                for(int i = 0; i < k - 1; i++)
                {
                    list[k - 1 - i].next = list[k - i - 2];
                }

                list[0].next = ReverseNodesRecurrence(temp, [], k);

                return list.Last();
            }
            else
            {
                return ReverseNodesRecurrence(head.next, list, k);
            }
        }

        public void TestSolution()
        {
            Console.WriteLine(Solution(new ListNode([1, 2, 3, 4, 5]), 3));
            Console.WriteLine(Solution(new ListNode([1, 2, 3, 4, 5]), 2));
        }
    }
}
