using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace GenericApplication {

    public static class ListConverter {

        private static char ListSeparator = ',';  // Separator used to separate values in string

        /// <summary>
        ///   Converts a source list into a string representation
        /// </summary>
        /// <typeparam name="T">type  of list items</typeparam>
        /// <param name="list">source list</param>
        /// <returns>
        ///   Returns the string representation of a list 
        /// </returns>
        /// <example>
        ///   { 1,2,3,4,5 } => "1,2,3,4,5"
        ///   { '1','2','3','4','5'} => "1,2,3,4,5"
        ///   { true, false } => "True,False"
        ///   { ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Cyan } => "Black,Blue,Cyan"
        ///   { new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 30) } => "01:00:00,00:00:30",
        ///   If list == null => return "", if element in list == null dont write it(element n-1, element n+1)
        /// </example>
        /// 

        
        public static string ConvertToString<T>(this IEnumerable<T> list)  // метод расширения
        {
            if (list == null)
                return "";

            StringBuilder sb = new StringBuilder();
            foreach (T l in list)
            {
                sb.Append((l != null ? ListSeparator + l.ToString() : ""));
            }

            sb.Remove(0, 1);

            return sb.ToString();
        }

        /// <summary>
        ///   Converts the string respresentation to the list of items
        /// </summary>
        /// <typeparam name="T">required-обязательный type of output items</typeparam>
        /// <param name="list">string representation of the list</param>
        /// <returns>
        ///   Returns the list of items from specified string
        /// </returns>
        /// <example>
        ///  "1,2,3,4,5" for int => {1,2,3,4,5}
        ///  "1,2,3,4,5" for char => {'1','2','3','4','5'}
        ///  "1,2,3,4,5" for string => {"1","2","3","4","5"}
        ///  "true,false" for bool => { true, false }
        ///  "Black,Blue,Cyan" for ConsoleColor => { ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Cyan }
        ///  "1:00:00,0:00:30" for TimeSpan =>  { new TimeSpan(1, 0, 0), new TimeSpan(0, 0, 30) },
        ///  If list is "" return collection=null
        ///  </example>
        
        public static IEnumerable<T> ConvertToList<T>(this string list) {
            if (list == "")
                return null;

            string[] items = list.Split(new char[] { ListSeparator }, StringSplitOptions.RemoveEmptyEntries);
            
            List<T> collection=new List<T>();

            TypeConverter typeCon = TypeDescriptor.GetConverter(typeof(T));
            foreach (string item in items)
            {
                collection.Add((T)typeCon.ConvertFromString(item));
                //collection.Add((T)Convert.ChangeType(item, typeof(T))); // рефлексия
            }

            return collection;
            
            // TODO : Implement ConvertToList<T>
            // HINT : Use TypeConverter.ConvertFromString method to parse string value TypeConverter.ConvertFromString()
            //throw new NotImplementedException();
        }

    }
    public static class ArrayExtentions
    {

        /// <summary>
        ///   Swaps the one element of source array with another
        /// </summary>
        /// <typeparam name="T">required type of</typeparam>
        /// <param name="array">source array</param>
        /// <param name="index1">first index</param>
        /// <param name="index2">second index</param>
        public static void SwapArrayElements<T>(this T[] array, int index1, int index2)
        {
            if (array == null)
                throw new NullReferenceException();
            if ((index1 < 0 || index1 > array.Length - 1) || (index2 < 0 || index2 > array.Length - 1))
                throw new IndexOutOfRangeException();
            if (index1 == index2)
                return;

            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;

            // TODO : Implement SwapArrayElements<T>
            // throw new NotImplementedException();
        }

        /// <summary>
        ///   Sorts the tuple array by specified column in ascending or descending order
        /// </summary>
        /// <param name="array">source array</param>
        /// <param name="sortedColumn">index of column</param>
        /// <param name="ascending">true if ascending order required; otherwise false</param>
        /// <example>
        ///   source array : 
        ///   { 
        ///     { 1, "a", false },
        ///     { 3, "b", false },
        ///     { 2, "c", true  }
        ///   }
        ///   result of SortTupleArray(array, 0, true) is sort rows by first column in a ascending order: 
        ///   { 
        ///     { 1, "a", false },
        ///     { 2, "c", true  },
        ///     { 3, "b", false }
        ///   }
        ///   result of SortTupleArray(array, 1, false) is sort rows by second column in a descending order: 
        ///   {
        ///     { 2, "c", true  },
        ///     { 3, "b", false }
        ///     { 1, "a", false },
        ///   }
        /// </example>
        // Tuple-кортеж
        public static void SortTupleArray<T1, T2, T3>(this Tuple<T1, T2, T3>[] array, int sortedColumn, bool ascending) where T1 : System.IComparable<T1>
                                                                                                                        where T2 : System.IComparable<T2>
                                                                                                                        where T3 : System.IComparable<T3>
        {
            Tuple<T1, T2, T3>[] result = array;

            switch (sortedColumn)
            {

                case 0:
                    result = ascending ? array.OrderBy(x => x.Item1).ToArray() : array.OrderByDescending(x => x.Item1).ToArray();

                    break;
                case 1:
                    result = ascending ? array.OrderBy(x => x.Item2).ToArray() : array.OrderByDescending(x => x.Item2).ToArray();

                    break;
                case 2:
                    result = ascending ? array.OrderBy(x => x.Item3).ToArray() : array.OrderByDescending(x => x.Item3).ToArray();

                    break;
                default:
                    throw new IndexOutOfRangeException();



                    // TODO :SortTupleArray<T1, T2, T3>
                    // HINT : Add required constraints to generic types
            }
            // поскольку нельзы вызвать ref для метода расширения
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = result[i];

            }
        }
    }
    /// <summary>
    ///   Generic singleton class
    /// </summary>
    /// <example>
    ///   This code should return the same MyService object every time:
    ///   MyService singleton = Singleton<MyService>.Instance;
    /// </example>
    public static class Singleton<T> where T : class, new() {
        // TODO : Implement generic singleton class 
        
    public static T Instance { get { return InternalContainer.Instance; }}
        
    private class InternalContainer
    {
       
        public static readonly T Instance;
                  
        static InternalContainer() // статический конструктор
        {
            Instance = new T();
        }
    }

}



	public static class FunctionExtentions {
		/// <summary>
		///   Tries to invoke-вызвать the specified function up to 3 times if the result is unavailable 
		/// </summary>
		/// <param name="function">specified function</param>
		/// <returns>
		///   Returns the result of specified function, if WebException occurs-случается duaring request then exception should be logged into trace 
		///   and the new request should be started (up to 3 times).
		/// </returns>
		/// <example>
		///   Sometimes if network is unstable it is required-обязательно to try several-несколько request to get data:
		///   
		///   Func<string> f1 = ()=>(new System.Net.WebClient()).DownloadString("http://www.google.com/");
		///   string data = f1.TimeoutSafeInvoke();
		///   
		///   If the first attemp to download data is failed by WebException then exception should be logged to trace log and the second attempt-попытка should be started.
		///   The second attemp has the same workflow-сценарий.
		///   If the third attemp fails then this exception should be rethrow-выбрасывать to the application.
		/// </example>
		public static T TimeoutSafeInvoke<T>(this Func<T> function) {
            int maxAttemptCount= 3;
            List<Exception> exceptions = new List<Exception>();
            Exception lastException=new Exception();

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {   
                try
                {  
                    return function();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    lastException = ex;    
                }
            }

            throw lastException;

           
            // TODO : Implement TimeoutSafeInvoke<T>
            //throw new NotImplementedException();
        }


        /// <summary>
        ///   Combines several predicates-утверждения using logical AND operator 
        /// </summary>
        /// <param name="predicates">array of predicates</param>
        /// <returns>
        ///   Returns a new predicate that combine the specified predicated-указанный using AND operator
        /// </returns>
        /// <example>
        ///   var result = CombinePredicates(new Predicate<string>[] {
        ///            x=> !string.IsNullOrEmpty(x),
        ///            x=> x.StartsWith("START"),
        ///            x=> x.EndsWith("END"),
        ///            x=> x.Contains("#")
        ///        })
        ///   should return the predicate that identical to 
        ///   x=> (!string.IsNullOrEmpty(x)) && x.StartsWith("START") && x.EndsWith("END") && x.Contains("#")
        ///
        ///   The following example should create predicate that returns true if int value between -10 and 10:
        ///   var result = CombinePredicates(new Predicate<int>[] {
        ///            x=> x>-10,
        ///            x=> x<10
        ///       })
        /// </example>
        public static Predicate<T> CombinePredicates<T>(Predicate<T>[] predicates) {
            Predicate<T> result = predicates[0];
            for (int i=1;i<predicates.Length; i++)
            {
                result = result.And<T>(predicates[i]);
            }
            return result;
			// TODO : Implement CombinePredicates<T>
			//throw new NotImplementedException();
		}

        private static Predicate<T> And<T>(this Predicate<T> left, Predicate<T> right)
        {
            return a => left(a) && right(a);
        }

	}


}
