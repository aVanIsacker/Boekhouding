using Boekhouding.Models;       //ook nodig, anders kan je kasboek niet gebruiken
using Boekhouding.Services;     //nodig voor IBoekhoudingDataService
using Boekhouding.Utilities;        // nodig voor observable Object
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;       //nodig voor observable collections
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.ViewModels
{
    public class KasBoekViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<KasVerrichting> _kasboek;
        private KasVerrichting _selectedKasVerrichting;

       

        public KasBoekViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            _kasboek = new ObservableCollection<KasVerrichting>(dataService.GeefKasboek());     //opvragen van kasboek via constructor
        }
        public ObservableCollection<KasVerrichting> KasBoek     //kasboek public property dat zich moet binden aan bijvoorbeeld Datagrid
        {
            get { return _kasboek; }
            set { OnPropertyChanged(ref _kasboek, value); }
        }
        public KasVerrichting SelectedKasVerrichting            //property moet binden aan selected item op control
        {
            get { return _selectedKasVerrichting; }
            set { OnPropertyChanged(ref _selectedKasVerrichting, value); }
        }
    }
}
