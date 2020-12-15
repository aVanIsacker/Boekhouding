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

        private KlantDetailsViewModel _klantDetailsVM;

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
            //ToonKlantDetailsCommand = new RelayCommand(ZetKlantDetailsZichtbaar);
        }

        //private void ZetKlantDetailsZichtbaar()
        //{
        //    AankoopDagboekZichtbaar = false;
        //    VerkoopDagboekZichtbaar = true;
        //    KasboekZichtbaar = false;
        //    KlantDetailsZichtbaar = true;
        //}
        
        private void NietsZichtbaar()
        {
            AankoopDagboekZichtbaar = false;
            VerkoopDagboekZichtbaar = false;
            KasboekZichtbaar = false;
            KlantDetailsZichtbaar = false;
        }

        private void ZetKasboekZichtbaar()
        {
            AankoopDagboekZichtbaar = false;
            VerkoopDagboekZichtbaar = false;
            KasboekZichtbaar = true;
            KlantDetailsZichtbaar = false;
        }

        private void ZetVerkoopDagboekZichtbaar()
        {
            AankoopDagboekZichtbaar = false;
            VerkoopDagboekZichtbaar = true;
            KasboekZichtbaar = false;
            KlantDetailsZichtbaar = true;
        }

        private void ZetAankoopDagboekZichtbaar()
        {
            AankoopDagboekZichtbaar = true;
            VerkoopDagboekZichtbaar = false;
            KasboekZichtbaar = false;
            KlantDetailsZichtbaar = false;
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

        private bool _klantDetailsZichtbaar;
        public bool KlantDetailsZichtbaar
        {
            get { return _klantDetailsZichtbaar; }
            set { OnPropertyChanged(ref _klantDetailsZichtbaar, value); }
        }


        public ICommand ToonAankoopDagBoek { get; private set; }
        public ICommand ToonVerkoopDagBoek { get; private set; }
        public ICommand ToonKasBoek { get; private set; }
        public ICommand ToonNietsCommand { get; private set; }
        public ICommand ToonKlantDetailsCommand { get; private set; }
        


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

        public KlantDetailsViewModel KlantDetailsVM
        {
            get { return _klantDetailsVM; }
            set { OnPropertyChanged(ref _klantDetailsVM, value); }
        }
        
        //code aanvullen met public properties voor LeveranciersVM ok,  AankoopDagboekVM ok, VerkoopDagboekVM ok en OverzichtVM ok
    }
}
