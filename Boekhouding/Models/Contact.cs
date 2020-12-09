using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Models
{
    public class Contact
    {
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public string BTWNr { get; set; }
        public int ContactNr { get; set; }
    }
}
