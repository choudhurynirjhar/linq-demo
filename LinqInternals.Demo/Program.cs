using System;
using System.Linq;

namespace LinqInternals.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new[] { 
                new Customer{
                    Name="Jon",
                    Phones=new []{
                        new Phone
                        { Number="123", PhoneType= PhoneType.Cell},
                        new Phone
                        { Number = "345", PhoneType= PhoneType.Home}
                    }
                },
                new Customer
                {
                    Name="Jane",
                    Phones=new[]
                    {
                        new Phone
                        { Number="345-345-3456", PhoneType= PhoneType.Cell},
                        new Phone
                        { Number="456-678-5678", PhoneType= PhoneType.Home}
                    }
                }
            };

            var customerPhones = customers.NewSelectMany(c => c.Phones );
            foreach (var item in customerPhones)
            {
                Console.WriteLine($"{item.Number} - {item.PhoneType}");
            }
        }

        private static void WhereDemo()
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
