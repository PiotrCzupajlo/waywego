using waywego.Model;
using waywego.Viewmodel;
namespace waywego.Desktop;



public partial class DesktopLoggedPage : ContentPage
{
	public DesktopLoggedPage(User user)
	{
        this.BindingContext = new LoggedPageViewModel(this.Navigation);

		InitializeComponent();
        resize();
	}
    public async void resize()
    {
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
        

    }

    private void basicmap_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {

    }
}