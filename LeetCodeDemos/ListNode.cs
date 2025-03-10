using System.Text;

namespace LeetCodeDemos
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(int[] list, int index = 0)
        {
            if (index < list.Length)
            {
                val = list[index];
            }


            if (index + 1 < list.Length)
            {
                next = new ListNode(list, ++index);
            }
            else
            {
                next = null;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"[{val}");

            var next = this.next;

            while (next != null)
            {
                str.Append($", {next.val}");
                next = next.next;
            }

            str.Append("]");

            return str.ToString();
        }
    }
}
