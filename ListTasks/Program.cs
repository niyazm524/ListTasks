using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTasks
{
    class Program
    {
        //Вариант 2
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("Words.txt");
            var lst1 = new WordSet(words);
            var lst2 = new WordSet(words);
            Console.WriteLine(new WordSet(lst1, lst2));
            Console.ReadKey();
        }
    }
}
 