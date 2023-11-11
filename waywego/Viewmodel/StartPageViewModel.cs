using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using waywego.Desktop;
using waywego.Mobile;
using waywego.Model;

namespace waywego.Viewmodel
{
    public partial class StartPageViewModel : INotifyPropertyChanged
    {
        public Databasehandler Databasehandler;
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation _navigation;

        public string Username { get; set; }

        public string Password { get; set; }

        public string alertmessage;

        public string Alertmessage
        {
            get => alertmessage;
            set { 
            alertmessage= value;
                OnPropetyChanged(nameof(Alertmessage));
                
            }
        
        }
        public StartPageViewModel() { }
        public StartPageViewModel(INavigation navigation) { 
        _navigation = navigation;
            Databasehandler = new Databasehandler();
        }
       
        public async Task<int> LogIn() {
            var data = Databasehandler.loguser(Username, Password);
            DataTable dt = await data;
            int numberofrows = dt.Rows.Count;
            return numberofrows;
        
        }
        //changing page after clicking login button and login sys ofc
        [RelayCommand]
        private async void NavigateToLoggedPage() {


#if WINDOWS
            if (await LogIn() == 1)
                await _navigation.PushAsync(new DesktopLoggedPage());
            else
            {
                Alertmessage = "incorrect login or password";
            }
#else
            await _navigation.PushAsync(new AndroidLoggedPage());
#endif

        }
        void OnPropetyChanged([CallerMemberName] string propertyname = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));


    }
}
