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
        static int[] arr = { 1,2,3,4,5};

        static void Main(string[] args)
        {
            PrintArray(arr);

            LeftRotateOnce(arr);
            LeftRotateOnce(arr);
            LeftRotateOnce(arr);
            LeftRotateOnce(arr);
            LeftRotateOnce(arr);            

            //RightRotateOnce(arr);

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        static void LeftRotateOnce(int[] arr)
        {
            int temp = arr[0];
            int i;
            int n = arr.Length;

            for (i = 0; i < n - 1; i++)
                arr[i] = arr[i + 1];

            arr[i] = temp;

            PrintArray(arr);
        }

        static void RightRotateOnce(int[] arr)
        {
            int i;
            int n = arr.Length - 1;
            int temp = arr[n];

            for (i = n; i > 0; i--)
                arr[i] = arr[i - 1];

            arr[i] = temp;

            PrintArray(arr);
        }

        static void PrintArray(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();
        }

    }
}
