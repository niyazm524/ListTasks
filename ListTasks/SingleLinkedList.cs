using System.Text;
using System;

namespace ListTasks
{
    class SingleLinkedList
    {
        protected Elem First { get; set; }
        protected int count;

        public int Length
        {
            get
            {
                return count;
            }
        }

        public void AddFirst(string x)
        {
            var el = new Elem() { Info = x, Next = First };
            First = el;
            count++;
        }

        public void AddLast(string x)
        {
            var el = First;
            if (el == null)
            {
                AddFirst(x);
                return;
            }
            while (el.Next != null)
                el = el.Next;
            el.Next = new Elem() { Info = x };
            count++;
        }

        public bool IsOrdered()
        {
            var el = First;
            if (el == null || el.Next == null)
                return true;
            while (el.Next != null)
            {
                if (el.Info.CompareTo(el.Next.Info) > 0 )
                    return false;
                el = el.Next;
            }
            return true;
        }

        public override string ToString()
        {
            if (First == null)
                throw new Exception("Але, ебло, ты указатель проебал");
            StringBuilder sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($"{el.Info} ");
                el = el.Next;
            }
            return sb.ToString();
        }
    }

    protected class Elem
    {
        private string Info { get; set; }
        private Elem Next { get; set; }
    }
}
