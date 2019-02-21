using System;
using System.IO;

namespace ListTasks
{
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
                    l3.AddLast(el1.Info); // n^2 time, would be better memorizing last element
                    el1 = el1.Next;
                }
                else
                {
                    l3.AddLast(el2.Info); // same here
                    el2 = el2.Next;
                }
            }
            if (el1 == null) // can be folded into Elem e = el1 == null ? el2 : el1; while(e != null) {...}
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
