using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMSProject.Models;

namespace OMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly Repository _context;

        public OrderItemsController(Repository context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public IEnumerable<OrderItems> GetOrderItems()
        {
            return _context.OrderItems;
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);

            if (orderItems == null)
            {
                return NotFound();
            }

            return Ok(orderItems);
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems([FromRoute] int id, [FromBody] OrderItems orderItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemsExists(id))
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

        // POST: api/OrderItems
        [HttpPost]
        public async Task<IActionResult> PostOrderItems([FromBody] OrderItems orderItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderItems.Add(orderItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItems", new { id = orderItems.Id }, orderItems);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return Ok(orderItems);
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }

        [HttpGet]
        [Route("GetByOrderID/{OrderId}")]
        public List<OrderItems> GetByOrderId([FromRoute] int OrderId)
        {

            return _context.OrderItems.Where(o => o.Order.Id == OrderId).ToList();
        }
    }
}