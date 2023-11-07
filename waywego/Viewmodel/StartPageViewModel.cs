using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using waywego.Desktop;
using waywego.Mobile;

namespace waywego.Viewmodel
{
    public partial class StartPageViewModel
    {
        public INavigation _navigation;
        public StartPageViewModel(INavigation navigation) { 
        _navigation = navigation;
        }
        [RelayCommand]
        private async void NavigateToLoggedPage() {


#if WINDOWS
            await _navigation.PushAsync(new DesktopLoggedPage());
#else
            await _navigation.PushAsync(new AndroidLoggedPage());
#endif

        }


    }
}
