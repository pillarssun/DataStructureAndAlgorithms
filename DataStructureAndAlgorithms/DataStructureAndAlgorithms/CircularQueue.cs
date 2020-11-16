using System;
namespace DataStructureAndAlgorithms
{
    public class CircularQueue
    {
        private string[] items;
        private int capacity = 0;
        private int head = 0;
        private int tail = 0;

        public CircularQueue(int _capacity)
        {
            capacity = _capacity;
            items = new string[capacity];
        }

        public bool enqueue(string item)
        {
            if ((tail + 1) % capacity == head)
            {
                return false;
            }
            items[tail] = item;
            tail = (tail + 1) % capacity;
            return true;
        }

        public string dequeue()
        {
            if (head == tail)
            {
                return null;
            }
            string result = items[head];
            head = (head + 1) % capacity;
            return result;
        }

        public string[] getItems()
        {
            return items;
        }
    }
}
