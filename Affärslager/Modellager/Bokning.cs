using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellager
{
    public class Bokning
    {
        public int BokningsID { get; set; }
        public DateTime StartDatum { get; set;  }
        public DateTime SlutDatum { get; set; }
        public DateTime ÅterlämningsDatum { get; set; }
        public List<Expidit> Expidit { get; set; }
        public List<Medlem> Medlem { get; set; }  
        public List<Böcker> Böckers { get; set; }
    }
}
