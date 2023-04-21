using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppPraxis
{

    class MainWindowViewModel : INotifyPropertyChanged                  //event regestrieren
    {

        public MainWindowViewModel()
        {

            this.ClearCommand = new DelegateCommand(
               (o) => !String.IsNullOrEmpty(Firstname) && !String.IsNullOrEmpty(Lastname),
               (o) => { this.Firstname = ""; this.Lastname = ""; }
             );
            Firstname = "Dave";
            Lastname = "Daven";


        }

        public DelegateCommand ClearCommand { get; set; }

        string firstname;
        public string Firstname
        {
            get => firstname;
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged(nameof(Fullname));
                    this.ClearCommand.RaiseCanExecuteChanged();


                }
            }

        }
        string lastname;
        public string Lastname

        {
            get => lastname;
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged(nameof(Fullname));


                }
            }

        }



        //public string Firstname { get; set; }
        //public string Lastname { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";

        public event PropertyChangedEventHandler PropertyChanged;



        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

















}
