using System;
using DataStructureAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestForDAndA
{
    [TestClass]
    public class UnitTest1
    {
        private int[] unSortedArr = { 202, 32, 11, 5, 4222, 88, 9 };
        private int[] sortedArr = { 5, 9, 11, 32, 88, 202, 4222 };

        [TestMethod]
        public void TestMergeSort()
        {
            Utils.printIntArray(unSortedArr);
            int[] temp = new int[7];
            Sorting.mergeSort(unSortedArr, temp, 0, 6);
            Utils.printIntArray(unSortedArr);
            CollectionAssert.AreEqual(unSortedArr, sortedArr);
        }

        [TestMethod]
        public void TestQuickSort()
        {
            Utils.printIntArray(unSortedArr);
            Sorting.quickSort(unSortedArr, 0, 6);
            Utils.printIntArray(unSortedArr);
            CollectionAssert.AreEqual(unSortedArr, sortedArr);
        }
    }
}
