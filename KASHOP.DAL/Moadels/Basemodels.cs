using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Moadels
{
    public  class Basemodels
    {

        public int Id { get; set; }

        public Status status { get; set; }
        public DateTime CreatedAT { get; set; }
    }
}
