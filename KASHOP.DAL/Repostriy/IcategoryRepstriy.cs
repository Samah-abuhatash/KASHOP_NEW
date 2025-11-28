using KASHOP.DAL.Moadels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repostriy
{
    public  interface IcategoryRepstriy
    {
        List<Categores> Getall();
        Categores create(Categores request);
    }

}
