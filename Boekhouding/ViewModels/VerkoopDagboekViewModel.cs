using Boekhouding.Models;       //nodig voor de Verkoop
using Boekhouding.Services;     //nodig voor IBoekhoudingDataService
using Boekhouding.Utilities;    //nodig voor ObservableObjects
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;       // nodig voor observable colleciton
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.ViewModels
{
    public class VerkoopDagboekViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataservice;
        private ObservableCollection<VerkoopFactuur> _verkoopDagboek;      //nodig voor de 2way binding
        private VerkoopFactuur _selectedVerkoop;

        
        public VerkoopDagboekViewModel(IBoekhoudingDataService dataService)
        {
            _dataservice = dataService;
            _verkoopDagboek = new ObservableCollection<VerkoopFactuur>(dataService.GeefVerkoopDagboek());
        }
        public ObservableCollection<VerkoopFactuur> VerkoopDagboek     //public property dat zich moet binden aan bijvoorbeeld Datagrid
        {
                get { return _verkoopDagboek; }
                set { OnPropertyChanged(ref _verkoopDagboek, value); }            
        }

        public VerkoopFactuur SelectedVerkoop       //SelectedVerkoop property moet binden aan selected item op control
        {
            get { return _selectedVerkoop; }
            set { OnPropertyChanged(ref _selectedVerkoop, value); }
        }

    
    }
}
