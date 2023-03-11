using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellager
{
    public class Expidit
    {
        [Key]
        public int AnställningsNr { get; set; }
        public string Roll { get; set; }
        public string Namn { get; set; }
        public string Lösenord { get; set; }

        public bool VerifyPassword(string input)
        {
            return Lösenord == input;
        }

    }
}
