using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Grupa_1A_P4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities())
            {

                context.Database.Log = Console.WriteLine;

                var currentQuery = context.Customers
                    .OrderBy(x => x.CompanyName)
                    .Take(5)
                    .Select(x => new
                    {
                        x.CompanyName,
                        Orders = x.Orders.Select(y => new
                        {
                            OrderId = y.OrderID,
                            EmloyeeLastName = y.Employees.LastName
                        })
                    });


                foreach (var query in currentQuery)
                {
                    Console.WriteLine($"{query.CompanyName}");
                    foreach (var order in query.Orders)
                    {
                        Console.WriteLine($"    -> {order.OrderId} - {order.EmloyeeLastName}");
                    }
                }
            }
        }
    }
}
