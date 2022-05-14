using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestConsoleApp.Models;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Console.WriteLine("==================Вводимо даннi ==================");

                Position p1 = new Position { Name = "Ракетка 1", Price = 1200, Quantity = 2, Amount = 2400 };
                Position p2 = new Position { Name = "Ракетка 2", Price = 1300, Quantity = 3, Amount = 3900 };
                Position p3 = new Position { Name = "Ракетка 3", Price = 1800, Quantity = 1, Amount = 1800 };
                Position p4 = new Position { Name = "Ракетка 4", Price = 1600, Quantity = 1, Amount = 1600 };
                Position p5 = new Position { Name = "Ракетка 5", Price = 1400, Quantity = 1, Amount = 1400 };

                db.Positions.AddRange(p1, p2, p3, p4, p5);

                var Order1 = new Order
                {
                    Date = new DateTime(2022, 5, 10),
                    CustomerFullName = "FullName_1",
                    FullAmount = 0
                };

                var Order2 = new Order
                {
                    Date = new DateTime(2022, 5, 11),
                    CustomerFullName = "FullName_1",
                    FullAmount = 0
                };

                var Order3 = new Order
                {
                    Date = new DateTime(2022, 5, 12),
                    CustomerFullName = "FullName_1",
                    FullAmount = 0
                };

                db.Orders.AddRange(Order1, Order2, Order3);

                Order1.Positions.AddRange(new List<Position>() { p1, p2, p3 });
                Order2.Positions.AddRange(new List<Position>() { p2, p4 });
                Order3.Positions.AddRange(new List<Position>() { p5 });

                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var orders = db.Orders.Include(c => c.Positions).ToList();
                Func.PrintOrders(orders);
                Console.WriteLine("==================Змiнюємо даннi==================");

                Position position1 = db.Positions.Include(s => s.Orders).FirstOrDefault(s => s.Id == 1);
                Order order1 = db.Orders.FirstOrDefault(c => c.Id == 1);
                if (position1 != null && order1 != null)
                {
                    order1.Positions.Remove(position1);
                }

                Order order3 = db.Orders.FirstOrDefault(c => c.Id == 3);
                order3.Positions.Add(position1);
                db.SaveChanges();

                var orders_change = db.Orders.Include(c => c.Positions).ToList();
                Func.PrintOrders(orders_change);
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("==================Пошук за датою==================");
                var required_date = new DateTime(2022, 5, 11);
                Console.WriteLine($"Цiльова дата: {required_date}");
                var orders = db.Orders.Include(c => c.Positions).Where(d => d.Date == required_date).ToList();
                Func.PrintOrders(orders);
            }
        }
    }
}
