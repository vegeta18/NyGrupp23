using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellager
{
    public class Böcker
    {
        public string BokTitel { get; set; }
        [Key]
        public string ISBNnummer { get; set; }  
        
    }
}