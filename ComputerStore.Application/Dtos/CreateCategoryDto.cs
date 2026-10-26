using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Application.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
