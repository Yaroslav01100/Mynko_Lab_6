using System;
using System.Collections.Generic;

namespace Lab_6_task_2
{
    public class Repository<T>
    {
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }

        public delegate bool Criteria<T>(T item);

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> Find(Criteria<T> criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Критерії не можуть бути нульовими.");
            }

            List<T> result = new List<T>();

            foreach (T item in items)
            {
                if (criteria(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Минко Ярослав");

            Repository<int> intRepository = new Repository<int>();

            intRepository.Add(1);
            intRepository.Add(2);
            intRepository.Add(3);
            intRepository.Add(4);
            intRepository.Add(5);

            Repository<int>.Criteria<int> evenCriteria = x => x % 2 == 0;

            List<int> evenNumbers = intRepository.Find(evenCriteria);

            Console.WriteLine("Парні числа:");
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }

}