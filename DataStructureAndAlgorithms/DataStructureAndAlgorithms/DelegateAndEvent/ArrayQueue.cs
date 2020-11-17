using System;
namespace DataStructureAndAlgorithms
{
    public class ArrayQueue
    {
        private string[] items;
        private int capacity = 0;
        private int head = 0;
        private int tail = 0;

        public ArrayQueue(int _capacity)
        {
            capacity = _capacity;
            items = new string[capacity];
        }

        public string dequeue()
        {
            if (head == tail)
            {
                return null;
            }
            string res = items[head++];
            return res;
        }

        public bool enqueue(string item)
        {
            if (tail == capacity)
            {
                if (head == 0) //full queue
                {
                    return false;
                }
                for (int i = head; i < capacity; i++)
                {
                    items[i - head] = items[i];
                }
                head = 0;
                tail -= head;
            }
            items[tail++] = item;
            return true;
        }

        public string[] getItems()
        {
            return items;
        }
    }
}
