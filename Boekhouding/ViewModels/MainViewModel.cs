using Boekhouding.Services;
using Boekhouding.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private IBoekhoudingDataService _dataService;
        private KlantenViewModel _klantenVM;
        private KasBoekViewModel _kasBoekVM;
        //private LeveranciersViewModel _leveranciersVM;

        //private AankoopDagBoekViewModel _aankoopDagboekVM;
        //private VerkoopDagBoekViewModel _verkoopDagboekVM;
        //private OverzichtViewModel _overzichtVM;
        public MainViewModel()
        {
            _dataService = new MockBoekhoudingDataService();
            KlantenVM = new KlantenViewModel(_dataService);         //object aanmaken van klantenVM anders gaat null zijn, moet _dataService doorgeven (nodig om klanten op te halen)             
            KasBoekVM = new KasBoekViewModel(_dataService);
        }

                                                //dan deze KlantenViewModel property binden aan de datacontext van de KlantenView usercontrol
        public KlantenViewModel KlantenVM
        {
            get { return _klantenVM; }
            set { OnPropertyChanged(ref _klantenVM, value); }
        }
        public KasBoekViewModel KasBoekVM
        {
            get { return _kasBoekVM; }
            set { OnPropertyChanged(ref _kasBoekVM, value); }
        }
        //code aanvullen met public properties voor LeveranciersVM,  AankoopDagboekVM, VerkoopDagboekVM en OverzichtVM
    }
}
