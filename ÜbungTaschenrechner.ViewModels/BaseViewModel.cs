using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ÜbungTaschenrechner.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged                  //  Benachrichtigt Clients, dass sich ein Eigenschaftswert geändert hat.
    {

        public event PropertyChangedEventHandler PropertyChanged;        //     Tritt ein, wenn sich ein Eigenschaftswert ändert.



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")             
        {
            if (!string.IsNullOrEmpty(propertyName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            //Invoke is selectet or not
        }
    }
}
