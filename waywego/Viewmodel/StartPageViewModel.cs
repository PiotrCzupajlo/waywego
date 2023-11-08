using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using waywego.Desktop;
using waywego.Mobile;

namespace waywego.Viewmodel
{
    public partial class StartPageViewModel : ObservableObject
    {
        public INavigation _navigation;
        public StartPageViewModel(INavigation navigation) { 
        _navigation = navigation;
        }

        public virtual async Task<int> LogIn() {
        await Task.Delay(1000);
            return 0;
        
        }
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;


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
