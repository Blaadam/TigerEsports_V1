namespace TigerEsports_V1.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Application.Current.MainPage = new RegisterPage();
    }
}