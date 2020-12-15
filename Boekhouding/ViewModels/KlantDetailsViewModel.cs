using Boekhouding.Models;
using Boekhouding.Services;
using Boekhouding.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boekhouding.ViewModels
{
    public class KlantDetailsViewModel : ObservableObject          /* needs to be adapted to only the data we need, right now it's a copy of KlantenViewModel*/
    {
        //wat heb ik nodig om het te kunnen tonen?
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<Klant> _klanten;
        private Klant _selectedKlant;

        //stap1
        public KlantDetailsViewModel(IBoekhoudingDataService dataService)            //constructor met parameter : Wat wil je tonen?
        {
            _dataService = dataService;
            Klanten = new ObservableCollection<Klant>(dataService.GeefAlleKlanten());       //opvragen van klanten via constructor

            //relaycommands voor de buttons worden hier geinitialiseerd --> hierna methode aanmaken in LeveranciersViewModel klasse (use generate method)
            AddKlantCommand = new RelayCommand(VoegKlantToe);
            UpdateKlantCommand = new RelayCommand(WijzigKlant);
            DeleteKlantCommand = new RelayCommand(VerwijderKlant);
        }

        //hoe geraak je aan alles dat je wilt tonen?
        public ObservableCollection<Klant> Klanten          //Lijst van klanten is public property die moet binden met vb listbox
        {
            get { return _klanten; }
            set { OnPropertyChanged(ref _klanten, value); }
        }
        public Klant SelectedKlant                          //prop moet binden op selected item op control
        {
            get { return _selectedKlant; }
            set { OnPropertyChanged(ref _selectedKlant, value); }
        }

        


        //ook aanvullen in IMockBoekhoudingDataService en IDataService voor de bewerking dat je met de buttons doet via relaycommand
        private void VoegKlantToe()
        {
            /*throw new NotImplementedException();    */    //deze lijn vervangen


            //contactnummer checken want gaf foutmelding
            Klant klant = new Klant() { ContactNr = _klanten[0].ContactNr, Familienaam = "Aguilera", BTWNr = "N/A", Straat = "N/A", Postcode = 0000, Gemeente = "N/A" };
            Klanten = new ObservableCollection<Klant>(_dataService.VoegKlantToe(klant));
            SelectedKlant = Klanten[Klanten.Count - 1];
        }

        private void WijzigKlant()    //check
        {
            _dataService.WijzigKlant(SelectedKlant);
        }

        private void VerwijderKlant()
        {

            Klanten = new ObservableCollection<Klant>(_dataService.VerwijderKlant(SelectedKlant));
            if (_klanten.Count > 0) SelectedKlant = _klanten[0];
        }


        //public properties voor de buttons
        public ICommand AddKlantCommand { get; private set; }
        public ICommand DeleteKlantCommand { get; private set; }
        public ICommand UpdateKlantCommand { get; private set; }

    }
}
