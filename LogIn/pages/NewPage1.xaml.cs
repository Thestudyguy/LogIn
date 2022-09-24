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

        progressLoading.IsVisible = true;
		var a = await user.UserLogIn(entryEmail.Text, entryPassword.Text);
        if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPassword.Text))
        {
            await DisplayAlert("LogIn", "Missing Fields", "Ok");
           
        }
        if (a)
        {
            await DisplayAlert("LogIn", "Acces Granted", "Ok");
            Application.Current!.MainPage = new AppShell();
            return;
            entryEmail.Text = "";
            entryPassword.Text = "";
        }

        else
		{
            await DisplayAlert("LogIn", "Acces Denied", "Ok");
            progressLoading.IsVisible = false;
        }
		
		
	}

	private async void btncancel_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new WelcomePage());;
    }
}