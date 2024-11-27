using TigerEsports_V1.Databases;
using TigerEsports_V1.Views;

namespace TigerEsports_V1
{
    public partial class App : Application
    {
        public App(UserDatabase database)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new LoginPage(database);
        }
    }
}
