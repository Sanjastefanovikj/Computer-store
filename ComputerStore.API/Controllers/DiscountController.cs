using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ComputerStore.Application.Dtos;
using ComputerStore.Application.Interfaces;

namespace ComputerStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("calculate")]
        public ActionResult<DiscountResultDto> CalculateDiscount([FromBody] List<BasketItemDto> basketItems)
        {
            var result = _discountService.CalculateDiscount(basketItems);
            return Ok(result);
        }
    }
}

