using KASHOP.DAL.Moadels.catgores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTOS.Response.catgores
{
    public  class Responsecategory
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]

        public Status status { get; set; }
        public string CreatedBy { get; set; }
      //  public string userName {  get; set; }
        public List<Responsetarnslation> translations { get; set; }

    }
}
