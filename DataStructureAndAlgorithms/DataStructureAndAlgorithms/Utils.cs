using System;
namespace DataStructureAndAlgorithms
{
    public class Utils
    {
        public Utils()
        {
        }
        public static void printIntArray(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
