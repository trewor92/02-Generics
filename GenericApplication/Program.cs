using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace GenericApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<object> list = new List<object>() { String.Empty,1, "xxxx", null, 2, 3, 4, new TimeSpan(1,0,0),true,ConsoleColor.Blue };
            Console.WriteLine(list.ConvertToString());
            //string str = "1:0:0,2:0:0,3:0:0,,,,,4:0:0";
            //string str = "1,2,3,,,,,4";

            //List<int> a = (List<int>)str.ConvertToList<int>();
            //a = a;
            //Console.WriteLine(a.ConvertToString());
            //Tuple<int, string, bool>[] tupl = new Tuple<int, string, bool>[] { new Tuple<int, string, bool>(9, "Я", true), new Tuple<int, string, bool>(-1, "Ты", false), new Tuple<int, string, bool>(7, "Он", true) };
            //tupl.SortTupleArray<int, string, bool>(1,true);
            //foreach (Tuple<int, string, bool> t in tupl)
            //{
            //Console.WriteLine(t.Item1 + "   "+ t.Item2 +"   "+ t.Item3);

            //}

            //Singleton<List<string>>.Instance.Add("a");
            //Singleton<List<int>>.Instance.Add(1);
            //Singleton<List<string>>.Instance.Add("b");
            //Singleton<List<int>>.Instance.Add(2);
            //foreach (string str in  Singleton<List<string>>.Instance)
            //{
            //Console.WriteLine(str + "   ");

            //}

            //foreach (int i in Singleton<List<int>>.Instance)
            //{
            //Console.WriteLine(i + "   ");

            //}

            //int[] array = new int[] { 1, 2, 3, 4, 5 };
            //foreach (int i in array)
            //{
            //Console.WriteLine(i + "   ");

            //}
            //array.SwapArrayElements<int>(2, 3);
            //foreach (int i in array)
            //{
            //   Console.WriteLine(i + "   ");

            //}

            //Predicate<int>[] predicates = new Predicate<int>[] {i=>i>0,i=>i<5 };
            //Predicate<int> c = FunctionExtentions.CombinePredicates<int>(predicates);
            //Console.WriteLine(predicates[0](6) + "   ");
            //Console.WriteLine(predicates[1](6) + "   ");
            //Console.WriteLine(c(6) + "   ");
            //Console.WriteLine(c(1) + "   ");
            //Console.WriteLine(predicates[0](-1) + "   ");
            //Console.WriteLine(predicates[1](-1) + "   ");
            //Console.WriteLine(c(-1) + "   ");


            //Func<string> f1 = () => (new System.Net.WebClient()).DownloadString("http://www.google.com/");
            //Func<string> f1 = () => (new System.Net.WebClient()).DownloadString("http://www.oogle.c/");
            //string data = f1.TimeoutSafeInvoke();
            //data = data;
            Console.ReadLine();
        }
    }
}
