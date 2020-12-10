using Boekhouding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Services
{
    public interface IBoekhoudingDataService
    {
        IList<AankoopFactuur> GeefAankoopDagboek();
        IList<KasVerrichting> GeefKasboek();
        IList<VerkoopFactuur> GeefVerkoopDagboek();

        IList<Klant> GeefAlleKlanten();
        IList<Leverancier> GeefAlleLeveranciers();

        IList<AankoopFactuur> VerwijderAankoopFactuur(AankoopFactuur factuur);
        IList<AankoopFactuur> VoegAankoopFactuurToe(AankoopFactuur factuur);
        void WijzigAankoopFactuur(AankoopFactuur nieuwefactuur);

        IList<VerkoopFactuur> VerwijderVerkoopFactuur(VerkoopFactuur factuur);
        IList<VerkoopFactuur> VoegVerkoopFactuurToe(VerkoopFactuur factuur);
        void WijzigVerkoopFactuur(VerkoopFactuur nieuwefactuur);

        IList<Leverancier> VoegLeverancierToe(Leverancier leverancier);
        void WijzigLeverancier(Leverancier leverancier);
        IList<Leverancier> VerwijderLeverancier(Leverancier leverancier);

        IList<Klant> VoegKlantToe(Klant klant);
        void WijzigKlant(Klant klant);
        IList<Klant> VerwijderKlant(Klant klant);
        //verder aan te vullen ok
    }
}
