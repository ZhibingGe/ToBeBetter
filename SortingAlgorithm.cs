using System;
namespace ToBeBetter
{
    /// <summary>
    /// 排序算法类
    /// 稳定：相同的元素，排序前后保持次序一致时稳定
    /// </summary>
    public class SortingAlgorithm
    {
        #region 快速排序 QuickSort
        /// <summary>
        /// 快速排序
        /// 算法：首选选择1个数，将数列中小于这个数的放这个数左边，大于这个数的放右边，然后对左右两边进行同样的动作，直到排序完毕
        /// 时间复杂度：最好nlogn 平均nlogn 最坏n^2
        /// 空间复杂度：最欢n
        /// 稳定性：不稳定
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(ref int[] array)
        {
            QuickSort(ref array,0,array.Length-1);
        }

        private static void QuickSort(ref int[] array, int startindex, int endindex)
        {
            if(startindex>=endindex)
                return;
            var currentIndex = startindex;
            for(int i=startindex+1;i<=endindex;i++)
            {
                if(array[i]<array[currentIndex])
                {
                    var temp = array[i];
                    if(i-currentIndex>1)
                    {
                        array[i]=array[currentIndex+1];
                        array[currentIndex+1]=array[currentIndex];
                        array[currentIndex++]=temp;
                    }
                    else
                    {
                        array[i]=array[currentIndex];
                        array[currentIndex++]=temp;
                    }
                }   
            }
            QuickSort(ref array,startindex,currentIndex-1);
            QuickSort(ref array,currentIndex+1,endindex);
        }
        #endregion
        
        #region 合并排序 MergeSort
        /// <summary>
        /// 合并排序
        /// 算法：Step1：首先分割数列，将array左右等分，如果奇数，则左多一个，递归进行，直到无法再分（最终每一块只有1个元素）。
        ///      Step2:两块进行合并，逐个取出两块的第一个元素的较小值，直到遍历两块所有元素，递归进行直到合成一块。
        /// 时间复杂度：nlogn
        /// 空间复杂度：n
        /// 稳定性：稳定
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(ref int[] array)
        {
            MergeSort(ref array,0,array.Length-1);
        }   
        public static void MergeSort(ref int[] array,int startindex,int endindex)
        {
            if(startindex>=endindex)
                return;
            int midx = (startindex+endindex)/2;
            MergeSort(ref array,startindex,midx);
            MergeSort(ref array,midx+1,endindex);
            Merge(ref array,startindex,midx,endindex);
        } 
        public static void Merge(ref int[] array,int startindex,int midx,int endindex)
        {
            var arrayTemp = new int[endindex-startindex+1];
            var lindex=0;
            var rindex=0;
            for(int i=0;i<arrayTemp.Length;i++)
            {
                if(array[lindex]>array[rindex])
                {
                    arrayTemp[i]=array[rindex];
                    rindex++;
                }
                else
                {
                    arrayTemp[i]=array[lindex];
                    lindex++;
                }
            }
            for(int i=0;i<arrayTemp.Length;i++)
            {
                array[startindex+i]=arrayTemp[i];
            }
        }
        #endregion

        #region 堆排序 HeapSort
        /// <summary>
        /// 堆排序算法：建堆，最小化堆，即根节点比子节点小，最大化堆：根节点比子节点大，从堆的最高节点提取最小值，提取后重新建堆（提取最后一个值放在堆顶然后建堆）
        /// 时间复杂度：nlogn
        /// 空间复杂度：1
        /// 稳定性：不稳定
        /// </summary>
        /// <param name="array"></param>
        public static void HeapSort(ref int[] array)
        {
            //建堆，最大值在上
            BuildHeap(ref array);
            //堆排序
            SortHeap(ref array);
        }   
        public static void SortHeap(ref int[] array)
        {
            Console.WriteLine(string.Join(",",array));
            //最大值再上面，需要与最后一个值互换，最后一个值放在堆顶需要重新排序一下
            for(int i=0;i<array.Length;i++)
            {
                //最大值与末尾值互换
                var temp = array[array.Length-1-i];
                array[array.Length-1-i]=array[0];
                array[0]=temp;
                //末尾值到堆顶需要重新整理堆,将堆顶与左右两节点中较大的互换
                var currentIndex=0;
                while(currentIndex*2+1<array.Length-1-i)
                {
                    var nextindex =0;
                    if(currentIndex*2+2>=array.Length-1-i||array[currentIndex*2+1]>array[currentIndex*2+2])
                    {
                        nextindex=currentIndex*2+1;
                    }
                    else
                    {
                        nextindex=currentIndex*2+2;
                    }
                    if(array[currentIndex]<array[nextindex])
                    {
                        temp = array[currentIndex];
                        array[currentIndex]=array[nextindex];
                        array[nextindex]=temp;
                        currentIndex=nextindex;
                    }
                    else
                        break;
                }
            Console.WriteLine(string.Join(",",array));                
            }
        }
        public static  void BuildHeap(ref int[] array)
        {
            for(int i=1;i<array.Length;i++)
            {
                int j=i;
                while(array[j]>array[(j-1)/2] && j>0)
                {
                    var temp = array[j];
                    array[j] = array[(j-1)/2];
                    array[(j-1)/2] = temp;
                    j=(j-1)/2;
                }
            }
        }
        #endregion
    }
}