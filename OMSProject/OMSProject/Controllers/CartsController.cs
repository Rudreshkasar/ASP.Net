﻿using System;
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
    public class CartsController : ControllerBase
    {
        private readonly Repository _context;

        public CartsController(Repository context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        [Route("GetCart")]
        public IEnumerable<Cart> GetCart()
        {
            return _context.Cart;
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart([FromRoute] int id, [FromBody] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [HttpPost]
        [Route("PostCart")]
        public async Task<IActionResult> PostCart([FromBody] Cart cart)
        {
            Users u = new Users();
            Products p = new Products();
            u.Id = cart.User.Id;
            p.Id = cart.Product.Id;
            cart.User.Id = u.Id;
            cart.Product.Id = p.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok(cart);
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }

        [HttpGet]
        [Route("Cart/{UserID}")]
        public List<Cart> GetByUId([FromRoute] int UserId)
        {

            return _context.Cart.Where(c => c.User.Id == UserId).ToList();
        }
    }
}