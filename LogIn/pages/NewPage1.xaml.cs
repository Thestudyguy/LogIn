using LogIn.Model;
namespace LogIn.pages;

public partial class NewPage1 : ContentPage
{
	private Users user = new();
	public NewPage1()
	{
		InitializeComponent();
	}

	private async void btnsignin_Clicked(object sender, EventArgs e)
	{
		
		var a = await user.UserLogIn(entryEmail.Text, entryPassword.Text);
        if (entryEmail.Text == null || entryPassword.Text == null)
        {
            await DisplayAlert("LogIn", "Missing Fields", "Ok");
           
        }
        if (a)
        {
            await DisplayAlert("LogIn", "Acces Granted", "Ok");
            return;
        }

        else
		{
            await DisplayAlert("LogIn", "Acces Denied", "Ok");
        }
		
		
	}

	private async void btncancel_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new WelcomePage());;
    }
}