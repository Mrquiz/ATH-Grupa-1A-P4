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

                //context.Database.Log = Console.WriteLine;

                var currentQuery = context.Employees
                    .Where(x => x.Boss == null);


                foreach (var query in currentQuery)
                {
                    ShowEmployee(query);
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
