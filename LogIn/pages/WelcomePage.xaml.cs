namespace LogIn.pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	private async void btnlogin_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
	}

	private async void btncancel_Clicked(object sender, EventArgs e)
	{
        
    }
}