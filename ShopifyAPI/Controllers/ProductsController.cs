using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopifyAPI.Dtos;
using ShopifyAPI.Interfaces;
using ShopifyAPI.Models;
using ShopifyAPI.Services;

namespace ShopifyAPI.Controllers
{
  
    [ApiController]
    [Route("webhook")]
    public class ProductsController : ControllerBase
    {
        private readonly ClothingStoreContext _context;
        private readonly IProductService _productService;
        private readonly IWebhookAuthenticationService _webhookAuthenticationService;


        public ProductsController(ClothingStoreContext context, IProductService productService, IWebhookAuthenticationService webhookAuthenticationService)
        {
            _context = context;
            _productService = productService;
            _webhookAuthenticationService = webhookAuthenticationService;
        }
            // GET: api/Products
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromBody] string requestBody)
            {
            // Retrieve HMAC header from request
            string hmacHeader = Request.Headers["X-Shopify-Hmac-SHA256"];

            // Validate the request using the authentication service
            //bool isValidRequest = _webhookAuthenticationService.IsRequestValid(requestBody, hmacHeader);
            //if (!isValidRequest)
            //{
            //    return Unauthorized(); // Return 401 Unauthorized if authentication fails
            //}

            // Process the webhook payload
            // Example: Save payload to database, trigger some business logic, etc.
        var products = await _context.Products
                    .Select(p => new ProductDto
                    {
                        ProductId = p.ProductId,
                        BarcodeId = p.BarcodeId,
                        Name = p.Name,
                        Description = p.Description,
                        // Map other properties as needed
                    })
                    .ToListAsync();

                return products;
            }

            // GET: api/Products/5
            [HttpGet("{id}")]
            public async Task<ActionResult<ProductDto>> GetProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                var productDto = new ProductDto
                {
                    ProductId = product.ProductId,
                    BarcodeId = product.BarcodeId,
                    Name = product.Name,
                    Description = product.Description,
                    // Map other properties as needed
                };

                return productDto;
            }

            // PUT: api/Products/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
            {
                if (id != productDto.ProductId)
                {
                    return BadRequest();
                }

                // Validate productDto
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = new Product
                {
                    ProductId = productDto.ProductId,
                    BarcodeId = productDto.BarcodeId,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    // Map other properties as needed
                };

                _context.Entry(product).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto productDto)
            {
            string requestBody;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
            }

            // Log the received webhook payload (optional)

            try
            {
                // Parse the request payload (assuming JSON format)
                // You can deserialize the JSON payload into a strongly typed object or process it directly
                // Example: var webhookEvent = JsonConvert.DeserializeObject<ShopifyWebhookEvent>(requestBody);

                // Process the webhook event based on its type
                // Example: if (webhookEvent.EventType == "orders/paid")
                //              ProcessOrderPaidEvent(webhookEvent);
                //          else if (webhookEvent.EventType == "orders/fulfilled")
                //              ProcessOrderFulfilledEvent(webhookEvent);

                // Respond with HTTP status 200 OK to acknowledge receipt of the webhook
                return Ok();
            }
            catch (Exception ex)
            {
                // Respond with HTTP status 500 Internal Server Error if an error occurs during processing
                return StatusCode(500);
            }

            // Validate productDto
            if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = new Product
                {
                    BarcodeId = productDto.BarcodeId,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    // Map other properties as needed
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Update productDto with generated ProductId
                productDto.ProductId = product.ProductId;

                return CreatedAtAction("GetProduct", new { id = product.ProductId }, productDto);
            }

            // DELETE: api/Products/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ProductExists(int id)
            {
                return _context.Products.Any(e => e.ProductId == id);
            }
        }
    
}
