using TigerEsports_V1.Databases;

namespace TigerEsports_V1.Views;

public partial class LoadingView : ContentPage
{
    private UserDatabase _database;
    public LoadingView(UserDatabase database)
    {
        InitializeComponent();
        _database = database;

        BeginTransition();
    }

    public async void BeginTransition()
    {
        await Task.Delay(3000);
        Application.Current.MainPage = new LoginPage(_database);
    }
}