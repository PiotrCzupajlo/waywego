using System;
using System.IO;
using waywego.Viewmodel;
using waywego.Model;

namespace waywego.Desktop;

public partial class DesktopLandingPage : ContentPage
{
    public User User { get; set; }
    public DesktopLandingPage()
	{
		InitializeComponent();
		this.BindingContext = new StartPageViewModel(this.Navigation);

		resize();
		changeimages();

	}


	// method resize: Resize the window to fullscreen and locks it size
	public async void resize() {
		await Task.Delay(10);
        double left = (DeviceDisplay.Current.MainDisplayInfo.Width / 5) * 2;
        double right = DeviceDisplay.Current.MainDisplayInfo.Width - left;
        leftside.WidthRequest = left;
        rightside.WidthRequest = right;
		Window.MinimumWidth = DeviceDisplay.Current.MainDisplayInfo.Width;
		Window.MinimumHeight = DeviceDisplay.Current.MainDisplayInfo.Height;
		rightimage.MaximumWidthRequest = right;
		rightimage.MaximumHeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height*0.8;
		
    }
	// change the images on the page
	public async void changeimages() {
		await Task.Delay(20);
		//getting the current directory
		string path = AppDomain.CurrentDomain.BaseDirectory;
		int index = path.IndexOf("\\bin\\");
		string s = path.Substring(0, index);
		string imagepath = s + "\\Images\\eiffel.png";

        rightimage.Source = ImageSource.FromFile(imagepath);
		imagepath = s + "\\Images\\logo-black.png";
		leftlogo.Source = ImageSource.FromFile(imagepath);


	}


}