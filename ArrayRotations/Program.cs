using System;

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

            InitializeArray();
            RightRotateOnce(arr);

            InitializeArray();
            LeftRotateByN(arr, 2);

            InitializeArray();
            LeftRotateByN(arr, 3);

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        private static void InitializeArray()
        {
            arr = new [] { 1, 2, 3, 4, 5, 6 };
        }

        static void LeftRotateOnce(int[] arr)
        {
            Console.WriteLine("Left rotate once: ");
            int temp = arr[0];
            int i;
            int l = arr.Length;

            for (i = 0; i < l - 1; i++)
                arr[i] = arr[i + 1];

            arr[i] = temp;

            PrintArray(arr);
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

            PrintArray(r);
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

            PrintArray(arr);
        }

        static void PrintArray(int[] a)  //Let's just print it on console
        {
            foreach (var i in a)
                Console.Write(i+" ");

            Console.WriteLine(); Console.WriteLine();
        }

    }
}
