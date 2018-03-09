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
                
                var currentQuery = context.Order_Details
                    .OrderByDescending(x => x.Discount)
                    .Take(10)
                    .Select(x => new
                    {
                        x.Products.ProductID,
                        x.Products.ProductName,
                        x.Discount
                    });



                foreach (var query in currentQuery)
                {
                    Console.WriteLine(query);
                }
            }
        }
    }
}
