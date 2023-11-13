using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace waywego.Viewmodel
{
    public partial class LoggedPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ColorConverter ColorConverter { get; set; }
        public INavigation _navigation { get; set; }
        public Microsoft.Maui.Graphics.Color purple = Microsoft.Maui.Graphics.Color.FromArgb("#6C63FF");
        public Microsoft.Maui.Graphics.Color grey = Microsoft.Maui.Graphics.Color.FromArgb("#666666");


        public LoggedPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            
        }
        public LoggedPageViewModel() { }


        public int tabopen;
        public int Tabopen {
            get => tabopen;
            set { 
            tabopen = value;
                OnPropetyChanged(nameof(Tabopen));
            
            }
        }
        #region buttonstates
        public int OverAllState { get; set; }
        public Microsoft.Maui.Graphics.Color btn1state = Microsoft.Maui.Graphics.Color.FromArgb("#6C63FF");
        public Microsoft.Maui.Graphics.Color btn2state = Microsoft.Maui.Graphics.Color.FromArgb("#666666");
        public Microsoft.Maui.Graphics.Color btn3state = Microsoft.Maui.Graphics.Color.FromArgb("#666666");

        public Microsoft.Maui.Graphics.Color Btn1state { 
        get => btn1state;
            set
            {
                btn1state = purple;
                btn2state = grey;
                btn3state= grey;
                OnPropetyChanged(nameof(Btn1state));
                OnPropetyChanged(nameof(Btn2state));
                OnPropetyChanged(nameof(Btn3state));
            }
        }

        public Microsoft.Maui.Graphics.Color Btn2state
        {
            get => btn2state;
            set
            {
                btn1state = grey;
                btn2state = purple;
                btn3state = grey;
                OnPropetyChanged(nameof(Btn1state));
                OnPropetyChanged(nameof(Btn2state));
                OnPropetyChanged(nameof(Btn3state));
            }
        }
        public Microsoft.Maui.Graphics.Color Btn3state
        {
            get => btn3state;
            set
            {
                btn1state = grey;
                btn2state = grey;
                btn3state = purple;
                OnPropetyChanged(nameof(Btn1state));
                OnPropetyChanged(nameof(Btn2state));
                OnPropetyChanged(nameof(Btn3state));
            }
        }
        #endregion

        #region button clicked

        [RelayCommand]
        private async void Btn1clicked() {
            Btn1state = purple;
        }
        [RelayCommand]
        private async void Btn2clicked()
        {
            Btn2state = purple;
        }
        [RelayCommand]
        private async void Btn3clicked()
        {
            Btn3state = purple;
        }


        #endregion

        void OnPropetyChanged([CallerMemberName] string propertyname = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
}
