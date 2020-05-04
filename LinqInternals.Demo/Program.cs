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
                    Id=1,
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
                    Id=2,
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

            var addresses = new[]
            {
                new Address{Id=1, CustomerId=2, Street="123 Street", City="City1"},
                new Address {Id=2, CustomerId=2, Street="457 Street", City="City2"}
            };

            var customerwithaddress = customers.NewJoin(addresses
                , c => c.Id
                , a => a.CustomerId
                , (c, a) => new { c.Name, a.Street, a.City });

            foreach (var item in customerwithaddress)
            {
                Console.WriteLine($"{item.Name} - {item.Street} - {item.City}");
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
