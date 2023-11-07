using System.Security.Cryptography.X509Certificates;
using waywego.Viewmodel;


namespace waywego.Desktop;

public partial class DesktopLandingPage : ContentPage
{
	public DesktopLandingPage()
	{
		InitializeComponent();
		this.BindingContext = new StartPageViewModel(this.Navigation);
	}
}