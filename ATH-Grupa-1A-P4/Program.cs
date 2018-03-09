﻿using System;
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

                var currentQuery = context.Orders
                    .Select(x => new
                    {
                        x.OrderID,
                        PriceWithDiscount = x.Order_Details.Sum(y => y.Quantity * (float)y.UnitPrice * (1 - y.Discount)),
                        Price = x.Order_Details.Sum(y => y.Quantity * y.UnitPrice)
                    });

                foreach (var query in currentQuery)
                {
                    Console.WriteLine(query);

                }
            }
        }
    }
}
