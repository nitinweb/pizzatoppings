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
            var rank = 0;
            foreach (var result in query)
            {
                rank++;
                Console.WriteLine("Rank {0}.Topping Name: {1} - Count: {2}",rank, result.Name, result.Count);
            }
        }
    }
}
