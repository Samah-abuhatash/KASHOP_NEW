using KASHOP.DAL.DATA;
using KASHOP.DAL.Moadels.catgores;
using KASHOP.DAL.Moadels.Proudct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy.Proudcts
{
    public class ProudctRepostry : IProudctsRepsotry
    {
        private readonly ApplicationDbContext _context;

        public ProudctRepostry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async  Task<Product> AddAsync(Product request )
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.products
                .Include(c => c.Translations)
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}
