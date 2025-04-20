using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.DataLayer.Models;

namespace SM.DataLayer.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetItemsByProductIdAsync(int productId);
        Task UpdateInventoryAsync(Inventory item);
    }
}
