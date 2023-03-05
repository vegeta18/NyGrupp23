using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellager
{
    public class Faktura
    {
        public int FakturaID { get; set; } 
        public decimal Summa { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public DateTime FakturaSlutDatum { get; set; }
        public Bokning Bokning { get; set; }
        public Böcker Böcker { get; set; }  
    }
}
