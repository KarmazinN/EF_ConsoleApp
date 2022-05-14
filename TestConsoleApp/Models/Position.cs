using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp.Models
{
    internal class Position
    {
        public int Id { get; set; } // id
        public string Name { get; set; } // Ім'я
        public decimal Price { get; set; } // Ціна
        public int Quantity { get; set; } // Кількість
        public decimal Amount { get; set; } // Вартість
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
