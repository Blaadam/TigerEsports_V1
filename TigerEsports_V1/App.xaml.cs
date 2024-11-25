using TigerEsports_V1.Views;

namespace TigerEsports_V1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new LoginPage();
        }
    }
}
