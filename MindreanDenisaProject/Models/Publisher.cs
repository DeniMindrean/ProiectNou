using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindreanDenisaProject.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}
