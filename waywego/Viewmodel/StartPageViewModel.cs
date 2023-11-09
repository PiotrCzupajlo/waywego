using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using waywego.Desktop;
using waywego.Mobile;

namespace waywego.Viewmodel
{
    public partial class StartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation _navigation;

        public string Username { get; set; }

        public string Password {get;set;}
        public StartPageViewModel() { }
        public StartPageViewModel(INavigation navigation) { 
        _navigation = navigation;
        }

        public virtual async Task<int> LogIn() {
        await Task.Delay(1000);
            return 0;
        
        }
        //changing page after clicking login button and login sys ofc
        [RelayCommand]
        private async void NavigateToLoggedPage() {


#if WINDOWS
            await LogIn();
            await _navigation.PushAsync(new DesktopLoggedPage());
#else
            await _navigation.PushAsync(new AndroidLoggedPage());
#endif

        }


    }
}
