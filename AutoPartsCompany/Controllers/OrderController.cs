using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPartsCompany.Models;
using ProductsCompany.Models;

namespace AutoPartsCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProductsDBContext _context;

        public OrderController(ProductsDBContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrderModel()
        {
            return await _context.OrderModel.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderModel(int id)
        {
            var OrderModel = await _context.OrderModel.FindAsync(id);

            if (OrderModel == null)
            {
                return NotFound();
            }

            return OrderModel;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderModel(int id, OrderModel OrderModel)
        {
            if (id != OrderModel.IdOrder)
            {
                return BadRequest();
            }

            _context.Entry(OrderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModelExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrderModel>> PostOrderModel(OrderModel OrderModel)
        {
            _context.OrderModel.Add(OrderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderModel", new { id = OrderModel.IdOrder }, OrderModel);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> DeleteOrderModel(int id)
        {
            var OrderModel = await _context.OrderModel.FindAsync(id);
            if (OrderModel == null)
            {
                return NotFound();
            }

            _context.OrderModel.Remove(OrderModel);
            await _context.SaveChangesAsync();

            return OrderModel;
        }

        private bool OrderModelExists(int id)
        {
            return _context.OrderModel.Any(e => e.IdOrder == id);
        }
    }
}
