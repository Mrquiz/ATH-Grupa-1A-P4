using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03a
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities())
            {

                context.Database.Log = Console.WriteLine;

                var top5CustomersWithEmployee = context.Customers
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

                var ordersPrice = context.Orders
                    .Select(x => new
                    {
                        x.OrderID,
                        PriceWithDiscount = x.Order_Details.Sum(y => y.Quantity * (float)y.UnitPrice * (1 - y.Discount)),
                        Price = x.Order_Details.Sum(y => y.Quantity * y.UnitPrice)
                    });

                var employeeWithOrderPriceAndTerritory = context.Employees
                    .Select(x => new
                    {
                        Name = x.FirstName + " " + x.LastName,
                        OrderPrice = x.Orders
                            .Sum(y => y.Order_Details.Sum(z => z.UnitPrice * z.Quantity)),
                        Territories = x.Territories.Select(y => y.TerritoryDescription)
                    })
                    .OrderByDescending(x => x.OrderPrice);

                var hierarchy = context.Employees
                    .Where(x => x.Boss == null);

                var top10ProductsWithBiggestDiscount = context.Order_Details
                    .OrderByDescending(x => x.Discount)
                    .Take(10)
                    .Select(x => new
                    {
                        x.Products.ProductID,
                        x.Products.ProductName,
                        x.Discount
                    });



                foreach (var query in top10ProductsWithBiggestDiscount)
                {
                    //Console.WriteLine(customer.CompanyName);
                    //foreach (var customerOrder in customer.Orders)
                    //{
                    //    Console.WriteLine($" - {customerOrder.OrderId} {customerOrder.EmloyeeLastName}");
                    //}
                    Console.WriteLine(query);

                }
            }
        }

        static void ShowEmployee(Employees emplyoee, int level = 0)
        {
            Console.WriteLine("{0} - {1}", "".PadLeft(level * 2, ' '), emplyoee.LastName);
            foreach (var emp in emplyoee.Employees1)
            {
                ShowEmployee(emp, level + 1);
            }

        }
    }
}
