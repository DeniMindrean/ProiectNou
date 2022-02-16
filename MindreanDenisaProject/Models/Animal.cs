using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindreanDenisaProject.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public int TipAnimalID { get; set; }
        public int AdapostID { get; set; }
        public DateTime Data_Nasterii { get; set; }


        public TipAnimal TipAnimal { get; set; }
        public Adapost Adapost { get; set; }
    }
}
