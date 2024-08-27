using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopifyAPI.Interfaces;
using ShopifyAPI.Models;

namespace ShopifyAPI.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly ClothingStoreContext _context;

        public InventoryService(ClothingStoreContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Inventory>> GetItemsByProductIdAsync(int productId)
        {
            // Retrieve inventory items with the specified product ID
            return await _context.Inventories
                .Where(item => item.ProductId == productId)
                .ToListAsync();
        }

        public async Task UpdateInventoryAsync(Inventory item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
