using System;
using System.Linq;

namespace LinqInternals.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            WhereDemo();

        }

        static void WhereDemo()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenItems = items.NewWhere(x => x % 2 == 0);
            foreach (var item in evenItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
