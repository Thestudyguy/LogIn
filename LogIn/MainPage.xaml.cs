namespace LogIn;
using LogIn.Model;
using Plugin.Connectivity;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Graphics.Text;


using static System.Net.Mime.MediaTypeNames;
using LogIn.pages;

public partial class MainPage : ContentPage
{

    
    public MainPage()
	{
		InitializeComponent();
       
      
    }
    /* private async void InternetConnection()
    {
       if (!CrossConnectivity.Current.IsConnected)
        {
            await DisplayAlert("Info", "Registered Succesfuly", "OK");
        }
        else
        {
           
        }
}*/
    Users Users = new Users();
    public async void Insert()
    {
        var result = await Users.AddUser(txtfname.Text, txtlname.Text, txtemail.Text, txtpassword.Text);
        if (result)
        {
            await DisplayAlert("Info", "Registered Succesfuly", "OK");
            txtemail.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtpassword.Text = "";
            errormessage.Text = "";
            passmessage.Text = "";
        }
        else
        {
            await DisplayAlert("Error", "Registered not Succesfuly", "OK");
        }
    }

	private async void btnregister_Clicked(object sender, EventArgs e)
	{   
        //Checks if fields is empty
        var fname = txtfname.Text;
        var lname = txtlname.Text;
        var email = txtemail.Text;
        var password = txtpassword.Text;
        if (string.IsNullOrEmpty(fname) ||
           string.IsNullOrEmpty(lname) ||
           string.IsNullOrEmpty(email) ||
           string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Information", "Missing Fields", "Ok");
           

        }
        else
        {
            Insert();
        }
    }

    private async void cancelbtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }
}

