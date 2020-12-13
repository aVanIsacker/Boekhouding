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

        private KlantDetailsViewModel klantDetailsVM;

        public MainViewModel()
        {
            _dataService = new MockBoekhoudingDataService();
            KlantenVM = new KlantenViewModel(_dataService);         //object aanmaken van klantenVM anders gaat null zijn, moet _dataService doorgeven (nodig om klanten op te halen)             
            KasBoekVM = new KasBoekViewModel(_dataService);
            LeveranciersVM = new LeveranciersViewModel(_dataService);       //object aanmaken van leveranciersVM
            AankoopDagboekVM = new AankoopDagboekViewModel(_dataService);
            VerkoopDagboekVM = new VerkoopDagboekViewModel(_dataService);
            OverzichtVM = new OverzichtViewModel(_dataService);
            ToonAankoopDagBoek = new RelayCommand(ZetAankoopDagboekZichtbaar);
            ToonVerkoopDagBoek = new RelayCommand(ZetVerkoopDagboekZichtbaar);
            ToonKasBoek = new RelayCommand(ZetKasboekZichtbaar);
            //AankoopDagboekZichtbaar = true;
            ToonNietsCommand = new RelayCommand(NietsZichtbaar);
        }
        
        private void NietsZichtbaar()
        {
            AankoopDagboekZichtbaar = false;
            VerkoopDagboekZichtbaar = false;
            KasboekZichtbaar = false;
        }

        private void ZetKasboekZichtbaar()
        {
            AankoopDagboekZichtbaar = false;
            VerkoopDagboekZichtbaar = false;
            KasboekZichtbaar = true;
        }

        private void ZetVerkoopDagboekZichtbaar()
        {
            AankoopDagboekZichtbaar = false;
            VerkoopDagboekZichtbaar = true;
            KasboekZichtbaar = false;
        }

        private void ZetAankoopDagboekZichtbaar()
        {
            AankoopDagboekZichtbaar = true;
            VerkoopDagboekZichtbaar = false;
            KasboekZichtbaar = false;
        }
        
        private bool _aankoopDagboekZichtbaar;
        
        public bool AankoopDagboekZichtbaar
        {
            get { return _aankoopDagboekZichtbaar; }
            set { OnPropertyChanged(ref _aankoopDagboekZichtbaar, value);}
        }
        
        private bool _verkoopDagboekZichtbaar;
        
        public bool VerkoopDagboekZichtbaar {
            get { return _verkoopDagboekZichtbaar; }
            set { OnPropertyChanged(ref _verkoopDagboekZichtbaar, value); }
        }
        
        private bool _kasboekZichtbaar;
        
        public bool KasboekZichtbaar {
            get { return _kasboekZichtbaar; }
            set { OnPropertyChanged(ref _kasboekZichtbaar, value); }
        }
        public ICommand ToonAankoopDagBoek { get; private set; }
        public ICommand ToonVerkoopDagBoek { get; private set; }
        public ICommand ToonKasBoek { get; private set; }
        public ICommand ToonNietsCommand { get; private set; }


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

        
        //code aanvullen met public properties voor LeveranciersVM ok,  AankoopDagboekVM ok, VerkoopDagboekVM ok en OverzichtVM ok
    }
}
