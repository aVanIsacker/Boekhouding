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
        private ObservableCollection<VerkoopFactuur> _verkoop;      //nodig voor de 2way binding
        private VerkoopFactuur _selectedVerkoop;

        
        public VerkoopDagboekViewModel(IBoekhoudingDataService dataService)
        {
            _dataservice = dataService;
            _verkoop = new ObservableCollection<VerkoopFactuur>(dataService.GeefVerkoopDagboek());
        }
        public ObservableCollection<VerkoopFactuur> Verkoop
        {
            get { return _verkoop; }
            set { OnPropertyChanged(ref _verkoop, value); }            
        }

        public VerkoopFactuur SelectedVerkoop
        {
            get { return _selectedVerkoop; }
            set { OnPropertyChanged(ref _selectedVerkoop, value); }
        }

    
    }
}
