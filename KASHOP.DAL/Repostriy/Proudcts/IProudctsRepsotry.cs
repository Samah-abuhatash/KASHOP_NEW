using KASHOP.DAL.Moadels.Proudct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy.Proudcts
{
    public interface IProudctsRepsotry
    {
        Task<Product> AddAsync(Product product);

    }
}
