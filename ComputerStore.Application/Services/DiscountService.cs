using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using ComputerStore.Application.Dtos;
using ComputerStore.Application.Interfaces;

namespace ComputerStore.Application.Services
{
    public class DiscountService : IDiscountService
    {
        public DiscountResultDto CalculateDiscount(IEnumerable<BasketItemDto> basketItems)
        {
            if (basketItems == null || !basketItems.Any())
            {
                return new DiscountResultDto
                {
                    TotalDiscount = 0m,
                    DiscountedItems = new List<BasketItemDto>()
                };
            }

            var groupedByCategory = basketItems.GroupBy(item => item.CategoryName);

            decimal totalDiscount = 0m;
            var discountedItems = new List<BasketItemDto>();

            foreach (var group in groupedByCategory)
            {
                var items = group.ToList();

                if (items.Count > 1)
                {
                    foreach (var item in items)
                    {
                        if (item.Quantity > 0)
                        {
                            var discountAmount = item.Price * 0.05m;
                            totalDiscount += discountAmount;
                            discountedItems.Add(new BasketItemDto
                            {
                                ProductName = item.ProductName,
                                CategoryName = item.CategoryName,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                Discount = discountAmount
                            });
                        }
                    }
                }
            }

            return new DiscountResultDto
            {
                TotalDiscount = totalDiscount,
                DiscountedItems = discountedItems
            };
        }
    }
}
