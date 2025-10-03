using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swagger.API.Models;

namespace Swagger.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly SwagerDbContext _context;

		public ProductsController(SwagerDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Bu endpoint tüm ürünleri list olarak geri döner.
		/// </summary>
		/// <remarks>
		/// örnek: https://localhost:44388/api/products
		/// </remarks>
		/// <returns></returns>
		/// <response code="404">verilen id'ye sahip ürün bulunamadı</response>
		/// <response code="200">verilen id'ye sahip ürün var</response>
		[Produces("application/json")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			return await _context.Products.ToListAsync();
		}

		/// <summary>
		/// Bu entpoint verilen idye sahip ürünü döner,
		/// </summary>
		/// <param name="id">ürünün id'si</param>
		/// <returns></returns>
		[Produces("application/json")]

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);

			if (product == null)
			{
				return NotFound();
			}

			return product;
		}

		// PUT: api/Products/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(int id, Product product)
		{
			if (id != product.Id)
			{
				return BadRequest();
			}

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

		/// <summary>
		/// Bu endpoin ürünekler
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		[Consumes("application/json")]
		[Produces("application/json")]
		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(Product product)
		{
			product.Date = DateTime.Now;
			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetProduct", new { id = product.Id }, product);
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
			return _context.Products.Any(e => e.Id == id);
		}
	}
}
