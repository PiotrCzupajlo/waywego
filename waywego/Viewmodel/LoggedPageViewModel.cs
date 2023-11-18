using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using waywego.Desktop;

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

        //region tasks makes buttons change the verticalstacklayout user see
        #region tasks
        public bool task1=true;
        public bool task2=false;
        public bool task3=false;

        public bool Task1
        { 
        get=>task1;
            set { 
            task1=true;
                task2 = false;
                task3=false;
                OnPropetyChanged(nameof(Task1));
                OnPropetyChanged(nameof(Task2));
                OnPropetyChanged(nameof(Task3));

            }  
        
        }

        public bool Task2
        { 
        get=>task2;
            set
            {
                task2=true;
                task3 = false;
                task1 = false;
                OnPropetyChanged(nameof(Task1));
                OnPropetyChanged(nameof(Task2));
                OnPropetyChanged(nameof(Task3));
            }
        
        }
        public bool Task3
        { 
        get => task3;
            set
            {
                task3=true;
                task1 = false;
                task2 = false;
                OnPropetyChanged(nameof(Task1));
                OnPropetyChanged(nameof(Task2));
                OnPropetyChanged(nameof(Task3));
            }
        }





        public int tabopen;
        public int Tabopen {
            get => tabopen;
            set { 
            tabopen = value;
                OnPropetyChanged(nameof(Tabopen));
            
            }
        }
        #endregion
        //region buttonstates change the colors of buttons
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
            Task1 = true;
            
        }
        [RelayCommand]
        private async void Btn2clicked()
        {
            Btn2state = purple;
            Task2 = true;
        }
        [RelayCommand]
        private async void Btn3clicked()
        {
            Btn3state = purple;
            Task3= true;
        }


        #endregion

        void OnPropetyChanged([CallerMemberName] string propertyname = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
}
