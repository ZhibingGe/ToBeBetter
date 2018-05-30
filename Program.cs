using System;

namespace ToBeBetter
{
    public delegate void SortMethodTest(ref int[] array);
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            method:SortMethodTest,len:10,costtime/len:0.022993ms
            method:SortMethodTest,len:100,costtime/len:0.0002397ms
            method:SortMethodTest,len:1000,costtime/len:0.00034251ms
            method:SortMethodTest,len:10000,costtime/len:0.000469044ms
            method:SortMethodTest,len:100000,costtime/len:0.0006087976ms
            method:SortMethodTest,len:1000000,costtime/len:0.00071012775ms
             */
            TestSortMethod(SortingAlgorithm.QuickSort);

            Console.WriteLine("Done!");
        }
        public static void TestSortMethod(SortMethodTest sortmethod)
        {
            //分别对长度为10，100，1000，10000，100000的数字进行排序，得到运行时间，每个长度运行10次取均值
            Random rn = new Random();
            int[] lengths = new int[] { 10, 100, 1000, 10000, 100000, 1000000 };
            int times = 10;
            foreach (var len in lengths)
            {
                DateTime dt1 = DateTime.Now;
                for (int i = 0; i < times; i++)
                {
                    int[] array = new int[len];
                    for (int j = 0; j < len; j++)
                    {
                        array[j] = rn.Next(0, len * 10);
                    }
                    sortmethod(ref array);
                }
                Console.WriteLine("method:{0},len:{1},costtime/len:{2}ms", sortmethod.GetType().Name, len, (DateTime.Now - dt1).TotalMilliseconds / times / len);
            }


        }
    }
}
