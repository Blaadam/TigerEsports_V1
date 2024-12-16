using System.Text.RegularExpressions;
using TigerEsports_V1.Data;
using TigerEsports_V1.Databases;
using TigerEsports_V1.Validation;

namespace TigerEsports_V1.Views;

public partial class RegisterPage : ContentPage
{
    private UserDatabase _database;

    public RegisterPage(UserDatabase database)
    {
        InitializeComponent();
        _database = database;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage = new LoginPage(_database);
    }

    private async void RegisterBtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsernameTb.Text) || string.IsNullOrEmpty(UsernameTb.Text.Trim()))
        {
            await DisplayAlert("Registration Error", "You need to enter a valid username before you can create an account.", "Ok");
            return;
        }

        if (!ValidationVault.RegPassword || !ValidationVault.RegConfirmPassword)
        {
            await DisplayAlert("Registration Error", "You need to input a valid password before you can create an account.", "Ok");
            return;
        }

        if (!ValidationVault.Email)
        {
            await DisplayAlert("Registration Error", "You need to input a valid email before you can create an account.", "Ok");
            return;
        }

        string email = EmailTb.Text.Trim();
        string username = UsernameTb.Text.Trim();
        string password = ValidationVault.StoredPasswordValidation;

        if (teamPicker.SelectedItem == null)
        {
            await DisplayAlert("Registration Error", "You need to select a team before you can create an account.", "Ok");
            return;
        }

        // Searches all the users to see if the username exists.
        var UserSearch = await _database.SearchUsersAsync(username);
        if (UserSearch.Count > 0)
        {
            await DisplayAlert("Registration Error", "An account with this username already exists.", "Ok");
            return;
        }

        string team = teamPicker.SelectedItem.ToString();

        User newUser = new User();
        newUser.Email = email;
        newUser.Username = username;
        newUser.Password = password;
        newUser.Team = team;

        await _database.SaveUserAsync(newUser);

        Application.Current.MainPage = new AppShell(_database);
        await DisplayAlert("Registration Successful", "You have successfully created an account!", "Continue");
    }

    private void ClearBtn_Clicked(object sender, EventArgs e)
    {
        EmailTb.Text = string.Empty;
        UsernameTb.Text = string.Empty;
        PasswordTb.Text = string.Empty;
        ConfirmPasswordTb.Text = string.Empty;
    }
}