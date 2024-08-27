using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ShopifyAPI.Interfaces;
using ShopifyAPI.Models;
using ShopifyAPI.Services;

namespace ShopifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly ClothingStoreContext _context;
        private readonly IInventoryService _inventoryService;
        private readonly IWebhookAuthenticationService _webhookAuthenticationService;
        HttpListenerContext context;
        public InventoriesController(ClothingStoreContext context, IInventoryService inventoryService, IWebhookAuthenticationService webhookAuthenticationService)
        {
            _context = context;
            _inventoryService = inventoryService;
            _webhookAuthenticationService = webhookAuthenticationService;

        }

        [HttpPost]
        public IActionResult HandlePostRequest()
        {
            using (Stream body = Request.Body)
            {
                using (StreamReader reader = new StreamReader(body, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    string hmacHeader = Request.Headers["X-Shopify-Hmac-Sha256"];

                    bool verified = _webhookAuthenticationService.VerifyWebhook(data, hmacHeader);

                    if (!verified)
                    {
                        return Unauthorized();
                    }

                    // Process webhook payload
                    // ...

                    return Ok();
                }
            }
        }
        // POST: api/Inventory/discountInventory
        [HttpPost("discountInventory")]
        public async Task<IActionResult> DiscountInventory(JObject data)
        {
            // HMAC-SHA256 signature received in the header
            string hmacHeader = "J06+7uQkUshK0oz4ssqrRl/1zO11dcmn/Tp6cgbi8/c=";
            var dataaa = data;
            // Now you have the raw string in the requestBody variable
            // You can use it as needed, such as passing it to IsRequestValid method

            // Example: Validate the request body using your IsRequestValid method
            // Example: Validate the request body using your IsRequestValid method
            //bool isValidRequest = _webhookAuthenticationService.IsRequestValid(dataaa.ToString(), hmacHeader);

            //if (!isValidRequest)
            //{
            //    return Unauthorized(); // Return 401 Unauthorized if authentication fails
            //}

            // Your logic here...

            return Ok();
            //string requestBody;
            //using (var reader = new StreamReader(Request.Body))
            //{
            //    requestBody = await reader.ReadToEndAsync();
            //}
 
            //string sku = data.Event.Body.LineItems[0].Sku;
            //int? quantity = data.Event.Body.LineItems[0].Quantity;

            //bool isValidRequest = _webhookAuthenticationService.IsRequestValid(requestBody, hmacHeader);
            //if (!isValidRequest)
            //{
            //    return Unauthorized(); // Return 401 Unauthorized if authentication fails
            //}

            //var product = await _context.Products.FirstOrDefaultAsync(p => p.BarcodeId == sku);
            //if (product == null)
            //{
            //    return NotFound($"Product with barcode ID {sku} not found.");
            //}

            //// Update the inventory quantity (assuming there's only one inventory record per product)
            //var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == product.ProductId);
            //if (inventory == null)
            //{
            //    return NotFound($"Inventory record for product with barcode ID {sku} not found.");
            //}

            //// Apply the discount operation (e.g., decrease inventory quantity by 1)
            //if (inventory.QuantityInStock > 0)
            //{
            //    inventory.QuantityInStock--; // Discount inventory by 1
            //    await _context.SaveChangesAsync();
            //    return Ok($"Inventory for product with barcode ID {sku} discounted successfully.");
            //}
            //else
            //{
            //    return BadRequest("Inventory quantity is already zero.");
            //}
            return Ok();
        }


        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories(ShopifyWebhookData data)
        {
          if (_context.Inventories == null)
          {
              return NotFound();
          }
            return await _context.Inventories.ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
          if (_context.Inventories == null)
          {
              return NotFound();
          }
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.InventoryId)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        //{
        //  if (_context.Inventories == null)
        //  {
        //      return Problem("Entity set 'ClothingStoreContext.Inventories'  is null.");
        //  }
        //    _context.Inventories.Add(inventory);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetInventory", new { id = inventory.InventoryId }, inventory);
        //}

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            if (_context.Inventories == null)
            {
                return NotFound();
            }
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(int id)
        {
            return (_context.Inventories?.Any(e => e.InventoryId == id)).GetValueOrDefault();
        }
    }
}
