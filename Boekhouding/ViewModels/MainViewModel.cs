using Boekhouding.Services;
using Boekhouding.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;         //for using relaycommand

namespace Boekhouding.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private IBoekhoudingDataService _dataService;
        private KlantenViewModel _klantenVM;
        private KasBoekViewModel _kasBoekVM;
        private LeveranciersViewModel _leveranciersVM;
        private AankoopDagboekViewModel _aankoopDagboekVM;
        private VerkoopDagboekViewModel _verkoopDagboekVM;
        private OverzichtViewModel _overzichtVM;

        

        public MainViewModel()
        {
            _dataService = new MockBoekhoudingDataService();
            KlantenVM = new KlantenViewModel(_dataService);         //object aanmaken van klantenVM anders gaat null zijn, moet _dataService doorgeven (nodig om klanten op te halen)             
            KasBoekVM = new KasBoekViewModel(_dataService);
            LeveranciersVM = new LeveranciersViewModel(_dataService);       //object aanmaken van leveranciersVM
        }

        //dan deze KlantenViewModel property binden aan de datacontext van de KlantenView usercontrol
        public KlantenViewModel KlantenVM
        {
            get { return _klantenVM; }
            set { OnPropertyChanged(ref _klantenVM, value); }
        }
        //dan deze LeveranciersVM property binden aan datacontext van LeveranciersView usercontrol
        public LeveranciersViewModel LeveranciersVM
        {
            get { return _leveranciersVM; }
            set { OnPropertyChanged(ref _leveranciersVM, value); }
        }

        public AankoopDagboekViewModel AankoopDagboekVM
        {
            get { return _aankoopDagboekVM; }
            set { OnPropertyChanged(ref _aankoopDagboekVM, value); }
        }
        public VerkoopDagboekViewModel VerkoopDagboekVM
        {
            get { return _verkoopDagboekVM; }
            set { OnPropertyChanged(ref _verkoopDagboekVM, value); }
        }

        public KasBoekViewModel KasBoekVM
        {
            get { return _kasBoekVM; }
            set { OnPropertyChanged(ref _kasBoekVM, value); }
        }
        public OverzichtViewModel OverzichtVM
        {
            get { return _overzichtVM; }
            set { OnPropertyChanged(ref _overzichtVM, value); }
        }
        //code aanvullen met public properties voor LeveranciersVM,  AankoopDagboekVM, VerkoopDagboekVM en OverzichtVM
    }
}
