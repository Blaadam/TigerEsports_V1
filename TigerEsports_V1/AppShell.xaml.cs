using TigerEsports_V1.Databases;
using TigerEsports_V1.Views;

namespace TigerEsports_V1
{
    public partial class AppShell : Shell
    {
        UserDatabase database;

        public AppShell(UserDatabase _database)
        {
            InitializeComponent();
            database = _database;
        }

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage(database);
        }
    }
}
