using System;
using System.Text;

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

        public static void printStringArray(string[] arr)
        {
            if (arr == null || arr.Length == 0) return;
            foreach (string i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static bool isPalindrome(string str)
        {
            char[] charArr = str.ToCharArray();
            Array.Reverse(charArr);
            string strReversed = new StringBuilder().Append(charArr).ToString();
            if (str == strReversed)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool isPalindromePlain(string str)
        {
            int size = str.Length;
            bool isPal = true;
            for (int i = 0; i < size; i++)
            {
                if (str[i] != str[size - 1 - i])
                {
                    isPal = false;
                    break;
                }
            }
            return isPal;
        }
    }
}
