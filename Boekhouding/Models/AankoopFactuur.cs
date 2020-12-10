using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Models
{
    public class AankoopFactuur : Factuur       //gebaseerd op kasverrichting, check of moet aangepast worden
    {
        public string Betaalwijze { get; set; }
        public string Type { get; set; }
    }
}
