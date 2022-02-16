using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MindreanDenisaProject.Models
{
    public class Oras
    {
        public int ID { get; set; }
        public string Nume { get; set; }

        public ICollection<Adapost> Adaposturi { get; set; }


    }
}
