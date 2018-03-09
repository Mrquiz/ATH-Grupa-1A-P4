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

                var currentQuery = context.Products
                    .Select(x => new
                    {
                        x.ProductName,
                        x.UnitsInStock,
                        Dostawca = x.Suppliers.CompanyName
                    });

                foreach (var query in currentQuery)
                {
                    Console.WriteLine($"{query.ProductName} - {query.UnitsInStock}");
                        Console.WriteLine($"    - {query.ProductName}" );
                }

            }
        }
    }
}