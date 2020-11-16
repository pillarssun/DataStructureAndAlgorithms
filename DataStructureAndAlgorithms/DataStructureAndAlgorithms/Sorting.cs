using System;
namespace DataStructureAndAlgorithms
{
    public class Sorting
    {
        public Sorting()
        {
        }

        //Merge Sorting
        public static void mergeSort(int[] arr, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int center = (left + right) / 2;
                mergeSort(arr, temp, left, center);
                mergeSort(arr, temp, center + 1, right);
                merge(arr, temp, left, center, right);
            }
            Utils.printIntArray(arr);
        }

        public static void merge(int[] arr, int[] temp, int left, int center, int right)
        {
            int i = left, j = center + 1; //i and j are the head index for the left and right sub-arrays

            for (int k = left; k <= right; k++)
            {
                if (i > center) //which means no left sub-array
                {
                    temp[k] = arr[j++];
                }
                else if (j > right) //no right sub-array
                {
                    temp[k] = arr[i++];
                }
                else if (arr[i] <= arr[j])  //assign the value from left to the temp
                {
                    temp[k] = arr[i++];
                }
                else                 // assign the value from the right
                {
                    temp[k] = arr[j++];
                }
            }
            // copy to original array
            for (int q = left; q <= right; q++)
            {
                arr[q] = temp[q];
            }
        }


        //Quick Sorting
        public static void quickSort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = partition(arr, p, r);
                quickSort(arr, p, q - 1);
                quickSort(arr, q + 1, r);
            }
        }
        public static int partition(int[] arr, int p, int r)
        {
            int pivot = arr[r];
            int i = p;
            for (int j = p; j < r; j++)
            {
                if (arr[j] < pivot)
                {
                    //swap
                    if (i != j)
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    } 
                    i++;
                }
            }
            //swap
            arr[r] = arr[i];
            arr[i] = pivot;

            Utils.printIntArray(arr);

            return i;
        }
    }
}
