using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boekhouding.Utilities
{
    public class ObservableObject : INotifyPropertyChanged          /*gebruiken voor 2way binding --> communicatie --> implementeert user interface*/
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;
            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

       //alle classes in de folder Models worden afgeleid van ObservableObject
       // alle classes in de folder ViewModels zijn ook child van ObservableObject
       // de usercontrols in Views niet
    }
}
