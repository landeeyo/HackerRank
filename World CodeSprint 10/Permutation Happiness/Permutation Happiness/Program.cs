using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Permutation_Happiness
{
    class Program
    {       

        public class Permuter
        {
            

            public static void Swap<T>(List<T> list, int indexA, int indexB)
            {
                T tmp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = tmp;
            }

            public static void Permute(List<int> list, int k, int m, List<List<int>> result)
            {
                int i;
                if (k == m)
                {
                    result.Add(list);
                    //for (int z = 0; z < list.Count; z++)
                    //{
                    //    Debug.WriteLine(list[z]);
                    //}
                    
                }
                else
                {
                    for (i = k; i <= m; i++)
                    {
                        Swap(list, k, i);
                        var clonedList = new List<int>(list.Count);
                        clonedList.AddRange(list);
                        Permute(clonedList, k + 1, m, result);
                        Swap(list, k, i);
                    }
                }
            }

            public static List<List<int>> GenerateLists(int size)
            {
                List<int> list = new List<int>(size);
                for (int i = 0; i < size; i++)
                {
                    list.Add(i + 1);
                }
                List<List<int>> result = new List<List<int>>();
                Permute(list, 0, list.Count - 1, result);
                return result;

                //List<int> list = new List<int> { 1, 2, 3 };
                //List<List<int>> result = new List<List<int>>();
                //Permuter.Permute(list, 0, list.Count - 1, result);
                //return result;
            }
        }

        public class HappyList
        {
            public List<int> List { get; set; }
            public int NumberOfHappyPeople
            {
                get
                {
                    if (List.Count == 1 )
                    {
                        return 0;
                    }
                    if (List.Count == 2)
                    {
                        return 1;
                    }
                    int result = 0;
                    if (List[1] > List[0])
                    {
                        result++;
                    }
                    for(int i = 1; i < List.Count-1; i++)
                    {
                        if(List[i-1]>List[i] || List[i + 1] > List[i])
                        {
                            result++;   
                        }
                    }
                    if (List.Count >= 3)
                    {
                        if (List[List.Count-2] > List[List.Count-1])
                        {
                            result++;
                        }
                    }
                    return result;
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    List<int> list = new List<int> { 1, 2, 3 };
        //    List<List<int>> result = new List<List<int>>();
        //    Permuter.Permute(list, 0, list.Count - 1, result);

        //    HappyList hl = new HappyList();
        //    hl.List = new List<int> { 3, 1, 2, 5, 4 };



        //    int x = 0;
        //}

        static void Main(String[] args)
        {
            string l1 = "1";
            string l2 = "10 7";

            //int q = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(l1);
            for (int a0 = 0; a0 < q; a0++)
            {
                //string[] tokens_n = Console.ReadLine().Split(' ');
                string[] tokens_n = l2.Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                // Find the number of ways to arrange 'n' people such that at least 'k' of them will be happy
                // The return value must be modulo 10^9 + 7
                //int result = query(n, k);
                var lists = Permuter.GenerateLists(n);
                //var happyLists = new List<HappyList>();
                int numberOfListsWithAtLeastNHappyPeople = 0;
                foreach (var list in lists)
                {
                    var happyList = new HappyList();
                    happyList.List = list;
                    //happyLists.Add(happyList);
                    if (happyList.NumberOfHappyPeople >= k)
                    {
                        numberOfListsWithAtLeastNHappyPeople++;
                    }
                }
                Console.WriteLine(numberOfListsWithAtLeastNHappyPeople % 1000000007);
                //Console.WriteLine(result);
            }
        }
    }
}
