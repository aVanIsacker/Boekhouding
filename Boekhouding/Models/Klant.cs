using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Models
{
    public class Klant : Contact
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
    }
}
