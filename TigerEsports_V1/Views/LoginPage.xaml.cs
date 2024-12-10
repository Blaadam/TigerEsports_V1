using TigerEsports_V1.Data;
using TigerEsports_V1.Databases;
using TigerEsports_V1.Validation;

namespace TigerEsports_V1.Views;
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

    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsernameTb.Text) || string.IsNullOrEmpty(UsernameTb.Text.Trim()))
        {
            await DisplayAlert("Registration Error", "You need to enter a username before you can log int.", "Ok");
            return;
        }

        if (!ValidationVault.LoginPassword)
        {
            await DisplayAlert("Registration Error", "You need to enter a valid password before you can log in.", "Ok");
            return;
        }

        string Username = UsernameTb.Text.Trim();
        string Password = PasswordTb.Text.Trim();

        var users = await _database.SearchUsersAsync(Username);
        bool isAuthenticated = false;

        foreach (User user in users)
        {
            if (user.Password == Password)
            {
                isAuthenticated = true;
                break;
            }
        }

        if (!isAuthenticated)
        {
            await DisplayAlert("Registration Error", "Your credentials are incorrect. Please try again.", "Ok");
            return;
        }

        Application.Current.MainPage = new AppShell(_database);
        await DisplayAlert("Login Successful", "You have successfully logged into your account.", "Continue");
    }

    private void LinkedInIb_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://www.linkedin.com");
    }

    private void FacebookIb_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://www.facebook.com");
    }

    private void YoutubeIb_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://www.youtube.com");
    }

    private void InstagramIb_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://www.instagram.com");
    }

    private void XIb_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://www.x.com");
    }
}