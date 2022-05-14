using System;
using System.Collections.Generic;
using System.Text;
using TestConsoleApp.Models;

namespace TestConsoleApp
{
    static class Func
    {
        public static void PrintOrders(List<Order> orders)
        {
            foreach (var o in orders)
            {
                Console.WriteLine($"Order: {o.Id} Data: {o.Date}");
                foreach (Position p in o.Positions)
                {
                    Console.WriteLine($"Name: {p.Name}");
                }
                Console.WriteLine("-------------------");
            }
        }
    }
}
