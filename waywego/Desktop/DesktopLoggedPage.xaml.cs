using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using waywego.Model;
using waywego.Viewmodel;
using Windows.Devices.Enumeration;

namespace waywego.Desktop;



public partial class DesktopLoggedPage : ContentPage
{
	public DesktopLoggedPage(User user)
	{
        this.BindingContext = new LoggedPageViewModel(this.Navigation);

		InitializeComponent();
        resize();



        basicmap.Pins.Clear();
        Pin p = new Pin()
        {
            Location = new Location(20, 30),
            Label = "okok"

        };
        p.MarkerClicked += P_MarkerClicked; ;
        basicmap.Pins.Add(p);
        basicmap.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(20, 30), Distance.FromKilometers(10)));
        
	}

    private void P_MarkerClicked(object sender, PinClickedEventArgs e)
    {
        Task.Delay(100);
    }

    public async void resize()
    {
        //changing the styles of the page
        await Task.Delay(10);
        double left = (DeviceDisplay.Current.MainDisplayInfo.Width / 5) * 2;
        double right = DeviceDisplay.Current.MainDisplayInfo.Width - left;
        Window.MinimumWidth = DeviceDisplay.Current.MainDisplayInfo.Width;
        Window.MinimumHeight = DeviceDisplay.Current.MainDisplayInfo.Height;
        Baner1.MinimumWidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 5;
        Baner1.MinimumHeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height /3;
        double width = DeviceDisplay.Current.MainDisplayInfo.Width / 5;
        double height = DeviceDisplay.Current.MainDisplayInfo.Height / 3;
        pright.Point = new Point(width,0);
        pdown.Point = new Point(0,height/5);
        place1.MinimumWidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width * 0.11;
        place1. MinimumHeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height * 0.4;
        place2.MinimumWidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width * 0.11;
        place2.MinimumHeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height * 0.4;
        place3.MinimumWidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width * 0.11;
        place3.MinimumHeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height * 0.4;
        


    }

    private void basicmap_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        Task.Delay(100);
    }

}