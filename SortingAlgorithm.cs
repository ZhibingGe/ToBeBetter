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
        ///       Step2:两块进行合并，逐个取出两块的第一个元素的较小值，直到遍历两块所有元素，递归进行直到合成一块。
        /// 时间复杂度：nlogn
        /// 空间复杂度：n
        /// 稳定性：稳定
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(ref int[] array)
        {

        }   
        public static void SpiltArray(ref int[] array,int startindex,int midx,int endindex)
        {

        } 
        #endregion
    }
}