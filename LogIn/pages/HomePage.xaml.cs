using LogIn.Model;

namespace LogIn.pages;

public partial class HomePage : ContentPage
{
	private Users userlist = new();
	public HomePage()
	{
		InitializeComponent();
		ListUsers.ItemsSource = userlist.GetUserList();
	}
}