using System;
using System.Collections.Generic;

namespace Queue2Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Pop());
            }

            Console.ReadKey();
        }
    }

    public class Queue<T>
    {
        private readonly Stack<T> _mainStack = new Stack<T>();
        private readonly Stack<T> _tmpStack = new Stack<T>();

        public void Push(T item)
        {
            _mainStack.Push(item);            
        }

        public T Pop()
        {
            while (_mainStack.Count > 1)
            {
                _tmpStack.Push(_mainStack.Pop());
            }

            var item = _mainStack.Pop();

            while (_tmpStack.Count > 0)
            {
                _mainStack.Push(_tmpStack.Pop());
            }

            return item;
        }

        public bool IsEmpty()
        {
            return _mainStack.Count == 0;
        }
    }
}
