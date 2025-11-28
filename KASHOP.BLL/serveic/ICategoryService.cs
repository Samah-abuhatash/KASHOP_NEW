using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic
{
    public interface ICategoryService
    {
        List<Responsecategory> Getall_categres();
        Responsecategory createl_categres(CategoryRequest request);
    }
}
