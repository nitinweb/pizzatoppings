using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaToppingCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = DataUtils.GetTop20Toppings();
            foreach (var result in query)
            {
                Console.WriteLine("Topping Name: {0} - Count: {1}", result.Name, result.Count);
            }
        }
    }
}
