using System;
using System.Linq;

namespace ArrayRotations
{
    /// <summary>
    /// TODO: I'm going to develop some primitive array rotation algorithms
    /// Not done yet, please ignore
    /// 
    /// Serge Klokov 2019
    /// 
    /// Loosly based on:
    /// https://hackernoon.com/fun-with-array-rotations-add4a335d79a
    /// </summary>
    class Program
    {
        //static int[] arr = { 1, 2, 3, 4, 5 };
        static int[] arr = { 1, 2, 3, 4, 5, 6 };

        static void Main(string[] args)
        {
            Console.WriteLine("Initial array: ");
            PrintArray(arr);

            LeftRotateOnce(arr);  // uncomment to test
            //InitializeArray(); LeftRotateByNCyclical(arr, 1);

            InitializeArray(); LeftRotateByN(arr, 2);
            //InitializeArray(); LeftRotateByNCyclical(arr, 2);

            InitializeArray(); LeftRotateByN(arr, 3);
            //InitializeArray(); LeftRotateByNCyclical(arr, 3);

            //InitializeArray(); LeftRotateByNCyclical(arr, 6);  // it should be no rotation, right? 
            //InitializeArray(); LeftRotateByNCyclical(arr, 7);
            //InitializeArray(); LeftRotateByNCyclical(arr, 8);

            InitializeArray(); RightRotateOnce(arr);

            int[] a = { 1, 2, 3 };
            int[] rotate = { 1,2,3,4 };
            GetMaxElementIndexes(rotate, a);  // expected result [1,0,2,1]

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        private static void InitializeArray()
        {
            arr = new [] { 1, 2, 3, 4, 5, 6 };
        }

        static void LeftRotateOnce(int[] a)
        {
            Console.WriteLine("Left rotate once: ");
            int temp = a[0];
            int i;
            int l = a.Length;

            for (i = 0; i < l - 1; i++)
                a[i] = a[i + 1];

            a[i] = temp;

            PrintArray(a); Console.WriteLine();
        }

        static void RightRotateOnce(int[] r)
        {
            Console.WriteLine("Right rotate once: ");
            int i;
            int l = r.Length - 1;
            int temp = r[l];

            for (i = l; i > 0; i--)
                r[i] = r[i - 1];

            r[i] = temp;

            PrintArray(r); Console.WriteLine();
        }

        static void LeftRotateByN(int[] a, int n)
        {
            Console.WriteLine($"Left rotate by {n}: ");

            int l = a.Length;

            if (n >= l - 1)
                throw new Exception("Can't rotate more than array length");

            int[] temp = new int[n]; // save first few
            for (int i = 0; i < n; i++)
                temp[i] = a[i];

            for (int i = 0; i < l - n; i++)  // shift 
                a[i] = a[i + n];

            for (int i = 0; i < n; i++)  // add saved elemenents to the end
                a[l - n + i] = temp[i];

            PrintArray(a); Console.WriteLine();
        }

        static void LeftRotateByNCyclical(int[] a, int n, bool toPrint = true)
        {
            if (toPrint)
                Console.WriteLine($"Left cyclical rotate by {n}: ");

            int l = a.Length;

            if (n >= l - 1)
                n = n % l ;

            int[] temp = new int[n]; // save first few
            for (int i = 0; i < n; i++)
                temp[i] = a[i];

            for (int i = 0; i < l - n; i++)  // shift 
                a[i] = a[i + n];

            for (int i = 0; i < n; i++)  // add saved elemenents to the end
                a[l - n + i] = temp[i];

            if (toPrint)
            {
                PrintArray(a);
                Console.WriteLine();
            }
         }

        /// <summary>
        /// This was hackerrank problem, see attached image "GetMaxElementIndexes.JPG"
        /// 
        /// Some links used: 
        /// https://stackoverflow.com/questions/13755007/c-sharp-find-highest-array-value-and-index
        /// https://stackoverflow.com/questions/5678216/all-possible-array-initialization-syntaxes
        /// </summary>
        private static void GetMaxElementIndexes(int[] rotate, int[] a)
        {
            int[] indices = new int[rotate.Length];
            int[] copy = new int[a.Length];

            for (int i = 0; i < rotate.Length; i++)
            {
                a.CopyTo(copy, 0); // let's copy array everytime 

                LeftRotateByNCyclical(copy, rotate[i], false);

                int maxValue = copy.Max();  // need LINQ for this 
                int maxIndex = Array.IndexOf(copy, maxValue);
                indices[i] = maxIndex;
            }

            Console.Write("Final array of indicies: ");
            PrintArray(indices);
        }

        static void PrintArray(int[] a)  //Let's just print it on console
        {
            foreach (var i in a)
                Console.Write(i+" ");

            Console.WriteLine(); 
        }

    }
}
