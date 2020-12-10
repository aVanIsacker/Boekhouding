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
        private ObservableCollection<AankoopFactuur> _aankoopDagboek;       //nodig voor de 2way binding
        private AankoopFactuur _selectedAankoop;

        

        public AankoopDagboekViewModel(IBoekhoudingDataService dataService)
        {
            _dataservice = dataService;
            _aankoopDagboek = new ObservableCollection<AankoopFactuur>(dataService.GeefAankoopDagboek());
        }
        public ObservableCollection<AankoopFactuur> AankoopDagboek      //public property dat zich moet binden aan bv datagrid
        {
            get { return _aankoopDagboek; }
            set { OnPropertyChanged(ref _aankoopDagboek, value); }
        }

        public AankoopFactuur SelectedAankoop       //SelectedAankoop property moet binden aan selected item op control
        {
            get { return _selectedAankoop; }
            set { OnPropertyChanged(ref _selectedAankoop, value); }
        }


    }
}
