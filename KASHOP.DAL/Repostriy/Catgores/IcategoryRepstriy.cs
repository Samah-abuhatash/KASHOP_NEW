using KASHOP.DAL.Moadels.catgores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy.Catgores
{
    public  interface IcategoryRepstriy
    {
         Task<List<Categores>> GetAllAsync();
         Task<Categores> createAsync(Categores request);
        Task<Categores?> FindByIdAsync(int id);
        Task DeleteAsync(Categores category);
        Task<Categores?> UpdateAsync(Categores category);
    }

}
