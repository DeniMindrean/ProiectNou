using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindreanDenisaProject.Models
{
    public class Adapost
    {
        public int ID { get; set; }
        public int OrasID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }

        public Oras Oras { get; set; }
    }
}
