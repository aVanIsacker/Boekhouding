using Boekhouding.Models;           //nodig voor aankoop
using Boekhouding.Services;         //nodig voor iboekhoudingdataservice
using Boekhouding.Utilities;        //nodig voor observable object
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;       // nodig voor observable collection
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.ViewModels
{
    public class AankoopDagboekViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataservice;
        private ObservableCollection<AankoopFactuur> _aankoop;
        private AankoopFactuur _selectedAankoop;

        

        public AankoopDagboekViewModel(IBoekhoudingDataService dataService)
        {
            _dataservice = dataService;
            _aankoop = new ObservableCollection<AankoopFactuur>(dataService.GeefAankoopDagboek());
        }
        public ObservableCollection<AankoopFactuur> Aankoop
        {
            get { return _aankoop; }
            set { OnPropertyChanged(ref _aankoop, value); }
        }

        public AankoopFactuur SelectedAankoop
        {
            get { return _selectedAankoop; }
            set { OnPropertyChanged(ref _selectedAankoop, value); }
        }


    }
}
