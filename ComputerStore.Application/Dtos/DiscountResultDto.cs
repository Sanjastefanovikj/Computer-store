using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace ComputerStore.Application.Dtos
{
    public class DiscountResultDto
    {
        public decimal TotalDiscount { get; set; }
        public List<BasketItemDto> DiscountedItems { get; set; } = new List<BasketItemDto>();
    }
}
