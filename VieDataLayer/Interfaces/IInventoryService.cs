using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMDataLayer.Models;

namespace SMDataLayer.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetItemsByProductIdAsync(int productId);
        Task UpdateInventoryAsync(Inventory item);
    }
}
