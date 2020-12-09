using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Models
{
    public class KasVerrichting : Factuur
    {

        public string Betaalwijze { get; set; }
        public string Type { get; set; }
    }
}
