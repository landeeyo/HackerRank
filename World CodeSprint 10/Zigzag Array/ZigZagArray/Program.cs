using System;

namespace ZigZagArray
{
    internal class Program
    {
        private static bool IsZigZag(int[] a)
        {
            if (a.Length == 0 || a.Length == 1)
                return false;
            if (a.Length == 2)
                return true;

            for (int i = 0; i < a.Length - 2; i++)
            {
                if ((a[i] < a[i + 1] && a[i + 1] < a[i + 2]) || (a[i] > a[i + 1] && a[i + 1] > a[i + 2]))
                {
                    return false;
                }
            }
            return true;
        }

        //private static int FindNumberOfRemovals(int[] a)
        //{
        //    for (int i = 0; i < a.Length - 2; i++)
        //    {
        //        if ((a[i] < a[i + 1] && a[i + 1] < a[i + 2]) || (a[i] > a[i + 1] && a[i + 1] > a[i + 2]))
        //        {
        //            var newArray = new int[a.Length - 1];
        //            int k = 0;
        //            for (int j = 0; j < a.Length; j++)
        //            {
        //                if (j != i + 2)
        //                {
        //                    newArray[k] = a[j];
        //                    k++;
        //                }
        //            }
        //            if (IsZigZag(newArray))
        //            {
        //                return 1;
        //            }
        //            else
        //            {
        //                return 1 + FindNumberOfRemovals(newArray);
        //            }
        //        }
        //    }
        //    return 0;
        //}

        private static int FindNumberOfRemovals(int[] a)
        {
            bool ascending = a[0] < a[1];
            var numberOfRemovals = 0;
            for (int i = 1; i < a.Length - 1; i++)
            {
                if (a[i] < a[i + 1] && ascending)
                {
                    numberOfRemovals++;
                }
                if (a[i] > a[i + 1] && !ascending)
                {
                    numberOfRemovals++;
                }
                ascending = a[i] < a[i + 1];
            }
            return numberOfRemovals;
        }

        private static int minimumDeletions(int[] a)
        {
            if (IsZigZag(a))
            {
                return 0;
            }
            return FindNumberOfRemovals(a.Clone() as int[]);
        }

        private static void Main(String[] args)
        {
            var line1 = "5";
            var line2 = "5 2 3 6 1";

            //int n = Convert.ToInt32(Console.ReadLine());
            //string[] a_temp = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line1);
            string[] a_temp = line2.Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            // Return the minimum number of elements to delete to make the array zigzag
            int result = minimumDeletions(a);
            Console.WriteLine(result);
        }
    }
}