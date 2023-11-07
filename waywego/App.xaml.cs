using waywego.Desktop;
using waywego.Mobile;
namespace waywego
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if ANDROID
            MainPage = new NavigationPage(new AndroidLandingPage());
#else
        MainPage = new NavigationPage(new DesktopLandingPage());
#endif

        }
    }
}