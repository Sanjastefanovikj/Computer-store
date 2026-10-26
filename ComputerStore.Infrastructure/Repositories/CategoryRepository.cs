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
using Category = ComputerStore.Domain.Entities.Category;

namespace ComputerStore.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ComputerStoreDbContext _context;

        public CategoryRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            // Fix: Ensure the correct assembly reference is used for the Category type
            if (_context.Entry(category).State == EntityState.Detached)
            {
                _context.Categories.Add(category);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            var trackedCategory = await _context.Categories.FindAsync(category.Id);
            if (trackedCategory != null)
            {
                _context.Entry(trackedCategory).CurrentValues.SetValues(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}

