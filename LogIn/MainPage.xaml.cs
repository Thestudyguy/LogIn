namespace LogIn;
using LogIn.Model;
public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
	Users Users = new Users();
	private async void btnregister_Clicked(object sender, EventArgs e)
	{
		await Users.AddUser(txtfname.Text, txtlname.Text, txtemail.Text, txtpassword.Text);
	}
}

