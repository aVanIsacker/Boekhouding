
using Boekhouding.Models;       // nodig voor overzichtverrichting
using Boekhouding.Services;     //nodig voor iboekhouding dataservice
using Boekhouding.Utilities;    //nodig voor observableObject
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;   //nodig voor observable collection
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.ViewModels
{
    public class OverzichtViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<Totaaloverzicht> _overzicht;
        private Totaaloverzicht _selectedOverzicht;
        public OverzichtViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            //_overzicht = new ObservableCollection<Totaaloverzicht>(dataService.GeefOverzicht());
        }
        public ObservableCollection<Totaaloverzicht> Overzicht
        {
            get { return _overzicht; }
            set { OnPropertyChanged(ref _overzicht, value); }
        }
        public Totaaloverzicht SelectedKasVerrichting
        {
            get { return _selectedOverzicht; }
            set { OnPropertyChanged(ref _selectedOverzicht, value); }
        }
    }
}
