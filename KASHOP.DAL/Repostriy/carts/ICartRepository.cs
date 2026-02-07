using KASHOP.DAL.Moadels.carts;
using KASHOP.DAL.Moadels.catgores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy.carts
{
    public  interface ICartRepository
    {
        Task<Cart> createAsync(Cart request);
        Task<List<Cart>> GetUserCartAsync(string userId);
        Task<Cart?> GetCartItemAsync(string userid, int productId);
        Task<Cart> UpdateAsync(Cart cart);
        Task ClearCartAsync(string userId);

    }
}
