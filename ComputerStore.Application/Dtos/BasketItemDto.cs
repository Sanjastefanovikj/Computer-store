using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Application.Dtos
{
    public class BasketItemDto
    {
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
