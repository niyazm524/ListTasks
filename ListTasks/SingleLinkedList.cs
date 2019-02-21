using System.Text;
using System;
using System.IO;

namespace ListTasks
{
    class Elem
    {
        public string Info { get; set; }
        public Elem Next { get; set; }
    }

    class SingleLinkedList
    {
        public Elem First { get; set; }

        public int Length
        {
            get
            {
                int k = 0;
                var el = First;
                while (el != null)
                {
                    k++;
                    el = el.Next;
                }
                return k;
            }
        }

        public void AddFirst(string x)
        {
            var el = new Elem() { Info = x, Next = First };
            First = el;
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

    class WordSet : SingleLinkedList
    {
        public WordSet(string[] arr)
        {
            foreach (var line in arr)
                AddLast(line);
        }

        public WordSet(WordSet w1, WordSet w2) // Не работает метод override .ToString(), т.к. First после этой оргии равен null
        {
            if (!w1.IsOrdered() || !w2.IsOrdered())
                throw new Exception("Списки не упорядочены");

            var el1 = w1.First;
            var el2 = w2.First;
            var l3 = new SingleLinkedList();

            while (el1 != null && el2 != null)
            {
                if (el1.Info.CompareTo(el2.Info) < 0)
                {
                    l3.AddLast(el1.Info);
                    el1 = el1.Next;
                }
                else
                {
                    l3.AddLast(el2.Info);
                    el2 = el2.Next;
                }
            }
            if (el1 == null)
                while (el2 != null)
                {
                    l3.AddLast(el2.Info);
                    el2 = el2.Next;
                }
            else
                while (el1 != null)
                {
                    l3.AddLast(el1.Info);
                    el1 = el1.Next;
                }
        } 

        public void Out(string fileName)
        {
            File.WriteAllText(fileName, this.ToString());
        }

        public void Insert(string word)
        {

        }

        public void Delete(string word)
        {

        }

        //public WordSet NewWordSetByWordLength(int l)
        //{

        //}

        //public WordSet[] VovelDivide()
        //{

        //}

        public void RemovePalindrome()
        {

        }
    }
}
