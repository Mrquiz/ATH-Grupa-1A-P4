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

                var currentQuery = context.Employees
                    .Select(x => new
                    {
                        Name = x.FirstName + " " + x.LastName,
                        OrderPrice = x.Orders
                            .Sum(y => y.Order_Details.Sum(z => z.UnitPrice * z.Quantity)),
                        Territories = x.Territories.Select(y => y.TerritoryDescription)
                    })
                    .OrderByDescending(x => x.OrderPrice);


                foreach (var query in currentQuery)
                {
                    Console.WriteLine($"{query.Name} -> {query.OrderPrice}");
                    foreach (var territory in query.Territories)
                    {
                        Console.WriteLine($"    - {territory}");
                    }
                }
            }
        }
    }
}
