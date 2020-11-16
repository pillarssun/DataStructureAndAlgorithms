using System;
using System.Collections;
using System.Collections.Generic;
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
        public void TestQueueAndStackUsages()
        {
            //Queue basics:
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("first_front");
            queue.Enqueue("second_rear"); //add in the back
            IEnumerator queueEnumerator = queue.GetEnumerator();
            while (queueEnumerator.MoveNext())
            {
                Console.WriteLine(queueEnumerator.Current);
            }
            string value1 = (string) queue.Peek();    //read head but not delete it
            string value2 = (string) queue.Dequeue(); // read head and delete it
            Console.WriteLine("value1: " + value1 + "  value2: " + value2);
            queueEnumerator = queue.GetEnumerator();
            while (queueEnumerator.MoveNext())
            {
                Console.WriteLine(queueEnumerator.Current);
            }

            //Stack basics:
            Stack newStack = new Stack();
            newStack.Push(30); //push is adding an item on the top
            newStack.Push(20);
            newStack.Push(10);
            IEnumerator enumerator = newStack.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            int value1_ = (int) newStack.Peek(); //read the top but not delete
            int value2_ = (int) newStack.Pop();  //read the top and then delete
            Console.WriteLine("value1_: " + value1_ + "  value2_: " + value2_);
            enumerator = newStack.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        [TestMethod]
        public void TestDictionaryUsages()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "aaa");
            hashtable.Add(5, "bbbb");
            hashtable.Add(4, "ccccc");
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }

            SortedList<int, string> sl = new SortedList<int, string>();  //It is sorted compared to hashtable
            sl.Add(1, "aaa");
            sl.Add(5, "bbbb");
            sl.Add(4, "ccccc");
            foreach (var item in sl)
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "aaa");
            dic.Add(5, "bbbb");
            dic.Add(4, "ccccc");
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }

            //To sort a hashtable
            ArrayList array = new ArrayList(hashtable.Keys);
            array.Sort();
            foreach (int e in array)
            {
                Console.WriteLine(hashtable[e]);
            }
        }

        [TestMethod]
        public void TestIsPalandrome()
        {
            string str = "abcba";
            string str2 = "dhakdhakk";
            Assert.IsTrue(Utils.isPalindrome(str));
            Assert.IsTrue(Utils.isPalindromePlain(str));
            Assert.IsFalse(Utils.isPalindrome(str2));
            Assert.IsFalse(Utils.isPalindromePlain(str2));
        }

        [TestMethod]
        public void TestCirlularQueue()
        {
            CircularQueue aq = new CircularQueue(3);
            Assert.IsTrue(aq.enqueue("aaa"));
            Assert.IsTrue(aq.enqueue("bbb"));
            Assert.IsFalse(aq.enqueue("ccc"));  // cirlular queue has to have 1 empty item
            Assert.AreEqual(aq.dequeue(), "aaa");
            Utils.printStringArray(aq.getItems());
        }

        [TestMethod]
        public void TestArrayQueue()
        {
            ArrayQueue aq = new ArrayQueue(3);
            Assert.IsTrue(aq.enqueue("aaa"));
            Assert.IsTrue(aq.enqueue("bbb"));
            Assert.IsTrue(aq.enqueue("ccc"));
            Assert.IsFalse(aq.enqueue("ddd"));
            Assert.AreEqual(aq.dequeue(), "aaa");
            Utils.printStringArray(aq.getItems());
        }

        [TestMethod]
        [DataRow(7, DisplayName = "7 number")]
        public void TestRecursion(int n)
        {
            RecursionExamples re = new RecursionExamples();
            int val1 = re.climbingPlan(n);
            int val2 = re.climbingPlanNonRecur(n);
            Console.WriteLine(val1);
            Console.WriteLine(val2);
            Assert.AreEqual(val1, val2);
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            Utils.printIntArray(unSortedArr);
            Sorting.bubbleSort(unSortedArr);
            Utils.printIntArray(unSortedArr);
            CollectionAssert.AreEqual(unSortedArr, sortedArr);
        }

        [TestMethod]
        public void TestInsertionSort()
        {
            Utils.printIntArray(unSortedArr);
            Sorting.insertSort(unSortedArr);
            Utils.printIntArray(unSortedArr);
            CollectionAssert.AreEqual(unSortedArr, sortedArr);
        }

        [TestMethod]
        public void TestSelectionSort()
        {
            Utils.printIntArray(unSortedArr);
            Sorting.selectSort(unSortedArr);
            Utils.printIntArray(unSortedArr);
            CollectionAssert.AreEqual(unSortedArr, sortedArr);
        }

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
