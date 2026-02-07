using KASHOP.DAL.DATA;
using KASHOP.DAL.Moadels.carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy.carts
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //add 
        public async  Task<Cart> createAsync(Cart request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
        //get information all
        public  async Task<List<Cart>> GetUserCartAsync(string userId)
        {
            return await _context.carts
        .Where(c => c.UserId == userId)
        .Include(c => c.Product)
        .ThenInclude(c => c.Translations)
        .ToListAsync();


        }
        //cart proudct found or not 
        public async Task<Cart?> GetCartItemAsync(string userid, int productId)
        {
            return await _context.carts.Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.UserId == userid && c.ProductId == productId);
        }
        public async Task<Cart> UpdateAsync(Cart cart)
        {
            _context.carts.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
        public async Task ClearCartAsync(string userId)
        {
            var items = await _context.carts.Where(c => c.UserId == userId).ToListAsync();
            _context.carts.RemoveRange(items);

            await _context.SaveChangesAsync();
        }
    }
}
