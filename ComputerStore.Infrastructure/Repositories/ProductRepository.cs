using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Repositories;
using ComputerStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ComputerStoreDbContext _context;

        public ProductRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            // Ensure the `Product` type being passed matches the `Product` type in the DbContext
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var trackedProduct = await _context.Products.FindAsync(product.Id);
            if (trackedProduct != null)
            {
                _context.Entry(trackedProduct).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
