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
        public string CreatedBy { get; set; }
       
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAT { get; set; }
    }
}
