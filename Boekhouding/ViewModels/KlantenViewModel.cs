using Boekhouding.Models;        //ook nodig, anders kan je Klant niet gebruiken
using Boekhouding.Services;     //ook nodig
using Boekhouding.Utilities;    //ook nodig
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;   //nodig voor observable collection
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.ViewModels
{
    public class KlantenViewModel : ObservableObject
    {
        //wat heb ik nodig om het te kunnen tonen?
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<Klant> _klanten;
        private Klant _selectedKlant;

        //stap1
        public KlantenViewModel(IBoekhoudingDataService dataService)            //constructor met parameter : Wat wil je tonen?
        {
            _dataService = dataService;
            Klanten = new ObservableCollection<Klant>(dataService.GeefAlleKlanten());       //opvragen van klanten via constructor
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
    }
}
