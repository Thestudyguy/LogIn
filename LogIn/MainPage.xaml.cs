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
       if (CrossConnectivity.Current.IsConnected)
        {
            await DisplayAlert("Info", "Registered Succesfuly", "OK");
        }
        else
        {
           
        }
}*/
    Users Users = new Users();

	private async void btnregister_Clicked(object sender, EventArgs e)
	{


        //Checks if fields is empty
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

        } else if (txtfname.Text == null || txtlname.Text == null || txtemail.Text == null || txtpassword.Text == null)
        {
            errormessage.Text = "Please Fill All Fields";
        }
        else
        {
            await DisplayAlert("Error", "Registered not Succesfuly", "OK");
        }


        /*if (txtfname.Text == null || txtlname.Text == null || txtemail.Text == null || txtpassword.Text == null)
		{
            errormessage.Text = "Please Fill All Fields";
        }
        
        //if fields are filled data entry will be registered
        else
        {
            InternetConnection();
            await Users.AddUser(txtfname.Text, txtlname.Text, txtemail.Text, txtpassword.Text);
            txtemail.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtpassword.Text = "";
            errormessage.Text = "";
            passmessage.Text = "";

        }
        //<!---->*/

    }

    private async void cancelbtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }
}

