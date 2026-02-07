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

        public async  Task<Cart> createAsync(Cart request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
