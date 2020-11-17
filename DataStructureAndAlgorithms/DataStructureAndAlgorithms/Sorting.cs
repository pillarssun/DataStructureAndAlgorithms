using System;
namespace DataStructureAndAlgorithms
{
    public class Sorting
    {
        public Sorting()
        {
        }

        //Bubble Sorting
        public static void bubbleSort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return;
            }
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                bool hasInterchange = false;
                for (int j = 0; j < size - i - 1; j++) // each round will make the very right section to be sorted
                {
                    if (arr[j + 1] < arr[j])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        hasInterchange = true;
                    }
                }
                if (!hasInterchange) // no need to continue bubble since there is no interchange of items
                {
                    break;
                }
            }
        }

        //Insertion Sorting
        public static void insertSort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return;
            }
            int size = arr.Length;
            for (int i = 1; i < size; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                for (; j >= 0; j--)
                {
                    if (arr[j] > temp) //larger than the waiting item, so move it to the right
                    {
                        arr[j + 1] = arr[j];
                    }
                    else //Found postion to insert
                    {
                        break;
                    }
                }
                arr[j + 1] = temp;  //arr[j] < temp, so insert on j's right
            }
        }

        //Selection Sorting
        public static void selectSort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return;
            }
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                //swap
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
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

        //Counting Sort
        public static void countingSort(int[] arr, int size)
        {
            if (arr == null || size < 1)
            {
                return;
            }

            int max = arr[0];
            for (int i = 1; i < size; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            //creating the bucket array
            int[] c = new int[max + 1];
            for (int i = 0; i <= max; i++)
            {
                c[i] = 0;
            }
            //putting items to c
            for (int i = 0; i < size; i++)
            {
                c[arr[i]]++;
            }
            //sum up
            for (int i = 1; i <= max; i++)
            {
                c[i] = c[i - 1] + c[i];
            }
            //temp array r to store the sorted items
            int[] r = new int[size];
            for (int i = size - 1; i >= 0; i--)
            {
                int index = c[arr[i]] - 1;
                r[index] = arr[i];
                c[arr[i]]--;
            }
            //copy to original array
            for (int i = 0; i < size; i++)
            {
                arr[i] = r[i];
            }
        }

        //Binary Sort
        public static int bSearch(int[] arr, int size, int target)
        {
            int low = 0;
            int high = size - 1;

            while (low <= high)
            {
                int mid = low + ((high - low) >> 1);
                //low + high may cause the stack overflow if both of them are large numbers
                //int mid = (low + high) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                } else if (arr[mid] < target)
                {
                    low = mid + 1;
                } else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        public static int bSearchRecursion(int[] arr, int size, int target)
        {
            return bSearchRecursionInternal(arr, 0, size - 1, target);
        }
        public static int bSearchRecursionInternal(int[] arr, int low, int high, int target)
        {
            if (low > high)
            {
                return -1;
            }
            int mid = low + ((high - low) >> 1);
            if (arr[mid] == target)
            {
                return mid;
            } else if (arr[mid] < target)
            {
                low = mid + 1;
                return bSearchRecursionInternal(arr, low, high, target);
            } else
            {
                high = mid - 1;
                return bSearchRecursionInternal(arr, low, high, target);
            }
        }

        //To find the first matched item in an array that has repeated items
        public static int bSearchToLocateFirstMatchValue(int[] arr, int size, int target)
        {
            int low = 0;
            int high = size - 1;

            while (low <= high)
            {
                int mid = low + ((high - low) >> 1);

                if (arr[mid] > target)
                {
                    high = mid - 1;
                } else if (arr[mid] < target)
                {
                    low = mid + 1;
                } else
                {
                    if (mid == 0 || arr[mid - 1] != target)  // find the very left one
                    {
                        return mid;
                    } else
                    {
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }

    }
}
