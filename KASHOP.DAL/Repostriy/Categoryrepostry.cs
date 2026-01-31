using KASHOP.DAL.DATA;
using KASHOP.DAL.Moadels.catgores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy
{
    public class Categoryrepostry: IcategoryRepstriy
    {
        private readonly ApplicationDbContext _context;

        public Categoryrepostry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<Categores> createAsync(Categores request)
        {
             await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;


        }

        public async Task<List<Categores>> GetAllAsync()
        {
            return await _context.Catgores
                .Include(c => c.translations)
                .Include(c => c.User)
                .ToListAsync();
        }
        public async Task<Categores?> FindByIdAsync(int id)
        {
            return await _context.Catgores
                .Include(c => c.translations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task DeleteAsync(Categores category)
        {
            _context.Catgores.Remove(category);
            await _context.SaveChangesAsync();
        }
        public async Task<Categores?> UpdateAsync(Categores category)
        {
            _context.Catgores.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
