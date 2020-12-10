using Boekhouding.Models;           //nodig voor leverancier
using Boekhouding.Services;         //nodig voor IBoekhoudingDataService
using Boekhouding.Utilities;        //nodig voor observableObject
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;   //nodig voor observable collection
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boekhouding.ViewModels
{
    public class LeveranciersViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<Leverancier> _leveranciers;
        private Leverancier _selectedLeverancier;

        public LeveranciersViewModel(IBoekhoudingDataService dataService)       //constructor met parameter
        {
            _dataService = dataService;
            Leveranciers = new ObservableCollection<Leverancier>(dataService.GeefAlleLeveranciers());       //opvragen van leverancier via constructor

            //relaycommands voor de buttons worden hier geinitialiseerd --> hierna methode aanmaken in LeveranciersViewModel klasse (use generate method)
            AddLeverancierCommand = new RelayCommand(VoegLeverancierToe);
            UpdateLeverancierCommand = new RelayCommand(WijzigLeverancier);
            DeleteLeverancierCommand = new RelayCommand(VerwijderLeverancier);


        }

        
      
        //ook aanvullen in IMockBoekhoudingDataService en IDataService voor de bewerking dat je met de buttons doet via relaycommand
        private void VoegLeverancierToe()
        {
            /*throw new NotImplementedException();    */    //deze lijn vervangen
        

            //contactnummer checken want gaf foutmelding
            Leverancier leverancier = new Leverancier() { ContactNr = _leveranciers[0].ContactNr, NaamBedrijf = "Nieuw Bedrijf", BTWNr = "N/A", Straat = "N/A", Postcode = 0000,Gemeente = "N/A" };
            Leveranciers = new ObservableCollection<Leverancier>(_dataService.VoegLeverancierToe(leverancier));
            SelectedLeverancier = Leveranciers[Leveranciers.Count - 1];
        }

        private void WijzigLeverancier()    //check
        {
            _dataService.WijzigLeverancier(SelectedLeverancier);
        }

        private void VerwijderLeverancier()
        {

            Leveranciers = new ObservableCollection<Leverancier>(_dataService.VerwijderLeverancier(SelectedLeverancier));
            if (_leveranciers.Count > 0) SelectedLeverancier = _leveranciers[0];
        }



        public ObservableCollection<Leverancier> Leveranciers       // lijst van leveranciers is een public property die moet binden met vb listbox
        {
            get { return _leveranciers; }
            set { OnPropertyChanged(ref _leveranciers, value); }
        }
        public Leverancier SelectedLeverancier                      //prop moet binden op selected item op control
        {
            get { return _selectedLeverancier; }
            set { OnPropertyChanged(ref _selectedLeverancier, value); }
        }

        //public properties voor de buttons
        public ICommand AddLeverancierCommand { get; private set; }
        public ICommand DeleteLeverancierCommand { get; private set; }
        public ICommand UpdateLeverancierCommand { get; private set; }
    }

}  