using KASHOP.DAL.Moadels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DATA
{
    public  class ApplicationDbContext : DbContext
    {
        public DbSet<Categores> Catgores { get; set; }
        public DbSet<CategoryTranslation> transelation { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

       
    }
}

