namespace TigerEsports_V1.Views;
using TigerEsports_V1.Databases;

public partial class LoginPage : ContentPage
{
    private UserDatabase _database;
    public LoginPage(UserDatabase database)
    {
		InitializeComponent();
        _database = database;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Application.Current.MainPage = new RegisterPage(_database);
    }
}