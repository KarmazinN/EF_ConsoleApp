using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string CustomerFullName { get; set; }
        public decimal FullAmount { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}
