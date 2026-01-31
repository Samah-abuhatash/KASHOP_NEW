using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Moadels
{
    public class Categores: Basemodels
    {
        
        public List<CategoryTranslation> translations { get; set; }
        public List<Product>products { get; set; }

    }
}
