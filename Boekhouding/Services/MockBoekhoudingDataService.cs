using Boekhouding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Services
{
    public class MockBoekhoudingDataService : IBoekhoudingDataService
    {
        #region fields
        private IList<Klant> _klanten;
        private IList<Leverancier> _leveranciers;
        private IList<AankoopFactuur> _aankoopDagboek;
        private IList<VerkoopFactuur> _verkoopDagboek;
        private IList<KasVerrichting> _kasboek;
        #endregion

        //constructor:
        public MockBoekhoudingDataService()
        {
            InitLijsten();
        }
        private void InitLijsten()
        {
            InitKlanten();
            InitLeveranciers();
            InitAankoopDagBoek();
            InitVerkoopDagBoek();
            InitKasBoek();
        }

        private void InitLeveranciers()
        {
            _leveranciers = new List<Leverancier>()
            {
                new Leverancier(){ ContactNr=6, NaamBedrijf="Bedrijf A", BTWNr="00014578441", Straat="Bedrijfstraat 1", Postcode=9000,Gemeente="Gent" },
                new Leverancier(){ ContactNr=7, NaamBedrijf="Bedrijf B", BTWNr="0008965321",Straat="Bedrijfstraat 2",Postcode=8500,Gemeente="Brugge"}
            };
        }

        private void InitKlanten()
        {
            _klanten = new List<Klant>()
            {
                new Klant(){ ContactNr=1,Voornaam = "Jan", Familienaam="Jansen", BTWNr="", Straat="Kerkstraat 8", Postcode=9000,Gemeente="Gent" },
                new Klant(){ ContactNr=2,Voornaam="Piet", Familienaam="Pieters", BTWNr="12345647",Straat="Molenstraat 10",Postcode=8500,Gemeente="Brugge"},
                new Klant(){ ContactNr=3,Voornaam="Joris", Familienaam="Joris", BTWNr="12345648",Straat="Molenstraat 1",Postcode=8500,Gemeente="Brugge"},
                new Klant(){ ContactNr=4,Voornaam="Korneel", Familienaam="Kornelis", BTWNr="",Straat="Molenstraat 2",Postcode=8500,Gemeente="Brugge"},
                new Klant(){ ContactNr=5,Voornaam="Jos", Familienaam="De Klos", BTWNr="",Straat="Molenstraat 3",Postcode=8500,Gemeente="Brugge"}
            };
        }

        private void InitKasBoek()
        {
            _kasboek = new List<KasVerrichting>(){
                new KasVerrichting() {  UniekNr = "14001", FactuurDatum = new DateTime(2020,1,13), Type="Bedrijfskosten", Omschrijving="Benzine",Contact=_klanten[0], BedragExclBTW=60.0,  BTWTarief=21},
                new KasVerrichting() {  UniekNr = "14002", FactuurDatum = new DateTime(2020,1,30), Contact=_klanten[0]}, //Verder aan te vullen
                new KasVerrichting() {  UniekNr = "14003", FactuurDatum = new DateTime(2020,2,1), Contact=_klanten[1]},//Verder aan te vullen
                new KasVerrichting() {  UniekNr = "14004", FactuurDatum = new DateTime(2020,2,25), Contact=_klanten[1]}//Verder aan te vullen
            };
        }

        private void InitVerkoopDagBoek()
        {
            //Verder aan te vullen
        }

        private void InitAankoopDagBoek()
        {
            //Verder aan te vullen
        }

        //om de lijsten te geven
        public IList<Klant> GeefAlleKlanten()
        {
            return _klanten;
        }
        public IList<Leverancier> GeefAlleLeveranciers()
        {
            return _leveranciers;
        }

        public IList<AankoopFactuur> GeefAankoopDagboek()
        {
            return _aankoopDagboek;
        }

        public IList<VerkoopFactuur> GeefVerkoopDagboek()
        {
            return _verkoopDagboek;
        }
        public IList<KasVerrichting> GeefKasboek()
        {
            return _kasboek;
        }

        //om aankoopfacturen aan te passen
        public IList<AankoopFactuur> VoegAankoopFactuurToe(AankoopFactuur factuur)
        {
            _aankoopDagboek.Add(factuur);
            return _aankoopDagboek;
        }
        public void WijzigAankoopFactuur(AankoopFactuur nieuwefactuur)
        {

            int index = _aankoopDagboek.IndexOf(nieuwefactuur);
            if (index >= 0)
            {
                _aankoopDagboek[index] = nieuwefactuur;
            }
        }
        public IList<AankoopFactuur> VerwijderAankoopFactuur(AankoopFactuur factuur)
        {
            _aankoopDagboek.Remove(factuur);
            return _aankoopDagboek;
        }

        //om leveranciers aan te passen
        public IList<Leverancier> VoegLeverancierToe(Leverancier leverancier)
        {
            int ContactNr = (_leveranciers.Count > 0) ? _leveranciers.Max(b => b.ContactNr) + 1 : 1;
            leverancier.ContactNr = ContactNr;
            _leveranciers.Add(leverancier);
            return _leveranciers;
        }
        public void WijzigLeverancier(Leverancier nieuwLeverancier)
        {
            int index = _leveranciers.IndexOf(nieuwLeverancier);
            if (index >= 0)
            {
                _leveranciers[index] = nieuwLeverancier;
            }
        }
        public IList<Leverancier> VerwijderLeverancier(Leverancier leverancier)
        {
            _leveranciers.Remove(leverancier);
            return _leveranciers;
        }

        //Verder aan te vullen



    }
}
