using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using ComputerStore.Application.Dtos;

namespace ComputerStore.Application.Interfaces
{
    public interface IDiscountService
    {
        DiscountResultDto CalculateDiscount(IEnumerable<BasketItemDto> basketItems);
    }
}
