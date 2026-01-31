using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Moadels
{
    public class Product:Basemodels
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public string MainImage { get; set; }

        public int CategoryId { get; set; }
        public Categores Category { get; set; }

        public List<ProductTranslation> Translations { get; set; }
    }
}
