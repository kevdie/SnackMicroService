using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPartsCompany.Models;
using ProductsCompany.Models;

namespace ProductsCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDBContext _context;

        public ProductsController(ProductsDBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsModel>>> GetProductsModel()
        {
            return await _context.ProductsModel.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsModel>> GetProductsModel(int id)
        {
            var ProductsModel = await _context.ProductsModel.FindAsync(id);

            if (ProductsModel == null)
            {
                return NotFound();
            }

            return ProductsModel;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsModel(int id, ProductsModel ProductsModel)
        {
            ProductsModel.IdProduct = id;

            _context.Entry(ProductsModel).State = EntityState.Modified;

            if (id != ProductsModel.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(ProductsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsModelExists(id))
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> PostProductsModel(ProductsModel ProductsModel)
        {
            _context.ProductsModel.Add(ProductsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsModel", new { id = ProductsModel.IdProduct }, ProductsModel);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsModel>> DeleteProductsModel(int id)
        {
            var ProductsModel = await _context.ProductsModel.FindAsync(id);
            if (ProductsModel == null)
            {
                return NotFound();
            }

            _context.ProductsModel.Remove(ProductsModel);
            await _context.SaveChangesAsync();

            return ProductsModel;
        }

        private bool ProductsModelExists(int id)
        {
            return _context.ProductsModel.Any(e => e.IdProduct == id);
        }
    }
}
