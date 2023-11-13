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


    }
}