using KASHOP.DAL.DATA;
using KASHOP.DAL.Moadels;
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

        public Categores create(Categores request)
        {
            _context.Add(request);
            _context.SaveChanges();
            return request;


        }

        public List<Categores> Getall()
        {
            return _context.Catgores.Include(c => c.translations).ToList();
        }
    }
}
