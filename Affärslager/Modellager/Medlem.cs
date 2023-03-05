using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellager
{
    public class Medlem
    {
        public int MedlemsID { get; set; } 
        public string Namn { get; set; }
        public int Telefonnummer { get; set; }
        public string Epost { get; set; }   

        public Bokning Bokning { get; set; }    
    }
}
